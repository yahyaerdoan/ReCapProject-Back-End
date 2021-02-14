using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using DateAccess.Concrete.EntitiyFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Concrete.EntityFrameWork
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDataBasesContext>, ICustomerDal
    {
    }
}
