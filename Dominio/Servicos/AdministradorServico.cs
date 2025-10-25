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

        public Administrador? BuscaPorId(int? id) {
            var adm = _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();

            return adm;
        }

        public Administrador Incluir(Administrador administrador) {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public Administrador? Login(LoginDTO loginDto) {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDto.Email && a.Senha == loginDto.Senha).FirstOrDefault();

            return adm;
        }

        public List<Administrador> Todos(int? pagina) {
             var query = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;

            if (pagina != null) {

                query = query.Skip(((int) pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }
    }
}