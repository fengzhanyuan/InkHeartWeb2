using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.IDAL
{
  public interface IDbSession
    {
        IUserDal UserDal { get; }
        IBookDal BookDal { get; }
        int SaveChanges();

    }
}
