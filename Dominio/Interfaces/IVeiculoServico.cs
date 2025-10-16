using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_crud_veiculos_dotnet.Dominio.Entidades;

namespace api_crud_veiculos_dotnet.Dominio.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> Todos(int pagina, string? nome = null, string? marca = null);
        Veiculo? BuscaPorId(int id);
        void Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Apagar(Veiculo veiculo);
    }
}