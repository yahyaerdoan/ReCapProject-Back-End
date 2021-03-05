using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // out byte : Gönderilen parametrenin Değişerek byte arraya aktarılmasını sağlıyor.
        //out : Gönderilen veiyi geri döndürebiliyor. passwordu vereceğiz  hash ve salta döndürecek ve dışarı çıkartacak.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //Gönderdiğimiz passwordu hashing yapar.
        {
            //
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //hmac (ilgili) algoritmasının key değerini kullanıyoruz. Standart olan başka bir değeri de kullanabiliriz. Değişmeyen anahtardır.
                                         // her kullanıcı ayrı key oluştulur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //stingin byt arayını almak için Encoding.UTF8.GetBytes kullanırız.
            }
        }

        //Gelen passwordun doğrulanması işlemi burada gerçekleşmektedir. Doğrulama işlemi burada yapılmaktadır.
        //PasswordHash'i doğrula. Gönderilen has ve saltı doğrula. Bu Metod tekrar giriş için çalışmaktadır.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) //Hesaplanan hashin değerlerini tek tek dolaş
                {
                    if (computedHash[i] != passwordHash[i]) // hesaplanan yani oluşturulan hashin  i değeri benim sana gönderdiğim i değer ile aynı değilse
                    {
                        return false; //Hata döndür.
                    }
                }
                return true; //aynı ise giriş yap. Kabul et
            }
        }
    }
}
