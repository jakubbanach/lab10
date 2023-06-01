using System.ComponentModel.DataAnnotations;

namespace Skoki.Models
{
    public class Konkurs
    {
        [Key]
        public int Id { get; set; }
        public Skocznia Skocznia { get; set; } = default!;
        public string Rodzaj { get; set; } = default!;
        public string Pora { get; set; } = default!;
        public DateTime Data { get; set; }
    }
}
