using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts.Configurations
{
    public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
    {
        public void Configure(EntityTypeBuilder<BodyPart> modelBuilder)
        {
            modelBuilder.ToTable(@"BodyParts");
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property<int>(x => x.Id).HasColumnName(@"Id").ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Property<string>(x => x.Name).HasColumnName(@"Name").ValueGeneratedNever().IsRequired(true);
        }
    }
}
