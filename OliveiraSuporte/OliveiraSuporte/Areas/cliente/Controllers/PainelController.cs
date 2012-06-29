using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OliveiraSuporte.Areas.cliente.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /cliente/Painel/
        //Este e um action Index redirecionando pra view Index do Painel, irá fazer validação

        //P.S verificar o RedirectToAction.
        public ActionResult Index()
        {
            if (Session["logadocliente"] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }

        public ActionResult Sair()
        {
            //vai verificar se o cliente esta logado.
            Session["logadocliente"] = null;
            Session["cliente"] = null;
            Session["ClienteId"] = null;
            return RedirectToAction("Index", "Login");
        }

    }
}
