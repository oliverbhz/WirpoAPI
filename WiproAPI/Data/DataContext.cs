using Microsoft.EntityFrameworkCore;
using WiproAPI.Models;

namespace WiproAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<ProcessingQueue> Queues { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProcessingQueue>()
				.Property(p => p.Id)
				.ValueGeneratedOnAdd();
		}
	}
}
