using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {   // get set propertydir.
        //get : sadece okunabilir demektir.
        //set : sadece yazmak demektir.
        //Constractor : get set işlemini yapabilir.
        bool Success { get; }
        string Message { get; }
    }
}
