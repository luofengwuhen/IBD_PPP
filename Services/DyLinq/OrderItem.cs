
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
    /// 排序项
    /// </summary> 
    public class OrderItem
    {
        public OrderItem() { }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="propName">属性名。</param>
        /// <param name="orderType">排序类型。</param>
        public OrderItem(string propName, OrderType orderType, Object tag = null)
        {
            this.PropertyName = propName;
            this.OrderType = orderType;
            this.Tag = tag;
        }

        /// <summary>
        /// 排序属性名。
        /// </summary> 
        public string PropertyName { get; set; }

        /// <summary>
        /// 排序类型。
        /// </summary> 
        public OrderType OrderType { get; set; }

        /// <summary>
        /// 获取附加对象（只读避免被序列化）。
        /// </summary>
        [NonSerialized]
        public Object Tag;

        //{
        //    get
        //    {
        //        return _tag;
        //    }

        //}
        //private Object _tag;

        ///// <summary>
        ///// 设置附加对象。
        ///// </summary>
        //public void SetTag(Object tag)
        //{
        //    this._tag = tag;
        //}
    }
}
