using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DateAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDataBasesContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDataBasesContext context = new ReCapDataBasesContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join cgt in context.Categories
                             on ca.CategoryId equals cgt.CategoryId
                             //join i in context.Images
                             //on ca.CarId equals i.CarId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 CarName = ca.CarName,
                                 BrandId = br.BrandId,
                                 BrandModel = br.BrandModel,
                                 ColorId = co.ColorId,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 CategoryId = cgt.CategoryId,
                                 CategoryName = cgt.CategoryName, 
                                 ImagePath = (from i in context.Images where i.CarId == ca.CarId select i.ImagePath).ToList(),
                                 ModelYear = ca.ModelYear,
                                 FindexPoint = ca.FindexPoint,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
