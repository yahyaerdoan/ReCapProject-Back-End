using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //Kullanıcının sahip olduğu rolleri veri tabanından çekmek için metod oluşturduk. //Join atmak için exstra metod yazdık
        List<OperationClaim> GetClaims(User user); 
    }
}
