
using kaiju8.Dominio.DTOs;
using kaiju8.Dominio.Interfaces;
using kaiju8.Dominio.Services;
using kaiju8.Infraestrutura.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorService, AdministradorService>();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});


var app = builder.Build();

app.MapGet("/", () => "Sex Fat Girl, LOVE!!!!!!!!!!!!!!!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorService administradorService) => 
{
    if(administradorService.Login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
