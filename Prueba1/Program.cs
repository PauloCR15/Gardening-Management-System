using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prueba1.BLL;
using Prueba1.DAL;

var builder = WebApplication.CreateBuilder(args);
// Configuración de CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5144") // El dominio de tu frontend
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("default-connection");
builder.Services.AddDbContext<Prueba1.DBContext>(x => x.UseSqlServer(connectionString));
// Program.cs o Startup.cs
builder.Services.AddScoped<ClientDataAccess>();  // Inyecta ClientDataAccess
builder.Services.AddScoped<ClientBLL>();  // Inyecta ClientBLL
builder.Services.AddScoped<EmployeeDataAccess>();
builder.Services.AddScoped<EmployeeBLL>();
builder.Services.AddScoped<MachineryDataAccess>();
builder.Services.AddScoped<MachineryBLL>();
builder.Services.AddScoped<MaintenanceDataAccess>();
builder.Services.AddScoped<MaintenanceBLL>();
var app = builder.Build();




// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS antes de la autorización
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

app.Run();