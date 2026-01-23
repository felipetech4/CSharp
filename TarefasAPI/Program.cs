using Microsoft.EntityFrameworkCore;
using TarefasAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

string? StringDeConexao = builder.Configuration.GetConnectionString("StringConexaoBanco");

if(StringDeConexao is null)
{
    throw new Exception("A string de conexão não foi definida no appsettings");
}

builder.Services.AddDbContext<TarefasApiContext>(opt => opt.UseNpgsql(StringDeConexao));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

