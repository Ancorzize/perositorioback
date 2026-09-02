using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafolioApi.Models;

[Table("redes_sociales")]
public class RedSocial
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    [Column("url")]
    public string Url { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column("icono")]
    public string? Icono { get; set; }

    [MaxLength(100)]
    [Column("usuario")]
    public string? Usuario { get; set; }

    [Column("orden")]
    public int Orden { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}