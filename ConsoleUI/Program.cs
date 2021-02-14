
using Busines.Concrete;
using DateAccess.Concrete.EntitiyFrameWork;
using DateAccess.Concrete.EntityFrameWork;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "Barış", LastName = "Balık", Email = "baba@gmail.com", Password = "bAerty" };
            userManager.Add(user);


            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { Id = (userManager.Get(user).Data.Id), CompanyName = " C Şirket" });




            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var results in result.Message)
            {
                Console.WriteLine(result.Message);
            }

            rentalManager.Add(new Rental {CarId = 3004, CustomerId = 1, RentDate = new DateTime(2021, 02, 12), ReturnDate = new DateTime(2021, 02, 24) });

            foreach (var results in result.Data)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}",
                    results.Id, results.Name, results.FirstName, results.LastName, results.CompanyName, results.RentDate, results.ReturnDate);
            }
















































            //CarManager carManager = new CarManager(new EfCarDal());

            //var result = carManager.GetCarDetails();

            //Console.WriteLine(result.Message);
            //Console.WriteLine();

            //if (result.Success==true)
            //{
            //    foreach (var car in carManager.GetCarDetails().Data)
            //    {
            //        Console.WriteLine("Araç Id No" + " - " + "Araç İsim" + " - " + "Marka Id No" + " - " + "Marka" + " - " + "Model" + " - " + "Renk Id No" + " - " + "Renk" + " - " + "Özellikler" + " - " + "Günlük Fiyat");

            //        Console.WriteLine();
            //        Console.WriteLine(car.Id + " - " + car.Name + " - " + car.BrandId + " - " + car.BrandName + " - " + car.BrandModel + " - " + car.ColorId + " - " + car.ColorName + " - " + car.Description + " - " + car.DailyPrice);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}




















            //CarManager carManager = new CarManager(new EfCarDal());

            //Console.WriteLine("--------Tümünü Listele-----------");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            //}
            //Console.WriteLine();

            //Console.WriteLine("--------Marka ID ile çağırma-----------");
            //foreach (var car in carManager.GetCarsByBrandId(2006))
            //{
            //    Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            //}
            //Console.WriteLine();


            //Console.WriteLine("--------Renk ID ile çağırma-----------");
            //foreach (var car in carManager.GetCarsByColorId(1007))
            //{
            //    Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            //}
            //Console.WriteLine();























            //CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { Name = "Mercedes-Benz", ModelYear = "2020", BrandId = 1, ColorId = 1, DailyPrice = 380.94M, Description = "63S V8 Turbo 635 PS 4 Matic+" });
            //carManager.Add(new Car { Name = "Mercedes-Benz", ModelYear = "2013", BrandId = 2, ColorId = 2, DailyPrice = 229.50M, Description = "Dizel / Manuel / Hatchback 5 kapı" });
            //carManager.Add(new Car { Name = "Mercedes-Benz", ModelYear = "2013", BrandId = 3, ColorId = 3, DailyPrice = 268.90M, Description = "Yarı Otomatik / Benzin" });
            //carManager.Add(new Car { Name = "BMW", ModelYear = "2020", BrandId = 4, ColorId = 4, DailyPrice = 500.94M, Description = "Benzin / Otomatik / Sedan" });
            //carManager.Add(new Car { Name = "Chevrolet", ModelYear = "2013", BrandId = 5, ColorId = 5, DailyPrice = 109.94M, Description = "Manuel / Benzin" });
            //carManager.Add(new Car { Name = "Citroen", ModelYear = "2017", BrandId = 6, ColorId = 6, DailyPrice = 139.94M, Description = "Dizel / Manuel" });
            //carManager.Add(new Car { Name = "Fiat", ModelYear = "2017", BrandId = 7, ColorId = 7, DailyPrice = 107.50M, Description = "Dizel / Manuel / Sedan" });

            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = "AMG GT", BrandModel = "3.0 S" });
            //brandManager.Add(new Brand { BrandName = "A Serisi", BrandModel = "A 180 CDI BlueEfficiency Style" });
            //brandManager.Add(new Brand { BrandName = "B Serisi", BrandModel = "B 180 BlueEfficiency Elite" });
            //brandManager.Add(new Brand { BrandName = "5 Serisi", BrandModel = "520i Special Edition M Sport" });
            //brandManager.Add(new Brand { BrandName = "Cruze Serisi", BrandModel = "1.6 LT" });
            //brandManager.Add(new Brand { BrandName = "C3 Serisi", BrandModel = "1.6 BlueHDi Live " });
            //brandManager.Add(new Brand { BrandName = "Egea Serisi", BrandModel = " 1.3 Multijet Easy " });

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorName = "Beyaz" });
            //colorManager.Add(new Color { ColorName = "Mavi" });
            //colorManager.Add(new Color { ColorName = "Beyaz" });
            //colorManager.Add(new Color { ColorName = "Siyah" });
            //colorManager.Add(new Color { ColorName = "Kırmızı" });
            //colorManager.Add(new Color { ColorName = "Beyaz" });
            //colorManager.Add(new Color { ColorName = "Füme" });

            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //CarManager carManager = new CarManager(new EfCarDal());
            //Car car = carManager.GetCarById(3002);
            //car.BrandId = brandManager.GetAll().SingleOrDefault(b => b.BrandName == "AMG GT" && b.BrandModel == "3.0 S").BrandId;
            //car.ColorId = colorManager.GetAll().SingleOrDefault(c => c.ColorName == "Beyaz" && c.ColorId == 1002).ColorId;
            //carManager.Update(car);




            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = " Focus ", BrandModel = " 1.5 TDCi Trend X " });

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorName = "Mavi" });

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Name = "Ford", ModelYear = "2016", BrandId = 8, ColorId = 8, DailyPrice = 156.94M, Description = "Yarı Otomatik / Manuel / Benzin" });





            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = " Focus ", BrandModel = "  1.6 Titanium  " });

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorName = "Lacivert" });

            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Name = "Ford", ModelYear = "2011", BrandId = 2010, ColorId = 1010, DailyPrice = 126.94M, Description = "Otomatik / Manuel / Benzin" });





























            //Car car1 = carManager.GetCarById(2003);
            //Car car2 = carManager.GetCarById(2004);
            //car1.BrandId = brandManager.GetAll().SingleOrDefault(b => b.BrandName == "Renault" && b.BrandModel == "Clio 5").BrandId;
            //car2.BrandId = brandManager.GetAll().SingleOrDefault(b => b.BrandName == "Volvo" && b.BrandModel == "C 40").BrandId;
            //car1.ColorId = colorManager.GetAll().SingleOrDefault(c => c.ColorName == "Mavi").ColorId;
            //car2.ColorId = colorManager.GetAll().SingleOrDefault(c => c.ColorName == "Beyaz").ColorId;

            ////Car car = new Car
            ////{
            ////    BrandId = brandManager.GetAll().SingleOrDefault(b => b.BrandName == "Nissan" && b.BrandModel == "Juke").BrandId,
            ////    ColorId = colorManager.GetAll().SingleOrDefault(c => c.ColorName == "Siyah").ColorId
            ////};
            ////car1 = car;

            //carManager.Update(car1);
            //carManager.Update(car2);

































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
