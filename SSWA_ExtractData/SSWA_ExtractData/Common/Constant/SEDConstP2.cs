using System.Text;

namespace SSWA_ExtractData.Common.Constant
{
    /// <summary>
    /// Create By: ManhNV1 -02/25/2016
    /// Description: Mores Update Constans to SW01Constans
    /// </summary>
    sealed partial class SEDConst
    {
        #region Message Constants
        /** ManhNV1 -Message Question set Status Account -> Stop*/
        public const string MESSAGE_ACCOUNTLIST_STOP_ACCOUNT = "Do you want to stop the operation status of the account: '{0}' ?";

        /** ManhNV1 -Message Question set Status Account -> Active*/
        public const string MESSAGE_ACCOUNTLIST_ACTIVE_ACCOUNT = "Do you want to activate the account '{0}' ?";

        /** ManhNV1 -Message Verified Account Stop Success*/
        public const string MESSAGE_ACCOUNTLIST_STOP_SUCCESS = "Account was deactivated '{0}' success!";

        /** ManhNV1 -Message Verified Account Active Success*/
        public const string MESSAGE_ACCOUNTLIST_ACTIVE_SUCCSESS = "Have activated Account '{0}' success!";

        /** ManhNV1 -Constans Contact Email*/
        public const string BACKGROUND_EMAIL = "https://mail.google.com";

        /** ManhNV1 -Constans Contact Facebook*/
        public const string BACKGROUND_FACEBOOK = "https://www.facebook.com/khong.minh.54943";

        /** ManhNV1 -Constans Warning Click GridView Facebook*/
        public const string MESSAGE_CLICK_GRIDVIEW = "Please click on the data grid to select filters!";

        /** ManhNV1 -Constans Warning Disconected Internet*/
        public const string MESSAGE_DISSCONECT_INTERNET = "Loss of network connection!";

        /** ManhNV1 -Constans Warning Check Connect Internet*/
        public const string MESSAGE_DISCONNECT_CHECK = "Lost network connection. Please check connectivity to execute this task!";

        /** ManhNV1 -Constans Warning Note Disconected*/
        public const string MESSAGE_WARNING_DISCONNECTED = "Warning Disconected!";

        /** MangNV1- Constans Warning Link Invalid*/
        public const string MESSAGE_LINK_INVALID = "Linking data does not exist or is not feasible! Please choose another category!";

        /** MangNV1- Constans Warning Xpath*/
        public const string MESSAGE_EROR_XPATH = "Error handling systems !. Please send error on mailbox: nguyenmanhit.mak@gmail.com";
        #endregion

        #region Constans Normal
        /** ManhNV1 -Constans '-'*/
        public const string MINUS = "-";

        /** ManhNV1 -Constans special characters*/
        public const string SPECIAL_CHARACTERS = "\r\n";

        /** ManhNV1 -Constans Set Caption is Please wait*/
        public const string SET_PLEASE_WAIT = "Please Wait";

        /** ManhNV1 -Constans Set Description is Loading ...*/
        public const string SET_LOADING = "Loading ...";
        #endregion
    }
}
