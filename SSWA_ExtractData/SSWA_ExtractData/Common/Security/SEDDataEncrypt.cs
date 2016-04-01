using SSWA_ExtractData.Common.Constant;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SSWA_ExtractData.Common.Security
{
    /// <summary>
    /// [EN] SSWADataEncrypt
    /// Create By: ManhNV1 -Date: 02/21/2016
    /// Description: Data Encryption - 1 Dimensional and 2 Dimensional
    /// </summary>
    public class SEDDataEncrypt
    {
        #region Data Encryption 1_Dimensional
        /// <summary>
        /// [EN] EncryptionBySHA512
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Function: Encrypt SHA512
        /// </summary>
        /// <param name="input">String need encode</param>
        /// <returns>String Encryption SHA512</returns>
        private string EncryptionBySHA512(string input)
        {
            var d_EncryptionSHA512 = new SHA512Managed();
            var ByteHasEncryption = d_EncryptionSHA512.ComputeHash(Encoding.Default.GetBytes(input));
            var sbdTemp = new StringBuilder();
            for (int i = 0; i < ByteHasEncryption.Length; i++)
            {
                sbdTemp.Append(ByteHasEncryption[i].ToString(SEDConst.X_2_LOWER));
            }
            return sbdTemp.ToString();
        }

        /// <summary>
        /// [EN] EncryptionByMD5
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Function: Encrypt MD5
        /// </summary>
        /// <param name="input">String required Encypt</param>
        /// <returns>String Encryption MD5</returns>
        private String EncryptionByMD5(string input)
        {
            var x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (byte b in bs) { s.Append(b.ToString(SEDConst.X_2_LOWER).ToLower()); }
            return s.ToString();
        }

        /// <summary>
        /// [EN] EncodeOneWay
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Function: Encrypt MD5
        /// </summary>
        /// <param name="input">String required Encypt</param>
        /// <returns>String Encryption MD5</returns>
        public string EncodeOneWay(string input)
        {
            var strChangeSha = this.EncryptionBySHA512(input);
            var strEncode = this.EncryptionByMD5(strChangeSha);
            return new StringBuilder(strEncode.Substring(2, 8))
                        .Append(strEncode.Substring(5, 15)).ToString();
        }
        #endregion

        #region Data Encryption 2_Dimensional
        /// <summary>
        /// [EN] EncryptionOneSt
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Descryption: Encode Data
        /// </summary>
        /// <param name="input">Encoding of Characters</param>
        /// <returns>String Encode</returns>
        private string EncryptionOneSt(char input)
        {
            var intCompare = (int) Convert.ToByte(input);
            if (intCompare <= 48)
            {
                return string.Format(SEDConst.ENCRYPT_COMPARE_SMALLER_48, input);
            }
            else if (intCompare <= 63)
            {
                return string.Format(SEDConst.ENCRYPT_COMPARE_SMALLER_63, input);
            }
            else if (intCompare <= 80)
            {
                return string.Format(SEDConst.ENCRYPT_COMPARE_SMALLER_80, input);
            }
            else if (intCompare <= 95)
            {
                return string.Format(SEDConst.ENCRYPT_COMPARE_SMALLER_95, input);
            }
            else if (intCompare <= 112)
            {
                return string.Format(SEDConst.ENCRYPT_COMPARE_SMALLER_112, input);
            }
            else
            {
                return string.Format(SEDConst.ENCRYPT_COMPARE, input);
            }
        }

        /// <summary>
        /// [EN] EncodeTwoWay
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Descryption: Encode Data
        /// </summary>
        /// <param name="input">Encoding of Characters</param>
        /// <returns>String Encode</returns>
        public string EncodeTwoWay(string input)
        {
            var arrayCharData = input.ToArray<char>();
            var sbdEncode = new StringBuilder();
            foreach (var item in arrayCharData)
            {
                sbdEncode.Append(this.EncryptionOneSt(item));
            }
            var strEncodeOutput = new StringBuilder(SEDConst.HEAD_ANDERS)
                                    .Append(sbdEncode.ToString()).Append(SEDConst.END_HEJLSBERG).ToString();
            return strEncodeOutput;
        }

        /// <summary>
        /// [EN] DecodeOneSt
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Descryption: Decode Data
        /// </summary>
        /// <param name="headerInput">First Character</param>
        /// <param name="input">Decode of Characters</param>
        /// <returns>String Decode</returns>
        private string DecodeOneSt(string headerInput, string input)
        {
            if (headerInput.Equals(SEDConst.HEAD_Q))
            {
                return input.Substring(1, 1);
            }
            else if (headerInput.Equals(SEDConst.HEAD_W))
            {
                return input.Substring(2, 1);
            }
            else if (headerInput.Equals(SEDConst.HEAD_E))
            {
                return input.Substring(3, 1);
            }
            else if (headerInput.Equals(SEDConst.HEAD_R))
            {
                return input.Substring(4, 1);
            }
            else if (headerInput.Equals(SEDConst.HEAD_T))
            {
                return input.Substring(5, 1);
            }
            else
            {
                return input.Substring(6, 1);
            }
        }

        /// <summary>
        /// [EN] DecodeTwoWay
        /// Create By: ManhNV1 -Date: 02/21/2016
        /// Descryption: Decode Data
        /// </summary>
        /// <param name="input">Decode of Characters</param>
        /// <returns>String Decode</returns>
        public string DecodeTwoWay(string input)
        {
            var strInputFilter = input.Substring(6, input.Length - 6).Substring(0, input.Length - 15);
            var sectionInput = strInputFilter.Length / 8;
            var arrayEncode = new string[sectionInput];
            var arrayHeader = new string[sectionInput];
            var sbdDecode = new StringBuilder();
            for (int i = 0; i < arrayEncode.Length; i++)
            {
                arrayEncode[i] = strInputFilter.Substring(i * 8, 8);
            }

            for (int i = 0; i < arrayEncode.Length; i++)
            {
                var headerEncode = arrayEncode[i].Substring(0, 1);
                sbdDecode.Append(this.DecodeOneSt(headerEncode, arrayEncode[i]));
            }
            return sbdDecode.ToString();
        }
        #endregion
    }
}
