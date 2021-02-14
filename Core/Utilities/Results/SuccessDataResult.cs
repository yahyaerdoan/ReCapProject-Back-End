using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {                                                       // Versiyon verdik çeşitli imkan biz ne vermek istiyorsak onu veririz
                                                            // Default dataya karşılık gelir datanın veri tipi ne ise onu alır.
        public SuccessDataResult(T data, string message): base (data, true, message)  // Data ve mesaj içerir
        {                       

        }
        public SuccessDataResult(T data): base(data, true) // Sadece data içerir.
        {                           

        }
        public SuccessDataResult(string message): base(default, true, message) // Sadece mesaj içerir
        {                       // Mesa içerir

        }
        public SuccessDataResult():base (default, true) //Hiç bir şey verilmemiş
        {

        }
    }
}
