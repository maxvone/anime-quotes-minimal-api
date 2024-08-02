using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.DataAccess.Data;
using MinimalApi.Routers;
using MinimalApi.Utility;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(config =>
	{
		config.SwaggerEndpoint("/swagger/v1/swagger.json", BaseConstants.ApiTitle);
	});
}

using (var scope = app.Services.CreateScope())
{
	IQuoteRouter? service = scope.ServiceProvider.GetService<IQuoteRouter>();
	service?.AddRoutes(app);

	app.Run();
}

static void AddServices(WebApplicationBuilder builder)
{
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen(config =>
	{
		config.SwaggerDoc("v1", new OpenApiInfo { Title = BaseConstants.ApiTitle, Version = "v1" });
	});
	builder.Services.AddDbContext<ApplicationDbContext>(options =>
	{
		options.UseSqlServer(
			builder.Configuration.GetConnectionString("DefaultConnection"));
	});
	builder.Services.AddScoped<IQuoteRouter, QuoteRouter>();
}