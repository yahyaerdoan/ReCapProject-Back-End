using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetCarById(int id); //Ürüne dair detay getirir.
        IDataResult<List<Car>> GetAll(); //Her bilgiyi getir.
        IDataResult<List<Car>> GetCarsByBrandId(int id); // Marka Id'sine göre getir.
        IDataResult<List<Car>> GetCarsByColorId(int id); //Renk Id'sine göre getir.
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetCarsAllByBrand(); // Markaya göre getir.
        IDataResult<List<Car>> GetCarsAllDescription(); // Bütün bilgileri getir.
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();



    }
}
