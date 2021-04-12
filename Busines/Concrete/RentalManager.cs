using Busines.Abstract;
using Busines.Constants;
using Core.Utilities.Results;
using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Busines.ValidationRules.FluentValidation;
using DateAccess.Concrete.EntityFrameWork;
using Core.Utilities.Business;

namespace Busines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }
        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(/*CarRentedCheck(rental),*/ 
                FindexScoreCheck(rental.CustomerId, rental.CarId), 
                UpdateCustomerFindexPoint(rental.CustomerId, rental.CarId));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.ListedByRentalId);
        }

        public IDataResult<List<Rental>> GetByRentalUndelivered()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null), Messages.ListedByRentalUndelivered);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IResult IsRentable(int carId)
        {

            var result = _rentalDal.GetAll();
            if (result.Where(r => r.CarId == carId && r.ReturnDate == null ).Any())
                return new ErrorResult(Messages.RentalInValid);
            return new SuccessResult(Messages.CarIsRentable);
        }
        public IResult CarIsReturned(int carId)
        {
            Rental result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalReturned);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult FindexScoreCheck(int customerId, int carId)
        {
            var customerFindexPoint = _customerService.GetByCustomerId(customerId).Data.FindexPoint;

            if (customerFindexPoint == 0)
                return new ErrorResult(Messages.CustomerFindexPointIsZero);

            var carFindexPoint = _carService.GetByCarId(carId).Data.FindexPoint;

            if (customerFindexPoint < carFindexPoint)
                return new ErrorResult(Messages.CustomerScoreIsInsufficient);

            return new SuccessResult();
        }

        //private IResult CarRentedCheck(Rental rental)
        //{
        //    var rentalledCars = _rentalDal.GetAll(
        //        r => r.CarId == rental.CarId && (
        //        r.ReturnDate == null ||
        //        r.ReturnDate < DateTime.Now)).Any();

        //    if (rentalledCars)
        //        return new ErrorResult(Messages.NotYetSuitableforReRental);

        //    return new SuccessResult();
        //}
        private IResult UpdateCustomerFindexPoint(int customerId, int carId)
        {
            var customer = _customerService.GetByCustomerId(customerId).Data;
            var car = _carService.GetByCarId(carId).Data;

            customer.FindexPoint = (car.FindexPoint / 2) + customer.FindexPoint;

            _customerService.Update(customer);
            return new SuccessResult();
        }
    }
}
