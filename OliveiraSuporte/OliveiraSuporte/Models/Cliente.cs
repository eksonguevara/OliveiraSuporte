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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 e 50 caracteres")]
        [Display(Name = "Nome *")]
        public string Nome { get; set; }
        
        [Display(Name = "Nome Da Empresa")]
        public string NomeEmpresa { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(("^[a-z0-9_\\+-]+(\\.[a-z0-9\\+-]+)*@[a-z0-9]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$"), ErrorMessage = "Email Inválido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O preenchimento deste campo é obrigatorio")]
        [StringLength(12,MinimumLength = 8, ErrorMessage = "O número deve conter no mínimo 8 digitos")]
        [RegularExpression(@"^([0-9]+)?$",ErrorMessage = "O campo deve possuir somente números")]
        [Display(Name = "Telefone *")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 e 20 caracteres")]
        [Display(Name = "Login *")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "A senha deve conter no mínimo 7 e máximo 20 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha *")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [Display(Name = "Endereço *")]
        public string Endereco { get; set; }
    }
}