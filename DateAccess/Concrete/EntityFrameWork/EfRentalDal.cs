using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDataBasesContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDataBasesContext context = new ReCapDataBasesContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cstmr in context.Customers
                             on r.CustomerId equals cstmr.CustomerId
                             join u in context.Users
                             on cstmr.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 CarId = r.RentalId,
                                 CarName = c.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cstmr.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 BrandModel = b.BrandModel,
                                 BrandName = b.BrandName,
                                 DailyPrice = r.DailyPrice           
                               
                                 
                             };
                return result.ToList();
            }
        }
    }
}
