using System.ComponentModel.DataAnnotations;

namespace PortafolioApi.DTOs.Estudios;

public class EstudioUpdateDto
{
    [Required]
    [MaxLength(150)]
    public string Institucion { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public bool Actualmente { get; set; }

    public int Orden { get; set; }
}