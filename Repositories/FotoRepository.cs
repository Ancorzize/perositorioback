using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public class FotoRepository : IFotoRepository
{
    private readonly PortafolioDbContext _context;

    public FotoRepository(PortafolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Foto>> GetAllAsync()
    {
        return await _context.Fotos
            .OrderBy(x => x.Orden)
            .ThenByDescending(x => x.Principal)
            .ToListAsync();
    }

    public async Task<Foto?> GetByIdAsync(long id)
    {
        return await _context.Fotos.FindAsync(id);
    }

    public async Task<Foto> CreateAsync(Foto entity)
    {
        _context.Fotos.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Foto entity)
    {
        _context.Fotos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Foto entity)
    {
        _context.Fotos.Remove(entity);
        await _context.SaveChangesAsync();
    }
}