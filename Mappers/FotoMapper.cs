using PortafolioApi.DTOs.Fotos;
using PortafolioApi.Models;

namespace PortafolioApi.Mappers;

public static class FotoMapper
{
    public static Foto ToEntity(FotoCreateDto dto)
    {
        return new Foto
        {
            Nombre = dto.Nombre,
            Tipo = dto.Tipo,
            ContenidoBase64 = dto.ContenidoBase64,
            MimeType = dto.MimeType,
            Descripcion = dto.Descripcion,
            Principal = dto.Principal,
            Orden = dto.Orden
        };
    }

    public static FotoResponseDto ToDto(Foto entity)
    {
        return new FotoResponseDto
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Tipo = entity.Tipo,
            ContenidoBase64 = entity.ContenidoBase64,
            MimeType = entity.MimeType,
            Descripcion = entity.Descripcion,
            Principal = entity.Principal,
            Orden = entity.Orden
        };
    }

    public static void UpdateEntity(Foto entity, FotoUpdateDto dto)
    {
        entity.Nombre = dto.Nombre;
        entity.Tipo = dto.Tipo;
        entity.ContenidoBase64 = dto.ContenidoBase64;
        entity.MimeType = dto.MimeType;
        entity.Descripcion = dto.Descripcion;
        entity.Principal = dto.Principal;
        entity.Orden = dto.Orden;
    }
}