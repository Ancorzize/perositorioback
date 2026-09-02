using System.ComponentModel.DataAnnotations;

namespace PortafolioApi.DTOs.Fotos;

public class FotoCreateDto
{
    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Tipo { get; set; } = string.Empty;

    [Required]
    public string ContenidoBase64 { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string MimeType { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public bool Principal { get; set; }

    public int Orden { get; set; }
}