using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen; 
using System.IO;

namespace Views
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();

            //T_User tu = new T_User();
            //tu.ID = 9;
            //tu.UserCode = "123";
            //tu.UserName = "测试22";
            //Global.User = tu;
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
            //RoleService rsr = new RoleService();
            //T_User tu = Global.User;
            //List<getRoleRight_Result> rrrList = new List<getRoleRight_Result>();
            //List<T_UserRole> trList = rsr.getUserRoleList(tu.ID);
            //if (trList.Count > 0) //单角色
            //{
            //    rrrList = rsr.getRoleRightList((int)trList[0].RoleID);
            //    Global.rrrList = rrrList;
            //}

            //CheckPrinterDll();

        }

        private void CheckPrinterDll()
        {
            //if (!File.Exists("Trace.dll"))
            //{
            //    if (Utils.GetPlateformRunMode() == 64)
            //    {
            //        File.Copy("Print\\EZio64.dll", "Trace.dll");
            //    }
            //    else
            //    {
            //        File.Copy("Print\\Ezio32.dll", "Trace.dll");
            //    }
            //}
        }
    }
}