﻿using BaseDatosMemoria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseDatosMemoria.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                //agregamos artistas
                if (_context.Artistas.Any())
                {
                    return;
                }
                    
                _context.Artistas.AddRange(
                    new Artista { Nombre = "Luis Miguel" },
                    new Artista { Nombre = "Ricardo Arjona" },
                    new Artista { Nombre = "Kalimba" }
                );
                _context.SaveChanges();
                //agregamos album
                if (_context.Albumes.Any()) {
                    return;
                }
                 
                _context.Albumes.AddRange(
                    new Album
                    {
                        ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Kalimba")).ArtistaID,
                        Titulo = "Mi otro Yo",
                        Precio = 200

                    },
                    new Album
                    {
                        ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Kalimba")).ArtistaID,
                        Titulo = "AeroSoul",
                        Precio = 275
                    },
                    new Album
                    {
                        ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Ricardo Arjona")).ArtistaID,
                        Titulo = "Circo Soledad",
                        Precio = 180
                    },
                    new Album
                    {
                        ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Luis Miguel")).ArtistaID,
                        Titulo = "Romance",
                        Precio = 290
                    }
                );
                _context.SaveChanges();
            }
        }
    }
}
