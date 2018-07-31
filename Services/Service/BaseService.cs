using log4net;
using SnCodeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace SnCodeServices
{
    public class BaseService
    {
        public static ILog _log = log4net.LogManager.GetLogger(typeof(BaseService)); 

       
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
        public DateTime GetSqlNow()
        {
            if (_sqlStartTime == DateTime.MinValue)  //尚未获取时间，记录Sql和当地时间。
            {
                try
                {
                    //using (SnCode_NorthEntities db = new SnCode_NorthEntities())
                    //{
                    //    var a = db.Database.SqlQuery<DateTime>("select GETDATE()", new object[] { });
                    //    _sqlStartTime = a.First();

                    //    _localStartTime = DateTime.Now;
                    //}
                }
                catch (Exception ex)
                {
                    Errors.Add(ex);
                    WriteException(ex);
                    return DateTime.Now;
                }
            }
            DateTime sqlNow = _sqlStartTime.Add(DateTime.Now - _localStartTime);  //起始Sql时间+（本地流逝时间）=目前Sql时间。
            return sqlNow;
        }

        #endregion

        /// <summary>
        /// 错误信息。
        /// </summary>
        public ValidationErrors Errors
        {
            get
            {
                if (_errors == null)
                {
                    _errors = new ValidationErrors();
                }
                return _errors;
            }
        }
        private ValidationErrors _errors = null;

        /// <summary>
        /// 是否存在错误。
        /// </summary>
        public bool HasError
        {
            get
            {
                if (_errors == null || _errors.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void WriteException(Exception excep)
        {
            _log.Error(excep);
        }

   
    }
}
