using Microsoft.EntityFrameworkCore;



namespace MPI
{
    public class MPIDBContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public MPIDBContext(DbContextOptions<MPIDBContext> options) : base(options)
        {
        }


    }
}