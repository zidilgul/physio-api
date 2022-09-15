using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts.Configurations
{
    public class MoveConfiguration : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> modelBuilder)
        {
            modelBuilder.ToTable(@"Moves");
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property<int>(x => x.Id).HasColumnName(@"Id").ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Property<string>(x => x.Name).HasColumnName(@"Name").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<int>(x => x.BodyPartId).HasColumnName(@"BodyPartId").ValueGeneratedNever();

            modelBuilder.HasOne(x => x.BodyPart).WithMany(op => op.Moves).IsRequired(true)
        .HasForeignKey(x => x.BodyPartId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
