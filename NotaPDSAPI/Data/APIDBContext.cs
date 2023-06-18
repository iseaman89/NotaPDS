using Microsoft.EntityFrameworkCore;
using NotaPDS.Model;

namespace NotaPDS.Data
{
	public class APIDBContext : DbContext
	{
		public virtual DbSet<ProjectDB> Projects { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }

		public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProjectDB>(entity =>
			{
				entity.HasOne(d => d.)
			});
        }
    }
}

