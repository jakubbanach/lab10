using System.ComponentModel.DataAnnotations;

namespace Skoki.Models
{
    public class Skocznia
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nazwa skoczni")]
        public string Nazwa { get; set; } = default!;
        [Display(Name = "Kraj")]
        public string Kraj { get; set; } = default!;
        [Display(Name = "Miejscowosc")]
        public string Miejscowosc { get; set; } = default!;
        [Display(Name = "Punkt K")]
        public decimal K;

        [Display(Name = "HS")]
        public decimal HS;

        [Display(Name = "Rekord")]
        public decimal rekord;
    }
}
