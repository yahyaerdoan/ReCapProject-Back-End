using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using DateAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Concrete
{
    public class EfImageDal : EfEntityRepositoryBase<Image, ReCapDataBasesContext>, IImageDal
    {
    }
}
