
using api_crud_veiculos_dotnet.Dominio.DTOs;
using api_crud_veiculos_dotnet.Dominio.Interfaces;
using api_crud_veiculos_dotnet.Dominio.ModelView;
using api_crud_veiculos_dotnet.Dominio.Servicos;
using api_crud_veiculos_dotnet.Infraestrutura.Db;
using api_crud_veiculos_dotnet.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


#region Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
builder.Configuration.GetConnectionString("mysql"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
#endregion


#region Home
app.MapGet("/", () => {

    var home = new Home();
    return Results.Content(home.Html, "text/html; charset=utf-8");
});
#endregion

#region Administradores
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDto, IAdministradorServico administradorServico) => {
    if (administradorServico.Login(loginDto) != null)
        return Results.Ok(new { message = "Logado com sucesso." });
    else
        return Results.Unauthorized();
});
#endregion

// #region Veiculos

// #endregion

# region App
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
#endregion
