using autos.Data;
using Microsoft.EntityFrameworkCore;
using autos.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//esto funciona para conectar el applicationDBcontext con la cadena de conexion a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
{
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("cadenaPSQL"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //proceso para ejecutar la migracion en docker
    app.ApplyMigrations();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
