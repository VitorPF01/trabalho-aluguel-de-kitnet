using KitnetAluguel.Api.Data;
using KitnetAluguel.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(conn);
});

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IKitnetService, KitnetService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Garantir banco criado
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Middleware simples de erro
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { message = "Erro interno", detail = ex.Message });
    }
});

// Swagger sempre habilitado
app.UseSwagger();
app.UseSwaggerUI();

// Sem HTTPS redirection para evitar problemas de porta
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
