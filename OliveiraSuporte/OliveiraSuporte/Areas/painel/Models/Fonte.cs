using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OliveiraSuporte.Areas.painel.Models
{
    public class Fonte
    {
        //criando as propriedades
        public int FonteId { get; set; }

        [Required(ErrorMessage = "Preencha este campo.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter de 2 a 50 caracteres")]
        public string Nome { get; set; }

        public string Fontes { get; set; }
        //fazendo um relacionamento de 1 para muitos
        public virtual ICollection<Noticia> Noticias { get; set; }
    }
}