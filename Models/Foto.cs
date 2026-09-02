using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafolioApi.Models;

[Table("fotos")]
public class Foto
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [MaxLength(150)]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [Required]
    [Column("contenido_base64")]
    public string ContenidoBase64 { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("principal")]
    public bool Principal { get; set; }

    [Column("orden")]
    public int Orden { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}