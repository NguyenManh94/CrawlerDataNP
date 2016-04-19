using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SSWA_ExtractData.Common
{
    /// <summary>
    ///     Create By: ManhNV1 -Date: -2/25/2016
    ///     Description: Extension Method -Support Progress String
    /// </summary>
    public static class ExtensionMethod
    {
        /// <summary>
        ///     [EN] ToStringNew
        ///     Create By: ManhNV1 -Date: 02/25/2016
        ///     Description: Add New Method ToStringNew to Object
        /// </summary>
        /// <param name="strSystem"></param>
        /// <returns>String text new</returns>
        public static string ToStringNew(this object strSystem)
        {
            return strSystem.ToString().Trim();
        }

        /// <summary>
        ///     [EN] TextTrim
        ///     Create By: ManhNV1 -Date: 02/25/2016
        ///     Description: Add New Method TextTrim to TextBox
        /// </summary>
        /// <param name="textBox">this TextBox</param>
        /// <returns>String text new</returns>
        public static string TextTrim(this TextBox textBox)
        {
            return textBox.Text.ToStringNew();
        }

        /// <summary>
        ///     [EN] TextTrim
        ///     Create By: ManhNV1 -Date: 02/25/2016
        ///     Description: Add New Method TextTrim to TextEdit
        /// </summary>
        /// <param name="textEdit"></param>
        /// <returns>String text new</returns>
        public static string TextTrim(this TextEdit textEdit)
        {
            return textEdit.Text.ToStringNew();
        }

        /// <summary>
        ///     [EN] SetString
        ///     Create By: ManhNV1 -Date: 02/25/2016
        ///     Description: Add New Method SetString
        /// </summary>
        /// <param name="strFirst">String First</param>
        /// <param name="input">string Input</param>
        /// <returns></returns>
        public static string SetString(this string strFirst, string input)
        {
            return new StringBuilder(strFirst).Append(input).ToStringNew();
        }

        /// <summary>
        ///     [EN] ReplaceNew
        ///     Create By: ManhNV1 -Date: 02/25/2016
        ///     Description: Add New Method ReplaceNew
        /// </summary>
        /// <param name="strFirst">String First</param>
        /// <returns></returns>
        public static string ReplaceNew(this string strFirst)
        {
            return strFirst.Replace("&#34", "").Replace(";", "\"");
        }
    }
}