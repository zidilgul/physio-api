using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts.Configurations
{
    public class PatientsMoveConfiguration : IEntityTypeConfiguration<PatientsMove>
    {
        public void Configure(EntityTypeBuilder<PatientsMove> modelBuilder)
        {
            modelBuilder.ToTable(@"PatientsMoves");
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property<int>(x => x.Id).HasColumnName(@"Id").ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Property<int>(x => x.PatientId).HasColumnName(@"PatientId").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<bool>(x => x.State).HasColumnName(@"State").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<int>(x => x.NumberOfRepetitons).HasColumnName(@"NumberOfRepetitons").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<int>(x => x.NumberOfSets).HasColumnName(@"NumberOfSets").ValueGeneratedNever().IsRequired(true);

            modelBuilder.HasOne(x => x.User).WithMany(op => op.PatientMoves).IsRequired(true)
              .HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.HasOne(x => x.Move).WithMany(op => op.PatientMoves).IsRequired(true)
              .HasForeignKey(x => x.MoveId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
