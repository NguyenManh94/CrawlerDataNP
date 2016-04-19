using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSWA_WFTestApp
{
    public partial class FrmMain: Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            txtOuput.Text = Encode(txtInput.Text);
        }

        /// <summary>
        /// Create By: ManhNV -Date: 02/20/2016
        /// Function: Encrypt SHA512
        /// </summary>
        /// <param name="input">String required Encypt</param>
        /// <returns>String Encryption SHA512</returns>
        private string EncryptionBySHA512(string input)
        {
            var d_EncryptionSHA512 = new SHA512Managed();
            var ByteHasEncryption = d_EncryptionSHA512.ComputeHash(Encoding.Default.GetBytes(input));
            var sbdTemp = new StringBuilder();
            for (int i = 0; i < ByteHasEncryption.Length; i++)
            {
                sbdTemp.Append(ByteHasEncryption[i].ToString("x2"));
            }
            return sbdTemp.ToString();
        }

        /// <summary>
        /// Create By: ManhNV -Date: 02/20/2016
        /// Function: Encrypt MD5
        /// </summary>
        /// <param name="input">String required Encypt</param>
        /// <returns>String Encryption MD5</returns>
        private String EncryptionByMD5(string strSource)
        {
            var x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(strSource);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (byte b in bs) { s.Append(b.ToString("x2").ToLower()); }
            return s.ToString();
        }

        /// <summary>
        /// Create By: ManhNV -Date: 02/20/2016
        /// Function: Encrypt MD5
        /// </summary>
        /// <param name="input">String required Encypt</param>
        /// <returns>String Encryption MD5</returns>
        public string Encode(string encode)
        {
            var strChangeSha = EncryptionBySHA512(encode);
            var strEncode = EncryptionByMD5(strChangeSha);
            return new StringBuilder(strEncode.Substring(2, 8))
                        .Append(strEncode.Substring(5, 15)).ToString();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
