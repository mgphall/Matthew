using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables.Core.ViewModels;
using PrimeTables.Core.Model;

namespace PrimeTables.Test
{
    [TestClass]
    public class PrimeTablesViewModelTests
    {
        [TestMethod]
        public void PrimeTablesViewModel_Returns10Primes()
        {
            var count = 10;
            var expectedPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            var model = new PrimeTablesModel();
            var viewmodel = new PrimeTablesViewModel(model);

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

            var model = new PrimeTablesModel();
            var viewmodel = new PrimeTablesViewModel(model);

            viewmodel.Estimate = 10;
            viewmodel.PrimeCount = 3;

            viewmodel.StartPrimeCalulation.Execute();

            Assert.AreEqual(count, viewmodel.PrimeCount);
            Assert.AreEqual(viewmodel.PrimeNumbers.Length, viewmodel.PrimeCount);

            CollectionAssert.AreEqual(expectedPrimes, viewmodel.PrimeNumbers);
            CollectionAssert.AreEqual(expectedTables, viewmodel.PrimeTable);
        }
    }
}
