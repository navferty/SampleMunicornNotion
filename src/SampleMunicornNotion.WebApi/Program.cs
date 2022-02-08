using System.Reflection;

using FluentValidation.AspNetCore;

using Microsoft.EntityFrameworkCore;

using SampleMunicornNotion.BL;
using SampleMunicornNotion.DAL;
using SampleMunicornNotion.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
	.AddControllers()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.Configure<MunicornNotionConfiguration>(
	builder.Configuration.GetSection(MunicornNotionConfiguration.Name));

builder.Services.AddDbContext<MunicornNotionDbContext>(p =>
	p.UseNpgsql(builder.Configuration.GetConnectionString("MunicornNotionDb")));

builder.Services.AddDataAccessLayer();
builder.Services.AddNotionSenders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
