using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kaiju8.Dominio.DTOs;
using kaiju8.Dominio.Entities;
using kaiju8.Dominio.Interfaces;
using kaiju8.Infraestrutura.Db;

namespace kaiju8.Dominio.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly DatabaseContext _contexto;
        public AdministradorService(DatabaseContext contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradors.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }
        

    }
}