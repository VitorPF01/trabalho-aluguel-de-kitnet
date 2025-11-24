
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Camada de Serviço
builder.Services.AddScoped<IKitnetService, KitnetService>();

// Configuração dos Controllers
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativar o Swagger na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
