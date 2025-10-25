
using api_crud_veiculos_dotnet.Dominio.DTOs;
using api_crud_veiculos_dotnet.Dominio.Entidades;
using api_crud_veiculos_dotnet.Dominio.Interfaces;
using api_crud_veiculos_dotnet.Dominio.ModelView;
using api_crud_veiculos_dotnet.Dominio.ModelViews;
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
}).WithTags("Home");
#endregion

#region Administradores
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDto, IAdministradorServico administradorServico) => {
    if (administradorServico.Login(loginDto) != null)
        return Results.Ok(new { message = "Logado com sucesso." });
    else
        return Results.Unauthorized();
}).WithTags("Administrador");
#endregion

#region Veiculos

ErrosDeValidacao validaDTO(VeiculoDTO veiculoDto) {
    var validacao = new ErrosDeValidacao();
    int anoAtual = DateTime.Now.Year;

    if (string.IsNullOrEmpty(veiculoDto.Nome))
        validacao.Mensagens.Add("O nome não pode ser vazio.");

    if (string.IsNullOrEmpty(veiculoDto.Marca))
        validacao.Mensagens.Add("A marca não pode ficar em branco.");

    if (veiculoDto.Ano < 1886 || veiculoDto.Ano >= anoAtual)
        validacao.Mensagens.Add("Ano de fabricação inválido. Deve ser entre 1886 e o ano atual.");

    return validacao;
}

app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDto, IVeiculoServico veiculoServico) => {

    var validacao = validaDTO(veiculoDto);
    if (validacao.Mensagens.Count > 0) {
        return Results.BadRequest(validacao);
    }

    var veiculo = new Veiculo {
        Nome = veiculoDto.Nome,
        Ano = veiculoDto.Ano,
        Marca = veiculoDto.Marca
    };

    veiculoServico.Incluir(veiculo);

    return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
}).WithTags("Veiculos");

app.MapGet("/veiculos", ([FromQuery] int? pagina, IVeiculoServico veiculoServico) => {

    var veiculos = veiculoServico.Todos(pagina);

    return Results.Ok(veiculos);
}).WithTags("Veiculos");

app.MapGet("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) => {

    var veiculo = veiculoServico.BuscaPorId(id);

    if (veiculo == null) return Results.NotFound();

    return Results.Ok(veiculo);
}).WithTags("Veiculos");

app.MapPut("/veiculos/{id}", ([FromRoute] int id, VeiculoDTO veiculoDto, IVeiculoServico veiculoServico) => {
    var validacao = validaDTO(veiculoDto);
    if (validacao.Mensagens.Count > 0) {
        return Results.BadRequest(validacao);
    }

    var veiculo = veiculoServico.BuscaPorId(id);
    if (veiculo == null) return Results.NotFound();

    veiculo.Nome = veiculoDto.Nome;
    veiculo.Marca = veiculoDto.Marca;
    veiculo.Ano = veiculoDto.Ano;

    veiculoServico.Atualizar(veiculo);

    return Results.Ok(veiculo);
}).WithTags("Veiculos");

app.MapDelete("/veiculos/{id}", ([FromRoute] int id, IVeiculoServico veiculoServico) => {
    var veiculo = veiculoServico.BuscaPorId(id);
    if (veiculo == null) return Results.NotFound();


    veiculoServico.Apagar(veiculo);

    return Results.NoContent();
}).WithTags("Veiculos");
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
#endregion
