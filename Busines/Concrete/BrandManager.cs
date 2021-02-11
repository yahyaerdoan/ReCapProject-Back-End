using Busines.Abstract;
using DateAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Marka Eklendi!");
        }

        public void Delete(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Marka Silindi!");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetCarsByBrandId(int id)
        {
            return _brandDal.Get(c => c.BrandId == id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Marka Güncellendi!");
        }
    }
}
