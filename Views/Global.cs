 
using SnCodeServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Views
{
    /// <summary>
    /// 存放全局变量的静态类。
    /// </summary>
    public static class Global
    {
        #region 静态成员变量

   

        #endregion

        #region 服务器时间

        /// <summary>
        /// 对应Sql服务器日期时间。
        /// </summary>
        private static DateTime _sqlStartTime = DateTime.MinValue;

        /// <summary>
        /// 本地时间。
        /// </summary>
        private static DateTime _localStartTime = DateTime.MinValue;

        /// <summary>
        /// 获取数据库服务器时间。
        /// </summary>
        public static DateTime SqlNow
        {
            get
            {
                if (_sqlStartTime == DateTime.MinValue)  //尚未获取时间，记录Sql和当地时间。
                {
                    BaseService svr = new BaseService();
                    _sqlStartTime = svr.GetSqlNow();
                    if (svr.HasError)
                    {
                        throw new ApplicationException("获取服务器时间失败，系统无法正常工作。" + svr.Errors);
                    }
                    _localStartTime = DateTime.Now;

                }
                DateTime sqlNow = _sqlStartTime.Add(DateTime.Now - _localStartTime);  //起始Sql时间+（本地流逝时间）=目前Sql时间。
                return sqlNow;
            }
        }

        #endregion

       
      
        /// <summary>
        /// 主窗体的句柄
        /// </summary>
        public static IntPtr MainHandle { get; set; }
    }
}
