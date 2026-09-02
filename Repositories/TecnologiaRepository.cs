using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public class TecnologiaRepository : ITecnologiaRepository
{
    private readonly PortafolioDbContext _context;

    public TecnologiaRepository(PortafolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tecnologia>> GetAllAsync()
    {
        return await _context.Tecnologias
            .OrderBy(x => x.Orden)
            .ThenBy(x => x.Nombre)
            .ToListAsync();
    }

    public async Task<Tecnologia?> GetByIdAsync(long id)
    {
        return await _context.Tecnologias.FindAsync(id);
    }

    public async Task<Tecnologia> CreateAsync(Tecnologia entity)
    {
        _context.Tecnologias.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Tecnologia entity)
    {
        _context.Tecnologias.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tecnologia entity)
    {
        _context.Tecnologias.Remove(entity);
        await _context.SaveChangesAsync();
    }
}