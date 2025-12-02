using AutonomiaVeiculosAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //mapeando os modelos de dominio deste contexto
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Fueling> Fuelings { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }

        //adicionando as configurações de modelos de entidade do banco de dados (ORM)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //definindo o banco de dados do contexto
            optionsBuilder.UseInMemoryDatabase(databaseName: "bd_autonomias");
        }        
    }
}
