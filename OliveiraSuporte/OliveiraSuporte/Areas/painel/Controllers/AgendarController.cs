using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Areas.painel.Models;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Areas.painel.Controllers
{
    public class AgendarController : Controller
    {
        //
        // GET: /painel/Agendar/
        private readonly DbComun _db = new DbComun();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Editar(int id)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //ao clicar no editar caso seja existente no banco irá poder edita-la.
            var agendamento = _db.Agendas.Find(id);
            return View(agendamento);
        }
        
        [HttpPost]
        public ActionResult Editar(Agenda agendar)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //vai verificar se é valido, se for vai ir para a area de edição, e após edita-la sera salva no banco.
            if (ModelState.IsValid)
            {
                _db.Entry(agendar).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agendar);
        }
        
        public ActionResult Excluir(int id)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //verificar se realmente é a fonte correta no banco para excluir
            var agendamento = _db.Agendas.Find(id);
            return View(agendamento);
        }
        
        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            //validação para impedir o usuario logar diretamente pela URL
            if (Session["logado"] == null)
                return RedirectToAction("Index", "Index");
            //vai verificar se realmente é a fonte correta a ser deletada pelo Id, se for removera e salvara no banco.
            var agendamento = _db.Agendas.Find(id);
            _db.Agendas.Remove(agendamento);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
