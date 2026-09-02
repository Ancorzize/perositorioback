using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public interface IFotoRepository
{
    Task<List<Foto>> GetAllAsync();
    Task<Foto?> GetByIdAsync(long id);
    Task<Foto> CreateAsync(Foto entity);
    Task UpdateAsync(Foto entity);
    Task DeleteAsync(Foto entity);
}