using PortafolioApi.DTOs.ExperienciaLaboral;
using PortafolioApi.Mappers;
using PortafolioApi.Repositories;

namespace PortafolioApi.Services;

public class ExperienciaLaboralService : IExperienciaLaboralService
{
    private readonly IExperienciaLaboralRepository _repository;

    public ExperienciaLaboralService(IExperienciaLaboralRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ExperienciaLaboralResponseDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(ExperienciaLaboralMapper.ToDto).ToList();
    }

    public async Task<ExperienciaLaboralResponseDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : ExperienciaLaboralMapper.ToDto(entity);
    }

    public async Task<ExperienciaLaboralResponseDto> CreateAsync(ExperienciaLaboralCreateDto dto)
    {
        var entity = ExperienciaLaboralMapper.ToEntity(dto);
        var created = await _repository.CreateAsync(entity);
        return ExperienciaLaboralMapper.ToDto(created);
    }

    public async Task<bool> UpdateAsync(long id, ExperienciaLaboralUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        ExperienciaLaboralMapper.UpdateEntity(entity, dto);
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