using System.ComponentModel.DataAnnotations;

namespace Skoki.Models
{
    public class Zawodnik
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Imię")]
        public string Imie { get; set; } = default!;
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; } = default!;
        [Display(Name = "Kraj pochodzenia")]
        public string Kraj { get; set; } = default!;
    }
}
