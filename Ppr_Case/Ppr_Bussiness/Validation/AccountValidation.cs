using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ppr_Schema;

namespace Ppr_Bussiness.Validation;

public class AccountValidation : AbstractValidator<AccountRequest>
{
    public AccountValidation()
    {
        RuleFor(x => x.AccountName)
            .NotEmpty()
            .WithMessage("Account name is required.")
            .MaximumLength(50)
            .WithMessage("Account name must not exceed 50 characters.");

        RuleFor(x => x.AccountSurname)
            .NotEmpty()
            .WithMessage("Account surname is required.")
            .MaximumLength(50)
            .WithMessage("Account surname must not exceed 50 characters.");

        RuleFor(x => x.AccountEmail)
            .NotEmpty()
            .WithMessage("Account email is required.")
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.AccountRole)
            .InclusiveBetween(0, 1)
            .WithMessage("Account role must be 0 (normal user) or 1 (admin).");

        RuleFor(x => x.AccountPassword)
            .NotEmpty()
            .WithMessage("Account password is required.")
            .MinimumLength(8)
            .WithMessage("Account password must be at least 8 characters long.");

        RuleFor(x => x.AccountStatus)
            .InclusiveBetween(0, 1)
            .WithMessage("Account status must be 0 (inactive) or 1 (active).");

        RuleFor(x => x.AccountWallet)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Account wallet must be greater than or equal to 0.");

        RuleFor(x => x.AccountIdentity)
            .NotEmpty()
            .WithMessage("Account identity is required.")
            .Length(11)
            .WithMessage("Account identity must be 11 characters long.");
    }
}
