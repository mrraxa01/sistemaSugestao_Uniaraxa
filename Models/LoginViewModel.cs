using System.ComponentModel.DataAnnotations;


namespace sistemasugestao.Models
{
    public class LoginViewModel
    {
         
        [Required(ErrorMessage = "O E-mail é origatório!", AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória!", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Manter logado!")]
        public bool flManterLogado { get; set; }
    
    }
}