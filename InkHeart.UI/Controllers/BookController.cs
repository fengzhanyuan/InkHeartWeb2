using InkHeart.BLL;
using InkHeart.IBLL;
using InkHeart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InkHeart.UI.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        //IBookService bookService = new BookService();
        public IBookService bookService { get; set; }//autofac属性注入
        public ActionResult Index()
        {
            ViewData.Model = bookService.GetEntities(u=>true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.Add(book);
            }
            return RedirectToAction("Index");
        }

    }
}