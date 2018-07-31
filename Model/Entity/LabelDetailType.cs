using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace SnCodeModels
{
    public enum LabelDetailType
    {
        /// <summary>
        /// 固定文本
        /// </summary>
        ldtText = 0,

        /// <summary>
        /// 属性文本，通过反射获取属性值
        /// </summary>
        ldtDynText = 1,

        /// <summary>
        /// 图片，相对路径
        /// </summary>
        ldtImage =2,

        /// <summary>
        /// 固定条码
        /// </summary>
        ldtBarCode = 3,

        /// <summary>
        /// 属性条码
        /// </summary>
        ldtDynamicBarCode = 4,

        /// <summary>
        /// 二维码
        /// </summary>
        QRCode = 5,

        /// <summary>
        /// 特殊日期YYMMDD(二维码)
        /// </summary>
        DateYYYYMMDD = 6,

        /// <summary>
        /// 数字印章
        /// </summary>
        DigitalStamp = 7,

        /// <summary>
        /// 特殊日期YYYYMMDD
        /// </summary>
        DateYYYYMMDDText = 8,

        /// <summary>
        /// 套打标记
        /// </summary>
        SuitePrintTag = 9,

        /// <summary>
        /// 套打文本显示
        /// </summary>
        SuitePrintText = 10,

        /// <summary>
        /// 打印备注
        /// </summary>
        MemoText = 11,


    }

    public static class LabelDetailTypeExtension
    {
        private static string[] Labels = new string[] { "固定文本", "属性文本", "图片", "固定条码", "属性条码", "二维码", "二维码（YYYYMMDD）", "数字印章", "属性文本(YYYYMMDD)", "套打标记", "套打文本显示", "打印备注" };

        /// <summary>
        /// 将枚举转换成序号对应的字符串。
        /// </summary>
        public static string GetDbValue(this LabelDetailType ldt)
        {
            int value = (int)ldt;
            return value.ToString();
        }

        /// <summary>
        /// 获取指定类型的标签。
        /// </summary>
        public static string GetLabel(this LabelDetailType ldt)
        {
            int value = (int)ldt;
            return Labels[value];
        }

  
    }
}
