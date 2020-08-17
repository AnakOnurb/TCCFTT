using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace CARE_Web_API.Utils
{
    public class Hasher
    {
        public static string Hash(string value)
        {
            // Create salt wth Pseudo Number Generator
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Create Rfc2898 (pbkdf2) and hash
            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, 100000);
            //byte[] hash = pbkdf2.GetBytes(20);
            byte[] hash = SHA256.Create().ComputeHash(pbkdf2.GetBytes(20));

            // Combine salt and hash
            //byte[] hashBytes = new byte[36];
            //Array.Copy(salt, 0, hashBytes, 0, 16);
            //Array.Copy(hash, 0, hashBytes, 16, 20);
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            // Convert salt+hash to string
            string passHash = Convert.ToBase64String(hashBytes);
            return passHash;
        }

        public static bool Verify(string newValue, string savedValue)
        {
            // Extract bytes
            byte[] hashBytes = Convert.FromBase64String(savedValue);

            // Get salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute the new value
            var pbkdf2 = new Rfc2898DeriveBytes(newValue, salt, 100000);
            //byte[] hash = pbkdf2.GetBytes(20);
            byte[] hash = SHA256.Create().ComputeHash(pbkdf2.GetBytes(20));

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
