using MediatR;
using Mv.Application.Exceptions;
using Mv.Application.Models;
using Mv.Application.Ports.Security;
using Mv.Application.Repositories;
using Mv.Domain.Entities;

namespace Mv.Application.UseCases.System.MarkOrderAsPaid;

public class MarkOrderAsPaidHandler(
  IRepository<Order> orderRepository,
  IUserService userService
) : IRequestHandler<MarkOrderAsPaidCommand, bool> {
  public async Task<bool> Handle(MarkOrderAsPaidCommand request, CancellationToken ct) {
    var order =
      await orderRepository.GetByIdAsync(request.Id, ct)
      ?? throw new WorkflowException("Đơn hàng không tồn tại", 404);

    var user =
      await userService.GetByIdAsync(order.CustomerId, UserRole.Customer, ct)
      ?? throw new WorkflowException("Người dùng không tồn tại", 404);

    order.MarkAsPaid(user.Email);
    await orderRepository.UpdateAsync(order, ct);
    return true;
  }
}
