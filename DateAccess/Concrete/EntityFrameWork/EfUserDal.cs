using Core.DataAccess.EntityFramework;
using DateAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DateAccess.Concrete.EntityFrameWork
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapDataBasesContext>, IUserDal
    {
        //Kullanıcı ile ilgili tabloları birleştirmek için burada joim işlemi yapıyoruz.
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapDataBasesContext())
            {
                var result = from OperationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals userOperationClaim.UserOperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 Id = OperationClaim.Id,
                                 Name = OperationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
