using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views
{
    /// <summary>
    /// 打印机端口信息
    /// </summary>
    public class PrinterPortInfo
    {
        /// <summary>
        /// 端口类型。
        /// </summary>
        public PrinterPortType PortType { get; set; }

        /// <summary>
        /// 端口标识。
        /// </summary>
        public string PortID { get; set; }

        /// <summary>
        /// 波特率（仅对串口有效）。
        /// </summary>
        public int BaudRate { get; set; }
    }

    /// <summary>
    /// 端口类别。
    /// </summary>
    public enum PrinterPortType
    {
        /// <summary>
        /// 并口
        /// </summary>
        pptLPT = 0,

        /// <summary>
        /// 串口
        /// </summary>
        pptCOM = 1,

        /// <summary>
        /// USB口
        /// </summary>
        pptUSB = 2,

        /// <summary>
        /// 打印驱动程序
        /// </summary>
        pptDriver = 3,

        /// <summary>
        /// 通过网络
        /// </summary>
        pptNet = 4
    }
}
