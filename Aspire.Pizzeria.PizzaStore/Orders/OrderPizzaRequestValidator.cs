using Aspire.Pizzeria.PizzaStore.Contracts;
using FluentValidation;

namespace Aspire.Pizzeria.PizzaStore.Orders;

public abstract class OrderPizzaRequestValidator<T> : AbstractValidator<T>
    where T : IOrderPizzaRequest
{
    protected OrderPizzaRequestValidator()
    {
        this.RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.");

        this.RuleFor(x => x.PizzaIds)
            .NotEmpty()
            .WithMessage("At least one pizza is required.");

        this.RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .When(x => x.IsDelivery)
            .WithMessage("Delivery address is required.");
    }
}
