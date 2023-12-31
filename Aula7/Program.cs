using Aula7.Data;
using Microsoft.EntityFrameworkCore;
using Aula7.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<AulaDbContext>(x => x.UseMySQL(connectionStringMySql));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapSalasEndpoints();

app.Run();
