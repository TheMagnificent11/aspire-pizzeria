using Lewee.Domain;

namespace Aspire.Pizzeria.Domain;

public sealed class OrderPreparedEvent : DomainEvent
{
    public OrderPreparedEvent(Guid orderId, string userId, DateTime eventDateTime)
        : base()
    {
        this.OrderId = orderId;
        this.UserId = userId;
        this.EventDateTime = eventDateTime;
    }

    public Guid OrderId { get; }
    public DateTime EventDateTime { get; }
}
