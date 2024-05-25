namespace MinimalApi.Routers
{
	public class QuoteRouter : IQuoteRouter
	{
		private IResult Get()
		{
			return Results.Ok("Minimal API launched");
		}

        public void AddRoutes(WebApplication app)
		{
			app.MapGet("/", () => Get());
		}
	}
}
