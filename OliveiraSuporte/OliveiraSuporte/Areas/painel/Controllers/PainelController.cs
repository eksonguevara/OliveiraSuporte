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
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            return View();
        }
        public ActionResult Sair()
        {
            //vai verificar se o cliente esta logado.
            Session["logado"] = null;
            Session["usuario"] = null;
            Session["UsuarioId"] = null;
            return RedirectToAction("Index", "Painel");
        }


    }
}
