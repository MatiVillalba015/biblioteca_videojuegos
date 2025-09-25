using BibliotecaVideojuegos.Data;
using BibliotecaVideojuegos.DTOs;
using BibliotecaVideojuegos.Services;
using BibliotecaVideojuegos.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICIOS PARA API
builder.Services.AddControllers(); // <- Habilita los controladores API
builder.Services.AddEndpointsApiExplorer(); // <- Necesario para Swagger
builder.Services.AddSwaggerGen(); // <- Genera la documentación Swagger

//BASE DE DATOS 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VideoJuegosContext>(options =>
    options.UseSqlServer(connectionString));

//SERVICIO
builder.Services.AddScoped<IVideoJuegoService, VideoJuegoService>();

// 4. VALIDADORES 
builder.Services.AddScoped<IValidator<VideoJuegoInsertDto>, VideoJuegoInsertValidator>();
builder.Services.AddScoped<IValidator<VideoJuegoUpdateDto>, VideoJuegoUpdateValidator>();

// 5. FLUENT VALIDATION
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

//SWAGGER
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

//MAPEO DE LOS CONTROLADORES
app.MapControllers();

app.Run();