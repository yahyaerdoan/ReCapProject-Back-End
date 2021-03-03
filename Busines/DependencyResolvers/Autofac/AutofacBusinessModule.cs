using Autofac;
using Autofac.Extras.DynamicProxy;
using Busines.Abstract;
using Busines.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DateAccess.Abstract;
using DateAccess.Concrete;
using DateAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module   //Sen artık autofac modülüsün. Module ile inherit ediyoruz. Autofac ile çözüyoruz.
    {                                             //Business Modülü dememizin sebebi business ile ilgili işlemleri burada yapıyor olacağız.
                                                  //Api katmanı strartup clasındaki ConfigureServices işlemini burada yapmamıza kolaylık sağlıyor.
                                                  //Autofacte istance oluşturmanın yöntemi aşağıdaki şekildedir.


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();
            builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}                             
