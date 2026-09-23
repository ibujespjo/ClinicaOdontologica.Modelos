using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("historialesmedicos")]
public class HistorialesMedicos
{
    [Key]
    [Column("id_historial")]
    public int IdHistorial { get; set; }

    [Column("alergias")]
    [StringLength(200)]
    public string? Alergias { get; set; } = "Ninguna";

    [Column("enfermedades_previas")]
    [StringLength(200)]
    public string? EnfermedadesPrevias { get; set; } = "Ninguna";

    [Column("tipo_sangre")]
    [StringLength(5)]
    public string? TipoSangre { get; set; }

    [Required]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [ForeignKey(nameof(IdPaciente))]
    public Pacientes? Paciente { get; set; }
}