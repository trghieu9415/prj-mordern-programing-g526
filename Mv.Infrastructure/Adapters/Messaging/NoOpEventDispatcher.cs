using Mv.Application.Ports.Messaging;

namespace Mv.Infrastructure.Adapters.Messaging;

public class NoOpEventDispatcher : IEventDispatcher {
  public Task DispatchEventsAsync(CancellationToken ct = default) {
    return Task.CompletedTask;
  }
}
