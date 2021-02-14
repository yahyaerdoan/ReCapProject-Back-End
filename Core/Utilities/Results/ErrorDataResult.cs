using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {                                                       // Versiyon verdik çeşitli imkan biz ne vermek istiyorsak onu veririz
                                                            // Default dataya karşılık gelir datanın veri tipi ne ise onu alır.
        public ErrorDataResult(T data, string message) : base(data, false, message)  // Data ve mesaj içerir
        {

        }
        public ErrorDataResult(T data) : base(data, false) // Sadece data içerir.
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) // Sadece mesaj içerir
        {                       // Mesa içerir

        }
        public ErrorDataResult() : base(default, false) //Hiç bir şey verilmemiş
        {

        }
    }
}
