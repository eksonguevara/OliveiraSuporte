using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OliveiraSuporte.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 50 caracteres")]
        public string Nome { get; set; }
        
        [Display(Name = "Nome Da Empresa")]
        public string NomeEmpresa { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O preenchimento deste campo é obrigatorio")]
        [RegularExpression(@"^([0-9]+)?$",ErrorMessage = "O campo deve possuir somente números")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 20 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "A senha deve conter no mínimo 7 e máximo 20 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string Endereco { get; set; }
    }
}