using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 分页查询
        /// 
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="total">总页数</param>
        /// <param name="wherelambda">查询条件</param>
        /// <param name="orderByLambda">排序</param>
        /// <param name="isAsc">升序</param>
        /// <returns></returns>
        IQueryable<T> GetPageEntities<s>(int pageSize, int pageIndex, out int total,
               Expression<Func<T, bool>> wherelambda,
               Expression<Func<T, s>> orderByLambda,
               bool isAsc
               );


    }
}
