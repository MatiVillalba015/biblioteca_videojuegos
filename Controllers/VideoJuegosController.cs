using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using BibliotecaVideojuegos.DTOs;
using BibliotecaVideojuegos.Models;
using BibliotecaVideojuegos.Services;
using FluentValidation;


namespace BibliotecaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VideoJuegosController : ControllerBase
    {
        private IValidator<VideoJuegoInsertDto> _juegoInsertValidator;
        private IValidator<VideoJuegoUpdateDto> _juegoUpdateValidator;
        private IVideoJuegoService _videojuegoService;

        //CONSTRUCTOR
        public VideoJuegosController(
            IValidator<VideoJuegoInsertDto> juegoInsertValidator,
            IValidator<VideoJuegoUpdateDto> juegoUpdateValidator, 
            IVideoJuegoService videojuegoService)
        {
            _juegoInsertValidator = juegoInsertValidator;
            _juegoUpdateValidator = juegoUpdateValidator;
            _videojuegoService = videojuegoService;
        }

        //ENDPOINTS


        //obtener todos los videojuegos por un get masivo
        [HttpGet]
        public async Task<IEnumerable<VideoJuegoReadDto>> Get() =>
            await _videojuegoService.GetAllVideoJuegos();

        //obtener videojuego por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VideoJuegoReadDto>> GetVideoJuegoPorId(int id)
        {
            var juegoDto = await _videojuegoService.GetVideoJuegoPorId(id);

            return juegoDto == null ? NotFound() : Ok(juegoDto);
        }

        //obtener videojuego por Nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<VideoJuegoReadDto>> GetVideoJuegoPorNombre(string nombre)
        {
            var juegoDto = await _videojuegoService.GetVideoJuegoPorNombre(nombre);
            return juegoDto == null ? NotFound(nombre) : Ok(juegoDto);
        }

        //obtener videojuego por Saga
        [HttpGet("saga/{saga}")]
        public async Task<ActionResult<VideoJuegoReadDto>> GetVideoJuegoPorSaga(string saga)
        {
            var juegoDto = await _videojuegoService.GetVideoJuegoPorSaga(saga);
            return juegoDto == null ? NotFound(saga) : Ok(juegoDto);
        }

        //editar lista de videojuegos
        [HttpPut("{id}")]
        public async Task<ActionResult<VideoJuegoUpdateDto>> UpdateVideoJuego(int id, VideoJuegoUpdateDto videoJuegoUpdateDto)
        {
            var validacion = await _juegoUpdateValidator.ValidateAsync(videoJuegoUpdateDto);
            if (!validacion.IsValid)
            {
                return BadRequest(validacion.Errors);
            }

            var juegoDto = await _videojuegoService.UpdateVideoJuego(id, videoJuegoUpdateDto);

            return juegoDto == null ? NotFound() : Ok(juegoDto);
        }

        //Crear videojuego en la BD
        [HttpPost]
        public async Task<ActionResult<VideoJuegoInsertDto>> AgregarVideojuego(VideoJuegoInsertDto videoJuegoInsertDto)
        {
            var validacion = await _juegoInsertValidator.ValidateAsync(videoJuegoInsertDto);
            if (!validacion.IsValid)
            {
                return BadRequest(validacion.Errors);
            }
            var juegoDto = await _videojuegoService.AgregarVideojuego(videoJuegoInsertDto);

            return null;
        }

        //Eliminar videojuego de la BD
        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoJuegoDto>> DeleteVideojuego(int id)
        {
            var juegoDto = await _videojuegoService.DeleteVideoJuego(id);

            return juegoDto == null ? NotFound() : Ok(juegoDto);
        }




        //----------------------------------------------------------------------------------
        //testeando si se conecta el endpoint con Postman

        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return Ok("Esta basura funciona");
        }
    }
}
