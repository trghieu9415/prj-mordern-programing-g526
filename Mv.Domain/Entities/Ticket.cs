using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Ticket : BaseEntity {
  private Ticket() {}

  public Guid OrderId { get; private set; }
  public Order Order { get; private set; } = null!;

  public string AuditoriumName { get; private set; } = null!;

  public SeatSnapshot SeatSnapshot { get; private set; } = null!;
  public decimal Price { get; private set; }

  public static Ticket Create(
    Order order, string auditoriumName,
    Guid seatId, char row, int number
  ) {
    return new Ticket {
      OrderId = order.Id,
      Order = order,
      AuditoriumName = auditoriumName,
      SeatSnapshot = new SeatSnapshot(seatId, row, number)
    };
  }

  public Ticket SetPrice(decimal price) {
    Price = price;
    return this;
  }
}
