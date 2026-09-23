using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

public class Odontologos
{
    [Key]
    [Column("id_odontologo")]
    public int IdOdontologo { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column("nombres")]
    [StringLength(50)]
    public string? Nombres { get; set; }


    [Required(ErrorMessage = "El apellido es obligatorio")]
    [Column("apellidos")]
    [StringLength(50)]
    public string? Apellidos { get; set; }


    [Required(ErrorMessage = "El registro medico es obligatorio")]
    [Column("registro_medico")]
    [StringLength(20)]
    public string? RegistroMedico { get; set; }


    [Required]
    [Column("id_especialidad")]
    public int? IdEspecialidad { get; set; }



    [ForeignKey(nameof(IdEspecialidad))]
    public Especialidades? Especialidades { get; set; }


}
