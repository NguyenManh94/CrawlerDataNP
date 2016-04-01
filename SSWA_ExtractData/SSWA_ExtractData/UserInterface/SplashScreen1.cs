using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using SSWA_ExtractData.Common.StringProcess;

namespace SSWA_ExtractData.UserInterface
{
    //TODO Comment
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void SplashScreen1_Load(object sender, EventArgs e)
        {
            //TODO System Publish Change Administrator
            //CheckExistFile();
        }

        private void CheckExistFile()
        {
            var path = @"C:\Program Files\Common Files\ExtracDataPro";
            var pathFile = @"C:\Program Files\Common Files\ExtracDataPro\DataPermission.db";
            //var path = @"C:\DisableData\Common Files\ExtracDataPro";
            //var pathFile = @"C:\DisableData\Common Files\ExtracDataPro\DataPermission.db";
            var checkPathDirectory = SEDFileProcess.CheckDirectoryPathExist(path);
            var checkPathFile = SEDFileProcess.CheckFilePathExist(pathFile);
            if (!checkPathDirectory || !checkPathFile)
            {
                var pathFileCoppy = Environment.CurrentDirectory + @"/Common/App_Data/DataPermission.db";
                SEDFileProcess.CreateNewFile(path);
                SEDFileProcess.CoppyFile(pathFileCoppy, path);
            }
        }
    }
}