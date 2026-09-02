using System.ComponentModel.DataAnnotations;

namespace PortafolioApi.DTOs.Tecnologias;

public class TecnologiaCreateDto
{
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Tipo { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Nivel { get; set; }

    public string? Descripcion { get; set; }

    [MaxLength(255)]
    public string? Icono { get; set; }

    public int Orden { get; set; }
}