using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly DbComun _db = new DbComun();

        public ActionResult Index()
        {

            ViewBag.noticias = _db.Noticias.ToList().Take(4);


            return View();
        }

    }
}
