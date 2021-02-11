using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface ICarService
    {
        Car GetCarById(int id);
        List<Car> GetAll(); //Her bilgiyi getir.
        List<Car> GetCarsByBrandId(int id); // Marka Id'sine göre getir.
        List<Car> GetCarsByColorId(int id); //Renk Id'sine göre getir.
        List<Car> GetCarsByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsAllByBrand(); // Markaya göre getir.
        List<Car> GetCarsAllDescription(); // Bütün bilgileri getir.
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

        List<CarDetailDto> GetCarDetails();



    }
}
