using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts.Configurations
{
    public class LastClickedsConfiguration : IEntityTypeConfiguration<LastClicked>
    {
        public void Configure(EntityTypeBuilder<LastClicked> modelBuilder)
        {
            modelBuilder.ToTable(@"LastClickeds");
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property<int>(x => x.Id).HasColumnName(@"Id").ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Property<int>(x => x.PatientsMoveId).HasColumnName(@"PatientsMoveId").ValueGeneratedNever().IsRequired(true);

            modelBuilder.HasOne(x => x.PatientsMove).WithMany(op => op.LastClickeds).IsRequired(true)
        .HasForeignKey(x => x.PatientsMoveId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
