using Busines.Abstract;
using DateAccess.Abstract;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrand()
        {
            return _carDal.GetAllByBrand();
        }

        public List<Car> GetAllDescription()
        {
            return _carDal.GetAllDescription();
        }

        public List<Car> GetByBrandId()
        {
            return _carDal.GetByBrandId();
        }
    }
}
