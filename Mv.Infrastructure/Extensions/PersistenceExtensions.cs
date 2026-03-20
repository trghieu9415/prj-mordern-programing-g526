using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mv.Application.Abstractions;
using Mv.Application.Ports.Messaging;
using Mv.Infrastructure.Adapters.Messaging;
using Mv.Infrastructure.Persistence;

namespace Mv.Infrastructure.Extensions;

public static class PersistenceExtensions {
  public static IServiceCollection AddPostgresPersistence(this IServiceCollection services, IConfiguration config) {
    var connectionString = config.GetConnectionString("DefaultConnection")
      ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    services.AddDbContext<AppDbContext>(options =>
      options.UseNpgsql(connectionString)
    );

    services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());
    services.AddScoped<IEventDispatcher, NoOpEventDispatcher>();
    return services;
  }
}
