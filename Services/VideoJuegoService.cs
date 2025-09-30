using BibliotecaVideojuegos.Data;
using BibliotecaVideojuegos.DTOs;
using BibliotecaVideojuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaVideojuegos.Services
{
    public class VideoJuegoService : IVideoJuegoService  //llamando a la intefaz para poder implementar los metodos en IVideoJuegoService.cs
    {
        private readonly VideoJuegosContext _context;

        public VideoJuegoService(VideoJuegosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VideoJuegoReadDto>> GetAllVideoJuegos() =>
            await _context.videoJuegos.Select(x => new VideoJuegoReadDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Genero = x.Genero,
                Saga = x.Saga,
                FechaLanzamiento = x.FechaLanzamiento,
                CompaniaDesarrolladora = x.CompaniaDesarrolladora,
                Estado = x.Estado,
                Puntuacion = x.Puntuacion

            }).ToListAsync();

        public async Task<VideoJuegoReadDto> GetVideoJuegoPorId(int id)
        {
            try
            {
                var juego = await _context.videoJuegos.FindAsync(id);
                if (juego != null)
                {
                    var juegoDto = new VideoJuegoReadDto
                    {
                        Id = juego.Id,
                        Nombre = juego.Nombre,
                        Genero = juego.Genero,
                        Saga = juego.Saga,
                        FechaLanzamiento = juego.FechaLanzamiento,
                        CompaniaDesarrolladora = juego.CompaniaDesarrolladora,
                        Estado = juego.Estado,
                        Puntuacion = juego.Puntuacion
                    };
                    return juegoDto;
                }
                ;
                return null;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al obtener el juego por Id", ex);
            }
        }

        public async Task<VideoJuegoReadDto> GetVideoJuegoPorNombre(string nombre)
        {
            var juego = await _context.videoJuegos.FirstOrDefaultAsync(x => x.Nombre == nombre);
            if(nombre != null)
            {
                var juegoDto = new VideoJuegoReadDto
                {
                    Id = juego.Id,
                    Nombre = juego.Nombre,
                    Genero = juego.Genero,
                    Saga = juego.Saga,
                    FechaLanzamiento = juego.FechaLanzamiento,
                    CompaniaDesarrolladora = juego.CompaniaDesarrolladora,
                    Estado = juego.Estado,
                    Puntuacion = juego.Puntuacion
                };
                return juegoDto;
            }
            return null;
        }

        public async Task<IEnumerable<VideoJuegoReadDto>> GetVideoJuegoPorSaga(string saga)
        {
            try
            {
                var juegos = await _context.videoJuegos
                    .Where(x => x.Saga == saga)
                    .Select(x => new VideoJuegoReadDto
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Genero = x.Genero,
                        Saga = x.Saga,
                        FechaLanzamiento = x.FechaLanzamiento,
                        CompaniaDesarrolladora = x.CompaniaDesarrolladora,
                        Estado = x.Estado,
                        Puntuacion = x.Puntuacion
                    }).ToListAsync();

                return juegos;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al obtener el juego por Saga", ex);
            }
        }

        public async Task<VideoJuegoUpdateDto> UpdateVideoJuego(int id, VideoJuegoUpdateDto videoJuegoUpdateDto)
        {
            var juego = await _context.videoJuegos.FindAsync(id);
            if(juego != null)
            {
                juego.Nombre = videoJuegoUpdateDto.Nombre;
                juego.Genero = videoJuegoUpdateDto.Genero;
                juego.Saga = videoJuegoUpdateDto.Saga;
                juego.FechaLanzamiento = videoJuegoUpdateDto.FechaLanzamiento;
                juego.CompaniaDesarrolladora = videoJuegoUpdateDto.CompaniaDesarrolladora;
                juego.Estado = videoJuegoUpdateDto.Estado;
                juego.Puntuacion = videoJuegoUpdateDto?.Puntuacion;

                await _context.SaveChangesAsync();

                var juegoDto = new VideoJuegoUpdateDto
                {
                    Nombre = juego.Nombre,
                    Genero = juego.Genero,
                    Saga = juego.Saga,
                    FechaLanzamiento = juego.FechaLanzamiento,
                    CompaniaDesarrolladora = juego.CompaniaDesarrolladora,
                    Estado = juego.Estado,
                    Puntuacion = juego.Puntuacion
                };
                return juegoDto;
            }

            return null;
        }

        public async Task<VideoJuegoInsertDto> AgregarVideojuego(VideoJuegoInsertDto videoJuegoInsertDto)
        {
            var juego = new VideoJuego()
            {
                Nombre = videoJuegoInsertDto.Nombre,
                Genero = videoJuegoInsertDto.Genero,
                Saga = videoJuegoInsertDto.Saga,
                FechaLanzamiento = videoJuegoInsertDto.FechaLanzamiento,
                CompaniaDesarrolladora = videoJuegoInsertDto.CompaniaDesarrolladora,
                Estado = videoJuegoInsertDto.Estado,
                Puntuacion = videoJuegoInsertDto.Puntuacion
            };
            //INSERSION EN LA BD
            await _context.videoJuegos.AddAsync(juego); //indicando el cambio
            await _context.SaveChangesAsync(); //cambio ya hecho

            var juegoDto = new VideoJuegoInsertDto()
            {
                Nombre = juego.Nombre,
                Genero = juego.Genero,
                Saga = juego.Saga,
                FechaLanzamiento = juego.FechaLanzamiento,
                CompaniaDesarrolladora = juego.CompaniaDesarrolladora,
                Estado = juego.Estado,
                Puntuacion = juego.Puntuacion
            };

            return juegoDto;
        }

        public async Task<bool> DeleteVideoJuego(int id)
        {
            var juego = await _context.videoJuegos.FindAsync(id);
            if (juego != null)
            {
                var juegoDto = new VideoJuegoDto
                {
                    Nombre = juego.Nombre,
                    Genero = juego.Genero,
                    Saga = juego.Saga,
                    FechaLanzamiento = juego.FechaLanzamiento,
                    CompaniaDesarrolladora = juego.CompaniaDesarrolladora,
                    Estado = juego.Estado,
                    Puntuacion = juego.Puntuacion
                };
                _context.Remove(juego);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
