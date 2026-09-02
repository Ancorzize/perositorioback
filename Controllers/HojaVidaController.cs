using Microsoft.AspNetCore.Mvc;
using PortafolioApi.Services;

[ApiController]
[Route("api/[controller]")]
public class HojaVidaController : ControllerBase
{
    private readonly IHojaVidaService _service;
    private readonly IPdfService _pdfService;

    public HojaVidaController(IHojaVidaService service, IPdfService pdfService)
    {
        _service = service;
        _pdfService = pdfService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetHojaVidaAsync();
        return Ok(result);
    }

    [HttpGet("pdf")]
    public async Task<IActionResult> GetPdf()
    {
        var data = await _service.GetHojaVidaAsync();
        var pdf = _pdfService.GenerarPdfHojaVida(data);

        return File(pdf, "application/pdf", "HojaVida.pdf");
    }
}