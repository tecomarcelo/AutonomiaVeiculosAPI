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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            {
                // se cache composta, na ordem builder.HasKey(u => new {u.Id, u.Name});
                builder.HasKey(u => u.Id);

                builder.Property(u => u.Name)
                        .HasMaxLength(150)
                        .IsRequired();
                
                builder.Property(u => u.Email)
                        .HasMaxLength(50)
                        .IsRequired();

                builder.Property(u => u.Password)
                        .HasMaxLength(40)
                        .IsRequired();

                builder.Property(u => u.CreatedAt)
                        .IsRequired();

                //criando o index
                builder.HasIndex(u => u.Email)
                        .IsUnique();

                // Relationship 1:N (User → Fuellings)
                builder.HasMany(u => u.Fuelings) //User possui muitos Fuelings
                       .WithOne(f => f.User) //cada Fueling tem UM user associado.
                       .HasForeignKey(f => f.IdUser) //a chave estrangeira (FK) está na tabela Fueling
                       .OnDelete(DeleteBehavior.Restrict); //Não deixa excluir o User, se existirem Fuelings usando ele
            }
        }
    }
}
