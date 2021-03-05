using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Giriş için elimizde bulunan anahtarlar anlamına gelmektedir.
        //Haslama yaparken securityKey anahtarını kullan ve HmacSha256Signature algoritmasını kullan diyoruz.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) //Anahtar
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature); //Algoritma //Burada farklı alagoritma seçenekleri de tercih edilebilir.
                                                                                           
        }
        //Burada jwt sistemini yöneteceksin güvenlik anahtarın (SecurityKey) budur. Şifreleme anahtarın da (HmacSha256Signature) budur dedik.
    }
}
