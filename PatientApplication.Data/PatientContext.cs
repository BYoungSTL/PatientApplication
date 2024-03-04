using Microsoft.EntityFrameworkCore;

namespace PatientApplication.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientContext).Assembly);
        }

        //private static DbContextOptions GetOptions() 
        //    => new DbContextOptionsBuilder().UseSqlServer("Server=DESKTOP-IF6776O\\SERVER;Database=PatientApplication;Trusted_Connection=True;").Options;
    }
}
