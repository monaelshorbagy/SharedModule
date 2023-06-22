using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MPI;
using MPI.Data;

namespace VM.Model.Model
{
    public class VMDBContext : DbContext, IDesignTimeDbContextFactory<VMDBContext>
    {

        public DbSet<Visit> Visits { get; set; }
        public VMDBContext(DbContextOptions<VMDBContext> options) : base(options)
        {

        }

        public VMDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VMDBContext>();
            optionsBuilder.UseSqlServer("Data Source=10.24.105.25;Initial Catalog=MedicalDB;User Id=ADS;Password=Ad$;Encrypt=False;TrustServerCertificate=True;"); // Replace with your actual connection string
            return new VMDBContext(optionsBuilder.Options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add entity configurations here
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

        }

    }






}
