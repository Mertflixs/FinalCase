using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;

public class ProductValidation : AbstractValidator<ProductRequest>
{
    public ProductValidation()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("ProductName is required.")
            .MaximumLength(255).WithMessage("ProductName cannot be longer than 255 characters.");

        RuleFor(x => x.ProductDescription)
            .MaximumLength(1000).WithMessage("ProductDescription cannot be longer than 1000 characters.");

        RuleFor(x => x.ProductPrice)
            .GreaterThan(0).WithMessage("ProductPrice must be greater than 0.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive status is required.");

        RuleFor(x => x.ProductFeatures)
            .MaximumLength(1000).WithMessage("ProductFeatures cannot be longer than 1000 characters.");

        RuleFor(x => x.RewardPercentage)
            .InclusiveBetween(0, 100).WithMessage("RewardPercentage must be between 0 and 100.")
            .ScalePrecision(2, 5).WithMessage("RewardPercentage must be a valid percentage with up to 2 decimal places.");

        RuleFor(x => x.MaxRewardAmount)
            .GreaterThan(0).WithMessage("MaxRewardAmount must be greater than 0.")
            .ScalePrecision(2, 18).WithMessage("MaxRewardAmount must be a valid amount with up to 2 decimal places.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
    }
}
