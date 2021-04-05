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

namespace Busines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(c => c.CarId == rental.CarId &&
            (c.ReturnDate == null || c.ReturnDate > DateTime.Now));
            if (result!= null)
            {
                return new ErrorResult(Messages.NotYetSuitableforReRental) ;
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
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
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id),Messages.ListedByRentalId);
        }

        public IDataResult<List<Rental>> GetByRentalUndelivered()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null),Messages.ListedByRentalUndelivered);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IResult IsRentable(Rental rental)
        {

            var result = _rentalDal.GetAll();
            if (result.Where(r => r.CarId == rental.CarId
                    && r.ReturnDate >= rental.RentDate
                    && r.RentDate <= rental.ReturnDate).Any())
                return new ErrorResult(Messages.RentalInValid);
            return new SuccessResult(Messages.CarIsRentable);

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }    
}
