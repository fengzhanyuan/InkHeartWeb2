using InkHeart.BLL;
using InkHeart.IBLL;
using InkHeart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkHeart.BLL
{
    public class BookService : BaseService<Book>,IBookService
    {
        public override void SetCurrentDal()
        {
            CurrentDal=this.DbSession.BookDal;
        }
    }
}
