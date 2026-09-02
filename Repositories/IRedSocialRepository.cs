using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public interface IRedSocialRepository
{
    Task<List<RedSocial>> GetAllAsync();
    Task<RedSocial?> GetByIdAsync(long id);
    Task<RedSocial> CreateAsync(RedSocial entity);
    Task UpdateAsync(RedSocial entity);
    Task DeleteAsync(RedSocial entity);
}