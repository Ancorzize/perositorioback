using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafolioApi.Models;

[Table("tecnologias")]
public class Tecnologia
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("nivel")]
    public string? Nivel { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [MaxLength(255)]
    [Column("icono")]
    public string? Icono { get; set; }

    [Column("orden")]
    public int Orden { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}