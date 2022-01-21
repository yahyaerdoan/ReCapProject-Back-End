using Busines.Abstract;
using Busines.Concrete;
using Core.Utilities.Security.Encryption;
using DateAccess.Abstract;
using DateAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Core.Utilities.IoC;
using Core.Extensions;
using Core.DpendencyResolvers;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(); // Front End'den gelen yaz� tipini json formata �evirip ekliyecek pakaet indirdik.

            //Burdadaki operasyonlar� AOP yapabilmek i�in AutofacBusiness Mod�le ta��d�k.
            //Art�k buray� kullanm�yor olaca��z.

            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();

            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();

            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();

            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();

            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //E�er birisi senden IHttpContextAccessor isterse ona HttpContextAccessor ver.


            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("https://localhost:44339"));
            });

            services.AddCors();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //using Microsoft.AspNetCore.Authentication.JwtBearer;
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                }); //Buraya farkl� enjectionlar� vitg�l ile ekleyebiliriz. Array yerine params veya colecsion da yap�labilirdi.
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            //ServiceTool.Create(services);
            //ServisTool local olarak ba��ml�l�k ��z�mledi. Ba��ml�l�k ��z�mleme i�ini core ta��d��m�z i�in oradan i�lem yapaca��z.

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi"));

            }
            app.ConfigureCustomExceptionMiddleware();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()); //AllowAnyHeader : solumdaki adreslerden ne gelirse gelsin g�veniyorum. Onlara a����m diyor.
                                                                                                                    //AllowAnyMethod : Hangi istek geli�rse kabul et izni veriyor.
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication(); //Giri� yapmak i�in anahtar // �NCE

            app.UseAuthorization(); //Yetki durumudur.S�n�rland�r�lm��t�r. // SONRA           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
