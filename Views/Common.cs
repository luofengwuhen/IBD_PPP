using DevExpress.XtraEditors.Controls; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text; 
namespace Views
{
    public class Common
    {
        [DllImport("Trace.dll")]
        private static extern int OpenUSB([MarshalAs(UnmanagedType.LPStr)] string usbID);
        [DllImport("Trace.dll")]
        private static extern void closeport();

        #region 打印命令

        [DllImport("Trace.dll")]
        public static extern int sendcommand([MarshalAs(UnmanagedType.LPStr)] string command);

        // 1 -> Success, 0 -> Fail
        [DllImport("Trace.dll")]
        public static extern int ecTextOut(int x, int y, int b,
            [MarshalAs(UnmanagedType.LPStr)] string c, [MarshalAs(UnmanagedType.LPStr)] string d);

        // 1 -> Success, 0 -> Fail
        [DllImport("Trace.dll")]
        public static extern int putimage(int x, int y, [MarshalAs(UnmanagedType.LPStr)] string filename, int degree);

        #endregion


    

        /// <summary>
        /// 从字节数组USBID获取字符串USBID。
        /// </summary>
        /// <returns>如果失败，返回null。</returns>
        public string GetUsbPort(byte[] usbID)
        {
            char[] separator = { '\0' };

            string usbPort = System.Text.Encoding.ASCII.GetString(usbID);
            string[] subString = usbPort.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (subString.Length == 0)
            {
                usbPort = null;
            }
            else
            {
                usbPort = subString[0];
            }
            return usbPort;
        }

        /// <summary>
        /// 打开USB打印机
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool OpenPort(PrinterPortInfo port)
        {
            bool rst = false;
            switch (port.PortType)
            { 
                case PrinterPortType.pptUSB:
                    rst = OpenUSB(port.PortID) != 0;
                    break; 
                default:
                    break;
            }

            return rst;
        }

        /// <summary>
        /// 关闭打印机端口。
        /// </summary>
        public void ClosePort(PrinterPortInfo port)
        {
            closeport();
        }

       



    }
}
