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
    public class ToDoItemConfigurations : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(l => l.Title).HasMaxLength(100).IsRequired(); 


            builder.HasOne(l => l.User)
                .WithMany(u => u.ToDoList)
                .HasForeignKey(l => l.UserId);
            
            builder.HasOne(l => l.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(l => l.CategoryId);
        }
    }
}
