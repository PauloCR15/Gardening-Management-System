using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Tarea1.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddScoped<IServicesEmployee, EmployeeServices>();
builder.Services.AddScoped<IServicesClient, ClientServices>();
builder.Services.AddScoped<IServicesMaintenance, MaintenanceServices>();
builder.Services.AddScoped<IServicesReport, ReportServices>();
builder.Services.AddScoped<IServicesMachinery, MachineryServices>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5144")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials(); // Permitir credenciales si es necesario
                      });
});

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar CORS antes de la ruta
app.UseCors(MyAllowSpecificOrigins);

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings =
        {
            [".avif"] = "image/avif",
            [".webp"] = "image/webp"
        }
    }
});

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();