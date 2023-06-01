using System.ComponentModel.DataAnnotations;

namespace Skoki.Models
{
    public class Wynik
    {
        [Key]
        public int Id { get; set; }

        public Konkurs Konkurs = default!;
        public Zawodnik Zawodnik = default!;

        [Display(Name = "Miejsce")]
        public int Miejsce { get; set; }

        [Display(Name = "Seria 1")]
        public decimal Seria1 { get; set; }

        [Display(Name = "Seria 2")]
        public decimal Seria2 { get; set; }

        [Display(Name = "Nota")]
        public decimal Nota { get; set; }

        [Display(Name = "Punkty")]
        public int PunktySezonowe { get; set; }
    }
}
