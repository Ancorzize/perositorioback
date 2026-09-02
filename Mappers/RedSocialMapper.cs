using PortafolioApi.DTOs.RedesSociales;
using PortafolioApi.Models;

namespace PortafolioApi.Mappers;

public static class RedSocialMapper
{
    public static RedSocial ToEntity(RedSocialCreateDto dto)
    {
        return new RedSocial
        {
            Nombre = dto.Nombre,
            Url = dto.Url,
            Icono = dto.Icono,
            Usuario = dto.Usuario,
            Orden = dto.Orden
        };
    }

    public static RedSocialResponseDto ToDto(RedSocial entity)
    {
        return new RedSocialResponseDto
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Url = entity.Url,
            Icono = entity.Icono,
            Usuario = entity.Usuario,
            Orden = entity.Orden
        };
    }

    public static void UpdateEntity(RedSocial entity, RedSocialUpdateDto dto)
    {
        entity.Nombre = dto.Nombre;
        entity.Url = dto.Url;
        entity.Icono = dto.Icono;
        entity.Usuario = dto.Usuario;
        entity.Orden = dto.Orden;
    }
}