
using Busines.Concrete;
using DateAccess.Concrete.EntitiyFrameWork;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //List<Car> cars = new List<Car> 
            //{ 
            //    new Car {Name ="Mercedes", ModelYear ="2021", DailyPrice =200, BrandId = 1, ColorId = 5, Description ="Otomatik"},
            //    new Car {Name ="WolksVogen", ModelYear ="2019", DailyPrice =190, BrandId = 5, ColorId = 1, Description ="Otomatik/Dizel"},
            //    new Car {Name ="Toyoto", ModelYear ="2018", DailyPrice =180, BrandId = 4, ColorId = 5, Description ="Manuel"}                        
            //};
            //foreach (var car in cars)
            //{
            //    carManager.Add(car);
            //    Console.WriteLine(car.Name);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByDailyPrice(185, 200))
            //{
            //    Console.WriteLine(car.Name +" / " + car.Description);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car {Name = "Ford", BrandId = 3, ColorId = 1, ModelYear ="2018", DailyPrice = 263, Description = "Dizel/Benzin, Otomatik"});


            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 13, });

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Name = "Nissan", BrandId = 3, ColorId = 4, ModelYear = "2017", DailyPrice = 260M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito" });


        }
    }
}
