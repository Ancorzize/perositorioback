using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public class DatosPersonalesRepository : IDatosPersonalesRepository
{
    private readonly PortafolioDbContext _context;

    public DatosPersonalesRepository(PortafolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<DatosPersonales>> GetAllAsync()
    {
        return await _context.DatosPersonales
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<DatosPersonales?> GetByIdAsync(long id)
    {
        return await _context.DatosPersonales.FindAsync(id);
    }

    public async Task<DatosPersonales> CreateAsync(DatosPersonales entity)
    {
        _context.DatosPersonales.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(DatosPersonales entity)
    {
        _context.DatosPersonales.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(DatosPersonales entity)
    {
        _context.DatosPersonales.Remove(entity);
        await _context.SaveChangesAsync();
    }
}