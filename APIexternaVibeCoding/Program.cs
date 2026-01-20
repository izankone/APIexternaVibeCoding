using System;
using APIExternaVibeCoding.Mappings;
using APIExternaVibeCoding.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Servicios (Inyección de Dependencias)
builder.Services.AddControllers(); // Habilita el uso de controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configuración de la Base de Datos SQLite
// Esto usará el AppDbContext que creaste en la carpeta Data
// Cambia <AppContext> por <AppDbContext>
builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlite("Data Source=mi_api.db"));
// Añade esto donde están los otros servicios
builder.Services.AddAutoMapper(typeof(MappingProfile));
// 3. Configuración de HttpClient y el Repositorio
// Registramos IApiRepository para que pueda ser inyectado en los controladores
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

// Importante: Esto mapea las rutas de tus controladores (ej: api/ExternalData/users)
app.MapControllers();

app.Run();