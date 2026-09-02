using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public class EstudioRepository : IEstudioRepository
{
    private readonly PortafolioDbContext _context;

    public EstudioRepository(PortafolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Estudio>> GetAllAsync()
    {
        return await _context.Estudios
            .OrderBy(x => x.Orden)
            .ThenByDescending(x => x.FechaFin)
            .ToListAsync();
    }

    public async Task<Estudio?> GetByIdAsync(long id)
    {
        return await _context.Estudios.FindAsync(id);
    }

    public async Task<Estudio> CreateAsync(Estudio entity)
    {
        _context.Estudios.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Estudio entity)
    {
        _context.Estudios.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Estudio entity)
    {
        _context.Estudios.Remove(entity);
        await _context.SaveChangesAsync();
    }
}