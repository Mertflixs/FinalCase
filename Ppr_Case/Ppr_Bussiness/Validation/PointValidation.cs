using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;

public class PointValidation : AbstractValidator<PointRequest>
{
    public PointValidation()
    {
        RuleFor(x => x.AccountId)
            .GreaterThan(0)
            .WithMessage("AccountId must be greater than 0.");

        RuleFor(x => x.PointId)
            .GreaterThan(0)
            .WithMessage("PointId must be greater than 0.");

        RuleFor(x => x.TotalPoint)
            .GreaterThanOrEqualTo(0)
            .WithMessage("TotalPoint must be greater than or equal to 0.");
    }
}
