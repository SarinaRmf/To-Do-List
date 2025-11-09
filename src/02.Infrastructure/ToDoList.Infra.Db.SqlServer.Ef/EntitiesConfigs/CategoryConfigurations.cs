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
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new List<Category>
            {
                new Category {Id = 1 , Name = "Personal", CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0) },
                new Category {Id = 2 , Name = "University", CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0) },
                new Category {Id = 3, Name = "Work", CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0) },
                new Category {Id = 4 , Name = "Others", CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0) }
            });
        }
    }
}
