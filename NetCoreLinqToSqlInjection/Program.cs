using NetCoreLinqToSqlInjection.Models;
using NetCoreLinqToSqlInjection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//RESOLVEMOS EL SERVICIO COCHE
//builder.Services.AddTransient<Coche>();
//builder.Services.AddSingleton<Coche>();
//builder.Services.AddSingleton<ICoche, Deportivo>();
Coche car = new Coche();
car.Marca = "4x4";
car.Modelo = "Deportivo";
car.Imagen = "4x4_Deportivo.jpeg";
car.Velocidad = 0;
car.VelocidadMaxima = 220;
//PARA ENVIAR NUUESTRO OBJETO PERSONALIZADO, SE UTILIZA LAMBDA
builder.Services.AddSingleton<ICoche, Coche>(x => car);
builder.Services.AddTransient<RepositoryDoctoresSQLServer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Doctores}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
