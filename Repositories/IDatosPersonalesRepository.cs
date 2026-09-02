using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public interface IDatosPersonalesRepository
{
    Task<List<DatosPersonales>> GetAllAsync();
    Task<DatosPersonales?> GetByIdAsync(long id);
    Task<DatosPersonales> CreateAsync(DatosPersonales entity);
    Task UpdateAsync(DatosPersonales entity);
    Task DeleteAsync(DatosPersonales entity);
}