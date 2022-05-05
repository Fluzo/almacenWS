using AlmacenWS.BaseDatos;
using AlmacenWS.Articulos.Servicios;
using AlmacenWS.Usuarios.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Base de datos
builder.Services.AddDbContext<AlmacenContext>(options =>
{
    options.UseSqlServer("data source=DESKTOP-CCF2V8K\\SQLEXPRESS;initial catalog=ALMACEN;user id=sa;password=Solid0231.");
});

//builder.Services.AddDbContext<AlmacenContext>(options => {
//    options.UseSqlServer("data source=DESKTOP-KHBQIV3\\SQLEXPRESS;initial catalog=ALMACEN;user id=sa;password=1234.");
//});

builder.Services.AddScoped<IArticulosService, ArticulosService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
