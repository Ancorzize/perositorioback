using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public interface IExperienciaLaboralRepository
{
    Task<List<ExperienciaLaboral>> GetAllAsync();
    Task<ExperienciaLaboral?> GetByIdAsync(long id);
    Task<ExperienciaLaboral> CreateAsync(ExperienciaLaboral entity);
    Task UpdateAsync(ExperienciaLaboral entity);
    Task DeleteAsync(ExperienciaLaboral entity);
}