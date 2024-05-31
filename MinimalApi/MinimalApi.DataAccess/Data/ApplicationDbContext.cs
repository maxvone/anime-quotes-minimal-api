using Microsoft.EntityFrameworkCore;
using MinimalApi.Models.Models;

namespace MinimalApi.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
        public DbSet<QuoteAuthor> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Quote>()
				.HasOne(q => q.Author)
				.WithMany(a => a.Quotes)
				.HasForeignKey(q => q.AuthorId);
		}
	}
}
