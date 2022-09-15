using Microsoft.EntityFrameworkCore;
using physio.Model.Contexts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model.Contexts
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<PatientsMove> PatientMoves { get; set; }
        public DbSet<DoctorsPatient> DoctorsPatients { get; set; }
        public DbSet<LastClicked> LastClickeds { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=95.111.238.110;Database=physio;User ID=physio; Password=123.123Aa**");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<BodyPart>(new BodyPartConfiguration());
            modelBuilder.ApplyConfiguration<Move>(new MoveConfiguration());
            modelBuilder.ApplyConfiguration<PatientsMove>(new PatientsMoveConfiguration());
            modelBuilder.ApplyConfiguration<DoctorsPatient>(new DoctorsPatientConfiguration());
            modelBuilder.ApplyConfiguration<LastClicked>(new LastClickedsConfiguration());

        }

    }
}
