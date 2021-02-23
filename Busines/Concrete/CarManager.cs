using Busines.Abstract;
using Busines.Constants;
using Busines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //Business codes

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);





            //return FluentValidationYaptığımıziçinAşağıdakiMetodaİhtiyacımızKalmadı(car);
        }

        private IResult FluentValidationYaptığımıziçinAşağıdakiMetodaİhtiyacımızKalmadı(Car car)
        {
            // Magic string (" ") yazılan bilgilendirici mesajdır. çok olunca yönetmesi hatalı olur. 
            //Onun için Messages clasından yönetmek için result işlemini yaptık.

            if (car.CarName == null || car.CarName.Length < 2) //eğer aracın isim karakteri 2den küçükse ekleme
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
            else if (car.DailyPrice <= 0)  // eğer dailyprice 0'dan küçükse ekleme
            {
                return new ErrorResult(Messages.CarDailyPrice);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

            }
        }



        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);

        }

        public IDataResult<Car> GetByCarId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.ListedByCarId);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(), Messages.CarsDetailListed);
        }

        public IDataResult<List<Car>> GetAllByCarBrand()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedByBrand);
        }

        public IDataResult<List<Car>> GetAllByCarDescription()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsDescriptionListed);
        }

        public IDataResult<List<Car>> GetByCarBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.ListedByBrandId);
        }

        public IDataResult<List<Car>> GetByCarColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.ListedByColor);
        }

        public IDataResult<List<Car>> GetByCarDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),Messages.PriceRangeListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
