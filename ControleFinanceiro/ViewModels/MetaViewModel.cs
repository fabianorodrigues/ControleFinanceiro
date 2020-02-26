using ControleFinanceiro.Dominio.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.ViewModels
{
    public class MetaViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Destino:")]
        public string Destino { get; set; }

        [Required]
        [Display(Name = "%:")]
        public float Porcentagem { get; set; }

        [Display(Name = "Tipo:")]
        public ETipoMeta TipoMeta { get; set; }
    }
}