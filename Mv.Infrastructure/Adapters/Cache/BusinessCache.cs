using Mv.Application.DTOs;
using Mv.Application.Ports.Cache;

namespace Mv.Infrastructure.Adapters.Cache;

public class BusinessCache : IBusinessCache {
  public Task<PlanDto?> GetCurrentPlanAsync(CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task<AuditoriumDto?> GetAuditoriumAsync(Guid id, CancellationToken ct) {
    throw new NotImplementedException();
  }

  public Task<ListingDto?> GetListingAsync(Guid id, CancellationToken ct) {
    throw new NotImplementedException();
  }
}
