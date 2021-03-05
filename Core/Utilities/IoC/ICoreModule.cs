using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Genel bağımlılıkları yüklenir.
        //Başka servislerin bağımlılklarını çözebiliriz.
        void Load(IServiceCollection serviceCollection);
    }
}
