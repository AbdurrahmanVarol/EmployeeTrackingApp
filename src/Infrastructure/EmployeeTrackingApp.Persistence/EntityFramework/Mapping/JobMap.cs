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
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(p => p.Id);



            builder
           .HasOne(x => x.Department)
           .WithMany()
           .HasForeignKey(x => x.DepartmentId);

            builder
                .HasOne(x => x.CreatedBy)
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(x => x.AssignedTo)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.AssignedToId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(x => x.ClosedBy)
                .WithMany()
                .HasForeignKey(x => x.ClosedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(x => x.ApprovedBy)
                .WithMany()
                .HasForeignKey(x => x.ApprovedById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Navigation(p => p.ApprovedBy).AutoInclude();
            builder.Navigation(p => p.CreatedBy).AutoInclude();
            builder.Navigation(p => p.ClosedBy).AutoInclude();
            builder.Navigation(p => p.Department).AutoInclude();

            builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
