using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Entities;

namespace ToDoList.Infra.Db.SqlServer.Ef.EntitiesConfigs
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(100).IsRequired();
            builder.Property(u => u.PasswordHash).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(200).IsRequired();

            builder.OwnsOne(u => u.Phone, mobile =>
            {
                mobile.Property(u => u.Value)
                .HasColumnName("Mobile")
                .HasMaxLength(11)
                .IsRequired(true);
            });

            builder.HasMany(u => u.ToDoList)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId);
        }
    }
}
