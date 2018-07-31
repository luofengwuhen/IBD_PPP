
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
    /// 查找条件项
    /// </summary> 
    public class ConditionItem 
    {
        public ConditionItem() { }
    
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="propName">属性名。</param>
        /// <param name="findType">查找类型。</param>
        /// <param name="values">查找值。</param>
        public ConditionItem(string propName, ConditionType findType, object[] values)
        {
            this.PropertyName = propName;
            this.FindType = findType;
            this.Values = values;
        }
    
        /// <summary>
        /// 查找属性名。
        /// </summary> 
        public string PropertyName { get; set;}
    
        /// <summary>
        /// 查找类型。
        /// </summary> 
        public ConditionType FindType { get; set; }
    
        /// <summary>
        /// 查找值。
        /// </summary> 
        public object[] Values { get; set; }
    }
}
