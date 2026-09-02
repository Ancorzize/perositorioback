using PortafolioApi.DTOs.Fotos;
using PortafolioApi.Mappers;
using PortafolioApi.Repositories;

namespace PortafolioApi.Services;

public class FotoService : IFotoService
{
    private readonly IFotoRepository _repository;

    public FotoService(IFotoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FotoResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(FotoMapper.ToDto).ToList();
    }

    public async Task<FotoResponseDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : FotoMapper.ToDto(entity);
    }

    public async Task<FotoResponseDto> CreateAsync(FotoCreateDto dto)
    {
        var entity = FotoMapper.ToEntity(dto);
        var created = await _repository.CreateAsync(entity);
        return FotoMapper.ToDto(created);
    }

    public async Task<bool> UpdateAsync(long id, FotoUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        FotoMapper.UpdateEntity(entity, dto);
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