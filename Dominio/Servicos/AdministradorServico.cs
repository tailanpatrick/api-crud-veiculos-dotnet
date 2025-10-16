using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_crud_veiculos_dotnet.Dominio.DTOs;
using api_crud_veiculos_dotnet.Dominio.Entidades;
using api_crud_veiculos_dotnet.Infraestrutura.Db;
using api_crud_veiculos_dotnet.Infraestrutura.Interfaces;

namespace api_crud_veiculos_dotnet.Dominio.Servicos
{
    
    public class AdministradorServico : IAdministradorServico {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto) {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDto) {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDto.Email && a.Senha == loginDto.Senha).FirstOrDefault();

            return adm;
        }
    }
}