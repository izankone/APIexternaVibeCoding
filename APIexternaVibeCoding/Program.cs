using Microsoft.EntityFrameworkCore;
using APIExternaVibeCoding.Mappings;
using APIExternaVibeCoding.Repositories;
using APIExternaVibeCoding.Data; // <--- 1. IMPORTANTE: Agregada esta línea para encontrar AppDbContext
using System;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Servicios (Inyección de Dependencias)
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configuración de la Base de Datos SQLite
// Corregido: Se cambió <AppContext> por <AppDbContext>
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=mi_api.db")); //

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 3. Configuración de HttpClient y el Repositorio
builder.Services.AddHttpClient<IApiRepository, ApiRepository>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

var app = builder.Build();

// 4. Configuración del Pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Importante: Mapeo de rutas
app.MapControllers();

app.Run();