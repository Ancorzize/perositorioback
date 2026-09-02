namespace PortafolioApi.DTOs.Fotos;

public class FotoResponseDto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string ContenidoBase64 { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Principal { get; set; }
    public int Orden { get; set; }
}