using System;
using System.Security.Cryptography;
using System.Text;

namespace IMagazineProgramming.Controllers
{
    public class EncodeData
    {
        /*Encrypt SHA512*/
        private string EncryptionBySHA512(string input)
        {
            SHA512 d_EncryptionSHA512 = new SHA512Managed();
            var ByteHasEncryption = d_EncryptionSHA512.ComputeHash(Encoding.Default.GetBytes(input));
            var sbdTemp = new StringBuilder();
            for (int i = 0; i < ByteHasEncryption.Length; i++)
            {
                sbdTemp.Append(ByteHasEncryption[i].ToString("x2"));
            }
            return sbdTemp.ToString();
        }

        /*Encrypt MD5*/
        private static String EncryptionByMD5(String strSource)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(strSource);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs) { s.Append(b.ToString("x2").ToLower()); }
            return s.ToString();
        }

        public string Encode(string encode)
        {
            var temp1 = EncryptionBySHA512(encode);
            var temp2 = EncryptionBySHA512(temp1);
            return EncryptionByMD5(temp2);
        }
    }
}