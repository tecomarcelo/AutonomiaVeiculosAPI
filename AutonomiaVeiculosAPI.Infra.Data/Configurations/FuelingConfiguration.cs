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
                       .HasMaxLength(50)
                       .IsRequired();

                builder.Property(f => f.Quantity)
                       .IsRequired();

                builder.Property(f => f.FuelingDate)
                       .IsRequired();

                builder.Property(f => f.CorrentKm)
                       .IsRequired();
            }
        }
    }
}
