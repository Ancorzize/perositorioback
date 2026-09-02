using PortafolioApi.DTOs.ExperienciaLaboral;
using PortafolioApi.Models;

namespace PortafolioApi.Mappers;

public static class ExperienciaLaboralMapper
{
    public static ExperienciaLaboral ToEntity(ExperienciaLaboralCreateDto dto)
    {
        return new ExperienciaLaboral
        {
            Empresa = dto.Empresa,
            Cargo = dto.Cargo,
            Descripcion = dto.Descripcion,
            FechaInicio = dto.FechaInicio,
            FechaFin = dto.FechaFin,
            Actualmente = dto.Actualmente,
            Ubicacion = dto.Ubicacion,
            Orden = dto.Orden
        };
    }

    public static ExperienciaLaboralResponseDto ToDto(ExperienciaLaboral entity)
    {
        return new ExperienciaLaboralResponseDto
        {
            Id = entity.Id,
            Empresa = entity.Empresa,
            Cargo = entity.Cargo,
            Descripcion = entity.Descripcion,
            FechaInicio = entity.FechaInicio,
            FechaFin = entity.FechaFin,
            Actualmente = entity.Actualmente,
            Ubicacion = entity.Ubicacion,
            Orden = entity.Orden
        };
    }

    public static void UpdateEntity(ExperienciaLaboral entity, ExperienciaLaboralUpdateDto dto)
    {
        entity.Empresa = dto.Empresa;
        entity.Cargo = dto.Cargo;
        entity.Descripcion = dto.Descripcion;
        entity.FechaInicio = dto.FechaInicio;
        entity.FechaFin = dto.FechaFin;
        entity.Actualmente = dto.Actualmente;
        entity.Ubicacion = dto.Ubicacion;
        entity.Orden = dto.Orden;
    }
}