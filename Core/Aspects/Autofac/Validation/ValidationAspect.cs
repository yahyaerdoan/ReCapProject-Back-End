using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Type ile çalışır
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //İnvocation metod demektir. Argumets parametre demektri.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // Bu satır reflactiondur.Çalışma anında bir şeyleri yapmak ve çalıştırmaktır. Çalışırken iş yapmaktır.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //CarValidatorun çalışma tipini bul, generic argümanlarından ilkini bul(Cardır)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Onunda parametrelerini bul (entityType (Car))
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
