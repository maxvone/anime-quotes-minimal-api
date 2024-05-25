using MinimalApi.Routers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IQuoteRouter, QuoteRouter>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	IQuoteRouter? service = scope.ServiceProvider.GetService<IQuoteRouter>();
	service?.AddRoutes(app);
}

app.Run();
