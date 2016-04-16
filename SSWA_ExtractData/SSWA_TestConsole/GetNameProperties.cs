using System;
using System.Text;

namespace SSWA_TestConsole
{
    public class GetNameProperties
    {
        #region Common Constants
        /** ManhNV1 -String Exists*/
        public const string PATH_USER_LOGIN = "UserLogin.json";

        /** ManhNV1 -Common Constants */
        public const string TITLE_NOTE = "Note!";

        /** ManhNV1 -Common Constants */
        public const string TITLE_WARNING = "Warning!";

        /** ManhNV1 -Common String Empty*/
        public const string STRING_EMPTY = "";

        /** ManhNV1 -Common Int Length Password Valid*/
        public const int LENGTH_PASS_VALID = 6;
        #endregion

        #region Message Constants
        /** ManhNV1 -Message Question CloseProgram*/
        public const string MAIN_MESSAGE_CLOSEPROGRAM = "Do you really want to exit the program ?";

        /** ManhNV1 -Message Question Logout*/
        public const string MAIN_MESSAGE_LOG_OUT = "You may want to log out of the system ?";

        /** ManhNV1 -Message Data Entry Warning*/
        public const string MAIN_MESSAGE_EMPTY = "Please enter the complete data before logging!";

        /** ManhNV1 -Message View Help*/
        public static string MAIN_HELP = new StringBuilder("ExtracData Create by: Manh Nguyen Van").Append("\n")
            .Append("Version 1.0 - Date: 29-02-2016").Append("\n")
            .Append("All inquiries or questions please send the attached mailboxes").Append("\n\t")
            .Append("- nguyenmanhit.mak@gmail.com").Append("\n\t")
            .Append("- Phone: (+84)97.808.9594").Append("\n")
            .Append("Thank you for using the program!").Append("\n\t")
            .Append("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t")
            .Append("-*- ManhNguyen -*-").ToString();

        /** ManhNV1 -Message Question CloseProgram*/
        public static string MAIN_ABOUT = new StringBuilder("Disaggregated data program developed by ManhNguyen").Append("\n\t")
            .Append("Main task: Get data on the web").Append("\n\t")
            .Append("Task sub: Putting aggregated data on news aggregator").Append("\n")
            .Append(" Thank teacher -Nguyen Manh Ha- helped me enthusiastically").ToString();

        /** ManhNV11 -Message Warning Account is Staff*/
        public const string MAIN_PERMISSION_NOT_GRATED = "Current account has no right to use this section!";

        /** ManhNV1 -Message Login Success*/
        public static string AUTHENTICATION_MESSAGE_LOGINSUCCESS = new StringBuilder("Loged in Succsessfully!").Append("\n\t")
            .Append("Thank you {0}!").Append("\n\t")
            .Append(" Wish you work efficiently!").ToString();

        /** ManhNV1 -Message Login Fail*/
        public static string AUTHENTICATION_MESSAGE_LOGINFAIL = new StringBuilder("Login failed!").Append("\n\t")
            .Append("Please check your account or password!").ToString();

        /** ManhNV1 -Message Warning Input Empty*/
        public const string MAIN_WARNING_CHECKEMPTY = "Check your data before remembering!";

        /** ManhNV1 -Message Notice Account Expire*/
        public static string AUTHENTICATION_ACCOUNT_EXPIRE = new StringBuilder("Accounts expire used! ").Append("\n\t")
            .Append("Please contact Email: nguyenmanhit.mak@gmail.com").ToString();

        /** ManhNV1 -Message Notice Not Find Database <<Sqlite>>*/
        public static string AUTHENTICATION_NOT_FIND_DATA = new StringBuilder("Not find data program!").Append("\n\t")
            .Append("Warning information loss can lead to one of processes run improperly!").Append("\n\t")
            .Append("Please send information about mailbox error: nguyenmanhit.mak@gmail.com").Append("\n")
            .Append("Thank you!").ToString();

        /** ManhNV1 -Message Warning behavior Database <<Sqlite>>*/
        public static string AUTHENTICATION_WARING_BEHAVIOR_DATABASE = new StringBuilder("Database errors and Warnings")
            .Append(": 1 Number behavior has an impact on database problems").ToString();

        /** ManhNV1 -Message Notice Input Password current*/
        public const string CHANGEPASS_MESSAGE_INPUT = "Please enter your current password!";

        /** ManhNV1 -Message Password Match*/
        public const string CHANGEPASS_MESSAGE_MATCH_PASSWORD = "Match the current password!";

        /** ManhNV1 -Message Password Not Match*/
        public const string CHANGEPASS_MESSAGE_NOTMATCH_PASSWORD = "Password do not match!";

        /** ManhNV1 -Message Password Number of characters invalid*/
        public const string CHANGEPASS_MESSAGE_NUMBER_OF_CHARACTER_INVALID = "The password must be at least 6 characters or more!";

        /** ManhNV1 -Message Retype password do not match*/
        public const string CHANGEPASS_MESSAGE_RETYPE_NOT_MATCH = "Retype password do not match!";

        /** ManhNV1 -Message Information Valid*/
        public const string CHANGEPASS_MESSAGE_VALID = "Valid Information!";

        /** ManhNV1 -Message CheckValid PassOld before 'Check Valid'*/
        public const string CHANGEPASS_MESSAGE_CHECK_PASSOLD = "Please 'Check PassOld' before 'Check Valid'!";

        /** ManhNV1 -Message CheckValid before 'Save'*/
        public const string CHANGEPASS_MESSAGE_CHECK_VALID = "Please choose '{0}' before 'Save'!";

