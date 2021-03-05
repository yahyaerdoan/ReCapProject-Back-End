using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Extensions
{
    //Başka enjectionlar yapabilmemiz için Extension işlemi yapıyoruz. Startup'da  istediğimiz modülü ekleyebilir hale geleceğiz.
    //api ve araya gimesini istediğimiz servislerin bağımlılıklarını çözümlüyecek
    //Bütün enjectionları bir araya toplayabileceğimiz yapıya dönüştü.
    //Polimorfizm yaptık. nedir?: Çok biçimlilik demektir. Bir nesneyi farklı amaçlarla implemente edip hepsine veya bazılarına ulaşmaktır.
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
                ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }

    }
}
