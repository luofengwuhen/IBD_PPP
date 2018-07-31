
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
    public class Pager
    {
        /// <summary>
        /// 每页行数.
        /// </summary>
        public int rows { get; set; }
    
        /// <summary>
        /// 当前页是第几页
        /// </summary>
        public int page { get; set; }
    
        /// <summary>
        /// 排序方式
        /// </summary>
        public string order { get; set; }
    
        /// <summary>
        /// 排序列
        /// </summary>
        public string sort { get; set; }
    
        /// <summary>
        /// 总行数
        /// </summary>
        public int totalRows { get; set; }
    
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPages 
        {
            get
            {
                return (int)Math.Ceiling((float)totalRows / (float)rows);
            }
        }
    }
}
