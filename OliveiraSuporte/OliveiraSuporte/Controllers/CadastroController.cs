using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Models;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Controllers
{
    public class CadastroController : Controller
    {
       private readonly DbComun _db = new DbComun(); 

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Cliente cliente, string confirmarSenha)
        {
            if(confirmarSenha != cliente.Senha)
            {
                ModelState.AddModelError("ConfirmarSenha","As senhas não conferem");
                return View(cliente);
            }

            if(ModelState.IsValid)
            {
                _db.Clientes.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction("Parabens");
            }
            return View();
        }
        public ActionResult Parabens()
        {
            return View();
        }
    }
}
