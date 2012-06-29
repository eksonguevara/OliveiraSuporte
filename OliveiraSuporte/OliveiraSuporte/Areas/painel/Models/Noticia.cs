using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OliveiraSuporte.Areas.painel.Models
{
    public class Noticia
    {
        //criando as propriedades.
        public int NoticiaId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public Fonte Fonte { get; set; }
    }
}