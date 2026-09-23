using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("citas")]
public class Citas
{
    [Key]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
    [Column("fecha_cita")]
    public DateTime FechaCita { get; set; }

    [Column("motivo")]
    [StringLength(200)]
    public string? Motivo { get; set; }

    [Column("estado_cita")]
    [StringLength(20)]
    public string? EstadoCita { get; set; } = "Pendiente";

    [Required]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Required]
    [Column("id_odontologo")]
    public int IdOdontologo { get; set; }

    [Required]
    [Column("id_consultorio")]
    public int IdConsultorio { get; set; }

    // Propiedades de navegación
    [ForeignKey(nameof(IdPaciente))]
    public Pacientes? Paciente { get; set; }

    [ForeignKey(nameof(IdOdontologo))]
    public Odontologos? Odontologo { get; set; }

    [ForeignKey(nameof(IdConsultorio))]
    public Consultorios? Consultorio { get; set; }
}