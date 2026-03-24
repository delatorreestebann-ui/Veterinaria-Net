using Veterinaria.Servicios;
using Veterinaria.Servicios.Interfaces;
using Veterinaria.Modelos;
using API_Consumer;

// Configuración del Endpoint
Crud<PersonalAdministrativos>.EndPoint = "https://localhost:7297/api/PersonalAdministrativos";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registro de los servicios (Asegúrate que AuthService esté en Veterinaria.Servicios)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpContextAccessor();

// Configuración de Autenticación por Cookies
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Account/Index";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// El orden es CRÍTICO: Primero Auth, luego Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();