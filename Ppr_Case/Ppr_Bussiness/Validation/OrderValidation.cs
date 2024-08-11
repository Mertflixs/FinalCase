using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;
public class OrderValidation : AbstractValidator<OrderRequest>
{
    public OrderValidation()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty().WithMessage("AccountId is required.")
            .GreaterThan(0).WithMessage("AccountId must be greater than zero.");

        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.")
            .GreaterThan(0).WithMessage("OrderId must be greater than zero.");

        RuleFor(x => x.CartAmount)
            .NotEmpty().WithMessage("CartAmount is required.")
            .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("CartAmount must be a valid number with up to two decimal places.");

        RuleFor(x => x.CouponAmount)
            .NotEmpty().WithMessage("CouponAmount is required.")
            .GreaterThanOrEqualTo(0).WithMessage("CouponAmount cannot be negative.");

        RuleFor(x => x.CouponCode)
            .NotEmpty().WithMessage("CouponCode is required.")
            .Matches("^[A-Z0-9]{6,10}$").WithMessage("CouponCode must be alphanumeric and between 6 to 10 characters long.");

        RuleFor(x => x.PointsAmount)
            .NotEmpty().WithMessage("PointsAmount is required.")
            .GreaterThanOrEqualTo(0).WithMessage("PointsAmount cannot be negative.");

        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("ShippingAddress is required.")
            .MaximumLength(250).WithMessage("ShippingAddress cannot exceed 250 characters.");

        RuleFor(x => x.OrderDate)
            .NotEmpty().WithMessage("OrderDate is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("OrderDate cannot be in the future.");
    }
}