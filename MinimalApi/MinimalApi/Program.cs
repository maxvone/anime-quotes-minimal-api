using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.DataAccess.Data;
using MinimalApi.Routers;

var builder = WebApplication.CreateBuilder(args);

//Packages services
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
	builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
	config.SwaggerDoc("v1", new OpenApiInfo { Title = "Anime Quotes API", Version = "v1" });
});

//Project services
builder.Services.AddScoped<IQuoteRouter, QuoteRouter>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(config =>
	{
		config.SwaggerEndpoint("/swagger/v1/swagger.json", "Anime Quotes API");
	});
}

using (var scope = app.Services.CreateScope())
{
	IQuoteRouter? service = scope.ServiceProvider.GetService<IQuoteRouter>();
	service?.AddRoutes(app);

	app.Run();
}
