using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure;

public static class DiInfrastructure
{
    public static void AddInfrastructureDi(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));

        builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config));
    }
}