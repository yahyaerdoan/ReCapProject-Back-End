using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken //Erişim Anahtarı
    {
        public string Token { get; set; } //Anahtar bilgisi
        public DateTime Expiration { get; set; } //Tokenen ne zamana kadar geçerli olduğunu belirtir. //Kullanım sonlanma bilgisi
    }
}
