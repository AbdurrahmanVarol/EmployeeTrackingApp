using EmployeeTrackingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Persistence.EntityFramework.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(p => p.DeparmentId);

            builder.Navigation(p => p.Department).AutoInclude();

            builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
