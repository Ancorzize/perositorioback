using Microsoft.EntityFrameworkCore;
using PortafolioApi.Data;
using PortafolioApi.Repositories;
using PortafolioApi.Services;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? $"Host={builder.Configuration["PGHOST"]};" +
       $"Port={builder.Configuration["PGPORT"]};" +
       $"Database={builder.Configuration["PGDATABASE"]};" +
       $"Username={builder.Configuration["PGUSER"]};" +
       $"Password={builder.Configuration["PGPASSWORD"]};" +
       $"SSL Mode=Require;Trust Server Certificate=true";

builder.Services.AddDbContext<PortafolioDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IDatosPersonalesRepository, DatosPersonalesRepository>();
builder.Services.AddScoped<IDatosPersonalesService, DatosPersonalesService>();
builder.Services.AddScoped<IExperienciaLaboralRepository, ExperienciaLaboralRepository>();
builder.Services.AddScoped<IExperienciaLaboralService, ExperienciaLaboralService>();
builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<IEstudioService, EstudioService>();
builder.Services.AddScoped<ITecnologiaRepository, TecnologiaRepository>();
builder.Services.AddScoped<ITecnologiaService, TecnologiaService>();
builder.Services.AddScoped<IRedSocialRepository, RedSocialRepository>();
builder.Services.AddScoped<IRedSocialService, RedSocialService>();
builder.Services.AddScoped<IFotoRepository, FotoRepository>();
builder.Services.AddScoped<IFotoService, FotoService>();
builder.Services.AddScoped<IHojaVidaService, HojaVidaService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                    "http://localhost:5173",
                    "https://portafoliofront-production.up.railway.app"
                )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
app.UseCors("AllowFrontend");
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();