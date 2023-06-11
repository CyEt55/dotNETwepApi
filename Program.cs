using Microsoft.EntityFrameworkCore;
using dotNETwepApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

const string allowedAddress = "http://localhost:4200";
// http://localhost:4200 is used because Angular serves the Front-End on port 4200 by default

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PracticeContext>(opt => opt.UseNpgsql("Host=localhost;Database=angularpractice;Username=me;Password=password"));
builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.WithOrigins(allowedAddress).AllowAnyMethod()));

var app = builder.Build();

app.UseHttpLogging();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
