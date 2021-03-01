using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {                              //(IValidator validator)Doğrulama kurallarının olduğu class, //(object entity)Doğrulanacak class
        public static void Validate(IValidator validator,object entity) //object base'dir.
        {
            var context = new ValidationContext<object>(entity);            
            var result = validator.Validate(context);
            if (!result.IsValid) //Doğru değilse
            {
                throw new ValidationException(result.Errors);
            }       

        }
    }
}

