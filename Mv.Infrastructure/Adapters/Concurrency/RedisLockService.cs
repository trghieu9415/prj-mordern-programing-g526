using Mv.Application.Ports.Concurrency;

namespace Mv.Infrastructure.Adapters.Concurrency;

public class RedisLockService : IDistributedLockService {
  public Task<IDisposable?> AcquireLockAsync(string resourceKey, TimeSpan wait) {
    throw new NotImplementedException();
  }
}
