using Microsoft.EntityFrameworkCore;
using dotNETwepApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PracticeContext>(opt => opt.UseNpgsql("Host=localhost;Database=angularpractice;Username=me;Password=password"));
builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
