using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public interface IEstudioRepository
{
    Task<List<Estudio>> GetAllAsync();
    Task<Estudio?> GetByIdAsync(long id);
    Task<Estudio> CreateAsync(Estudio entity);
    Task UpdateAsync(Estudio entity);
    Task DeleteAsync(Estudio entity);
}