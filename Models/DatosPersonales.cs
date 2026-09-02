using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafolioApi.Models;

[Table("datos_personales")]
public class DatosPersonales
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [Column("correo")]
    public string Correo { get; set; } = string.Empty;

    [MaxLength(30)]
    [Column("telefono")]
    public string? Telefono { get; set; }

    [MaxLength(150)]
    [Column("ubicacion")]
    public string? Ubicacion { get; set; }

    [MaxLength(150)]
    [Column("profesion")]
    public string? Profesion { get; set; }

    [Column("sobre_mi")]
    public string? SobreMi { get; set; }

    [Column("fecha_nacimiento")]
    public DateTime? FechaNacimiento { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}