using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Areas.painel.Models;
using OliveiraSuporte.Util;
using System.Data.Entity;

namespace OliveiraSuporte.Areas.painel.Controllers
{
    public class FonteController : Controller
    {
        private readonly DbComun _db = new DbComun();

        public ActionResult Index()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            var listaDeFontes = _db.Fontes.ToList();
            return View(listaDeFontes);
        }

        public ActionResult Cadastrar()
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Fonte fonte)
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            if (ModelState.IsValid)
            {
                _db.Fontes.Add(fonte);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonte);
        }

        public ActionResult Editar(int id)
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            var fonte = _db.Fontes.Find(id);
            return View(fonte);
        }

        [HttpPost]
        public ActionResult Editar(Fonte fonte)
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            if (ModelState.IsValid)
            {
                _db.Entry(fonte).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonte);
        }

        public ActionResult Detalhes(int id)
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            Fonte fonte = _db.Fontes.FirstOrDefault(x => x.FonteId == id);
            return View(fonte);
        }

        public ActionResult Excluir(int id)
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            var fonte = _db.Fontes.Find(id);
            return View(fonte);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            var fonte = _db.Fontes.Find(id);
            _db.Fontes.Remove(fonte);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
