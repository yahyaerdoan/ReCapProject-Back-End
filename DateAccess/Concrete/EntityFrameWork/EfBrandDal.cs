using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DateAccess.Concrete.EntitiyFrameWork
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapDataBasesContext>, IBrandDal
    {
        
    }
}
