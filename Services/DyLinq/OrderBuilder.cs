
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
    /// Linq排序构造器。
    /// </summary>
    public static class OrderBuilder
    {
        private static IQueryable<T> OrderBy<T>(IQueryable<T> source, string propertyStr) where T : class
        {
            //c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            //c.<propertyStr>
            Expression property = GetPropertyByName<T>(propertyStr, param);
            //c=>c.<propertyStr>
            LambdaExpression le = Expression.Lambda(property, param);
            //OrderBy
            Type type = typeof(T);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                "OrderBy", new Type[] { type, property.Type }, source.Expression, Expression.Quote(le));
    
            return source.Provider.CreateQuery<T>(resultExp);
        }
    
        private static IQueryable<T> OrderByDescending<T>(IQueryable<T> source, string propertyStr) where T : class
        {
            //c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            //c.<propertyStr>
            Expression property = GetPropertyByName<T>(propertyStr, param);
            //c=>c.<propertyStr>
            LambdaExpression le = Expression.Lambda(property, param);
            //OrderBy
            Type type = typeof(T);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                "OrderByDescending", new Type[] { type, property.Type }, source.Expression, Expression.Quote(le));
    
            return source.Provider.CreateQuery<T>(resultExp);
        }

        private static IQueryable<T> ThenBy<T>(IQueryable<T> source, string propertyStr) where T : class
        {
            //c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            //c.<propertyStr>
            Expression property = GetPropertyByName<T>(propertyStr, param);
            //c=>c.<propertyStr>
            LambdaExpression le = Expression.Lambda(property, param);
            //OrderBy
            Type type = typeof(T);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                "ThenBy", new Type[] { type, property.Type }, source.Expression, Expression.Quote(le));

            return source.Provider.CreateQuery<T>(resultExp);
        }

        private static IQueryable<T> ThenByDescending<T>(IQueryable<T> source, string propertyStr) where T : class
        {
            //c
            ParameterExpression param = Expression.Parameter(typeof(T), "c");
            //c.<propertyStr>
            Expression property = GetPropertyByName<T>(propertyStr, param);
            //c=>c.<propertyStr>
            LambdaExpression le = Expression.Lambda(property, param);
            //OrderBy
            Type type = typeof(T);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                "ThenByDescending", new Type[] { type, property.Type }, source.Expression, Expression.Quote(le));

            return source.Provider.CreateQuery<T>(resultExp);
        }    
    
        /// <summary>
        /// 动态建立查询。
        /// </summary>
        /// <param name="conditions">查询项清单。</param>
        public static IQueryable<T> AddOrders<T>(this IQueryable<T> source, params OrderItem[] orders) where T : class
        {
            IQueryable<T> src = source;

            if (orders != null)
            {
                for (int i = 0; i < orders.Length; i++)
                {
                    OrderItem order = orders[0];
                    if (order.OrderType == OrderType.otDescending)
                    {
                        if (i == 0)
                        {
                            src = OrderByDescending<T>(src, order.PropertyName);
                        }
                        else
                        {
                            src = ThenByDescending<T>(src, order.PropertyName);
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            src = OrderBy<T>(src, order.PropertyName);
                        }
                        else
                        {
                            src = ThenBy<T>(src, order.PropertyName);
                        }
                    }
                }
            }
    
            return src;
        }
    
        /// <summary>
        /// 根据属性名，获取给定参数的属性表达式。
        /// </summary>
        /// <param name="propertyName">属性名（支持多级）。</param>
        /// <param name="param">参数。</param>
        /// <returns>形为param.PropertyName的表达式。</returns>
        public static Expression GetPropertyByName<T>(string propertyName, ParameterExpression param)
        {
            string[] propertyNames = propertyName.Split('.');
            PropertyInfo pi = typeof(T).GetProperty(propertyNames[0]);
            Expression exp = Expression.Property(param, pi);
    
            for (int i = 1; i < propertyNames.Length; i++)
            {
                pi = pi.PropertyType.GetProperty(propertyNames[i]);
                exp = Expression.Property(exp, pi);
            }
    
            return exp;
        }
    }
}
