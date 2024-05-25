using Microsoft.EntityFrameworkCore;
using MinimalApi.Models.Models;

namespace MinimalApi.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Quote> Quotes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Quote>().HasData(
				new Quote { QuoteId = 1, QuoteContent = "Test Quote Content" }
			); 
		}
	}
}
