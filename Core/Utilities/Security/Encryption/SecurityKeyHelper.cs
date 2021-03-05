using Core.Utilities.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //Nedir? : şifreleme olan sistemlerde her şeyi bty array formatında oluşturmamız gerekir. 
        //Basit bir string ile  password oluşturamıyoruz. Sebebi ise AspNet JWT  anlayamadığıu için jwt'nin anlayacağı halde oluşturuyoruz.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //Simetik Anahatar oluşturduk.

            //WebApi appsettings.json dosyamızda verdiğimiz securityKey'i strin olarak verdik ve dönüştürmek için Byt Arraye çevirdik. Byt'ı altık SymmetricSecurityKey (simerik anahtar)haline getirdik. Artık Json Amca şifrelerimizi okuyup anlayabilecek.
        }
    }
}
