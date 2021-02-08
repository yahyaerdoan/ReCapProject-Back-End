using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByBrandId();
        List<Car> GetAllByBrand();
        List<Car> GetAllDescription();

    }
}
