using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DateAccess.Concrete.EntitiyFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDataBasesContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDataBasesContext context = new ReCapDataBasesContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             select new CarDetailDto 
                             { 
                                 Id = ca.Id,
                                 Name = ca.Name,
                                 BrandId = br.BrandId,
                                 BrandName = br.BrandName,
                                 BrandModel = br.BrandModel,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description                       
                             
                             };
                return result.ToList();
            }
        }
    }
}
