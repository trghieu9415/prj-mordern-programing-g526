using Mv.Application.Models;
using Mv.Application.Ports.Security;

namespace Mv.Infrastructure.Adapters.Security;

public class AuthService : IAuthService {
  public Task<AuthTokens> LoginAsync(string email, string password, UserRole role, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task<AuthTokens> RegisterAsync(User user, string password, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task<AuthTokens> RefreshAsync(string refreshToken, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task LogoutAsync(string refreshToken, bool revokeAll, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task<AuthTokens>
    ChangePasswordAsync(Guid userId, string oldPassword, string newPassword, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task RequestPasswordAsync(string email, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task ResetPasswordAsync(string email, string token, string newPassword, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task<bool> ValidateSecurityStampAsync(Guid userId, string tokenSecurityStamp, CancellationToken ct) {
    throw new NotImplementedException();
  }
}
