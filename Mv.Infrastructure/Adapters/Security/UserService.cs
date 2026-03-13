using Mv.Application.Models;
using Mv.Application.Ports.Security;

namespace Mv.Infrastructure.Adapters.Security;

public class UserService : IUserService {
  public Task<User?> GetByIdAsync(Guid id, UserRole? role, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task<(int total, List<User> users)> GetAsync(UserRole? role, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task<(int total, List<User> users)> GetDeletedAsync(UserRole? role, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task<Guid> CreateAsync(User user, string password, UserRole role, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(User user, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(Guid id, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task RestoreAsync(Guid id, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task LockAsync(Guid id, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task UnlockAsync(Guid id, CancellationToken ct = default) {
    throw new NotImplementedException();
  }
}
