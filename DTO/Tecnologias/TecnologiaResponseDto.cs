namespace PortafolioApi.DTOs.Tecnologias;

public class TecnologiaResponseDto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string? Nivel { get; set; }
    public string? Descripcion { get; set; }
    public string? Icono { get; set; }
    public int Orden { get; set; }
}