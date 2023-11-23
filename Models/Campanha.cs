using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemasugestao.Models
{
    public class Campanha
    {
        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Preencha o nome da campanha", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O tamanho minimo é de 10 e o máximo 150")]
        public string Descricao { get; set; }

        public int SugestaoID {get; set;}
        public Sugestao Sugestao{get;set;}

        public int AvaliadorID { get; set; }
        public Avaliador Avaliador{get; set;}
    }
}