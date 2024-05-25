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

        public DbSet<QuoteAuthor> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }
	}
}
