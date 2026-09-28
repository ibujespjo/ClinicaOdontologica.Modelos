using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ClinicaOdontologicaAPIContext") ?? throw new InvalidOperationException("Connection string 'ClinicaOdontologicaAPIContext' not found.");

builder.Services.AddDbContext<ClinicaOdontologicaAPIContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
// Se agrega la opción para ignorar referencias circulares en el JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();