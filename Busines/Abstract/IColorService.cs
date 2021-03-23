using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetCarsByColorId(int colorId); //Renk Id'sine göre getir.
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
