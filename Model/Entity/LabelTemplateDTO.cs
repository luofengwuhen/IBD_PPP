using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnCodeModels
{
    /// <summary>
    /// 票签打印数据传递类
    /// </summary>
    public class LabelTemplateDTO
    {
        #region 界面属性

        /// <summary>
        /// 界面选择。
        /// </summary>
        public bool UIChecked { get; set; }

        /// <summary>
        /// 界面输入日期。
        /// </summary>
        public string DeliveryDate { get; set; }

        /// <summary>
        /// 打印数量
        /// </summary>
        public int PrintNum { get; set; }

        #endregion
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

    }
}
