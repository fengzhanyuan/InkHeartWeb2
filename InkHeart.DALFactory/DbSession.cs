using InkHeart.EFDAL;
using InkHeart.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.DALFactory
{
    public class DbSession : IDbSession
    {
        public IBookDal BookDal
        {
            get { return StaticDalFactory.GetBookDal(); }
        }

        public IUserDal UserDal
        {
            get { return StaticDalFactory.GetUserDal(); }
        }

        /// <summary>
        /// 拿到当前EF的上下文。然后进行把修改的实体进行一个整体的提交。
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
