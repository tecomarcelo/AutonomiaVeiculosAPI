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
    public class FuelingConfiguration : IEntityTypeConfiguration<Fueling>
    {
        public void Configure(EntityTypeBuilder<Fueling> builder)
        {
            {
                builder.ToTable("Fuelings");

                // Primary Key
                builder.HasKey(f => f.IdFueling);

                builder.Property(f => f.IdFueling)
                       .ValueGeneratedOnAdd();

                // Properties
                builder.Property(f => f.TypeFuel)
                       .IsRequired();

                builder.Property(f => f.Quantity)
                       .IsRequired();

                builder.Property(f => f.FuelingDate)
                       .IsRequired();

                builder.Property(f => f.CorrentKm)
                       .IsRequired();

                builder.Property(f => f.FuelingCosts)
                       .IsRequired();

                builder.Property(f => f.IdVehicle)
                       .IsRequired();

                builder.Property(f => f.IdUser).IsRequired();

                // Relationship N:1 (Fuellings → User)
                builder.HasOne(f => f.User) //fueling tem um User
                       .WithMany(u => u.Fuelings) //User tem muitos Fuelings
                       .HasForeignKey(u => u.IdUser) //a FK é UserId nesta tabela (Fuelings)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
