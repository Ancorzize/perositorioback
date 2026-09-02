using PortafolioApi.DTOs.HojaVida;

public interface IHojaVidaService
{
    Task<HojaVidaResponseDto> GetHojaVidaAsync();
}