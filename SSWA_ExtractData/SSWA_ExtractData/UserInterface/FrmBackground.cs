using SSWA_ExtractData.Common.Constant;
using System;
using System.Diagnostics;

namespace SSWA_ExtractData.UserInterface
{
    /// <summary>
    /// [EN] FrmBackground
    /// Create By: ManhNV1 -Date 02/25/2016
    /// Description: Show Background Form
    /// </summary>
    public partial class FrmBackground: DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// [EN] FrmBackground
        /// Create By: ManhNV1 -Date 02/25/2016
        /// Description: Initial Component
        /// </summary>
        public FrmBackground() { InitializeComponent(); }

        /// <summary>
        /// [EN] timerRunText_Tick
        /// Create By: ManhNV1 -Date 02/25/2016
        /// Description: Show Background Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRunText_Tick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// [EN] hyperLinkContactEmail_DoubleClick
        /// Create By: ManhNV1 -Date 02/25/2016
        /// Description: Contact Email
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs double Click</param>
        private void hyperLinkContactEmail_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(SEDConst.BACKGROUND_EMAIL);
        }

        /// <summary>
        /// [EN] pbFaceBook_DoubleClick
        /// Create By: ManhNV1 -Date 02/25/2016
        /// Description: Contact Facebook
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs double Click</param>
        private void pbFaceBook_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(SEDConst.BACKGROUND_FACEBOOK);
        }

        private void FrmBackground_Load(object sender, EventArgs e)
        {
            
        }
    }
}