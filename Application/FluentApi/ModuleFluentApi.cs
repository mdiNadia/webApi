using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FluentApi
{
    public class ModuleFluentApi: IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasOne(Current => Current.Parent).WithMany(Current => Current.Children).HasForeignKey(Current => Current.ParentId);

        }
    }
}
