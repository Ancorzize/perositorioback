using PortafolioApi.DTOs.HojaVida;
using PortafolioApi.Services;

public class HojaVidaService : IHojaVidaService
{
    private readonly IDatosPersonalesService _datos;
    private readonly IEstudioService _estudios;
    private readonly IExperienciaLaboralService _experiencias;
    private readonly ITecnologiaService _tecnologias;
    private readonly IRedSocialService _redes;
    private readonly IFotoService _fotos;

    public HojaVidaService(
        IDatosPersonalesService datos,
        IEstudioService estudios,
        IExperienciaLaboralService experiencias,
        ITecnologiaService tecnologias,
        IRedSocialService redes,
        IFotoService fotos)
    {
        _datos = datos;
        _estudios = estudios;
        _experiencias = experiencias;
        _tecnologias = tecnologias;
        _redes = redes;
        _fotos = fotos;
    }

    public async Task<HojaVidaResponseDto> GetHojaVidaAsync()
    {
        var datos = await _datos.GetAllAsync();

        return new HojaVidaResponseDto
        {
            DatosPersonales = datos.FirstOrDefault(),
            Estudios = await _estudios.GetAllAsync(),
            Experiencias = await _experiencias.GetAllAsync(),
            Tecnologias = await _tecnologias.GetAllAsync(),
            Redes = await _redes.GetAllAsync(),
            Fotos = await _fotos.GetAllAsync()
        };
    }
}