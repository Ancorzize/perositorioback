using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public class RedSocialRepository : IRedSocialRepository
{
    private readonly PortafolioDbContext _context;

    public RedSocialRepository(PortafolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<RedSocial>> GetAllAsync()
    {
        return await _context.RedesSociales
            .OrderBy(x => x.Orden)
            .ThenBy(x => x.Nombre)
            .ToListAsync();
    }

    public async Task<RedSocial?> GetByIdAsync(long id)
    {
        return await _context.RedesSociales.FindAsync(id);
    }

    public async Task<RedSocial> CreateAsync(RedSocial entity)
    {
        _context.RedesSociales.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(RedSocial entity)
    {
        _context.RedesSociales.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RedSocial entity)
    {
        _context.RedesSociales.Remove(entity);
        await _context.SaveChangesAsync();
    }
}