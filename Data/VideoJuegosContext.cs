using Microsoft.EntityFrameworkCore;
using BibliotecaVideojuegos.Models;
using BibliotecaVideojuegos.DTOs;  //conectando la carpeta models a la clase VideoJuegosContext.cs

namespace BibliotecaVideojuegos.Data
{
    public class VideoJuegosContext : DbContext   
    {
        public VideoJuegosContext(DbContextOptions<VideoJuegosContext>options)
            :base(options)
        { }
        public DbSet<VideoJuego> videoJuegos { get; set; }
    }
}
