using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("detallescita")]
public class DetallesCita
{
    [Key]
    [Column("id_detalle_cita")]
    public int IdDetalleCita { get; set; }

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Required]
    [Column("id_tratamiento")]
    public int IdTratamiento { get; set; }

    [Required(ErrorMessage = "El costo aplicado es obligatorio")]
    [Column("costo_aplicado", TypeName = "numeric(10, 2)")]
    public decimal CostoAplicado { get; set; }

    [Column("observaciones")]
    [StringLength(200)]
    public string? Observaciones { get; set; }

    [ForeignKey(nameof(IdCita))]
    public Citas? Cita { get; set; }

    [ForeignKey(nameof(IdTratamiento))]
    public Tratamientos? Tratamiento { get; set; }
}