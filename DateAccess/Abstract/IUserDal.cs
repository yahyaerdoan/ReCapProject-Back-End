using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //Kullanıcının sahip olduğun rolleri çekmek için metod oluşturduk.
        List<OperationClaim> GetClaims(User user);
    }
}
