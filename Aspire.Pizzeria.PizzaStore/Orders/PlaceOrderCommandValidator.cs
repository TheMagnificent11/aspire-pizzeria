using Aspire.Pizzeria.Domain;
using FluentValidation;

namespace Aspire.Pizzeria.PizzaStore.Orders;

public class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidator()
    {
        this.RuleFor(x => x.CustomerName)
            .NotEmpty()
            .MaximumLength(Order.FieldLengths.CustomerName);

        this.RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .MaximumLength(Order.FieldLengths.DeliveryAddress);

        this.RuleFor(x => x.PizzaIds)
            .NotEmpty();
    }
}
