using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Areas.painel.Models;
using OliveiraSuporte.Util;
using System.Data.Entity;

namespace OliveiraSuporte.Areas.painel.Controllers
{
        public class NoticiaController : Controller
        {
            private readonly DbComun _db = new DbComun();

            public ActionResult Index()
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                return View(_db.Noticias.Include(x => x.Fonte).ToList());
            }

            public ActionResult Details(int id)
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                Noticia noticia = _db.Noticias.Include(x => x.Fonte).FirstOrDefault(x => x.NoticiaId == id);
                return View(noticia);
            }

            
            public ActionResult Create()
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                var listaDeFontes = _db.Fontes.ToList();

                //<select>
                // <option value="1">Texto</option>
                //</select>
                ViewBag.ListaDeFontes = new SelectList(listaDeFontes, "FonteId", "Nome");

                return View();
            }

            [HttpPost]
            public ActionResult Create([Bind(Exclude = "Fonte")]Noticia noticia, int fonteId)
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                if (ModelState.IsValid)
                {
                    noticia.Fonte = _db.Fontes.Find(fonteId);
                    _db.Noticias.Add(noticia);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(noticia);
            }

            public ActionResult Edit(int id)
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                Noticia noticia = _db.Noticias.Include(x => x.Fonte).FirstOrDefault(x => x.NoticiaId == id);
                
                var listaDeFontes = _db.Fontes.ToList();
                ViewBag.ListaDeFontes = new SelectList(listaDeFontes, "FonteId", "Nome", noticia.Fonte.FonteId);

                return View(noticia);
            }

            [HttpPost]
            public ActionResult Edit([Bind(Exclude = "Fonte")]Noticia noticia, int fonteId)
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                if (ModelState.IsValid)
                {
                    var noticiaQueVaiProBanco = _db.Noticias.Find(noticia.NoticiaId);
                    noticiaQueVaiProBanco.Conteudo = noticia.Conteudo;
                    noticiaQueVaiProBanco.Titulo = noticia.Titulo;

                    noticiaQueVaiProBanco.Fonte = _db.Fontes.Find(fonteId);

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(noticia);
            }

            public ActionResult Delete(int id)
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                Noticia noticia = _db.Noticias.Find(id);
                return View(noticia);
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                if (Session["logado"] == null)
                    return RedirectToAction("Index", "Index");

                Noticia noticia = _db.Noticias.Find(id);
                _db.Noticias.Remove(noticia);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                _db.Dispose();
                base.Dispose(disposing);
            }
        }
    
}
