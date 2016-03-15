namespace SSWA_ExtractData.Common.StringProcess
{
    /// <summary>
    /// Create By: ManhNV1 -Date:03/03/2016
    /// Description: Method Support ProcessString
    /// </summary>
    sealed class SPFunc
    {
        /// <summary>
        /// Create By: ManhNV1 -Date:03/03/2016
        /// Description: Change Unicode Title
        /// </summary>
        /// <param name="title">String Title First</param>
        /// <returns></returns>
        public static string changeUnicodeTitle(string title)
        {
            string result = title.ToLower().Trim();
            result = result.Replace(" - ", "-");
            result = result.Replace("- ", "-");
            result = result.Replace(" -", "-");
            result = result.Replace(".com", "-com");
            //dac biet
            result = result.Replace("`", "");
            result = result.Replace("~", "");
            result = result.Replace("!", "");
            result = result.Replace("@", "");
            result = result.Replace("#", "");
            result = result.Replace("$", "");
            result = result.Replace("%", "");
            result = result.Replace("^", "");
            result = result.Replace("&", "");
            result = result.Replace("*", "");
            result = result.Replace("|", "");
            result = result.Replace("=", "");
            result = result.Replace("+", "");
            result = result.Replace(",", "");
            result = result.Replace("'", "");
            result = result.Replace(";", "");
            result = result.Replace(":", "");
            result = result.Replace("[", "");
            result = result.Replace("]", "");
            result = result.Replace("{", "");
            result = result.Replace("}", "");

            result = result.Replace("  ", "-");//
            result = result.Replace(" ", "-");//
            result = result.Replace(" ...", "");
            result = result.Replace(" ..", "");
            result = result.Replace(" .", "");
            result = result.Replace("...", "");
            result = result.Replace("..", "");

            result = result.Replace("(", "");
            result = result.Replace(")", "");
            result = result.Replace("“", "");
            result = result.Replace("”", "");
            result = result.Replace("\"", "");
            result = result.Replace("'", "");
            result = result.Replace("đ", "d");
            result = result.Replace("?", "");
            result = result.Replace("/", ".");

            result = result.Replace("_", "-");//
            result = result.Replace("__", "-");//
            //a
            result = result.Replace("ả", "a");
            result = result.Replace("à", "a");
            result = result.Replace("á", "a");
            result = result.Replace("ã", "a");
            result = result.Replace("ạ", "a");

            result = result.Replace("ă", "a");
            result = result.Replace("ắ", "a");
            result = result.Replace("ằ", "a");
            result = result.Replace("ẳ", "a");
            result = result.Replace("ẵ", "a");
            result = result.Replace("ặ", "a");

            result = result.Replace("â", "a");
            result = result.Replace("ấ", "a");
            result = result.Replace("ầ", "a");
            result = result.Replace("ẩ", "a");
            result = result.Replace("ẫ", "a");
            result = result.Replace("ậ", "a");
            //e
            result = result.Replace("é", "e");
            result = result.Replace("è", "e");
            result = result.Replace("ẻ", "e");
            result = result.Replace("ẽ", "e");
            result = result.Replace("ẹ", "e");

            result = result.Replace("ê", "e");
            result = result.Replace("ế", "e");
            result = result.Replace("ề", "e");
            result = result.Replace("ể", "e");
            result = result.Replace("ễ", "e");
            result = result.Replace("ệ", "e");
            //i
            result = result.Replace("í", "i");
            result = result.Replace("ì", "i");
            result = result.Replace("ỉ", "i");
            result = result.Replace("ĩ", "i");
            result = result.Replace("ị", "i");
            //o
            result = result.Replace("ó", "o");
            result = result.Replace("ò", "o");
            result = result.Replace("ỏ", "o");
            result = result.Replace("õ", "o");
            result = result.Replace("ọ", "o");

            result = result.Replace("ô", "o");
            result = result.Replace("ố", "o");
            result = result.Replace("ồ", "o");
            result = result.Replace("ổ", "o");
            result = result.Replace("ỗ", "o");
            result = result.Replace("ộ", "o");

            result = result.Replace("ơ", "o");
            result = result.Replace("ớ", "o");
            result = result.Replace("ờ", "o");
            result = result.Replace("ở", "o");
            result = result.Replace("ỡ", "o");
            result = result.Replace("ợ", "o");
            //u
            result = result.Replace("ú", "u");
            result = result.Replace("ù", "u");
            result = result.Replace("ủ", "u");
            result = result.Replace("ũ", "u");
            result = result.Replace("ụ", "u");

            result = result.Replace("ư", "u");
            result = result.Replace("ứ", "u");
            result = result.Replace("ừ", "u");
            result = result.Replace("ử", "u");
            result = result.Replace("ữ", "u");
            result = result.Replace("ự", "u");
            //y
            result = result.Replace("ý", "y");
            result = result.Replace("ỳ", "y");
            result = result.Replace("ỷ", "y");
            result = result.Replace("ỹ", "y");
            result = result.Replace("ỵ", "y");
            if (result.Substring(result.Length - 1) == ".")
                result = result.Substring(0, result.Length - 1);

            return result;
        }
    }
}
