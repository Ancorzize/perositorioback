using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public interface ITecnologiaRepository
{
    Task<List<Tecnologia>> GetAllAsync();
    Task<Tecnologia?> GetByIdAsync(long id);
    Task<Tecnologia> CreateAsync(Tecnologia entity);
    Task UpdateAsync(Tecnologia entity);
    Task DeleteAsync(Tecnologia entity);
}