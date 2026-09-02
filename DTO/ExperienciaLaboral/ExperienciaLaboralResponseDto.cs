namespace PortafolioApi.DTOs.ExperienciaLaboral;

public class ExperienciaLaboralResponseDto
{
    public long Id { get; set; }
    public string Empresa { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool Actualmente { get; set; }
    public string? Ubicacion { get; set; }
    public int Orden { get; set; }
}