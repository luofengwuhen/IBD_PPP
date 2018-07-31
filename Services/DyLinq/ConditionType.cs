
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
    /// 条件类型。
    /// </summary>
    public enum ConditionType
    {
        /// <summary>
        /// 无效。
        /// </summary>
        ctNone,

        /// <summary>
        /// 等于。
        /// </summary>
        ctEqual,

        /// <summary>
        /// 包含。
        /// </summary>
        ctLike,

        /// <summary>
        /// 在...之间。
        /// </summary>
        ctBetween,

        /// <summary>
        /// 在...之中。
        /// </summary>
        ctIn,

        /// <summary>
        /// 不等于。
        /// </summary>
        ctNotEqual,

        /// <summary>
        /// 不包含。
        /// </summary>
        ctNotLike,

        /// <summary>
        /// 不在...之间。
        /// </summary>
        ctNotBetween,

        /// <summary>
        /// 不在...之中。
        /// </summary>
        ctNotIn,

        /// <summary>
        /// 小于。
        /// </summary>
        ctLessThan,

        /// <summary>
        /// 小于或等于。
        /// </summary>
        ctLessThanOrEqual,

        /// <summary>
        /// 大于。
        /// </summary>
        ctGreaterThan,

        /// <summary>
        /// 大于或等于。
        /// </summary>
        ctGreaterThanOrEqual
    }
}
