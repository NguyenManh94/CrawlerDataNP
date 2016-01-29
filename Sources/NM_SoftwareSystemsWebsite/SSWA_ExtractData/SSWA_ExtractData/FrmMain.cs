using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;


namespace SSWA_ExtractData
{
    public partial class FrmMain : RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
 
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

    }
}