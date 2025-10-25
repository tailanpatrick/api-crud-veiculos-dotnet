namespace api_crud_veiculos_dotnet.Dominio.ModelViews;

public struct ErrosDeValidacao {
    public List<string> Mensagens { get; set; }

    public ErrosDeValidacao() {
        Mensagens = new List<string>();
    }
}