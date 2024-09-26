using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kaiju8.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace kaiju8.Infraestrutura.Db
{
    public class DatabaseContext : DbContext
    {
         private readonly IConfiguration _configuracaoAppSettings;
        public DatabaseContext(IConfiguration settings)
        {
            _configuracaoAppSettings = settings;
        }


        public DbSet<Administrador> Administradors {get; set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData
            (
                new Administrador
                {
                    Id = 1,
                    Email = "administrador@teste.com",
                    Senha = "123456",
                    Perfil = "Adm"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {

                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
                if(!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql
                    (
                       stringConexao, 
                       ServerVersion.AutoDetect(stringConexao)
                    );
                }
            }

        }
    }
}