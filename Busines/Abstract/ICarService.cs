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
        IDataResult<Car> GetByCarId(int id); //Ürüne dair detay getirir.
        IDataResult<List<Car>> GetAll(); //Her bilgiyi getir.
        IDataResult<List<Car>> GetByCarBrandId(int id); // Marka Id'sine göre getir.
        IDataResult<List<Car>> GetByCarColorId(int id); //Renk Id'sine göre getir.
        IDataResult<List<Car>> GetByCarDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAllByCarBrand(); // Markaya göre getir.
        IDataResult<List<Car>> GetAllByCarDescription(); // Bütün bilgileri getir.
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();

        IResult TransactionalOperation(Car car);
    }
}
