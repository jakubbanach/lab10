using System.ComponentModel.DataAnnotations;

namespace Skoki.Models
{
    public class Konkurs
    {
        [Key]
        public int Id { get; set; }

        public string Nazwa { get; set; } = default!;
        public Skocznia Skocznia { get; set; } = default!;
        public string Rodzaj { get; set; } = default!;
        public string Pora { get; set; } = default!;
        public DateTime Data { get; set; }
    }
}
