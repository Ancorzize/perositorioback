using PortafolioApi.DTOs.Tecnologias;
using PortafolioApi.Mappers;
using PortafolioApi.Repositories;

namespace PortafolioApi.Services;

public class TecnologiaService : ITecnologiaService
{
    private readonly ITecnologiaRepository _repository;

    public TecnologiaService(ITecnologiaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TecnologiaResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(TecnologiaMapper.ToDto).ToList();
    }

    public async Task<TecnologiaResponseDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : TecnologiaMapper.ToDto(entity);
    }

    public async Task<TecnologiaResponseDto> CreateAsync(TecnologiaCreateDto dto)
    {
        var entity = TecnologiaMapper.ToEntity(dto);
        var created = await _repository.CreateAsync(entity);
        return TecnologiaMapper.ToDto(created);
    }

    public async Task<bool> UpdateAsync(long id, TecnologiaUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        TecnologiaMapper.UpdateEntity(entity, dto);
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