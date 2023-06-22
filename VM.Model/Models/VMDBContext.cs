using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MPI.Data;
using System.IO;
using VM.Model.Model;
using Microsoft.Extensions.Configuration;

namespace VM.Model
{
    public class VMDBContext : DbContext, IDesignTimeDbContextFactory<VMDBContext>
    {
        public DbSet<Visit> Visits { get; set; }

        public VMDBContext(DbContextOptions<VMDBContext> options) : base(options)
        {

        }

        public VMDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<VMDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

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
