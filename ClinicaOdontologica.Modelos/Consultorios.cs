using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("consultorios")]
public class Consultorios
{
    [Key]
    [Column("id_consultorio")]
    public int IdConsultorio { get; set; }


    [Required(ErrorMessage = "El numero de sala es obligatorio")]
    [Column("numero_sala")]
    [StringLength(10)]
    public string? Numero_Sala { get; set; }


    [Required(ErrorMessage = "El numero de piso es obligatorio")]
    [Column("piso")]
    public int Piso { get; set; }


    [Required(ErrorMessage = "El numero de sala es obligatorio")]
    [Column("equipamiento_principal")]
    [StringLength(100)]
    public string? Equipamiento_Principal { get; set; }

}
