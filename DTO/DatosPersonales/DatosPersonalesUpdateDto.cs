using System.ComponentModel.DataAnnotations;

namespace PortafolioApi.DTOs.DatosPersonales;

public class DatosPersonalesUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [EmailAddress]
    public string Correo { get; set; } = string.Empty;

    [MaxLength(30)]
    public string? Telefono { get; set; }

    [MaxLength(150)]
    public string? Ubicacion { get; set; }

    [MaxLength(150)]
    public string? Profesion { get; set; }

    public string? SobreMi { get; set; }

    public DateTime? FechaNacimiento { get; set; }
}