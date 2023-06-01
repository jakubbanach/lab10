using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skoki.Models;

namespace MvcPracownik.Data
{
    public class MvcPracownikContext : DbContext
    {
        public MvcPracownikContext (DbContextOptions<MvcPracownikContext> options)
            : base(options)
        {
        }

        public DbSet<Skoki.Models.Konkurs> Konkurs { get; set; } = default!;

        public DbSet<Skoki.Models.Zawodnik> Zawodnik { get; set; } = default!;

        public DbSet<Skoki.Models.Wynik> Wynik { get; set; } = default!;

        public DbSet<Skoki.Models.Skocznia> Skocznia { get; set; } = default!;
    }
}
