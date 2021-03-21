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
        IDataResult<Car> GetByCarId(int carId); //Ürüne dair detay getirir.
        IDataResult<List<Car>> GetAll(); //Her bilgiyi getir.
        IDataResult<List<Car>> GetCarsByBrandId(int brandId); // Marka Id'sine göre getir.
        IDataResult<List<Car>> GetCarsByColorId(int colorId); //Renk Id'sine göre getir.
        IDataResult<List<Car>> GetByCarDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAllByCarBrand(); // Markaya göre getir.
        IDataResult<List<Car>> GetAllByCarDescription(); // Bütün bilgileri getir.
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarsDetails();

        IResult TransactionalOperation(Car car);
        IDataResult<List<Car>> GetCarsByCategoryId(int categoryId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByCategoryId(int categoryId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByCarId(int carId);
    }
}
