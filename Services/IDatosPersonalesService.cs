using PortafolioApi.DTOs.DatosPersonales;

namespace PortafolioApi.Services;

public interface IDatosPersonalesService
{
    Task<List<DatosPersonalesResponseDto>> GetAllAsync();
    Task<DatosPersonalesResponseDto?> GetByIdAsync(long id);
    Task<DatosPersonalesResponseDto> CreateAsync(DatosPersonalesCreateDto dto);
    Task<bool> UpdateAsync(long id, DatosPersonalesUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}