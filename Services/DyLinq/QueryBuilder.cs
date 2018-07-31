
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
    /// Linq查询条件构造器。
    /// </summary>
    /// <typeparam name="T">对象。</typeparam>
    public class QueryBuilder<T>
    {
        /// <summary>
        /// 内部Where表达式。
        /// </summary>
        private Expression<Func<T, bool>> expression;
    
        /// <summary>
        /// 内部统一的参数。
        /// </summary>
        private ParameterExpression param;
    
        /// <summary>
        /// 转换成最终的Where表达式。
        /// </summary>
        public Expression<Func<T, bool>> ToExpression()
        {
            return expression;
        }
    
        /// <summary>
        /// 创建Linq查询条件构造器。
        /// </summary>
        public static QueryBuilder<T> Create()
        {
            return new QueryBuilder<T>();
        }
    
        /// <summary>
        /// 构造函数。
        /// </summary>
        private QueryBuilder()
        {
            expression = null;
            param = Expression.Parameter(typeof(T), "c");
        }
    
        /// <summary>
        /// 使用And合并所给的判断表达式。
        /// </summary>
        /// <param name="exp"></param>
        public void And(Expression<Func<T, bool>> exp)
        {
            if (this.expression == null)
            {
                //新表达式
                expression = exp;
            }
            else
            {
                //原表达式和新表达式And融合并采用相同的参数。
                //var invokedExpr = Expression.Invoke(exp, expression.Parameters.Cast<Expression>());
                expression = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expression.Body, exp.Body), expression.Parameters);
            }
        }
    
        /// <summary>
        /// 动态建立查询。
        /// </summary>
        /// <param name="conditions">查询项清单。</param>
        public QueryBuilder<T> AddConditions(params ConditionItem[] conditions)
        {
            if (conditions == null) return this;
    
            foreach (ConditionItem cond in conditions)
            {
                switch (cond.FindType)
                {
                    case ConditionType.ctEqual:
                        this.Equal(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctLike:
                        this.Like(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctBetween:
                        this.Between(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctIn:
                        this.In(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctNotEqual:
                        this.NotEqual(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctNotLike:
                        this.NotLike(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctNotBetween:
                        this.NotBetween(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctNotIn:
                        this.NotIn(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctLessThanOrEqual:
                        this.LessThanOrEqual(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctGreaterThanOrEqual:
                        this.GreaterThanOrEqual(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctLessThan:
                        this.LessThan(cond.PropertyName, cond.Values);
                        break;
                    case ConditionType.ctGreaterThan:
                        this.GreaterThan(cond.PropertyName, cond.Values);
                        break;
                    default:
                        break;
                }
            }
    
            return this;
        }
    
        /// <summary>
        /// 动态建立Between 查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为from，第2项作为to。</param>
        public QueryBuilder<T> Between(string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> lambda = BuildBetweenExpression(param, propertyName, values);
    
            this.And(lambda);
    
            return this;
        }
    
        /// <summary>
        /// 动态建立Not Between 查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为from，第2项作为to。</param>
        public QueryBuilder<T> NotBetween(string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> lambda = BuildBetweenExpression(param, propertyName, values);
            //取反
            lambda = Expression.Lambda<Func<T, bool>>(Expression.Not(lambda.Body), lambda.Parameters);
    
            this.And(lambda);
    
            return this;
        }
    
        /// <summary>
        /// 动态建立Less Than Or Equal查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为to。</param>
        public QueryBuilder<T> LessThanOrEqual(string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> lambda = BuildLessThanOrEqualExpression(param, propertyName, values);
    
            this.And(lambda);
    
            return this;
        }
    
        /// <summary>
        /// 动态建立Greater Than Or Equal查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为from。</param>
        public QueryBuilder<T> GreaterThanOrEqual(string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> lambda = BuildGreaterThanOrEqualExpression(param, propertyName, values);
    
            this.And(lambda);
    
            return this;
        }

        /// <summary>
        /// 动态建立Less Than查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为to。</param>
        public QueryBuilder<T> LessThan(string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> lambda = BuildGreaterThanOrEqualExpression(param, propertyName, values);

            //空值表示没有限制，可以忽略。
            if (lambda != null)
            {
                //取反
                lambda = Expression.Lambda<Func<T, bool>>(Expression.Not(lambda.Body), lambda.Parameters);
                this.And(lambda);
            }

            return this;
        }

        /// <summary>
        /// 动态建立Greater Than查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为from。</param>
        public QueryBuilder<T> GreaterThan(string propertyName, params object[] values)
        {
            Expression<Func<T, bool>> lambda = BuildLessThanOrEqualExpression(param, propertyName, values);
            
            //空值表示没有限制，可以忽略。
            if (lambda != null)
            {
                //取反
                lambda = Expression.Lambda<Func<T, bool>>(Expression.Not(lambda.Body), lambda.Parameters);
                this.And(lambda);
            }

            return this;
        }
    
        /// <summary>
        /// 动态建立Equal查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项。</param>
        public QueryBuilder<T> Equal(string propertyName, params object[] values)
        {
            var lambda = BuildEqualExpression(param, propertyName, values);
            this.And(lambda);
    
            return this;
        }
    
        /// <summary>
        /// 动态建立Not Equal查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项。</param>
        public QueryBuilder<T> NotEqual(string propertyName, params object[] values)
        {
            var lambda = BuildEqualExpression(param, propertyName, values);
            //取反
            lambda = Expression.Lambda<Func<T, bool>>(Expression.Not(lambda.Body), lambda.Parameters);
            this.And(lambda);
    
            return this;
        }
    
        /// <summary>
        /// 动态建立Like查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，必须为string，且只取第1项。</param>
        public QueryBuilder<T> Like(string propertyName, params object[] values)
        {
            var lambda = BuildLikeExpression(param, propertyName, values);
    
            //空值表示没有限制，可以忽略。
            if (lambda != null)
            {
                this.And(lambda);
            }
            return this;
        }
    
        /// <summary>
        /// 动态建立Like查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，必须为string，且只取第1项。</param>
        public QueryBuilder<T> NotLike(string propertyName, params object[] values)
        {
            var lambda = BuildLikeExpression(param, propertyName, values);
    
            //空值表示没有限制，可以忽略。
            if (lambda != null)
            {
                //取反
                lambda = Expression.Lambda<Func<T, bool>>(Expression.Not(lambda.Body), lambda.Parameters);
                this.And(lambda);
            }
            return this;
        }
    
        /// <summary>
        /// 动态建立In查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">查询值</param>
        public QueryBuilder<T> In(string propertyName, params object[] values)
        {
            var lambda = BuildInExpression(param, propertyName, values);
    
            this.And(lambda);
    
            return this;
        }
    
        /// <summary>
        /// 动态建立In查询条件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">查询值</param>
        public QueryBuilder<T> NotIn(string propertyName, params object[] values)
        {
            var lambda = BuildInExpression(param, propertyName, values);
    
            //取反
            lambda = Expression.Lambda<Func<T, bool>>(Expression.Not(lambda.Body), lambda.Parameters);
            this.And(lambda);
    
            return this;
        }
    
        #region 建立动态表达式
    
        /// <summary>
        /// 动态建立Between表达式
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为from，第2项作为to。</param>
        private static Expression<Func<T, bool>> BuildBetweenExpression(ParameterExpression param, string propertyName, object[] values)
        {
            if (values == null || values.Length != 2)
            {
                throw new Exception("Between操作必须指定2个参数。");
            }
    
            object from = values[0];
            object to = values[1];
    
            //c.<propertyName>
            Expression p = OrderBuilder.GetPropertyByName<T>(propertyName, param);
            //from, to
            Expression cstFrom = Expression.Constant(from);
            Expression cstTo = Expression.Constant(to);
            if (cstFrom.Type.Equals(p.Type) == false)
            {
                cstFrom = ConstantExpression.Convert(cstFrom, p.Type);
            }
            if (cstTo.Type.Equals(p.Type) == false)
            {
                cstTo = ConstantExpression.Convert(cstTo, p.Type);
            }
    
            Expression<Func<T, bool>> lambda;
            if (p.Type == typeof(string))
            {
                MethodCallExpression methodExpFrom = Expression.Call(null, typeof(string).GetMethod("Compare",
                   new Type[] { typeof(string), typeof(string) }), p, cstFrom);
                MethodCallExpression methodExpTo = Expression.Call(null, typeof(string).GetMethod("Compare",
                   new Type[] { typeof(string), typeof(string) }), p, cstTo);
                Expression cstZero = Expression.Constant(0, typeof(int));
                //c.<propertyName>>=from
                var c1 = Expression.GreaterThanOrEqual(methodExpFrom, cstZero);
                //c.<propertyName><=to
                var c2 = Expression.LessThanOrEqual(methodExpTo, cstZero);
                //between = c1 and c2
                var c = Expression.AndAlso(c1, c2);
    
                lambda = Expression.Lambda<Func<T, bool>>(c, param);
            }
            else
            {
                //c.<propertyName>>=from
                var c1 = Expression.GreaterThanOrEqual(p, cstFrom);
                //c.<propertyName><=to
                var c2 = Expression.LessThanOrEqual(p, cstTo);
                //between = c1 and c2
                var c = Expression.AndAlso(c1, c2);
    
                lambda = Expression.Lambda<Func<T, bool>>(c, param);
            }
            return lambda;
        }
    
        /// <summary>
        /// 动态建立LessThanOrEqual表达式
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为to。</param>
        private static Expression<Func<T, bool>> BuildLessThanOrEqualExpression(ParameterExpression param, string propertyName, object[] values)
        {
            if (values == null || values.Length != 1)
            {
                throw new Exception("LessThanOrEqual操作必须指定1个参数。");
            }
    
            object to = values[0];
    
            //c.<propertyName>
            Expression p = OrderBuilder.GetPropertyByName<T>(propertyName, param);
            //to
            Expression cstTo = Expression.Constant(to);
            if (cstTo.Type.Equals(p.Type) == false)
            {
                cstTo = ConstantExpression.Convert(cstTo, p.Type);
            }
    
            Expression<Func<T, bool>> lambda;
            if (p.Type == typeof(string))
            {
                MethodCallExpression methodExpFrom = Expression.Call(null, typeof(string).GetMethod("Compare",
                   new Type[] { typeof(string), typeof(string) }), p, cstTo);
                Expression cstZero = Expression.Constant(0, typeof(int));
                //c.<propertyName><=to
                var c = Expression.LessThanOrEqual(methodExpFrom, cstZero);
    
                lambda = Expression.Lambda<Func<T, bool>>(c, param);
            }
            else
            {
                //c.<propertyName><=to
                var c = Expression.LessThanOrEqual(p, cstTo);
    
                lambda = Expression.Lambda<Func<T, bool>>(c, param);
            }
            return lambda;
        }
    
        /// <summary>
        /// 动态建立GreaterThanOrEqual表达式
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项作为from。</param>
        private static Expression<Func<T, bool>> BuildGreaterThanOrEqualExpression(ParameterExpression param, string propertyName, object[] values)
        {
            if (values == null || values.Length != 1)
            {
                throw new Exception("GreaterThanOrEqual操作必须指定1个参数。");
            }
    
            object from = values[0];
    
            //c.<propertyName>
            Expression p = OrderBuilder.GetPropertyByName<T>(propertyName, param);
            //from
            Expression cstFrom = Expression.Constant(from);
            if (cstFrom.Type.Equals(p.Type) == false)
            {
                cstFrom = ConstantExpression.Convert(cstFrom, p.Type);
            }
    
            Expression<Func<T, bool>> lambda;
            if (p.Type == typeof(string))
            {
                MethodCallExpression methodExpFrom = Expression.Call(null, typeof(string).GetMethod("Compare",
                   new Type[] { typeof(string), typeof(string) }), p, cstFrom);
                Expression cstZero = Expression.Constant(0, typeof(int));
                //c.<propertyName>>=from
                var c = Expression.GreaterThanOrEqual(methodExpFrom, cstZero);
    
                lambda = Expression.Lambda<Func<T, bool>>(c, param);
            }
            else
            {
                //c.<propertyName>>=from
                var c = Expression.GreaterThanOrEqual(p, cstFrom);
    
                lambda = Expression.Lambda<Func<T, bool>>(c, param);
            }
            return lambda;
        }
    
        /// <summary>
        /// 动态建立Equal表达式
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，只取第1项。</param>
        /// <param name="isNotEq">是否是不相等。</param>
        private static Expression<Func<T, bool>> BuildEqualExpression(ParameterExpression param, string propertyName, object[] values)
        {
            if (values == null || values.Length != 1)
            {
                throw new Exception("Equal操作必须指定1个参数。");
            }
    
            object value = values[0];
    
            //c.<propertyName>
            Expression p = OrderBuilder.GetPropertyByName<T>(propertyName, param);
            //value
            Expression cst = Expression.Constant(value);
            if (cst.Type.Equals(p.Type) == false)
            {
                cst = ConstantExpression.Convert(cst, p.Type);
            }
            //c.<propertyName> = value
            var c = Expression.Equal(p, cst);
            var lambda = Expression.Lambda<Func<T, bool>>(c, param);
            return lambda;
        }
    
        /// <summary>
        /// 动态建立Like表达式
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="values">查询值，必须为string，且只取第1项。</param>
        private Expression<Func<T, bool>> BuildLikeExpression(ParameterExpression param, string propertyName, object[] values)
        {
            if (values == null || values.Length != 1)
            {
                throw new Exception("Like操作必须指定1个参数。");
            }
    
            string value = values[0].ToString();
    
            //空值表示没有限制，可以忽略。
            if (value != null)
            {
                //c.<propertyName>
                Expression p = OrderBuilder.GetPropertyByName<T>(propertyName, param);
                //value
                Expression cst = Expression.Constant(value);
                //c.<propertyName> like %value%
                MethodCallExpression methodExp = Expression.Call(p, typeof(string).GetMethod("Contains",
                     new Type[] { typeof(string) }), cst);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, param);
    
                return lambda;
            }
            else
            {
                return null;
            }
        }
    
        /// <summary>
        /// 动态建立In表达式
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">查询值</param>
        private static Expression<Func<T, bool>> BuildInExpression(ParameterExpression param, string propertyName, object[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new Exception("In操作至少指定1个参数。");
            }
    
            //c.<propertyName>
            Expression p = OrderBuilder.GetPropertyByName<T>(propertyName, param);
            //value
            Array typedValues = Array.CreateInstance(p.Type, values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                typedValues.SetValue(values[i], i);
            }
            Expression cst = Expression.Constant(typedValues);
    
            var containExp = Expression.Call(typeof(Enumerable), "Contains", new Type[] { p.Type }, cst, p);
            var lambda = Expression.Lambda<Func<T, bool>>(containExp, param);
            return lambda;
        }
    
        #endregion
    }
}
