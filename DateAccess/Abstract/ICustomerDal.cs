using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
