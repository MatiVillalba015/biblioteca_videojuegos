using BibliotecaVideojuegos.Models;
using static BibliotecaVideojuegos.Models.VideoJuego;
namespace BibliotecaVideojuegos.DTOs
{
    public class VideoJuegoInsertDto
    {
        public string Nombre { get; set; }      //Final Fantasy IX, Skyrim, Hotline Miami, Castelvania III, etc
        public string Genero { get; set; }      //JRPG, RPG, Sandbox, etc
        public string? Saga { get; set; }       //Final Fantasy, GTA, The Elder Scrolls, etc
        public int FechaLanzamiento { get; set; }       //2001, 2013, etc
        public string CompaniaDesarrolladora { get; set; }   //SquareEnix, Rockstar, etc
        public EstadoVideojuego Estado { get; set; }  //completado/jugando/dropeado
        public int? Puntuacion { get; set; } //del 0 a 100
    }
}
