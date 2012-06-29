using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Controllers
{
    public class NoticiasController : Controller
    {
        //
        // GET: /Noticias/
        private readonly  DbComun _db = new DbComun();

        public ActionResult Index(int Id = 0)
        {
            ViewBag.noticias = _db.Noticias.ToList().Take(4);

            if (Id == 0)
            {
                return View(_db.Noticias.ToList().Last());
            }
            //se nao for zero
            return View(_db.Noticias.Find(Id));
        }

    }
}
