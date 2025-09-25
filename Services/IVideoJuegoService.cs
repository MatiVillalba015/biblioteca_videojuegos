using BibliotecaVideojuegos.DTOs;
using BibliotecaVideojuegos.Models; //llamando a la carpeta Models
namespace BibliotecaVideojuegos.Services
{
    public interface IVideoJuegoService
    {
        Task<VideoJuegoInsertDto> AgregarVideojuego(VideoJuegoInsertDto videojuegoInsertDto);
        Task<IEnumerable<VideoJuegoReadDto>> GetAllVideoJuegos(); //llamar a todos los videojuegos mediante lista no editable
        Task<VideoJuegoReadDto?> GetVideoJuegoPorId(int id); //el ? es por si no existe esa id
        Task<VideoJuegoReadDto> GetVideoJuegoPorNombre(string nombre); //obtener videojuego por string nombre
        Task<IEnumerable<VideoJuegoReadDto>> GetVideoJuegoPorSaga(string saga);      //obtener lista de videojuegos por nombre de saga
        Task<VideoJuegoUpdateDto> UpdateVideoJuego(int id, VideoJuegoUpdateDto videoJuegoUpdateDto); //editar el objeto videojuego
        Task<bool> DeleteVideoJuego(int id); //true elimina, false no el juego que se llame por id
    }
}
