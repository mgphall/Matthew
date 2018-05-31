using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables.Core.ViewModels;
using PrimeTables.Core.Model;
using PrimeTables.Core.Validation;
using PrimeTables.Core.Constants;

namespace PrimeTables.Test
{
    [TestClass]
    public class PrimeTablesViewModelTests
    {
        [TestMethod]
        public void PrimeTablesViewModel_Returns10VaildPrimes()
        {
            var count = 10;
            var expectedPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            var viewmodel = setup();

            viewmodel.Estimate = 100;
            viewmodel.PrimeCount = 10;

            viewmodel.StartPrimeCalulation.Execute();

            Assert.AreEqual(count, viewmodel.PrimeCount);
            Assert.AreEqual(viewmodel.PrimeNumbers.Length, viewmodel.PrimeCount);

            CollectionAssert.AreEqual(expectedPrimes, viewmodel.PrimeNumbers);
        }

        [TestMethod]
        public void PrimeTablesViewModel_Returns3PrimesAndCorrectTable()
        {
            var count = 3;
            var expectedPrimes = new int[] { 2, 3, 5};
            var expectedTables = new int[,] {
            {0,2,3,5},
            {2,4,6,10},
            {3,6,9,15},
            {5,10,15,25}};

            var viewmodel = setup();

            viewmodel.Estimate = 10;
            viewmodel.PrimeCount = 3;

            viewmodel.StartPrimeCalulation.Execute();

            Assert.AreEqual(count, viewmodel.PrimeCount);
            Assert.AreEqual(viewmodel.PrimeNumbers.Length, viewmodel.PrimeCount);

            CollectionAssert.AreEqual(expectedPrimes, viewmodel.PrimeNumbers);
            CollectionAssert.AreEqual(expectedTables, viewmodel.PrimeTable);
        }

        [TestMethod]
        public void PrimeTablesViewModel_Returns_InValidEstimateReturnsNullWithErrorMessage()
        {
            var viewmodel = setup();

            viewmodel.Estimate = 10;
            viewmodel.PrimeCount = -1;

            viewmodel.StartPrimeCalulation.Execute();

            Assert.IsNull(viewmodel.PrimeNumbers);
            Assert.IsNull(viewmodel.PrimeTable);
            Assert.AreSame(viewmodel.DisplayError, "please enter a vaild number");
        }

        [TestMethod]
        public void PrimeTablesViewModel_MaxPrimesPlusOne_Returns_InValid()
        {
            var viewmodel = setup();

            viewmodel.Estimate = 10;
            viewmodel.PrimeCount = PrimeConstants.MaxPrimes+1;

            viewmodel.StartPrimeCalulation.Execute();

            Assert.IsNull(viewmodel.PrimeNumbers);
            Assert.IsNull(viewmodel.PrimeTable);
            Assert.AreSame(viewmodel.DisplayError, "please enter a vaild number");
        }

        private PrimeTablesViewModel setup()
        {
            var model = new PrimeTablesModel();
            return new PrimeTablesViewModel(model);
        }
    }
}
