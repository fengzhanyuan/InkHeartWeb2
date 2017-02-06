using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.EFDAL
{
    public class BaseDal<T> where T : class, new()
    {
        //获取上下文
        public DbContext Db
        {
            get { return DbContextFactory.GetCurrentDbContext(); }
        }

        #region 查询
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="total">总共的条数</param>
        /// <param name="wherelambda">查询条件</param>
        /// <param name="orderByLambda">分页依据</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<s>(int pageSize, int pageIndex, out int total,
    Expression<Func<T, bool>> wherelambda,
    Expression<Func<T, s>> orderByLambda,
    bool isAsc
    )
        {
            total = Db.Set<T>().Where(wherelambda).Count();
            if (isAsc)//升序
            {
                var temp = Db.Set<T>().Where(wherelambda)
                   .OrderBy<T, s>(orderByLambda)
                   .Skip(pageSize * (pageIndex - 1))
                   .Take(pageSize).AsQueryable();
                return temp;
            }
            else//降序
            {
                var temp = Db.Set<T>().Where(wherelambda)
             .OrderByDescending<T, s>(orderByLambda)
             .Skip(pageSize * (pageIndex - 1))
             .Take(pageSize).AsQueryable();
                return temp;
            }
        }

        #endregion

        #region 增加
        /// <summary>
        /// 插入增加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
            return entity;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return Db.SaveChanges() > 0;
            //return true;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return Db.SaveChanges() > 0;
            //return true;
        }
        #endregion

    }
}
