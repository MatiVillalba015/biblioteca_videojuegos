using FluentValidation;
using BibliotecaVideojuegos.DTOs;

namespace BibliotecaVideojuegos.Validators
{
    public class VideoJuegoInsertValidator : AbstractValidator<VideoJuegoInsertDto>
    {
        public VideoJuegoInsertValidator()
        {
            RuleFor(juego => juego.Nombre).NotEmpty().WithMessage("El nombre del videojuego es obligatorio");

            RuleFor(juego => juego.FechaLanzamiento).NotEmpty().WithMessage("Todo videojuego tiene una fecha de lanzamiento");

            RuleFor(juego => juego.Puntuacion).GreaterThan(0).WithMessage("El puntaje no puede ser menor a 0");

            RuleFor(juego => juego.Puntuacion).LessThan(101).WithMessage("El puntaje no puede ser mas de 100");
        }
    }
}
