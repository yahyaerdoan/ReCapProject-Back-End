using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
     

        public Result(bool success, string message): this(success) //Buraya Constractor yapısı kurduk. 
                                                                   //This keywordu aşağıdaki constractoru da çalıştırır.
        {
            Message = message;                     
        }
        public Result(bool success ) //Buraya Constractor yapısı kurduk
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
