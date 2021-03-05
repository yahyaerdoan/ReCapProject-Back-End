using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool

    //İnjection altyapımız okuyabilmeye yarayan araçtır. SecuredOperation clasında İnjection yapmak istesek başarılı olamayız. 
    //Sebebi ise bağımlılık zinciri içersimde olmamasıdır.
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) //.Net'in IServiceCollection servislerini al 
        {
            ServiceProvider = services.BuildServiceProvider(); // ve onları buil ett. wep api ve Autofacte oluşturduğumuz İnjectionları oluşturabilmemizi sağlıyor.
                                                               //Bundan böyle oluşturduğumuz herhangi bir interface'in servisteki karşılığını bu servicetool ile alabiliriz.
            return services;
        }
    }
}
