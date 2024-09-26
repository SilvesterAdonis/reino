using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kaiju8.Dominio.DTOs;
using kaiju8.Dominio.Entities;

namespace kaiju8.Dominio.Interfaces
{
    public interface IAdministradorService
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}