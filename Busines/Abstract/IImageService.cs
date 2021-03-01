using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IImageService
    {
        IDataResult<Image> GetById(int id);
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetImageByCarId(int id);
        IResult Add(Image image, IFormFile file);
        IResult Delete(Image image);
        IResult Update(IFormFile file, Image image);
    }
}
