using Domain.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity {
  private readonly List<Ticket> _tickets = [];
  private Order() {}
  public Guid? CustomerId { get; private set; }
  public string CustomerName { get; private set; } = null!;
  public OrderStatus Status { get; private set; } = OrderStatus.Pending;
  public decimal TotalPrice { get; private set; }
  public IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

  public static Order Create(string name) {
    var order = new Order {
      CustomerName = name
    };

    return order;
  }
}
