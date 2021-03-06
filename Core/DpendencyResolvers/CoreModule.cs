using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DpendencyResolvers
{
    //Uygulama seviyesinde servis bağımlılıklarımızı çözümlediğimiz classtır.
    //Her yapılan istekle oluşan işlemdir. İsteğin başlangıcından bitişine kadar süreçte kullanıcının isteğinin takip edilmesi işlemidir.
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //Arka planda hazır IMemoryCache instencesı oluşturyor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
