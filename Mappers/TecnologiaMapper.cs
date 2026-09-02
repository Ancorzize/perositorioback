using PortafolioApi.DTOs.Tecnologias;
using PortafolioApi.Models;

namespace PortafolioApi.Mappers;

public static class TecnologiaMapper
{
    public static Tecnologia ToEntity(TecnologiaCreateDto dto)
    {
        return new Tecnologia
        {
            Nombre = dto.Nombre,
            Tipo = dto.Tipo,
            Nivel = dto.Nivel,
            Descripcion = dto.Descripcion,
            Icono = dto.Icono,
            Orden = dto.Orden
        };
    }

    public static TecnologiaResponseDto ToDto(Tecnologia entity)
    {
        return new TecnologiaResponseDto
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Tipo = entity.Tipo,
            Nivel = entity.Nivel,
            Descripcion = entity.Descripcion,
            Icono = entity.Icono,
            Orden = entity.Orden
        };
    }

    public static void UpdateEntity(Tecnologia entity, TecnologiaUpdateDto dto)
    {
        entity.Nombre = dto.Nombre;
        entity.Tipo = dto.Tipo;
        entity.Nivel = dto.Nivel;
        entity.Descripcion = dto.Descripcion;
        entity.Icono = dto.Icono;
        entity.Orden = dto.Orden;
    }
}