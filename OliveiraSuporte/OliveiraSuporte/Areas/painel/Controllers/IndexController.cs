﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Areas.painel.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /painel/Index/
        private readonly DbComun _db = new DbComun();
        //Esta é uma ação do Index redirecionando para a view Index-Index.
        public ActionResult Index()
        {
            return View();
        }
        //validação se usuario e senha estao preenchidos, e se estão corretos.
        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            if (login == "" || senha == "")
            {
                ModelState.AddModelError("login", "Os campos não podem estar vazios");
                return View();
            }
            var usuario = _db.Clientes.FirstOrDefault(x => x.Login == login && x.Senha == senha);
            if (usuario == null)
            {
                ModelState.AddModelError("login", "O usuário ou a senha não são validos");
                return View();
            }

            Session["logado"] = true;
            Session["usuario"] = usuario.Nome;

            return RedirectToAction("Index", "Painel");
        }
    }
}
