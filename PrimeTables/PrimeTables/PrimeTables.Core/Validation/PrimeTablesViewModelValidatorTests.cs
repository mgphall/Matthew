using FluentValidation;
using PrimeTables.Core.Constants;
using PrimeTables.Core.ViewModels;

namespace PrimeTables.Core.Validation
{
    public class PrimeTablesViewModelValidator : AbstractValidator<PrimeTablesViewModel>
    {
        public PrimeTablesViewModelValidator()
        {
            RuleFor(prime => prime.PrimeCount).InclusiveBetween(PrimeConstants.MinPrimes,PrimeConstants.MaxPrimes).WithMessage("please enter a vaild number");
            RuleFor(prime => prime.PrimeCount).NotEmpty().WithMessage("please enter a vaild number");
        }
    }
}

