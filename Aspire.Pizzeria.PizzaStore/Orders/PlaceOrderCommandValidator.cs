using FluentValidation;

namespace Aspire.Pizzeria.PizzaStore.Orders;

public class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidator()
    {
        this.RuleFor(x => x.CustomerName).NotEmpty();
        this.RuleFor(x => x.DeliveryAddress).NotEmpty();
        this.RuleFor(x => x.PizzaIds).NotEmpty();
    }
}
