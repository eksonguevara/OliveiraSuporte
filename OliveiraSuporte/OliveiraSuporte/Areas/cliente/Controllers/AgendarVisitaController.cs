using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using OliveiraSuporte.Areas.painel.Models;
using OliveiraSuporte.Util;

namespace OliveiraSuporte.Areas.cliente.Controllers
{
    public class AgendarVisitaController : Controller
    {

        private readonly DbComun _db = new DbComun();

        public ActionResult ListaDeVisitas()
        {
            //pegar aqui os dados do cliente logado
            var idDoClienteNaSessao = 0;
            int.TryParse(Session["ClienteId"].ToString(), out idDoClienteNaSessao);

            return View(_db.Agendas.Where(x => x.Cliente.ClienteId == idDoClienteNaSessao));
        }

        public ActionResult Cadastrar()
        {
            var agenda = new Agenda();
            agenda.DateDaVisita = DateTime.Now;
            return View(agenda);
        }

        [HttpPost]
        public ActionResult Cadastrar(Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                var idDoClienteNaSessao = 0;
                int.TryParse(Session["ClienteId"].ToString(), out idDoClienteNaSessao);
                agenda.Cliente = _db.Clientes.Find(idDoClienteNaSessao);
                agenda.Status = "Nova";
                _db.Agendas.Add(agenda);
                _db.SaveChanges();
                return RedirectToAction("ListaDeVisitas");
            }

            return View(agenda);
        }

        public ActionResult Detalhes(int id)
        {
            var agenda = _db.Agendas.FirstOrDefault(x => x.AgendaId == id);
            return View(agenda);
        }

        public ActionResult Delete(int id)
        {
            var agenda = _db.Agendas.Find(id);
            return View(agenda);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
          
            //confirmação da exclusão da noticia
            var agenda = _db.Agendas.Find(id);
            _db.Agendas.Remove(agenda);
            _db.SaveChanges();
            return RedirectToAction("ListaDeVisitas");
        }
    }
}
