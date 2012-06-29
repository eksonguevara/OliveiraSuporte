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
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //irá listar as fontes existentes.
            var listaDeFontes = _db.Fontes.ToList();
            return View(listaDeFontes);
        }

        public ActionResult Cadastrar()
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Fonte fonte)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //vai fazer uma validação, se passar irá add a fonte, salvar no banco e redirecionar para a Index cadastrar.
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
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //ao clicar no editar caso seja existente no banco irá poder edita-la.
            var fonte = _db.Fontes.Find(id);
            return View(fonte);
        }

        [HttpPost]
        public ActionResult Editar(Fonte fonte)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //vai verificar se é valido, se for vai ir para a area de edição, e após edita-la sera salva no banco.
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
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //vai verificar os detalhes da fonte
            Fonte fonte = _db.Fontes.FirstOrDefault(x => x.FonteId == id);
            return View(fonte);
        }

        public ActionResult Excluir(int id)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //verificar se realmente é a fonte correta no banco para excluir
            var fonte = _db.Fontes.Find(id);
            return View(fonte);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //vai verificar se realmente é a fonte correta a ser deletada pelo Id, se for removera e salvara no banco.
            var fonte = _db.Fontes.Find(id);
            _db.Fontes.Remove(fonte);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