        /** ManhNV1 -Message Update Success*/
        public const string CHANGEPASS_MESSAGE_UPDATE = "Update Successfuly!";

        /** ManhNV1 -Message Create Account Success*/
        public const string ACCOUNTCRUD_MESSAGE_CREATE_SUCCSESS = "Create Account Successfuly!";

        /** ManhNV1 -Message Warning Email input Empty*/
        public const string ACCOUNTCRUD_MESSAGE_EMAIL_EMPTY = "Please enter your email before checking!";

        /** ManhNV1 -Message Warning Email Invalid*/
        public const string ACCOUNTCRUD_EMAIL_INVALID = "Invalid Email! Please re-enter";

        /** ManhNV1 -Message Information Email Valid*/
        public const string ACCOUNTCRUD_EMAIL_VALID = "Email Valid!";

        /** ManhNV1 -Message Warning Password input Empty*/
        public const string ACCOUNTCRUD_PASSWORD_EMPTY = "Please enter your password before checking!";

        /** ManhNV1 -Message Information Password Valid*/
        public const string ACCOUNTCRUD_PASSWORD_VALID = "Valid password!";

        /** ManhNV1 -Message Check All*/
        public const string ACCOUNTCRUD_MESSAGE_CHECK_ALL = "Please check {0} and {1} before {2}";

        /** ManhNV1 -Message Warning lack of data*/
        public const string ACCOUNTCRUD_MESSAGE_LACK_OF_DATA = "Please enter the full data!";
        #endregion

        #region String Encryption Data
        /** ManhNV1 -String x2 MD5*/
        public const string X_2_LOWER = "x2";

        /** ManhNV1 -String X2 Check Ip Mac*/
        public const string X_2_UPPER = "X2";

        /** ManhNV1 -String Header Decode Data*/
        public const string HEAD_Q = "Q";

        /** ManhNV1 -String Header Decode Data*/
        public const string HEAD_W = "W";

        /** ManhNV1 -String Header Decode Data*/
        public const string HEAD_E = "E";

        /** ManhNV1 -String Header Decode Data*/
        public const string HEAD_R = "R";

        /** ManhNV1 -String Header Decode Data*/
        public const string HEAD_T = "T";

        /** ManhNV1 -String EncodeData*/
        public const string ENCRYPT_COMPARE_SMALLER_48 = "Q{0}P1!+MZ";

        /** ManhNV1 -String EncodeData*/
        public const string ENCRYPT_COMPARE_SMALLER_63 = "WO{0}2@)NX";

        /** ManhNV1 -String EncodeData*/
        public const string ENCRYPT_COMPARE_SMALLER_80 = "EI3{0}#(BC";

        /** ManhNV1 -String EncodeData*/
        public const string ENCRYPT_COMPARE_SMALLER_95 = "RU4${0}*LA";

        /** ManhNV1 -String EncodeData*/
        public const string ENCRYPT_COMPARE_SMALLER_112 = "TY5%&{0}KS";

        /** ManhNV1 -String EncodeData*/
        public const string ENCRYPT_COMPARE = "GH6^^J{0}D";

        /** ManhNV1 -String EncodeData*/
        public const string HEAD_ANDERS = "ANDERS";

        /** ManhNV1 -String EncodeData*/
        public const string END_HEJLSBERG = "HEJLSBERG";
        #endregion

        #region Write History to Log
        /** ManhNV1 -Update Password*/
        public const string WRITE_LOG_UPDATE_PASSWORD = "Update Password!";

        /** ManhNV1 -Login Success*/
        public const string WRITE_LOG_UPDATE_LOGIN = "Login System Succsess!";

        /** ManhNV1 -Logout System*/
        public const string WRITE_LOG_OUT_SYSTEM = "Logout System!";

        /** ManhNV1 -Update Status Account to Operate*/
        public const string WRITE_LOG_UPDATE_STATUS_ACCOUNT = "Account status updates '{0}' to operate!";

        /** ManhNV1 -Update Status Account to Stop Operate*/
        public const string WRITE_LOG_UPDATE_STATUS_ACCOUNT_STOP = "Account status updates '{0}' to stop operate!";

        /** ManhNV1 -String Datetime Now*/
        public static string WRITE_DATETIME_NOW = new StringBuilder(DateTime.Now.ToShortDateString())
            .Append(" ").Append(DateTime.Now.ToLongTimeString()).ToString();
        #endregion

        #region Linq- Query Constants
        /** ManhNV1 -Query Set Staff*/
        public const string QUERY_STAFF = "Staff";

        /** ManhNV1 -Query Set Administrator*/
        public const string QUERY_ADMINISTRATOR = "Administrator";

        /** ManhNV1 -Query Set Not Active*/
        public const string QUERY_NOT_ACTIVE = "Not Active";

        /** ManhNV1 -Query Set Active*/
        public const string QUERY_ACTIVE = "Active";
        #endregion

        #region Show BarManager
        /** ManhNV1 -Bar UserName*/
        public const string BAR_USERNAME = "UserName: {0}";

        /** ManhNV1 -Bar Email*/
        public const string BAR_EMAIL = "Email: {0}";

        /** ManhNV1 -Bar Status*/
        public const string BAR_STATUS = "Status: {0}";

        /** ManhNV1 -Bar Permission*/
        public const string BAR_PERMISSION = "Permission: {0}";
        #endregion

        #region Regex Partern
        /** ManhNV1 -Bar Permission*/
        public const string PARTERN_CHECK_EMAIL = @"^\w+\.?\w+\@\w{3,5}\.\w{2,3}";
        #endregion
    }
}
