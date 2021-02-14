using Busines.Abstract;
using Busines.Constants;
using Core.Utilities.Results;
using DateAccess.Abstract;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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
        public IResult Add(Car car)
        {
            if (car.Name == null|| car.Name.Length< 2) // Magic string (" ") yazılan bilgilendirici mesajdır. çok olunca yönetmesi hatalı olur. 
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPrice);
            }           
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
                
            }
        } //eğer aracın isim karakteri 2den küçükse ekleme
        // eğer dailyprice 0dan küçükse ekleme

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

       
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarAdded);

        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour ==20)
            {
                return new ErrorDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.GetCarDetails);
        }

        public IDataResult<List<Car>> GetCarsAllByBrand()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsAllDescription()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
