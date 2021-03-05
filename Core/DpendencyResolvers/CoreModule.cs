using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DpendencyResolvers
{
    //Uygulama seviyesinde servis bağımlılıklarımızı çözümlediğimiz classtır.
    //Her yapılan istekle oluşan işlemdir. İsteğin başlangıcından bitişine kadar süreçte kullanıcının isteğinin takip edilmesi işlemidir.
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
