using Microsoft.EntityFrameworkCore;
using EstudiantesAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la Base de Datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Agregar Controladores
builder.Services.AddControllers();

// 3. Configurar Swagger (Solo estas dos líneas son necesarias)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Habilitar Swagger
// Lo dejamos fuera del if para que siempre puedas probarlo
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();