using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Modelos;

namespace Veterinaria.API.Data
{
    public class VeterinariaAPIContext : DbContext
    {
        public VeterinariaAPIContext (DbContextOptions<VeterinariaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Veterinaria.Modelos.Citas> Citas { get; set; } = default!;
        public DbSet<Veterinaria.Modelos.Dueños> Dueños { get; set; } = default!;
        public DbSet<Veterinaria.Modelos.Especies> Especies { get; set; } = default!;
        public DbSet<Veterinaria.Modelos.Horarios> Horarios { get; set; } = default!;
        public DbSet<Veterinaria.Modelos.Mascotas> Mascotas { get; set; } = default!;
        public DbSet<Veterinaria.Modelos.PersonalAdministrativos> PersonalAdministrativos { get; set; } = default!;
        public DbSet<Veterinaria.Modelos.TipoCitas> TipoCitas { get; set; } = default!;
    }
}
