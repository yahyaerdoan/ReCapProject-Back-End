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
        public List<CarDetailDto> GetAllCarDetails()
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
                             select new CarDetailDto 
                             { 
                                 CarId = ca.CarId,
                                 CarName = ca.CarName,
                                 BrandId = br.BrandId,
                                 BrandModel= br.BrandName,
                                 ColorId = co.ColorId,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 CategoryId = cgt.CategoryId,
                                 CategoryName = cgt.CategoryName                                
                             };
                return result.ToList();
            }
        }
    }
}
