using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;
public class OrderDetailValidation : AbstractValidator<OrderDetailRequest>
{
    public OrderDetailValidation()
    {
        RuleFor(x => x.OrderDetailId)
            .NotEmpty().WithMessage("OrderDetailId is required.")
            .GreaterThan(0).WithMessage("OrderDetailId must be greater than zero.");

        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.")
            .GreaterThan(0).WithMessage("OrderId must be greater than zero.");

        RuleFor(x => x.AccountId)
            .NotEmpty().WithMessage("AccountId is required.")
            .GreaterThan(0).WithMessage("AccountId must be greater than zero.");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.")
            .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}
