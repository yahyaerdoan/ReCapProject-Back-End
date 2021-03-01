using Busines.Abstract;
using Busines.Constants;
using Busines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DateAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Busines.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(Image image, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitBorder(image.CarId), CheckIfImageExtensionValid(file));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = ImageFileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }
       
        public IResult Delete(Image image)
        {
            var result = _imageDal.Get(c => c.ImageId == image.ImageId);
            ImageFileHelper.Delete(result.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<Image> GetById(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(i => i.ImageId == id));
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetImageByCarId(int id)
        {
            return new SuccessDataResult<List<Image>>(CheckIfThereIsAImage(id));
        }


        public IResult Update(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitBorder(image.CarId));
            if (result != null)
            {
                return result;
            }
            var result1 = _imageDal.Get(c => c.ImageId == image.ImageId);
            image.ImagePath = ImageFileHelper.Update(file, result1.ImagePath);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }

        //Bir arabanın en fazla 5 resmi olabilir.
        private IResult CheckIfImageLimitBorder(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageInsertionLimitExceeded);
            }
            return new SuccessResult();
        }

        //Eğer bir arabaya ait resim yoksa, default bir resim gösteriniz. Tek elemanlı liste. 
        private List<Image> CheckIfThereIsAImage(int carId)
        {
            string path = @"\wwwroot\Images\logo.png";
            var result = _imageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<Image> { new Image { CarId = carId, ImagePath = path, Date = DateTime.Now } };
            }
            return _imageDal.GetAll(i => i.CarId == carId);
        }

        //Görüntü Uzantısının Geçerli Olup Olmadığını Kontrol Edin
        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
            {
                return new ErrorResult(Messages.InValidImageExtension);
            }
            return new SuccessResult();
        }
    }
}
