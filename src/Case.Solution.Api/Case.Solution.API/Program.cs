using Case.Solution.Application.Services;
using Case.Solution.Infrastructure.Data;
using Case.Solution.Infrastructure.Repositories;
using Case.Solution.Infrastructure.Services;
using CaseSolution.Core.Ports;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Case.Solution.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CaseSolutionDatabase");
	
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ViaCepService>();
builder.Services.AddHttpClient<IViaCep, ViaCepService>();

builder.Services.AddDbContext<PersonDbContext>(options =>
	options.UseSqlServer(connectionString));


builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<IDbConnection>(sp =>
{
	var conn = new SqlConnection(connectionString);
	conn.Open();
	return conn;
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<PersonDbContext>();
	db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
