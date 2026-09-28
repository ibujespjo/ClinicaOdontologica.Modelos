using Microsoft.EntityFrameworkCore;

public class ClinicaOdontologicaAPIContext(DbContextOptions<ClinicaOdontologicaAPIContext> options) : DbContext(options)
{
    public DbSet<ClinicaOdontologica.Modelos.DetallesCita> DetallesCita { get; set; } = default!;
}
