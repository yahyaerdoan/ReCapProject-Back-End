using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    //Ne zaman çalışır? datanın bozulduğu zaman ne zaman bozulur? ekleme silme güncelleme, data silinme vb durumlardır.
    //Manegarde veriyi manipule eden metodlara CacheRemoveAspect uygulanır.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation) //işlemlerin başarılı olması durumunda bellekteki cache uçurulur. Yani silinir yeni cache oluşturulur.
        {                                                          //Ne den başarı durumunda ya ekleme hatalı olursa diye cache silmemmek için
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
