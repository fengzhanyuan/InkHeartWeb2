using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        #region 查询
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="whereLambda">Linq查询语句</param>
        /// <returns></returns>
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
        #endregion

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="total">总页数</param>
        /// <param name="wherelambda">Linq查询语句</param>
        /// <param name="orderByLambda">排序依据</param>
        /// <param name="isAsc">升序降序</param>
        /// <returns></returns>
        IQueryable<T> GetPageEntities<s>(int pageSize, int pageIndex, out int total,Expression<Func<T, bool>> wherelambda, Expression<Func<T, s>> orderByLambda,bool isAsc);

        #region 插入增加
        T Add(T entity);
        #endregion

        #region 修改
        bool Update(T entity);
        #endregion

        #region 删除
        bool Delete(T entity);
        #endregion

    }
}
