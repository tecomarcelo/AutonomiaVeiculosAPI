using AutonomiaVeiculosAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Data.Configurations
{
    public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.ToTable("FuelTypes");

            // Primary Key
            builder.HasKey(f => f.IdFuelType);

            // Properties
            builder.Property(f => f.IdFuelType)
                   .ValueGeneratedOnAdd();

            builder.Property(f => f.VehicleType)
                   .HasMaxLength(50)
                   .IsRequired();

            // Relationship 1:N (FuelType → Vehicles)
            builder.HasMany(f => f.Vehicles) //FuelType possui muitos Vehicles
                   .WithOne(v => v.Type) //cada Vehicle tem UM FuelType associado.
                   .HasForeignKey(v => v.IdFuelType) //a chave estrangeira (FK) está na tabela Vehicle
                   .OnDelete(DeleteBehavior.Restrict); //Não deixa excluir o FuelType, se existirem Vehicles usando ele
        }
    }
}
