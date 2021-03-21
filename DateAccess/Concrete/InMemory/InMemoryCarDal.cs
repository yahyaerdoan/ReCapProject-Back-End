using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DateAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId = 1, CarName= "Renault Renault Clio 1.5 Ekonomik", BrandId = 1, ColorId = 1, ModelYear ="2017", DailyPrice = 201.07M, Description = "Dizel/Benzin, Manuel, 500.00 Tl Depozito, 500KM, 21 Yaş Üstü, Ehliyet Yaşı 1 ve Üzeri, 1 Kredi Kartı"},
                new Car {CarId = 2, CarName = "Renault Renault Clio AT 1.5 Ekonomik", BrandId = 1, ColorId = 1, ModelYear ="2018", DailyPrice = 228.97M, Description = "Dizel/Benzin, Otomatik, 500.00 Tl Depozito, 500KM,21 Yaş Üstü"},
                new Car {CarId = 3, CarName = "Fiat Fiat Egea Ekonomik", BrandId = 2,  ColorId = 1, ModelYear ="2016", DailyPrice = 245.1M, Description = "Dizel/Benzin, Otomatik, 750.00 Tl Depozito, 500KM, 21 Yaş Üstü"},
                new Car {CarId = 4, CarName = "Ford Ford Focus 1.5 Konfor", BrandId = 3,ColorId = 1, ModelYear ="2018", DailyPrice = 263.47M, Description = "Dizel/Benzin, Otomatik, 750.00 Tl Depozito, 500KM, Ehliyet Yaşı 2 ve Üzeri"},
                new Car {CarId = 5, CarName = "Ford Ford Kuga 1.5 Prestij", BrandId = 3,  ColorId = 2, ModelYear ="2020", DailyPrice = 338.73M, Description = "Hybrid/Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM"},
                new Car {CarId = 6, CarName = "Opel Opel Insignia 1.6 Prestij", BrandId = 4, ColorId = 2, ModelYear ="2019", DailyPrice = 360.14M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM"},
                new Car {CarId = 7, CarName = "Bmw Bmw 320i 1.6 Premium", BrandId = 5, ColorId = 3, ModelYear ="2019", DailyPrice = 412.45M, Description = "Dizel/Benzin, Otomatik, 2,500.00 Tl Depozito, 500KM, 27 Yaş Üstü, Ehliyet Yaşı 3 ve Üzeri"},
                new Car {CarId = 8, CarName = "Peugeot Peugeot 5008 Premium", BrandId = 6, ColorId = 4, ModelYear ="2020", DailyPrice = 478.89M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM, 7 Yetişkin"},
                new Car {CarId = 9, CarName = "Ford Tourneo Custom Van", BrandId = 7,  ColorId = 5, ModelYear ="2017", DailyPrice = 507.49M, Description = "Dizel/Benzin, Manuel/Otomatik, 1,250.00 Tl Depozito, 500KM, 9 Yetişkin"},
                new Car {CarId = 10, CarName = "Volvo Volvo S90 Premium", BrandId = 9,  ColorId = 3, ModelYear ="2020", DailyPrice = 545.5M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM, 27 Yaş Üstü, Ehliyet Yaşı 3 ve Üzeri, 1 Kredi Kartı"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.BrandId == c.BrandId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(string brand)
        {
            return _cars.Where(c => c.CarName == brand).ToList();

        }

        public List<Car> GetAllByBrand()
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllDescription()
        {
            return _cars;
        }

        public List<Car> GetByBrandId()
        {
            return _cars;
        }
        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.BrandId == c.BrandId);
            carToUpdate.CarName = car.CarName;
            carToUpdate.CarId = car.CarId;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;

        }
    }
}
