using AutonomiaVeiculosAPI.Domain.Models;
using AutonomiaVeiculosAPI.Infra.Data.Configurations;
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
        //método construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //adicionando as configurações de modelos de entidade do banco de dados (ORM)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FuelTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FuelingConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        }

        //mapeando os modelos de dominio deste contexto
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Fueling> Fuelings { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }     
    }
}
