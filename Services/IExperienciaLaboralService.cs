using PortafolioApi.DTOs.ExperienciaLaboral;

namespace PortafolioApi.Services;

public interface IExperienciaLaboralService
{
    Task<List<ExperienciaLaboralResponseDto>> GetAllAsync();
    Task<ExperienciaLaboralResponseDto?> GetByIdAsync(long id);
    Task<ExperienciaLaboralResponseDto> CreateAsync(ExperienciaLaboralCreateDto dto);
    Task<bool> UpdateAsync(long id, ExperienciaLaboralUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}