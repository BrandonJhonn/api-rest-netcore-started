using Microsoft.EntityFrameworkCore;
using NetCoreApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add First DBContext in Memory Storage (Volatile)
builder.Services.AddDbContext<CTodoContext>(opt =>
    opt.UseInMemoryDatabase("DBTodoList")
);

// Add Second DBContext in a DataBase PostgreSQL v15 (Non Volatile)
builder.Services.AddDbContext<CItemContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("pgSqlConnection")));

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

app.Run();
