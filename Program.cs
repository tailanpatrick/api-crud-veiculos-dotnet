
using api_crud_veiculos_dotnet.Dominio.DTOs;
using api_crud_veiculos_dotnet.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
builder.Configuration.GetConnectionString("mysql"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();



app.MapGet("/", () => "Olá, pessoal!");

app.MapPost("/login", (LoginDTO loginDto) => {
    if (loginDto.Email == "adm@teste.com" && loginDto.Senha == "123456")
        return Results.Ok(new { message = "Logado com sucesso." });
    else
        return Results.Unauthorized();
});


app.Run();

