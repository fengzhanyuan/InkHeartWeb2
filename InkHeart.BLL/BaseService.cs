using InkHeart.DALFactory;
using InkHeart.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public BaseService()//积累的构造函数
        {
            SetCurrentDal();//抽象方法
        }
        public abstract void SetCurrentDal();//抽象方法，要求子类必须实现
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }

        #region 增删改查
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda">拉姆达表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="total">全部页数</param>
        /// <param name="wherelambda">拉姆达表达式</param>
        /// <param name="orderByLambda">排序</param>
        /// <param name="isAsc">升序降序</param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<s>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> wherelambda,
            Expression<Func<T, s>> orderByLambda,
            bool isAsc
            )
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, wherelambda, orderByLambda, isAsc);
        }

        #endregion



    }
}
