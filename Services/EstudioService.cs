using PortafolioApi.DTOs.Estudios;
using PortafolioApi.Mappers;
using PortafolioApi.Repositories;

namespace PortafolioApi.Services;

public class EstudioService : IEstudioService
{
    private readonly IEstudioRepository _repository;

    public EstudioService(IEstudioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EstudioResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(EstudioMapper.ToDto).ToList();
    }

    public async Task<EstudioResponseDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : EstudioMapper.ToDto(entity);
    }

    public async Task<EstudioResponseDto> CreateAsync(EstudioCreateDto dto)
    {
        var entity = EstudioMapper.ToEntity(dto);
        var created = await _repository.CreateAsync(entity);
        return EstudioMapper.ToDto(created);
    }

    public async Task<bool> UpdateAsync(long id, EstudioUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        EstudioMapper.UpdateEntity(entity, dto);
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