using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetCarsByCategoryId(int categoryId); // Marka Id'sine göre getir.
        IDataResult<List<Category>> GetAll(); //Her bilgiyi getir.
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
