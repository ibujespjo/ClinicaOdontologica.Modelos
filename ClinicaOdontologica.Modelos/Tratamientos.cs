using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("tratamientos")]
public class Tratamientos
{
    [Key]
    [Column("id_tratamiento")]
    public int IdTratamiento { get; set; }

    [Required(ErrorMessage = "El nombre del tratamiento es obligatorio")]
    [Column("nombre_tratamiento")]
    [StringLength(100)]
    public string? NombreTratamiento { get; set; }

    [Required(ErrorMessage = "El costo base es obligatorio")]
    [Column("costo_base", TypeName = "numeric(10, 2)")]
    public decimal CostoBase { get; set; }

    [Required(ErrorMessage = "La duración estimada es obligatoria")]
    [Column("duracion_estimada_minutos")]
    public int DuracionEstimadaMinutos { get; set; }
}