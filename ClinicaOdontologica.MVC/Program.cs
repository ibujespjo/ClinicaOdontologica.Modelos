using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;


CRUD<Citas>.Endpoint = "https://localhost:7026/api/Citas";
CRUD<Consultorios>.Endpoint = "https://localhost:7026/api/Consultorios";
CRUD<DetallesCita>.Endpoint = "https://localhost:7026/api/DetallesCitas";
CRUD<Especialidades>.Endpoint = "https://localhost:7026/api/Especialidades";
CRUD<Facturas>.Endpoint = "https://localhost:7026/api/Facturas";
CRUD<HistorialesMedicos>.Endpoint = "https://localhost:7026/api/HistorialesMedicos";
CRUD<Odontologos>.Endpoint = "https://localhost:7026/api/Odontologos";
CRUD<Pacientes>.Endpoint = "https://localhost:7026/api/Pacientes";
CRUD<Recetas>.Endpoint = "https://localhost:7026/api/Recetas";
CRUD<Tratamientos>.Endpoint = "https://localhost:7026/api/Tratamientos";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
