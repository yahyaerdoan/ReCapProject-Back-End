using Busines.Abstract;
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

        public void Add(Car car)
        {
            if (car.Name == null|| car.Name.Length< 2)
            {
                Console.WriteLine("Eklediğiniz aracın ismi minimum 2 karakter olmalıdır!");

            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Eklediğiniz aracın günlük fiyatı 0'dan büyük olmalıdır!");
            }           
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araç Eklendi"); 
            }
        } //eğer aracın isim karakteri 2den küçükse ekleme
        // eğer dailyprice 0dan küçükse ekleme

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç Silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();

        }

        public Car GetCarById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsAllByBrand()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsAllDescription()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araç Güncellendi!");
        }
    }
}
