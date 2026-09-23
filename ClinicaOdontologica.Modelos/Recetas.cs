using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("recetas")]
public class Recetas
{
    [Key]
    [Column("id_receta")]
    public int IdReceta { get; set; }

    [Required(ErrorMessage = "La fecha de emisión es obligatoria")]
    [Column("fecha_emision")]
    public DateTime FechaEmision { get; set; }

    [Required(ErrorMessage = "Las indicaciones son obligatorias")]
    [Column("indicaciones", TypeName = "text")]
    public string? Indicaciones { get; set; }

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [ForeignKey(nameof(IdCita))]
    public Citas? Cita { get; set; }
}