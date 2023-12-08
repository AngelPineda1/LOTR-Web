
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using LOTR_Web.Repositories.Repositorios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
/*El connectionString es la "Cadena de conexion" que se encuentra en el archivo appsettings.json*/
/*Default es el nombre de la conexion para acceder remotamente*/
/*Deploy es el nombre de la conexion para acceder localmente (Una vez ya publicada en el servidor para evitar que se llame asi mismo)*/
builder.Services.AddDbContext<LotrdbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("default"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("default"))
        ));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(c =>
{
    c.AccessDeniedPath = "/Home/Login";
    c.LoginPath = "/Home/Login";
    c.LogoutPath = "/Home/Logout";
    c.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    c.Cookie.Name = "LOTR-Web-PFinal";
});

builder.Services.AddTransient<IRepo, Repo>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPublicacionesRepository, PublicacionesRepository>();
builder.Services.AddTransient<IPeliculasRepository,PeliculasRepository>();
builder.Services.AddTransient<IEstudiosRepository, EstudiosRepository>();
builder.Services.AddTransient<ILibrosRepository, LibrosRepository>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<IJuegosRepository, JuegosRepository>();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.Run();
