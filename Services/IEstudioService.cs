using PortafolioApi.DTOs.Estudios;

namespace PortafolioApi.Services;

public interface IEstudioService
{
    Task<List<EstudioResponseDto>> GetAllAsync();
    Task<EstudioResponseDto?> GetByIdAsync(long id);
    Task<EstudioResponseDto> CreateAsync(EstudioCreateDto dto);
    Task<bool> UpdateAsync(long id, EstudioUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}