using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistemasugestao.Models
{
    public class Sugestao
    {
        public int SugestaoID { get; set; }
        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Preencha a descrição", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O tamanho minimo é de 10 e o máximo 150")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite o custo estimado", AllowEmptyStrings = false)]
        public double CustoEstimado { get; set; }
        public int CampanhaID { get; set; }
        public Campanha Campanha { get; set; }
        public int AvaliadorID { get; set; }
        public Avaliador Avaliador { get; set; }
    }
}