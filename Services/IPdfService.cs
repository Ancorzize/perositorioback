using PortafolioApi.DTOs.HojaVida;

public interface IPdfService
{
    byte[] GenerarPdfHojaVida(HojaVidaResponseDto data);
}
