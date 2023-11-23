using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemasugestao.Models
{
    public class Avaliador
    {
        public int AvaliadorID { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha o nome", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho minimo é de 3 e o máximo 50")]
        public string name { get; set; }
        
    }
}