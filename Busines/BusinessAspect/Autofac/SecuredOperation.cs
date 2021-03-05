using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Busines.Constants;

namespace Busines.BusinessAspect.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //Jwt için yazmış olduk
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //Her istek için HttpContex oluşturulur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // Attribute olduğu için virgül ile ayırarak  getirmemiz gerekir. Metni belirttiğimiz karektere göre ayırıp arraya atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); //using Microsoft.Extensions.DependencyInjection;

        }

        protected override void OnBefore(IInvocation invocation) //Metodun önünde çalış. Rolleri bul, uygun rol eşleşirse doğru yoksa hata döndür.
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role)) //ilgili rol varsa çalıştır.
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //Yoksa hata fırlat.
        }
    }
}
