using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IColorService
    {
        Color GetCarsByColorId(int id); //Renk Id'sine göre getir.
        List<Color> GetAll();
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);



    }
}
