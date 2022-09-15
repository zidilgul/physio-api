using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts.Configurations
{
    public class DoctorsPatientConfiguration : IEntityTypeConfiguration<DoctorsPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorsPatient> modelBuilder)
        {
            modelBuilder.ToTable(@"DoctorsPatients");
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property<int>(x => x.Id).HasColumnName(@"Id").ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Property<int>(x => x.PatientId).HasColumnName(@"PatientId").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<int>(x => x.DoctorId).HasColumnName(@"DoctorId").ValueGeneratedNever().IsRequired(true);

            modelBuilder.HasOne(x => x.DUser).WithMany(op => op.Doctor).IsRequired(true)
              .HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.HasOne(x => x.PUser).WithMany(op => op.Patient).IsRequired(true)
              .HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
