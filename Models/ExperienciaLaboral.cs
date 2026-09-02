using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafolioApi.Models;

[Table("experiencia_laboral")]
public class ExperienciaLaboral
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [MaxLength(150)]
    [Column("empresa")]
    public string Empresa { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [Column("cargo")]
    public string Cargo { get; set; } = string.Empty;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Required]
    [Column("fecha_inicio")]
    public DateTime FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateTime? FechaFin { get; set; }

    [Column("actualmente")]
    public bool Actualmente { get; set; }

    [MaxLength(150)]
    [Column("ubicacion")]
    public string? Ubicacion { get; set; }

    [Column("orden")]
    public int Orden { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}