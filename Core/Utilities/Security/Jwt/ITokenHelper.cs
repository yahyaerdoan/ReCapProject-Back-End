using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        //Giriş için bize Anahtar oluşturacak sistem.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
//Tokene eklenmesi için Burada kullanıcı bilgisi ve kullanıcı rollerini metod içersinde verdik.
//Bizim için Token üretecek olan araç clastır.
//Başka zaman başka bir tekniğe geçtiğimizde bu interface class ile yeni token oluşturmak için yaptık.
