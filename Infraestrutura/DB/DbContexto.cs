using api_crud_veiculos_dotnet.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace api_crud_veiculos_dotnet.Infraestrutura.Db;

public class DbContexto : DbContext {
    private readonly IConfiguration _configuracaoAppSettings;

    public DbContexto(IConfiguration _configuracaoAppSettings) {
        this._configuracaoAppSettings = _configuracaoAppSettings;
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();

            if (!string.IsNullOrEmpty(stringConexao)) {

                optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
            }

        }


    }
}