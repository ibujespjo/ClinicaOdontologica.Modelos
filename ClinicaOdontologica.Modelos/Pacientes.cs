using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("pacientes")]
public class Pacientes
{
    [Key]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio")]
    [Column("dni")]
    [StringLength(10)]
    public string? Dni { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column("nombres")]
    [StringLength(50)]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [Column("apellidos")]
    [StringLength(50)]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [Column("fecha_nacimiento", TypeName = "date")]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El email es obligatorio")]
    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("telefono")]
    [StringLength(15)]
    public string? Telefono { get; set; }

    public HistorialesMedicos? HistorialMedico { get; set; }
}