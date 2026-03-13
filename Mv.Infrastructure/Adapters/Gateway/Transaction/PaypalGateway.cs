using Mv.Application.Ports.Gateway;
using Mv.Domain.Entities;

namespace Mv.Infrastructure.Adapters.Gateway.Transaction;

public class PaypalGateway : IPaymentGateway {
  public Task<string> CreatePaymentUrl(Payment payment, Order order, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task<(bool isSucceed, string transactionId)> VerifyPayment(GatewayPayload payload,
    CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public Task<bool> RefundPayment(Payment payment, CancellationToken ct = default) {
    throw new NotImplementedException();
  }

  public GatewayPayload ToGatewayPayload(object payload) {
    throw new NotImplementedException();
  }
}
