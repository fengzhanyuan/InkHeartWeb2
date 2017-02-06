using InkHeart.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.EFDAL
{
   public  class DbContextFactory
    {
        /// <summary>
        /// 返回基类DbContext可以做到一次请求公用一个实例。
        /// </summary>
        /// <returns></returns>
        public static DbContext GetCurrentDbContext()
        {
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if (db==null)
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext",db);
            }
            return db;
        }
    }
}
