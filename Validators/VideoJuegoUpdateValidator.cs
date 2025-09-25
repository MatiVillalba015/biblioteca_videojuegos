using BibliotecaVideojuegos.DTOs;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaVideojuegos.Validators
{
    public class VideoJuegoUpdateValidator : AbstractValidator<VideoJuegoUpdateDto>
    {

        public VideoJuegoUpdateValidator() 
        {
            RuleFor(juego => juego.Nombre).NotEmpty().WithMessage("El nombre del videojuego es obligatorio");

            RuleFor(juego => juego.Genero).NotEmpty().WithMessage("El genero es necesario");

            RuleFor(juego => juego.CompaniaDesarrolladora).NotEmpty().WithMessage("Es obligatorio poner la compania/autor del juego");

            RuleFor(juego => juego.FechaLanzamiento).NotEmpty().WithMessage("Todo videojuego tiene una fecha de lanzamiento");

            RuleFor(juego => juego.Puntuacion).GreaterThan(0).WithMessage("El puntaje no puede ser menor a 0");

            RuleFor(juego => juego.Puntuacion).LessThan(101).WithMessage("El puntaje no puede ser mas de 100");

            RuleFor(juego => juego.Estado).NotEmpty().WithMessage("Es obligatorio aclarar si el juego ya lo jugaste o estas jugandolo");

        }

    }
}
