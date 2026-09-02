namespace PortafolioApi.DTOs.RedesSociales;

public class RedSocialResponseDto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string? Icono { get; set; }
    public string? Usuario { get; set; }
    public int Orden { get; set; }
}