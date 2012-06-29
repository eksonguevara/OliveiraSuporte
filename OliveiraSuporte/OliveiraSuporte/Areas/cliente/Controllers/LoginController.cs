using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Areas.cliente.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /cliente/Login/
        private readonly DbComun _db = new DbComun();

        public ActionResult Index()
        {
            return View();
        }
        // Aqui e uma ação direcionada a view Index do controler Login, que vai fazer uma validação para que os campos não sejam vazios ou usuario e senha estejam errados.

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            if (login == "" || senha == "")
            {
                ModelState.AddModelError("login", "Os campos não podem estar vazios");
                return View();
            }
            var cliente = _db.Clientes.FirstOrDefault(x => x.Login == login && x.Senha == senha);
            if (cliente == null)
            {
                ModelState.AddModelError("login", "O usuário ou a senha não são validos");
                return View();
            }
            //vai verificar se o cliente esta logado.
            Session["logadocliente"] = true;
            Session["cliente"] = cliente.Nome;
            Session["ClienteId"] = cliente.ClienteId;

            return RedirectToAction("Index", "Painel");
        }

    }
}
