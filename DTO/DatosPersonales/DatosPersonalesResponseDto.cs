namespace PortafolioApi.DTOs.DatosPersonales;

public class DatosPersonalesResponseDto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Ubicacion { get; set; }
    public string? Profesion { get; set; }
    public string? SobreMi { get; set; }
    public DateTime? FechaNacimiento { get; set; }
}