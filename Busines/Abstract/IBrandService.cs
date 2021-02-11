using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IBrandService
    {
        Brand GetCarsByBrandId(int id); // Marka Id'sine göre getir.
        List<Brand> GetAll(); //Her bilgiyi getir.
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);

    }
}
