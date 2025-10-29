using System.Runtime.Serialization;

namespace api_crud_veiculos_dotnet.Dominio.Enums
{
    public enum Perfil
    {
        [EnumMember(Value = "adm")]
        Adm,

        [EnumMember(Value = "editor")]
        Editor
    }
}
