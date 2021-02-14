using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetCarsByBrandId(int id); // Marka Id'sine göre getir.
        IDataResult<List<Brand>> GetAll(); //Her bilgiyi getir.
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);

    }
}
