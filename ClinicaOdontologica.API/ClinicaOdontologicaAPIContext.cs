using Microsoft.EntityFrameworkCore;

public class ClinicaOdontologicaAPIContext(DbContextOptions<ClinicaOdontologicaAPIContext> options) : DbContext(options)
{
    public DbSet<ClinicaOdontologica.Modelos.Citas> Citas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Consultorios> Consultorios { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.DetallesCita> DetallesCita { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Especialidades> Especialidades { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Facturas> Facturas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.HistorialesMedicos> HistorialesMedicos { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Odontologos> Odontologos { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Pacientes> Pacientes { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Recetas> Recetas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Tratamientos> Tratamientos { get; set; } = default!;
}