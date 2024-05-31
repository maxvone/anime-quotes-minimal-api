using Microsoft.EntityFrameworkCore;
using MinimalApi.DataAccess.Data;
using MinimalApi.Models.Models;
using MinimalApi.Utility;

namespace MinimalApi.Routers
{
	public class QuoteRouter : IQuoteRouter
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<QuoteRouter> _logger;

		public string? UrlFragment { get; private set; }

		public QuoteRouter(ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
        {
			_dbContext = dbContext;
			_logger = loggerFactory.CreateLogger<QuoteRouter>();

			UrlFragment = UrlFragmentsConstants.QuoteUrlFragment;
		}
		private async Task<IResult> GetAllQuotes()
		{
			List<Quote> quotes = _dbContext.Quotes.Include(q => q.Author).ToList();
			List<QuoteViewModel> quotesVms = new();

			foreach (var quote in quotes)
			{
				QuoteViewModel quoteVm = new(quote);
				quotesVms.Add(quoteVm);
			}

			return TypedResults.Ok(quotesVms);
		}

		private async Task<IResult> GetQuote(int id)
		{
			List<Quote> quotes = _dbContext.Quotes.Include(q => q.Author).ToList();

			Quote? quote = quotes.Find(q => q.Id == id);

			if (quote == null)
				return TypedResults.NotFound();

			return TypedResults.Ok(new QuoteViewModel(quote));
		}

        private async Task<IResult> GetRandomQuote()
		{
			List<Quote> quotes = _dbContext.Quotes.Include(q => q.Author).ToList();

			int randomIndex = new Random().Next(0, quotes.Count);
			Quote randomQuote = quotes[randomIndex];

			return TypedResults.Ok(new QuoteViewModel(randomQuote));
		}

        public void AddRoutes(WebApplication app)
		{

			RouteGroupBuilder group = app.MapGroup("/" + UrlFragment).WithTags("Quotes");

			group.MapGet("/", async () => await GetAllQuotes())
				.WithSummary("Get All Quotes");

			group.MapGet("/random", async () => await GetRandomQuote())
				.WithSummary("Get random quote");

			group.MapGet("/{id}", async (int id) => await GetQuote(id))
				.WithName("view-quote")
				.WithSummary("Get quote")
				.ProducesProblem(404)
				.Produces<QuoteViewModel>();
		}
	}
}
