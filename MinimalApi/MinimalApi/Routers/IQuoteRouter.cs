namespace MinimalApi.Routers
{
	public interface IQuoteRouter
	{
		string? UrlFragment { get; }

		void AddRoutes(WebApplication app);
	}
}
