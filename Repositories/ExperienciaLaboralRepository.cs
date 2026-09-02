using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Models;

namespace PortafolioApi.Repositories;

public class ExperienciaLaboralRepository : IExperienciaLaboralRepository
{
    private readonly PortafolioDbContext _context;

    public ExperienciaLaboralRepository(PortafolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExperienciaLaboral>> GetAllAsync()
    {
        return await _context.ExperienciasLaborales
            .OrderBy(x => x.Orden)
            .ThenByDescending(x => x.FechaInicio)
            .ToListAsync();
    }

    public async Task<ExperienciaLaboral?> GetByIdAsync(long id)
    {
        return await _context.ExperienciasLaborales.FindAsync(id);
    }

    public async Task<ExperienciaLaboral> CreateAsync(ExperienciaLaboral entity)
    {
        _context.ExperienciasLaborales.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(ExperienciaLaboral entity)
    {
        _context.ExperienciasLaborales.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ExperienciaLaboral entity)
    {
        _context.ExperienciasLaborales.Remove(entity);
        await _context.SaveChangesAsync();
    }
}