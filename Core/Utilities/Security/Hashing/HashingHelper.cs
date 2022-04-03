using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Parolayı hash'le hashi ve salt'ı dışarı çıkar
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //salt oluştur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //saltlı parolaya ekleyerek hashle (new lenen HMACSHA512 newlediğimiz için  bir key oluşturdu)
            }
        }

        public static bool VerifyPasswordHash(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            //HMACSHA512 'i new lerken salt ı verdik böylece hash oluştururken verdiğimiz bu saltla hash leyecek böylece karşılaştırma yaptığımızda salt+hash'li parolamızı kontrol edebileceğiz
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
