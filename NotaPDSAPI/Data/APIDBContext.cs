using Microsoft.EntityFrameworkCore;
using NotaPDSAPI.Model;

namespace NotaPDSAPI.Data
{
	public class APIDBContext : DbContext
	{
		public DbSet<Project> Projects { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<ChatMessage> ChatMessages { get; set; }
		public DbSet<User> Users { get; set; }

		public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) {}
    }
}