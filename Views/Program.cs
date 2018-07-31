using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel; 
using System.Threading;
using DevExpress.XtraSplashScreen;
using Views;

namespace Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            //LoginForm loginForm = new LoginForm();
            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{
                Application.Run(new MainForm());  //
            //}
             
        }
    }
}