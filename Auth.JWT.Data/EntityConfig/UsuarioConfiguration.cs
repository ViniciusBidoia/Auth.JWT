using Auth.JWT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Data.EntityConfig
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(p => p.Username)                
                .IsRequired();

            builder
                .Property(p => p.Email)                
                .IsRequired();

            builder
                .Property(p => p.Password)                
                .IsRequired();

            builder
                .Property(p => p.DataHoraRegistro)
                .IsRequired();
        }
    }
}
