using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_crud_veiculos_dotnet.Dominio.Enums;

namespace api_crud_veiculos_dotnet.Dominio.DTOs {
    public class AdministradorDTO {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
        public Perfil? Perfil { get; set; } = default!;

    }
}