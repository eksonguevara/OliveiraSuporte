using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OliveiraSuporte.Areas.painel.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /painel/Painel/
        public ActionResult Index()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            return View();
        }

    }
}
