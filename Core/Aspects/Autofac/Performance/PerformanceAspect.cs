using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
    //Performans Aspectimizi Utilities teki İncerteceptorda AspectInterceptorSelector clasına eklersek tüm metodlara eklemiş oluruz. mevcuyt ve ilerde eklenecek tüm metotlara eklenir
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval) //interval Verilen zamanın geçmesi
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation) //Metodun önünde kronometre çalışıyor
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation) //Geçen süre hesaplanıyor
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
