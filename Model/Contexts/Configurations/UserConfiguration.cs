using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable(@"Users");
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property<int>(x => x.Id).HasColumnName(@"Id").ValueGeneratedOnAdd().UseIdentityColumn();
            modelBuilder.Property<string>(x => x.UserName).HasColumnName(@"Username").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<string>(x => x.FullName).HasColumnName(@"FullName").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<string>(x => x.Password).HasColumnName(@"Password").ValueGeneratedNever().IsRequired(true);
            modelBuilder.Property<bool>(x => x.IsDoctor).HasColumnName(@"IsDoctor").HasDefaultValue(false).IsRequired(true);
        }
    }
}
