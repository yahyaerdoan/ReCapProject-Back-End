using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetAllByBrand();
        List<Car> GetByBrandId();      
        
        List<Car> GetAllDescription();
        List<Car> GetById(int brandId);
        List<Car> GetAllByBrand(string brand);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        

    }
}
