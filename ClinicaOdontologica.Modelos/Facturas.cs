using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaOdontologica.Modelos;

[Table("facturas")]
public class Facturas
{
    [Key]
    [Column("id_factura")]
    public int IdFactura { get; set; }

    [Required(ErrorMessage = "La fecha de emisión es obligatoria")]
    [Column("fecha_emision")]
    public DateTime FechaEmision { get; set; }

    [Required(ErrorMessage = "El subtotal es obligatorio")]
    [Column("subtotal", TypeName = "numeric(10, 2)")]
    public decimal Subtotal { get; set; }

    [Required(ErrorMessage = "Los impuestos son obligatorios")]
    [Column("impuestos", TypeName = "numeric(10, 2)")]
    public decimal Impuestos { get; set; }

    [Required(ErrorMessage = "El total es obligatorio")]
    [Column("total", TypeName = "numeric(10, 2)")]
    public decimal Total { get; set; }

    [Column("estado_pago")]
    [StringLength(20)]
    public string? EstadoPago { get; set; } = "Pendiente";

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [ForeignKey(nameof(IdCita))]
    public Citas? Cita { get; set; }
}