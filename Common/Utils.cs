using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace SnCodeCommon
{

    /// <summary>
    /// 工具类。
    /// </summary>
    public static class Utils
    {
        #region 类型转换

        /// <summary>
        /// 判断所给的字符串是否表示数量（是正整数，而且不超过10000）。
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <param name="amount">如果是数字，返回值。</param>
        /// <returns>如果是数量，返回true，否则返回false。</returns>
        public static bool IsAmount(string str, out int amount)
        {
            amount = 0;
            if (str.Length <= 4 && int.TryParse(str, out amount) == true)
            {
                return amount > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 将一个可为空的整数转换成整数。
        /// </summary>
        /// <param name="value">可为空（Nullable）的整数。、</param>
        /// <returns>整数。如果为空，则返回0。</returns>
        public static int ToInt(int? value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                return (int)value;
            }
        }

        /// <summary>
        /// 将一个可为空的布尔值转换成布尔值。
        /// </summary>
        /// <param name="value">可为空（Nullable）的布尔值。</param>
        /// <returns>布尔值。如果为空，则返回false。</returns>
        public static bool ToBool(bool? value)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                return (bool)value;
            }
        }

 

        /// <summary>
        /// 将一个可为空的整数转换成整数。
        /// </summary>
        /// <param name="value">可为空（Nullable）的整数。、</param>
        /// <returns>整数。如果为空，则返回0。</returns>
        public static int ToInt(decimal? value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                return (int)value;
            }
        }

        /// <summary>
        /// 将一个可为空的日期转换成日期。
        /// </summary>
        /// <param name="value">可为空（Nullable）的日期。</param>
        /// <returns>日期。如果为空，则返回MaxDate。</returns>
        public static DateTime ToDateTime(DateTime? value)
        {
            if (value == null)
            {
                return DateTime.MaxValue;
            }
            else
            {
                return (DateTime)value;
            }
        }

        /// <summary>
        /// 将null的字符串转换成string.empty
        /// </summary>
        /// <param name="value">字符串。</param>
        /// <returns>如果字符串为null，则返回string.Empty；否则返回字符串本身。</returns>
        public static string ToString(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 将可以为null的日期转换成yyyy-MM-dd格式的字符串。如果为null，则返回空串。
        /// </summary>
        /// <param name="value">可为空日期值</param>
        /// <returns>如果字符串为null，则返回string.Empty；否则返回yyyy-MM-dd格式的字符串。</returns>
        public static string ToString(DateTime? value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 将日期转换成yyyy-MM-dd格式的字符串。
        /// </summary>
        /// <param name="value">可为空日期值</param>
        /// <returns>返回yyyy-MM-dd格式的字符串。</returns>
        public static string ToString(DateTime value)
        {
            return value.ToString("yyyy-MM-dd");
        }

        #endregion

        #region 字符串判断

        /// <summary>
        /// 判断所给的字符串是否表示数量（是正整数，而且不超过1000）。
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <returns>如果是数量，返回true，否则返回false。</returns>
        public static bool IsAmount(string str)
        {
            int amount;
            return IsAmount(str, out amount);
        }

        /// <summary>
        /// 批量条码处理：宜家打包后的条码结构“(xxx)[货号]16844(xx)xxxx(xx)[数量]”，本函数判断是否为该格式的条码
        /// 如果是，返回true，并通过参数返回对应宜家条码（货号+168449）；否则返回false。
        /// </summary>
        /// <param name="code">采集项字符串</param>
        /// <param name="scanCode">返回宜家条码。</param>
        /// <param name="amount">返回数量。</param>
        /// <returns>是否是宜家批量条码。</returns>
        public static bool IsIkeaBatchScanCode(string code, out string scanCode, out string amount)
        {
            scanCode = amount = string.Empty;

            Regex r = new Regex(@"240(\d{8})(\d{6})1\d{4}30(\d+)");
            Match m = r.Match(code);
            if (m.Success == true)
            {
                scanCode = m.Groups[1].Value + m.Groups[2].Value;  //第1捕获项为货号，增加后缀168449。
                amount =  m.Groups[3].Value;
            }

            return m.Success;
        }

        public static bool IsSCMScanCode(string code, out string scanCode, out string amount,out string xh)
        {
            scanCode = amount = xh = string.Empty;

            string[] codes = code.Split(new char[1] { ',' });
            bool result = false;
            if (codes.Count() == 4)
            {
                scanCode = codes[0];
                amount = codes[1];
                xh = codes[3];
                result = true;
            }

            return result;
        }


        /// <summary>
        /// 批量条码处理：宜家打包后的条码结构“(xxx)[货号]16844(xx)xxxx(xx)[数量]”，本函数判断是否为该格式的条码
        /// 如果是，返回true，并通过参数返回对应宜家条码（货号+168449）；否则返回false。
        /// </summary>
        /// <param name="code">采集项字符串</param>
        /// <param name="scanCode">返回宜家条码。</param>
        /// <param name="amount">返回数量。</param>
        /// <param name="amount">周期</param> 
        /// <returns>是否是宜家批量条码。</returns>
        public static bool IsIkeaBatchScanCode(string code, out string scanCode, out string amount,out string Period)
        {
            Period = scanCode = amount = string.Empty;

            Regex r = new Regex(@"240(\d{8})(\d{6})1(\d{4})30(\d+)");
            Match m = r.Match(code);
            if (m.Success == true)
            {
                scanCode = m.Groups[1].Value + m.Groups[2].Value;  //第1捕获项为货号，增加后缀168449。
                amount = m.Groups[4].Value;
                Period = m.Groups[3].Value;
            }
            return m.Success;
        }


        /// <summary>
        /// 批量条码处理：宜家打包后的条码结构“(xxx)[货号]16844(xx)xxxx(xx)[数量]”，本函数判断是否为该格式的条码
        /// 如果是，返回true，并通过参数返回对应宜家条码（货号+168449）；否则返回false。
        /// </summary>
        /// <param name="code">采集项字符串</param>
        /// <param name="scanCode">返回宜家条码。</param>
        /// <param name="amount">返回数量。</param>
        /// <returns>是否是宜家批量条码。</returns>
        public static bool IsIkeaBatchScanCode(string code)
        {
            Regex r = new Regex(@"240(\d{8})(\d{6})1\d{4}30(\d+)");
            Match m = r.Match(code);
            return m.Success;
        }

        /// <summary>
        /// 整理一条采集项。（1）去掉“=”的位置后缀；（2）替换宜家条码后缀“168442”=>“168449”；(3)转换成大写。
        /// </summary>
        /// <param name="code">采集项。</param>
        /// <returns>整理后的采集项。</returns>
        public static string ClearScanCode(string code)
        {
            if (code == null) return null;
            code = code.ToUpper();
            int idx = code.IndexOf("=");
            if (idx >= 0)  //去掉位置后缀
            {
                code = code.Remove(idx);
            }

            idx = code.IndexOf("168442");
            if (idx >= 0)
            {
                code = string.Format("{0}168449", code.Remove(idx));
            }

            return code.Trim();
        }

        /// <summary>
        /// 判断两个字符串是否相同（null和Empty认为相同）。
        /// </summary>
        public static bool StringEqual(string strA, string strB)
        {
            if (string.IsNullOrEmpty(strA) && string.IsNullOrEmpty(strB))
            {
                return true;
            }
            else
            {
                return strA == strB;
            }
        }

        #endregion

        #region 杂项

        /// <summary>
        /// 显示一般提示信息。
        /// </summary>
        /// <param name="msType">消息类型。</param>
        /// <param name="prompt">提示信息。</param>
        /// <param name="label">显示信息用的状态栏标签。可以为null。</param>
        /// <param name="showBox">true = 显示提示框，false = 无提示框。</param>
        /// <param name="btns">提示框按钮，可以为null。</param>
        public static DialogResult ShowPrompt(MessageType msType, string prompt, ToolStripStatusLabel label = null, MessageBoxButtons? btns = null)
        {
            if (label != null)
            {
                label.Text = prompt;
                label.ForeColor = (msType == MessageType.mtError) ? Color.Red : Color.Navy;
            }

            if (btns == null)
            {
                btns = MessageBoxButtons.OK;
            }

            string caption = "消息";
            MessageBoxIcon icon = MessageBoxIcon.Information;
            if (msType == MessageType.mtError)
            {
                caption = "错误";
                icon = MessageBoxIcon.Error;
            }
            else if (msType == MessageType.mtWarning)
            {
                caption = "警告";
                icon = MessageBoxIcon.Warning;
            }
            DialogResult dr = MessageBox.Show(prompt, caption, (MessageBoxButtons)btns, icon);

            System.Windows.Forms.Application.DoEvents();
            return dr;
        }

        /// <summary>
        /// 判断操作系统是32位还是64位
        /// </summary>
        public static int GetPlateformRunMode()
        {
            if (IntPtr.Size == 8)
            {
                return 64;
            }
            return 32;
        }

        /// <summary>
        /// 生成ESB用的GUID。
        /// </summary>
        public static string GeneratGuid()
        {
            string s1 = Guid.NewGuid().ToString();
            string s2 = Guid.NewGuid().ToString();
            s1 = s1.Substring(0, 8) + s1.Substring(9, 4) + s1.Substring(14, 4) + s1.Substring(0x13, 4) + s1.Substring(0x18, 12);
            s2 = s2.Substring(0, 8) + s2.Substring(9, 4) + s2.Substring(14, 4) + s2.Substring(0x13, 4) + s2.Substring(0x18, 12);
            return (s1 + s2).Substring(0, 0x30);
        }

        #endregion

        #region 加密/解密

        private static byte[] DesKey = Encoding.ASCII.GetBytes("www.chin");
        private static byte[] DesIV = Encoding.ASCII.GetBytes("abed.com");

        /// <summary>
        /// 加密字符串。
        /// </summary>
        /// <param name="plainText">明文。</param>
        /// <returns>密文。</returns>
        public static string Encrypt(string plainText)
        {
            MemoryStream ms = new MemoryStream();

            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(DesKey, DesIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(encStream);
            sw.WriteLine(plainText);
            sw.Close();
            encStream.Close();
            string crypto = Convert.ToBase64String(ms.ToArray());

            ms.Close();
            return crypto;
        }

        /// <summary>
        /// 解密字符串。
        /// </summary>
        /// <param name="cypherText">密文。</param>
        /// <returns>明文。</returns>
        public static string Decrypt(string cypherText)
        {
            byte[] crypto = Convert.FromBase64String(cypherText);
            MemoryStream ms = new MemoryStream(crypto);

            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(DesKey, DesIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(encStream);
            string val = sr.ReadLine();
            sr.Close();
            encStream.Close();

            ms.Close();
            return val;
        }

        #endregion

        #region 字符串列表处理

        /// <summary>
        /// 基于统一料品的序列号前缀相同的原理，压缩序列号清单。
        /// </summary>
        /// <param name="snList">序列号数组。</param>
        /// <returns>前缀1;后缀11,后缀12,...;前缀2;后缀21,后缀22，...</returns>
        public static string CompressSnList(string snList)
        {
            if (string.IsNullOrEmpty(snList))
            {
                return string.Empty;
            }
            else
            {
                //string[] snArray = snList.Split(Consts.Seperator);
                ////排序
                //Array.Sort<string>(snArray);
                ////获取前缀方案：自然前缀
                //StringBuilder sb = new StringBuilder();
                //string prefix = null;
                //int prefixLen = 0;
                //for (int i = 0; i < snArray.Length; i++)
                //{
                //    string sn = snArray[i];
                //    //新的前缀
                //    if (prefix == null || !sn.StartsWith(prefix))
                //    {
                //        //尾巴的","修改成";"。
                //        if (sb.Length > 0)
                //        {
                //            sb.Remove(sb.Length - 1, 1);
                //            sb.Append(";");
                //        }
                //        //两种可能的前缀分隔符：-，=
                //        prefixLen = sn.IndexOf(Consts.Seperator) + 1;
                //        if (prefixLen == 0)
                //        {
                //            prefixLen = sn.IndexOf(Consts.SetTo) + 1;
                //        }
                //        if (prefixLen == 0)  //无分隔符，整个作为后缀。
                //        {
                //            prefix = null;
                //            sb.Append(";");
                //        }
                //        else
                //        {
                //            //截取新的前缀
                //            prefix = sn.Substring(0, prefixLen);
                //            sb.Append(prefix).Append(";");
                //        }
                //    }
                //    //后缀
                //    sb.Append(sn.Substring(prefixLen)).Append(",");
                //}
                ////移除尾巴的","或";"。
                //if (sb.Length > 0)
                //{
                //    sb.Remove(sb.Length - 1, 1);
                //}
                //return sb.ToString();
                return null;
            }
        }

        /// <summary>
        /// 基于统一料品的序列号前缀相同的原理，解压缩序列号清单。
        /// </summary>
        /// <param name="snList">序列号数组。前缀1;后缀11,后缀12,...;前缀2;后缀21,后缀22，...</param>
        /// <returns>序列号清单，逗号分隔</returns>
        public static string DecompressSnList(string snList)
        {
            if (string.IsNullOrEmpty(snList))
            {
                return string.Empty;
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                string[] snArray = snList.Split(';');
                for (int i = 0; i < snArray.Length; i += 2)
                {
                    string prefix = snArray[i];  //前缀
                    string[] snTails = snArray[i + 1].Split(',');  //后缀清单
                    foreach (string snt in snTails)
                    {
                        sb.Append(prefix).Append(snt).Append(',');
                    }
                }
                //移除尾巴的","。
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 按照指定长度分割字符串。长度的计算：汉字算2个。
        /// </summary>
        /// <returns>如果字符串为空，或者size小于等于0，则返回长度为1，元素为空串的数组。</returns>
        public static string[] SpliteBySize(this string str, int size)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(str) && size > 0)
            {
                StringBuilder sb = new StringBuilder();
                int cnt = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    sb.Append(str[i]);
                    int asc = Convert.ToChar(str[i]);
                    cnt += (asc < 0 || asc > 127) ? 2 : 1;  //汉字算2个。
                    if (cnt >= size)  //到达指定尺寸，分割出1个字符串。
                    {
                        list.Add(sb.ToString());
                        sb.Clear();  //准备开始下一个。
                        cnt = 0;
                    }
                }
                if (cnt < size)
                {
                    list.Add(sb.ToString());
                }
            }
            else
            {
                list.Add(string.Empty);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 将newStr作为列表项，添加到逗号分隔的strList中。
        /// </summary>
        /// <param name="newStr">为空，表示不添加。</param>
        /// <param name="noDup">是否允许重复。</param>
        public static string AddToList(string strList, string newStr, bool noDup)
        {
            if (string.IsNullOrEmpty(strList))
            {
                return newStr;
            }
            else if (string.IsNullOrEmpty(newStr))
            {
                return strList;
            }
            else
            {
                //string[] strArray = strList.Split(Consts.Seperator);
                //if (!noDup || Array.IndexOf<string>(strArray, newStr) == -1)  //允许重复，或者原来没有此项。
                //{
                //    return string.Format("{0}{1}{2}", strList, Consts.Seperator, newStr);  //添加。
                //}
                //else
                //{
                //    return strList;
                //}
                return null;
            }
        }

        /// <summary>
        /// 将removeStr作为列表项，从逗号分隔的strList中删除。
        /// </summary>
        public static string RemoveFromList(string strList, string removeStr)
        {
            if (string.IsNullOrEmpty(strList))
            {
                return strList;
            }
            else
            {
                //List<string> strArray = strList.Split(Consts.Seperator).ToList();
                //strArray.Remove(removeStr);

                //if (strArray.Count > 0)
                //{
                //    return string.Join(Consts.Seperator.ToString(), strArray.ToArray());
                //}
                //else
                //{
                //    return string.Empty;
                //}
                return null;
            }
        }    
        
        #endregion

        #region  导出EXCEL
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="dgv"></param>
        public static void DataGridViewToExcel(DataGridView dgv)
        {
            #region   验证可操作性
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xlsx ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLSX)|*.xlsx ";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数   
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0   
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0   
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536   
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于100   
            if (colscount > 100)
            {
                MessageBox.Show("数据记录列数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它   
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见   
                objExcel.Visible = false;

                //向Excel中写入表格的表头   
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //设置进度条   
                //this.tempProgressBar.Refresh();
                //this.tempProgressBar.Visible = true;
                //this.tempProgressBar.Minimum = 1;
                //this.tempProgressBar.Maximum = dgv.RowCount;
                //this.tempProgressBar.Step = 1;   
                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //this.tempProgressBar.PerformStep();   

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                if (displayColumnsCount == 1)
                                {
                                    objExcel.Cells[row + 2, displayColumnsCount] = "'"+ dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                }
                                else
                                {
                                    objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                }
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }
                //隐藏进度条   
                //this.tempProgressBar.Visible   =   false;   
                //保存文件   
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion



        #region
        /// <summary>
        /// 读取Excel文档/Xml文档（从Excel转换得到）到DataSet，每个Sheet一个Table。
        /// </summary>
        /// <param name="sFileName">Excel文档/Xml文档文件全名。</param>
        public static DataSet Import(string sFileName)
        {

            string FileType = sFileName.Substring(sFileName.LastIndexOf('.') + 1);
            DataSet objDataSet = new DataSet();
            if (FileType.Equals("xml", StringComparison.OrdinalIgnoreCase))
            {
                objDataSet.ReadXml(sFileName);
            }
            if (FileType.Equals("xls", StringComparison.OrdinalIgnoreCase) || FileType.Equals("xlsx", StringComparison.OrdinalIgnoreCase))
            {

                OleDbConnection conn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", sFileName));

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    object[] restrictions = new object[4];
                    restrictions[3] = "TABLE";
                   System.Data.DataTable dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
                    foreach (DataRow dtSheet in dtExcelSchema.Rows)
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();

                        string sheetName = dtSheet["TABLE_NAME"].ToString().Trim();
                        OleDbDataAdapter oleExcelDataAdapter = new OleDbDataAdapter(string.Format(" select * from [{0}]", sheetName), conn);
                        oleExcelDataAdapter.Fill(dt);
                        dt.TableName = sheetName.Substring(0, sheetName.IndexOf("$"));

                        objDataSet.Tables.Add(dt);
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
            return objDataSet;
        }

        private static IWorkbook workbook = null;
        /// <summary>
        /// npoi导入
        /// </summary>
        /// <param name="strFileName">导入文件</param>
        /// <param name="isFirstRowColumn">是否去掉第一行表头</param>
        /// <returns></returns>
        public static System.Data.DataTable ImportNPOI(string strFileName, bool isFirstRowColumn)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            int startRow = 0;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            { 
                if (strFileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(file);
                else if (strFileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(file);
            }
            ISheet sheet = workbook.GetSheetAt(0);


            if (sheet != null)
            {
                IRow firstRow = sheet.GetRow(0);
                int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                {
                    ICell cell = firstRow.GetCell(i);
                    if (cell != null)
                    {
                        string cellValue = cell.StringCellValue;
                        if (cellValue != null)
                        {
                            DataColumn column = new DataColumn(cellValue);
                            dt.Columns.Add(column);
                        }
                    }
                }

                if (isFirstRowColumn)
                { 
                    startRow = sheet.FirstRowNum + 1;
                }
                else
                {
                    startRow = sheet.FirstRowNum;
                }

                //最后一列的标号
                int rowCount = sheet.LastRowNum;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //没有数据的行默认是null　　　　　　　

                    DataRow dataRow =  dt.NewRow(); 
                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                    {
                        if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            return dt;


            //System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            //IRow headerRow = sheet.GetRow(0);
            //int cellCount = headerRow.LastCellNum;

            //for (int j = 0; j < cellCount; j++)
            //{
            //    ICell cell = headerRow.GetCell(j);
            //    dt.Columns.Add(cell.ToString());
            //}

            //for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            //{
            //    IRow row = sheet.GetRow(i);
            //    DataRow dataRow = dt.NewRow();

            //    for (int j = row.FirstCellNum; j < cellCount; j++)
            //    {
            //        if (row.GetCell(j) != null)
            //            dataRow[j] = row.GetCell(j).ToString();
            //    }

            //    dt.Rows.Add(dataRow);
            //}
            //return dt;
        }

        #endregion

        #region 本地配置文件、文本配置文件、数据库读写

        /// <summary>   
        /// App.Config appSettings写入值   
        /// </summary>   
        /// <param name="key"></param>   
        /// <param name="value"></param>   
        public static void SetAppSettingsValue(string key, string value)
        {
            //增加的内容写在appSettings段下 <add key="RegCode" value="0"/>   
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件    
        }

        /// <summary>   
        /// App.Config appSettings读取指定key的值   
        /// </summary>   
        public static string GetAppSettingsValue(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 读取本地文本配置文件，获取配置。
        /// </summary>
        public static string GetLocalConfig(string name)
        {
            string value = null;
            if (!string.IsNullOrEmpty(name))
            {
                string filename = PrepareConfigFile(name);

                if (File.Exists(filename))
                {
                    FileStream cfgFile = new FileStream(filename, FileMode.OpenOrCreate);
                    StreamReader sr = new StreamReader(cfgFile);
                    value = sr.ReadLine();
                    sr.Close();
                }
            }
            return value;
        }

        /// <summary>
        /// 写本地文本配置文件。
        /// </summary>
        public static void SetLocalConfig(string name, string value)
        {
            if (!string.IsNullOrEmpty(name))
            {
                string filename = PrepareConfigFile(name);

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                FileStream cfgFile = new FileStream(filename, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(cfgFile);
                sw.WriteLine(value);
                sw.Close();
            }
        }

        /// <summary>
        /// 删除本地文本配置文件
        /// </summary>
        public static void DeleteLocalDB(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                string filename = PrepareConfigFile(name);

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
        }

        /// <summary>
        /// 准备本地文本配置文件夹，并返回配置文件名。
        /// </summary>
        /// <param name="name">配置名。</param>
        /// <returns>配置文件名。</returns>
        private static string PrepareConfigFile(string name)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string specificFolder = Path.Combine(folder, "XlmUa");
            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);
            string filename = Path.Combine(specificFolder, name + ".ini");
            return filename;
        }

        /// <summary>
        /// 读取本地数据库文件。
        /// </summary>
        public static T LoadLocalDB<T>(string dbName)
        {
            string jsonString = GetLocalConfig(dbName);
            if (string.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }
            else
            {
                JsonSerializerSettings setting = new JsonSerializerSettings();
                try
                {
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                catch
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// 写本地数据库文件。
        /// </summary>
        public static void SaveLocalDB<T>(string dbName, T data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            SetLocalConfig(dbName, jsonString);
        }

        #endregion




        /// <summary>
        /// 创建数字印章  维尚床垫条码 打印使用
        /// </summary>
        /// <param name="sourcePath">源图片路径</param>
        /// <param name="itemDingShu">需要增加的文字</param>
        public static void CreateDigitalStamp(string sourcePath, string itemDingShu)
        {
            string path = Path.Combine(sourcePath, "dt.bmp");
            string resultPath = Path.Combine(sourcePath, string.Format("{0}.bmp", itemDingShu));
            //读取图片
            Bitmap bmp = new Bitmap(path);
            Graphics g = Graphics.FromImage(bmp);
            String str = itemDingShu;
            System.Drawing.Font font = new System.Drawing.Font("Verdana", (float)(90), FontStyle.Regular);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            //编辑
            g.DrawString(str, font, sbrush, new PointF(70, 80));
            MemoryStream ms = new MemoryStream();
            //另存
            bmp.Save(resultPath, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        
        /// <summary>
        /// 查询表名
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static string[] GetExcelSheetNames(OleDbConnection con)
        {
            try
            {
                System.Data.DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new[] { null, null, null, "Table" });//检索Excel的架构信息
                var sheet = new string[dt.Rows.Count];
                for (int i = 0, j = dt.Rows.Count; i < j; i++)
                {
                    //获取的SheetName是带了$的
                    sheet[i] = dt.Rows[i]["TABLE_NAME"].ToString();
                }
                return sheet;
            }
            catch
            {
                return null;
            }
        }
    }

}
