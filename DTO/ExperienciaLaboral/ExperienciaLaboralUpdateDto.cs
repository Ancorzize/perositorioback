using System.ComponentModel.DataAnnotations;

namespace PortafolioApi.DTOs.ExperienciaLaboral;

public class ExperienciaLaboralUpdateDto
{
    [Required]
    [MaxLength(150)]
    public string Empresa { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Cargo { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    [Required]
    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public bool Actualmente { get; set; }

    [MaxLength(150)]
    public string? Ubicacion { get; set; }

    public int Orden { get; set; }
}