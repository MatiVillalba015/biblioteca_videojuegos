using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaVideojuegos.Models
{
    public class VideoJuego
    {

        public enum EstadoVideojuego{
            Jugando,
            Completado,
            Dropeado
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }      //Final Fantasy IX, Skyrim, Hotline Miami, Castelvania III, etc
        public string Genero { get; set; }      //JRPG, RPG, Sandbox, etc
        public string? Saga { get; set; }       //Final Fantasy, GTA, The Elder Scrolls, etc
        public DateTime FechaLanzamiento { get; set; }       //2001, 2013, etc  //nuevo cambio (28/09/2025) de int a datetime
        public string CompaniaDesarrolladora { get; set; }   //SquareEnix, Rockstar, etc
        public EstadoVideojuego Estado { get; set; }  //completado/jugando/dropeado
        public int? Puntuacion { get; set; } //del 0 a 100
    }
}
