using api_crud_veiculos_dotnet.Dominio.Enums;

namespace api_crud_veiculos_dotnet.Dominio.ModelViews;

public record AdministradorModelView {

    public int Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public String Perfil { get; set; } = default!;
}