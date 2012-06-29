using System;
using OliveiraSuporte.Models;

namespace OliveiraSuporte.Areas.painel.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DateDaVisita { get; set; }
        public string Status { get; set; }
        public Cliente Cliente { get; set; }
    }
}