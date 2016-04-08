using System;
using System.Windows.Forms;
using SSWA_ExtractData.UserInterface;

namespace SSWA_ExtractData
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                Application.Run(new A00FrmMain());
            }
            catch
            {
                // ignored
            }
        }
    }
}