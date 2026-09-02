using PortafolioApi.DTOs.DatosPersonales;
using PortafolioApi.DTOs.Estudios;
using PortafolioApi.DTOs.ExperienciaLaboral;
using PortafolioApi.DTOs.Tecnologias;
using PortafolioApi.DTOs.RedesSociales;
using PortafolioApi.DTOs.Fotos;

namespace PortafolioApi.DTOs.HojaVida;

public class HojaVidaResponseDto
{
    public DatosPersonalesResponseDto? DatosPersonales { get; set; }

    public List<EstudioResponseDto> Estudios { get; set; } = new();
    public List<ExperienciaLaboralResponseDto> Experiencias { get; set; } = new();
    public List<TecnologiaResponseDto> Tecnologias { get; set; } = new();
    public List<RedSocialResponseDto> Redes { get; set; } = new();
    public List<FotoResponseDto> Fotos { get; set; } = new();
}