using PortafolioApi.DTOs.DatosPersonales;
using PortafolioApi.Mappers;
using PortafolioApi.Repositories;

namespace PortafolioApi.Services;

public class DatosPersonalesService : IDatosPersonalesService
{
    private readonly IDatosPersonalesRepository _repository;

    public DatosPersonalesService(IDatosPersonalesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DatosPersonalesResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(DatosPersonalesMapper.ToDto).ToList();
    }

    public async Task<DatosPersonalesResponseDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : DatosPersonalesMapper.ToDto(entity);
    }

    public async Task<DatosPersonalesResponseDto> CreateAsync(DatosPersonalesCreateDto dto)
    {
        var entity = DatosPersonalesMapper.ToEntity(dto);
        var created = await _repository.CreateAsync(entity);
        return DatosPersonalesMapper.ToDto(created);
    }

    public async Task<bool> UpdateAsync(long id, DatosPersonalesUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        DatosPersonalesMapper.UpdateEntity(entity, dto);
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