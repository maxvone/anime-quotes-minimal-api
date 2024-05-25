using Microsoft.EntityFrameworkCore;
using MinimalApi.DataAccess.Data;
using MinimalApi.Routers;

var builder = WebApplication.CreateBuilder(args);

//Packages services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Project services
builder.Services.AddDbContext<ApplicationDbContext>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IQuoteRouter, QuoteRouter>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	IQuoteRouter? service = scope.ServiceProvider.GetService<IQuoteRouter>();
	service?.AddRoutes(app);
}

app.Run();
