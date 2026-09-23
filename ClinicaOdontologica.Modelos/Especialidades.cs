using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

public class Especialidades
{
    [Key]
    [Column("id_especialidad")]
    public int Id_Especialidad { get; set; }

    [Required]
    [Column("nombre_especialidad")]
    [StringLength(50)]
    public string? Especialidad { get; set; }


    [Column("descripcion")]
    [StringLength(200)]
    public string? Descripcion { get; set; }
}
