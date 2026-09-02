using System.ComponentModel.DataAnnotations;

namespace PortafolioApi.DTOs.RedesSociales;

public class RedSocialUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    [Url]
    public string Url { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Icono { get; set; }

    [MaxLength(100)]
    public string? Usuario { get; set; }

    public int Orden { get; set; }
}