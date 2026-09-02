using PortafolioApi.DTOs.Fotos;

namespace PortafolioApi.Services;

public interface IFotoService
{
    Task<List<FotoResponseDto>> GetAllAsync();
    Task<FotoResponseDto?> GetByIdAsync(long id);
    Task<FotoResponseDto> CreateAsync(FotoCreateDto dto);
    Task<bool> UpdateAsync(long id, FotoUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}