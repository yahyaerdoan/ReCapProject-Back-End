using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DateAccess.Concrete.EntityFrameWork
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDataBasesContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapDataBasesContext context = new ReCapDataBasesContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 FindexPoint = (int)c.FindexPoint
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

    }
}
