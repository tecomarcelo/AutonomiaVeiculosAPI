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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            {
                builder.ToTable("Vehicles");

                // Primary Key
                builder.HasKey(v => v.IdVehicle);

                builder.Property(v => v.IdVehicle)
                       .ValueGeneratedOnAdd();

                // Properties
                builder.Property(v => v.VehicleModel)
                       .HasMaxLength(100)
                       .IsRequired();

                builder.Property(v => v.Fabricant)
                       .HasMaxLength(100)
                       .IsRequired();

                builder.Property(v => v.Color)
                       .HasMaxLength(40)
                       .IsRequired(false);

                builder.Property(v => v.Autonomy)
                       .IsRequired();

                // Foreign Key (IdFuelType)
                builder.HasOne(v => v.Type)
                       .WithMany(f => f.Vehicles)
                       .HasForeignKey(v => v.IdFuelType)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
