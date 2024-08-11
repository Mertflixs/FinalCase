using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;
public class CouponValidation : AbstractValidator<CouponRequest>
{
    public CouponValidation()
    {
        RuleFor(x => x.CouponId)
            .NotEmpty().WithMessage("CouponId is required.")
            .GreaterThan(0).WithMessage("CouponId must be greater than zero.");

        RuleFor(x => x.CouponName)
            .NotEmpty().WithMessage("CouponName is required.")
            .MaximumLength(100).WithMessage("CouponName cannot exceed 100 characters.");

        RuleFor(x => x.CouponAmount)
            .NotEmpty().WithMessage("CouponAmount is required.")
            .GreaterThan(0).WithMessage("CouponAmount must be greater than zero.");

        RuleFor(x => x.CouponCode)
            .NotEmpty().WithMessage("CouponCode is required.")
            .Matches("^[A-Z0-9]{6,10}$").WithMessage("CouponCode must be alphanumeric and between 6 to 10 characters long.");

        RuleFor(x => x.ExpryDate)
            .NotEmpty().WithMessage("ExpryDate is required.")
            .Must(date => date > DateTime.UtcNow).WithMessage("ExpryDate must be in the future.");
    }
}
