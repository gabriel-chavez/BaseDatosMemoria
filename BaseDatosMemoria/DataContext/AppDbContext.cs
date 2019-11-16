using BaseDatosMemoria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseDatosMemoria.DataContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Album> Albumes { get; set; }
        public DbSet<Artista> Artistas { get; set; }
    }
}
