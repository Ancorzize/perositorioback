using PortafolioApi.DTOs.RedesSociales;

namespace PortafolioApi.Services;

public interface IRedSocialService
{
    Task<List<RedSocialResponseDto>> GetAllAsync();
    Task<RedSocialResponseDto?> GetByIdAsync(long id);
    Task<RedSocialResponseDto> CreateAsync(RedSocialCreateDto dto);
    Task<bool> UpdateAsync(long id, RedSocialUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}