using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnCodeServices
{
    public class ValidationError
    {
        public ValidationError() { }
        public string ErrorMessage { get; set; }       
    }

    public class ValidationErrors : List<ValidationError>
    {
        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="errorMessage">信息描述</param>
        public void Add(string errorMessage)
        {
            base.Add(new ValidationError { ErrorMessage = errorMessage });
        }

        /// <summary>
        /// 添加异常
        /// </summary>
        /// <param name="exp">信息描述</param>
        public void Add(Exception exp)
        {
            while (exp != null)
            {
                base.Add(new ValidationError { ErrorMessage = exp.Message });
                exp = exp.InnerException;
            }
        }

        public override string ToString()
        {
            string error = "";
            this.All(a =>
            {
                error += a.ErrorMessage + "\n";
                return true;
            });
            return error;
        }
    }
}
