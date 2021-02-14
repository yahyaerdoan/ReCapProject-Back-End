using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool succes, string message): base (succes, message) //Base datayı çalıştırdığımızda T data çalışmamakta 
                                                                                        //dolayısıyla çalıştırmak için onu Datayı eşitlememiz gerekir.
        {
            Data = data;  //Buraya data vererek set ettik
        }
        public DataResult(T data, bool success): base (success)
        {
            Data = data;
        }
        public T Data { get; }

    }
}
