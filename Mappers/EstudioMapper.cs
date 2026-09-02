using PortafolioApi.DTOs.Estudios;
using PortafolioApi.Models;

namespace PortafolioApi.Mappers;

public static class EstudioMapper
{
    public static Estudio ToEntity(EstudioCreateDto dto)
    {
        return new Estudio
        {
            Institucion = dto.Institucion,
            Titulo = dto.Titulo,
            Descripcion = dto.Descripcion,
            FechaInicio = dto.FechaInicio,
            FechaFin = dto.FechaFin,
            Actualmente = dto.Actualmente,
            Orden = dto.Orden
        };
    }

    public static EstudioResponseDto ToDto(Estudio entity)
    {
        return new EstudioResponseDto
        {
            Id = entity.Id,
            Institucion = entity.Institucion,
            Titulo = entity.Titulo,
            Descripcion = entity.Descripcion,
            FechaInicio = entity.FechaInicio,
            FechaFin = entity.FechaFin,
            Actualmente = entity.Actualmente,
            Orden = entity.Orden
        };
    }

    public static void UpdateEntity(Estudio entity, EstudioUpdateDto dto)
    {
        entity.Institucion = dto.Institucion;
        entity.Titulo = dto.Titulo;
        entity.Descripcion = dto.Descripcion;
        entity.FechaInicio = dto.FechaInicio;
        entity.FechaFin = dto.FechaFin;
        entity.Actualmente = dto.Actualmente;
        entity.Orden = dto.Orden;
    }
}