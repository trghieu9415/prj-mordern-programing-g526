using Microsoft.Extensions.DependencyInjection;
using Mv.Infrastructure.Services;
using Mv.Infrastructure.Services.Abstractions;

namespace Mv.Infrastructure.Extensions;

public static class AuthSupportExtensions {
  public static IServiceCollection AddAuthSupportServices(this IServiceCollection services) {
    services.AddScoped<IEmailService, EmailService>();
    return services;
  }
}
