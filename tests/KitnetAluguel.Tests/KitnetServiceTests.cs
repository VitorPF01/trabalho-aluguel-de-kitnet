using System;
using System.Threading.Tasks;
using KitnetAluguel.Api.Data;
using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KitnetAluguel.Tests;

public class KitnetServiceTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("KitnetTestDb_" + Guid.NewGuid())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateAsync_ValidData_CreatesKitnet()
    {
        using var ctx = CreateContext();
        var service = new KitnetService(ctx);

        var req = new KitnetCreateRequest("K1", "Rua A", 700m, 25);
        var result = await service.CreateAsync(req);

        Assert.NotEqual(0, result.Id);
        Assert.Equal("K1", result.Code);
    }

    [Fact]
    public async Task CreateAsync_InvalidRent_Throws()
    {
        using var ctx = CreateContext();
        var service = new KitnetService(ctx);

        var req = new KitnetCreateRequest("K2", "Rua B", 0m, 20);
        await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(req));
    }
}
