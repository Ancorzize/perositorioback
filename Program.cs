using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Repositories;
using PortafolioApi.Services;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// BASE DE DATOS
// ==========================================

var connectionString =
    builder.Configuration["DATABASE_URL"]
    ?? builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "No se encontró la cadena de conexión."
    );

builder.Services.AddDbContext<PortafolioDbContext>(options =>
    options.UseNpgsql(connectionString)
);


// ==========================================
// REPOSITORIES
// ==========================================

builder.Services.AddScoped<IDatosPersonalesRepository, DatosPersonalesRepository>();
builder.Services.AddScoped<IExperienciaLaboralRepository, ExperienciaLaboralRepository>();
builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<ITecnologiaRepository, TecnologiaRepository>();
builder.Services.AddScoped<IRedSocialRepository, RedSocialRepository>();
builder.Services.AddScoped<IFotoRepository, FotoRepository>();


// ==========================================
// SERVICES
// ==========================================

builder.Services.AddScoped<IDatosPersonalesService, DatosPersonalesService>();
builder.Services.AddScoped<IExperienciaLaboralService, ExperienciaLaboralService>();
builder.Services.AddScoped<IEstudioService, EstudioService>();
builder.Services.AddScoped<ITecnologiaService, TecnologiaService>();
builder.Services.AddScoped<IRedSocialService, RedSocialService>();
builder.Services.AddScoped<IFotoService, FotoService>();

builder.Services.AddScoped<IHojaVidaService, HojaVidaService>();
builder.Services.AddScoped<IPdfService, PdfService>();


// ==========================================
// CONTROLLERS / SWAGGER
// ==========================================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ==========================================
// CORS
// ==========================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// ==========================================
// QUEST PDF
// ==========================================

QuestPDF.Settings.License = LicenseType.Community;


// ==========================================
// BUILD APP
// ==========================================

var app = builder.Build();


// ==========================================
// PUERTO RAILWAY
// ==========================================

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

app.Urls.Add($"http://0.0.0.0:{port}");


// ==========================================
// MIDDLEWARE
// ==========================================

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();


// ==========================================
// RUN
// ==========================================

app.Run();