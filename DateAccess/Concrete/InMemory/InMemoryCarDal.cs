//using DateAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace DateAccess.Concrete.InMemory
//{
//    public class InMemoryCarDal : ICarDal
//    {
//        List<Car> _cars;
//        public InMemoryCarDal()
//        {
//            _cars = new List<Car> 
//            { 
//                new Car {Id = 1, Brand = "Renault", Name = "Renault Clio 1.5", BrandId = 1, Class = "Ekonomik", ColorId = 1, ModelYear ="2017", DailyPrice = 201.07M, Description = "Dizel/Benzin, Manuel, 500.00 Tl Depozito, 500KM, 21 Yaş Üstü, Ehliyet Yaşı 1 ve Üzeri, 1 Kredi Kartı"},
//                new Car {Id = 2, Brand = "Renault", Name = "Renault Clio AT 1.5", BrandId = 1, Class = "Ekonomik", ColorId = 1, ModelYear ="2018", DailyPrice = 228.97M, Description = "Dizel/Benzin, Otomatik, 500.00 Tl Depozito, 500KM,21 Yaş Üstü"},
//                new Car {Id = 3, Brand = "Fiat", Name = "Fiat Egea", BrandId = 2, Class = "Ekonomik", ColorId = 1, ModelYear ="2016", DailyPrice = 245.1M, Description = "Dizel/Benzin, Otomatik, 750.00 Tl Depozito, 500KM, 21 Yaş Üstü"},
//                new Car {Id = 4, Brand = "Ford", Name = "Ford Focus 1.5", BrandId = 3, Class = "Konfor", ColorId = 1, ModelYear ="2018", DailyPrice = 263.47M, Description = "Dizel/Benzin, Otomatik, 750.00 Tl Depozito, 500KM, Ehliyet Yaşı 2 ve Üzeri"},
//                new Car {Id = 5, Brand = "Ford", Name = "Ford Kuga 1.5", BrandId = 3, Class = "Prestij", ColorId = 2, ModelYear ="2020", DailyPrice = 338.73M, Description = "Hybrid/Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM"},
//                new Car {Id = 6, Brand = "Opel", Name = "Opel Insignia 1.6", BrandId = 4, Class = "Prestij", ColorId = 2, ModelYear ="2019", DailyPrice = 360.14M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM"},
//                new Car {Id = 7, Brand = "Bmw", Name = "Bmw 320i 1.6", BrandId = 5, Class = "Premium", ColorId = 3, ModelYear ="2019", DailyPrice = 412.45M, Description = "Dizel/Benzin, Otomatik, 2,500.00 Tl Depozito, 500KM, 27 Yaş Üstü, Ehliyet Yaşı 3 ve Üzeri"},
//                new Car {Id = 8, Brand = "Peugeot", Name = "Peugeot 5008", BrandId = 6, Class = "Premium", ColorId = 4, ModelYear ="2020", DailyPrice = 478.89M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM, 7 Yetişkin"},
//                new Car {Id = 9, Brand = "Ford", Name = "Tourneo Custom", BrandId = 7, Class = "Van", ColorId = 5, ModelYear ="2017", DailyPrice = 507.49M, Description = "Dizel/Benzin, Manuel/Otomatik, 1,250.00 Tl Depozito, 500KM, 9 Yetişkin"},
//                new Car {Id = 10, Brand = "Volvo", Name = "Volvo S90", BrandId = 9, Class = "Premium", ColorId = 3, ModelYear ="2020", DailyPrice = 545.5M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito, 500KM, 27 Yaş Üstü, Ehliyet Yaşı 3 ve Üzeri, 1 Kredi Kartı"},

//            };
//        }
        
//        public void Add(Car car)
//        {
//            _cars.Add(car);
//        }

//        public void Delete(Car car)
//        {
//            Car carToDelete = _cars.SingleOrDefault(c=> c.BrandId == c.BrandId);
//            _cars.Remove(carToDelete);
//        }

//        public Car Get(Expression<Func<Car, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Car> GetAll()
//        {
//            return _cars;
//        }

//        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Car> GetAllByBrand(string brand)
//        {
//            return _cars.Where(c => c.Brand == brand).ToList();
           
//        }

//        public List<Car> GetAllByBrand()
//        {
//            return _cars;
//        }

//        public List<Car> GetAllDescription()
//        {
//            return _cars;
//        }

//        public List<Car> GetByBrandId()
//        {
//            return _cars;
//        }
//        public List<Car> GetById(int brandId)
//        {
//            return _cars.Where(c => c.BrandId == brandId).ToList();
//        }

//        public void Update(Car car)
//        {
//            Car carToUpdate = _cars.SingleOrDefault(c => c.BrandId == c.BrandId);
//            carToUpdate.Name = car.Name;
//            carToUpdate.Id = car.Id;
//            carToUpdate.Description = car.Description;           
//            carToUpdate.ColorId = car.ColorId;
//            carToUpdate.DailyPrice = car.DailyPrice;
//            carToUpdate.ModelYear = car.ModelYear;
           
//        }
//    }
//}
