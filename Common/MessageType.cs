using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnCodeCommon
{
    /// <summary>
    /// 消息类型。
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 一般消息。
        /// </summary>
        mtInformation = 0,

        /// <summary>
        /// 警告消息。
        /// </summary>
        mtWarning = 1,

        /// <summary>
        /// 错误消息。
        /// </summary>
        mtError = 2
    }
}
