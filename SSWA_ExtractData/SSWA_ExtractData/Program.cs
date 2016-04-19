using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using SSWA_ExtractData.UserInterface;

namespace SSWA_ExtractData
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SkinManager.EnableFormSkins();
                BonusSkins.Register();
                Application.Run(new A00FrmMain());
            }
            catch
            {
                // ignored
            }
        }
    }
}