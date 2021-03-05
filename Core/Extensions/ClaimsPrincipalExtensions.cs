using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions //Bir kişinin jwt'dan gelen claimlerine ulaşmak için kullandığımız .netteki classs
    {
        //HelperClasstır. Jwt helpere yardım eder.
        // ? null olabilir demektir. Token oluşturulmamış olabilir yani istek gönderilmemiş olabilir.
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
