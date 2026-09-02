using PortafolioApi.DTOs.RedesSociales;
using PortafolioApi.Mappers;
using PortafolioApi.Repositories;

namespace PortafolioApi.Services;

public class RedSocialService : IRedSocialService
{
    private readonly IRedSocialRepository _repository;

    public RedSocialService(IRedSocialRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RedSocialResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(RedSocialMapper.ToDto).ToList();
    }

    public async Task<RedSocialResponseDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : RedSocialMapper.ToDto(entity);
    }

    public async Task<RedSocialResponseDto> CreateAsync(RedSocialCreateDto dto)
    {
        var entity = RedSocialMapper.ToEntity(dto);
        var created = await _repository.CreateAsync(entity);
        return RedSocialMapper.ToDto(created);
    }

    public async Task<bool> UpdateAsync(long id, RedSocialUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        RedSocialMapper.UpdateEntity(entity, dto);
        entity.UpdatedAt = DateTime.Now;

        await _repository.UpdateAsync(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}