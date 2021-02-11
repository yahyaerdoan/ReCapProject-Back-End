
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

            //Console.WriteLine("------GÜNLÜK ARAÇ KİRA FİYATLARI------");
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("Marka Adı                      Marka Id             Renk Id                        Model Yılı                             Açıklama                                           Günlük ücret");
            //Console.WriteLine("--------                      -------               ----------                     --------                               ------------                                       --------------");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Name + "   --   " + car.BrandId + "      --   " + car.ColorId + "   --    " + car.ModelYear + "          ---    " + car.Description + "                --       " + car.DailyPrice + " TL");
            //}



            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Console.WriteLine("------ARAÇ MARKA ID VE MARKA ADI BİLGİSİ------");
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("Marka Id                               Marka Adı                          Marka Model");
            //Console.WriteLine("--------                               ---------                        ------------------");
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandId + "             ---    " + brand.BrandName + "       ---  " + brand.BrandModel);
            //}


            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //Console.WriteLine("------ARAÇ RENK ID VE MARKA ADI BİLGİSİ------");
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("Renk Id               Renk Adı");
            //Console.WriteLine("-------         --------");
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorId + "       ---  " + color.ColorName);
            //}















































            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Name + car.ColorName);
            }

            //CarManager carManager = new CarManager(new EfCarDal());
            //List<Car> cars = new List<Car>
            //{
            //    new Car {Name ="Mercedes", ModelYear ="2020", DailyPrice =250, BrandId = 2, ColorId = 6, Description ="Otomatik"},
            //    new Car {Name ="Volvo", ModelYear ="2018", DailyPrice =195, BrandId = 6, ColorId = 4, Description ="Manuel/Dizel"},
            //    new Car {Name ="Renault", ModelYear ="2017", DailyPrice =150, BrandId = 3, ColorId = 5, Description ="Manuel"}
            //};
            //foreach (var car in cars)
            //{
            //    carManager.Add(car);
            //}


            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //List<Brand> brands = new List<Brand> 
            //{ 
            //    new Brand{ BrandName = "Mercedes", BrandModel ="AMG GT"},
            //    new Brand{ BrandName = "Volvo", BrandModel ="C 40"},
            //    new Brand{ BrandName = "Renault", BrandModel ="Clio 5"}            
            //};
            //foreach (var brand in brands)
            //{
            //    brandManager.Add(brand);
            //}

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //List<Color> colors = new List<Color>
            //{
            //    new Color {ColorName ="Beyaz"},
            //    new Color {ColorName = "Mavi"},
            //    new Color {ColorName = "Siyah"}
            //};
            //foreach (var color in colors)
            //{
            //    colorManager.Add(color);
            //}







            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByDailyPrice(185, 200))
            //{
            //    Console.WriteLine(car.Name +" / " + car.Description);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car {Name = "Ford", BrandId = 3, ColorId = 1, ModelYear ="2018", DailyPrice = 263, Description = "Dizel/Benzin, Otomatik"});


            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Delete(new Car { Id = 1002, });

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Name = "Nissan", BrandId = 7, ColorId = 6, ModelYear = "2016", DailyPrice = 270M, Description = "Dizel/Benzin, Otomatik, 1,250.00 Tl Depozito" });
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = "Nissan", BrandModel = "Juke" });
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorName = "Kırmızı" });



            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand {BrandName = "Passat"});




        }
    }
}
