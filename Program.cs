
using api_crud_veiculos_dotnet.Dominio.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/", () => "Olá, pessoal!");

app.MapPost("/login", (LoginDTO loginDto) => {
    if (loginDto.Email == "adm@teste.com" && loginDto.Senha == "123456")
        return Results.Ok(new {message = "Logado com sucesso."});
    else
        return Results.Unauthorized();
});


app.Run();

