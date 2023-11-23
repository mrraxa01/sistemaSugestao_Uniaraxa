using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemasugestao.Models
{
    public class Campanha
    {
        public int CampanhaID { get; private set; }
        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Preencha o titulo da campanha", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O tamanho minimo é de 10 e o máximo 150")]
        public string Titulo { get; set; }

    }
}