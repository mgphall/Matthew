using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables.Core.Constants;
using PrimeTables.Core.Model;
using PrimeTables.Core.Validation;
using PrimeTables.Core.ViewModels;
using PrimeTables.WPF;

namespace PrimeTables.Test.Tests
{
    [TestClass]
    public class PrimeTablesViewModelValidatorTests
    {
        private PrimeTablesViewModelValidator validator;

        [TestMethod]
        public void Validator_Should_not_have_error_PrimeTablesViewModel()
        {
            var PrimeTableVM = setup();

            validator = new PrimeTablesViewModelValidator();
            validator.ShouldHaveValidationErrorFor(p => p.PrimeCount, PrimeTableVM as PrimeTablesViewModel);
        }

        [TestMethod]
        public void Validator_Should_have_error_when_PrimeCount_is_zero()
        {
            var PrimeTableVM =  setup();
            PrimeTableVM.PrimeCount = 0;

            validator = new PrimeTablesViewModelValidator();
            validator.ShouldHaveValidationErrorFor(p => p.PrimeCount, PrimeTableVM);
        }

        [TestMethod]
        public void Validator_Should_have_error_when_PrimeCount_is_AboveMaxValue()
        {
            var PrimeTableVM = setup();
            PrimeTableVM.PrimeCount = PrimeConstants.MaxPrimes+1;

            validator = new PrimeTablesViewModelValidator();
            validator.ShouldHaveValidationErrorFor(p => p.PrimeCount, PrimeTableVM);
        }

        [TestMethod]
        public void Validator_Should_not_have_error_when_PrimeCount_is_100()
        {
            var PrimeTableVM = setup();
            PrimeTableVM.PrimeCount = 100;

            validator = new PrimeTablesViewModelValidator();
            validator.ShouldNotHaveValidationErrorFor(p => p.PrimeCount, PrimeTableVM);
        }

        [TestMethod]
        public void Validator_Should_not_have_error_when_PrimeCount_is_MaxValue()
        {
            var PrimeTableVM = setup();
            PrimeTableVM.PrimeCount = PrimeConstants.MaxPrimes;

            validator = new PrimeTablesViewModelValidator();
            validator.ShouldNotHaveValidationErrorFor(p => p.PrimeCount, PrimeTableVM);
        }

        private PrimeTablesViewModel setup()
        {
            var model = new PrimeTablesModel();
            return new PrimeTablesViewModel(model);
        }
    }
}
