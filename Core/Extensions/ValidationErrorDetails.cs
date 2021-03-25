using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Extensions
{
    //Doğrulama hatası için liste oluşturması için ValidationErrorDetails oluşturduk
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}
