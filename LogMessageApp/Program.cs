using Microsoft.EntityFrameworkCore;
using LogMessageApp.Data;
using LogMessageApp.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("LogMessageDb"));



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ILogMessageRepository, LogMessageRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

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
