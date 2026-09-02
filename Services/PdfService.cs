
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using PortafolioApi.DTOs.HojaVida;

public class PdfService : IPdfService
{
    public byte[] GenerarPdfHojaVida(HojaVidaResponseDto data)
    {
        var foto = data.Fotos?
            .OrderByDescending(f => f.Principal)
            .ThenBy(f => f.Orden)
            .FirstOrDefault();

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(28);

                page.DefaultTextStyle(x =>
                    x.FontSize(10)
                     .FontFamily("Arial"));

                page.Content().Column(col =>
                {
                    col.Spacing(16);

                    col.Item().Row(row =>
                    {
                        row.ConstantItem(130).Column(left =>
                        {
                            left.Item()
                                .Width(115)
                                .Height(115)
                                .Background(Colors.Grey.Lighten3)
                                .Border(1)
                                .BorderColor(Colors.Blue.Lighten3)
                                .AlignCenter()
                                .AlignMiddle()
                                .Element(c =>
                                {
                                    var imageBytes = ObtenerImagenBase64(foto?.ContenidoBase64);

                                    if (imageBytes != null)
                                        c.Image(imageBytes).FitArea();
                                    else
                                        c.Text("Foto")
                                            .FontSize(11)
                                            .FontColor(Colors.Grey.Darken1);
                                });

                            left.Item().PaddingTop(12).Column(contact =>
                            {
                                Contacto(contact, "Correo", data.DatosPersonales?.Correo);

                                Contacto(contact, "Teléfono", data.DatosPersonales?.Telefono);

                                if (data.Redes != null && data.Redes.Any())
                                {
                                    contact.Item()
                                        .PaddingTop(10)
                                        .Text("Redes")
                                        .Bold()
                                        .FontColor(Colors.Blue.Darken3);

                                    foreach (var red in data.Redes.OrderBy(r => r.Orden))
                                    {
                                        contact.Item()
                                            .PaddingBottom(8)
                                            .Column(redItem =>
                                            {
                                                redItem.Item()
                                                    .Text(red.Nombre)
                                                    .Bold()
                                                    .FontSize(8.5f)
                                                    .FontColor(Colors.Blue.Darken3);

                                                redItem.Item()
                                                    .PaddingLeft(6)
                                                    .Text(red.Url)
                                                    .FontSize(8)
                                                    .FontColor(Colors.Grey.Darken2);
                                            });
                                    }
                                }
                            });
                        });

                        row.RelativeItem()
                            .PaddingLeft(18)
                            .Column(info =>
                            {
                                info.Item()
                                    .Text($"{data.DatosPersonales?.Nombre} {data.DatosPersonales?.Apellidos}")
                                    .FontSize(25)
                                    .Bold()
                                    .FontColor(Colors.Blue.Darken4);

                                info.Item()
                                    .Text(data.DatosPersonales?.Profesion ?? "")
                                    .FontSize(14)
                                    .SemiBold()
                                    .FontColor(Colors.Grey.Darken2);

                                info.Item()
                                    .PaddingVertical(8)
                                    .LineHorizontal(1)
                                    .LineColor(Colors.Blue.Lighten2);

                                info.Item()
                                    .Text("Perfil profesional")
                                    .FontSize(14)
                                    .Bold()
                                    .FontColor(Colors.Blue.Darken3);

                                info.Item()
                                    .PaddingTop(6)
                                    .Text(data.DatosPersonales?.SobreMi ?? "")
                                    .FontSize(10)
                                    .LineHeight(1.35f)
                                    .FontColor(Colors.Grey.Darken3);
                            });
                    });

                    Seccion(col, "Experiencia Laboral");

                    foreach (var exp in data.Experiencias ?? [])
                    {
                        col.Item()
                            .BorderLeft(3)
                            .BorderColor(Colors.Blue.Medium)
                            .PaddingLeft(10)
                            .PaddingBottom(10)
                            .Column(item =>
                            {
                                item.Item()
                                    .Text($"{exp.Cargo} - {exp.Empresa}")
                                    .Bold()
                                    .FontSize(12)
                                    .FontColor(Colors.Grey.Darken4);

                                item.Item()
                                    .PaddingTop(3)
                                    .Text(exp.Descripcion ?? "")
                                    .FontSize(9.5f)
                                    .LineHeight(1.3f)
                                    .FontColor(Colors.Grey.Darken2);
                                   
                            });
                    }

                    Seccion(col, "Educación");

                    foreach (var est in data.Estudios ?? [])
                    {
                        col.Item()
                            .PaddingBottom(4)
                            .Text($"{est.Titulo} - {est.Institucion}")
                            .FontSize(11)
                            .Bold()
                            .FontColor(Colors.Grey.Darken3);
                    }

                    Seccion(col, "Tecnologías");

                    col.Item()
                        .Background(Colors.Grey.Lighten4)
                        .Padding(10)
                        .Text(string.Join("  •  ", data.Tecnologias?.Select(t => t.Nombre) ?? []))
                        .FontSize(9.5f)
                        .LineHeight(1.2f)
                        .FontColor(Colors.Grey.Darken3);
                });
            });
        });

        return document.GeneratePdf();
    }

    private static void Contacto(ColumnDescriptor col, string titulo, string? valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            return;

        col.Item()
            .Text(titulo)
            .Bold()
            .FontSize(9)
            .FontColor(Colors.Blue.Darken3);

        col.Item()
            .PaddingBottom(6)
            .Text(valor)
            .FontSize(8.5f)
            .FontColor(Colors.Grey.Darken2);
    }

    private static void Seccion(ColumnDescriptor col, string titulo)
    {
        col.Item()
            .PaddingTop(8)
            .Column(section =>
            {
                section.Item()
                    .Text(titulo)
                    .FontSize(15)
                    .Bold()
                    .FontColor(Colors.Blue.Darken3);

                section.Item()
                    .PaddingTop(2)
                    .LineHorizontal(1)
                    .LineColor(Colors.Blue.Lighten3);
            });
    }

    private static byte[]? ObtenerImagenBase64(string? contenidoBase64)
    {
        if (string.IsNullOrWhiteSpace(contenidoBase64))
            return null;

        try
        {
            if (contenidoBase64.StartsWith("data:image"))
            {
                var base64 = contenidoBase64.Split(',')[1];
                return Convert.FromBase64String(base64);
            }

            return Convert.FromBase64String(contenidoBase64);
        }
        catch
        {
            return null;
        }
    }
}

