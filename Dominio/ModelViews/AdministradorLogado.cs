using api_crud_veiculos_dotnet.Dominio.Enums;

namespace api_crud_veiculos_dotnet.Dominio.ModelViews;

public record AdministradorLogado {

    public string Email { get; set; } = default!;
    public string Token { get; set; } = default!;
    public String Perfil { get; set; } = default!;
    
}