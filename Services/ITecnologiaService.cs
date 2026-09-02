using PortafolioApi.DTOs.Tecnologias;

namespace PortafolioApi.Services;

public interface ITecnologiaService
{
    Task<List<TecnologiaResponseDto>> GetAllAsync();
    Task<TecnologiaResponseDto?> GetByIdAsync(long id);
    Task<TecnologiaResponseDto> CreateAsync(TecnologiaCreateDto dto);
    Task<bool> UpdateAsync(long id, TecnologiaUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}