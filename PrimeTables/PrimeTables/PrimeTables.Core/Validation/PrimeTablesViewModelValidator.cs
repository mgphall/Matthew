using FluentValidation;
using PrimeTables.Core.ViewModels;

namespace PrimeTables.Core.Validation
{
    public class PrimeTablesViewModelValidator : AbstractValidator<PrimeTablesViewModel>
    {
        public PrimeTablesViewModelValidator()
        {
            RuleFor(prime => prime.PrimeCount).GreaterThan(0).WithMessage("please enter a positive number");
            RuleFor(prime => prime.PrimeCount).LessThan(10000).WithMessage("please enter a vaild number");
            RuleFor(prime => prime.PrimeCount).NotEmpty().WithMessage("please enter a vaild number");
        }
    }
}

