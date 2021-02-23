using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.ValidationRules.FluentValidation
{
                                         //Fluentvalidationdan geldiği için çözüyoruz. Kimin doğrulama kodlarını yazacaksak o
                                         // nesneyi ekliyoruz.
    public class CarValidator : AbstractValidator<Car> 
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty(); // CarName boş geçilemez.
            RuleFor(c => c.CarName).MinimumLength(2); // CarName 2 harften büyük olmalıdır.
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.DailyPrice == 10); //alakasız oldu ama metodu öğrenmek için yazdım. Category için yazabirim
                 //Özel bir doğrulama yapmak istersen aşağıdaki gibi yapabiliyoruz. GenericMetod ile çözümlüyoruz.
            //RuleFor(c => c.CarName).Must(StartWithCar).WithMessage("İsimler 'Car' eki ile başlamalıdır!");

        }

        private bool StartWithCar(string arg)
        {
            return arg.StartsWith("Car");
        }
    }
}
