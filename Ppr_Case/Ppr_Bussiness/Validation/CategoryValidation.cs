using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;
public class CategoryValidation : AbstractValidator<CategoryRequest>
{
    public CategoryValidation()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.")
            .GreaterThan(0).WithMessage("CategoryId must be greater than zero.");

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("CategoryName is required.")
            .MaximumLength(50).WithMessage("CategoryName cannot exceed 50 characters.");

        RuleFor(x => x.CategoryUrl)
            .NotEmpty().WithMessage("CategoryUrl is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("CategoryUrl must be a valid URL.");

        RuleFor(x => x.CategoryTags)
            .NotEmpty().WithMessage("CategoryTags are required.")
            .MaximumLength(100).WithMessage("CategoryTags cannot exceed 100 characters.");
    }
}
