namespace PortafolioApi.DTOs.Estudios;

public class EstudioResponseDto
{
    public long Id { get; set; }
    public string Institucion { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool Actualmente { get; set; }
    public int Orden { get; set; }
}