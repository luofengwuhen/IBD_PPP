
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;


namespace SnCodeServices
{
    /// <summary>
    /// 排序类型。
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 升序。
        /// </summary>
        otAscending,
            
        /// <summary>
        /// 降序。
        /// </summary>
        otDescending
    }
}
