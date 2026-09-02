using PortafolioApi.DTOs.DatosPersonales;
using PortafolioApi.Models;

namespace PortafolioApi.Mappers;

public static class DatosPersonalesMapper
{
    public static DatosPersonales ToEntity(DatosPersonalesCreateDto dto)
    {
        return new DatosPersonales
        {
            Nombre = dto.Nombre,
            Apellidos = dto.Apellidos,
            Correo = dto.Correo,
            Telefono = dto.Telefono,
            Ubicacion = dto.Ubicacion,
            Profesion = dto.Profesion,
            SobreMi = dto.SobreMi,
            FechaNacimiento = dto.FechaNacimiento
        };
    }

    public static DatosPersonalesResponseDto ToDto(DatosPersonales entity)
    {
        return new DatosPersonalesResponseDto
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Apellidos = entity.Apellidos,
            Correo = entity.Correo,
            Telefono = entity.Telefono,
            Ubicacion = entity.Ubicacion,
            Profesion = entity.Profesion,
            SobreMi = entity.SobreMi,
            FechaNacimiento = entity.FechaNacimiento
        };
    }

    public static void UpdateEntity(DatosPersonales entity, DatosPersonalesUpdateDto dto)
    {
        entity.Nombre = dto.Nombre;
        entity.Apellidos = dto.Apellidos;
        entity.Correo = dto.Correo;
        entity.Telefono = dto.Telefono;
        entity.Ubicacion = dto.Ubicacion;
        entity.Profesion = dto.Profesion;
        entity.SobreMi = dto.SobreMi;
        entity.FechaNacimiento = dto.FechaNacimiento;
    }
}