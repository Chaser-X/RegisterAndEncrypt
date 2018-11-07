using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAndEncrypt
{
    public class DESEncrypt
    {
        private static readonly string encryptKeyWord  = "AOI*";
      
        public static string Encrypt(string content)
        {
            var keyWord = Encoding.Unicode.GetBytes(encryptKeyWord);
            var data = Encoding.Unicode.GetBytes(content);

            var ms = new MemoryStream();

            var cs = new CryptoStream(ms, new DESCryptoServiceProvider().CreateEncryptor(keyWord, keyWord), CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string content)
        {
            var keyWord = Encoding.Unicode.GetBytes(encryptKeyWord);
            var data = Convert.FromBase64String(content);

            var ms = new MemoryStream();

            var cs = new CryptoStream(ms, new DESCryptoServiceProvider().CreateDecryptor(keyWord, keyWord), CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();

            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}
