using BILL.Service;
using DAL.DataContext;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbpracticaContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CADENASQL"));

}
);

builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
