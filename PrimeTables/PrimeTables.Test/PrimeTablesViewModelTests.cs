using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables.Core.ViewModels;
using PrimeTables.Core.Model;

namespace PrimeTables.Test
{
    [TestClass]
    public class PrimeTablesViewModelTests
    {
        [TestMethod]
        public void PrimeCount_ReturnsFirstTwoPrimes()
        {
            var count = 10;
            var expectedResult = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            var model = new PrimeTablesModel();
            var viewmodel = new PrimeTablesViewModel(model);

            viewmodel.Extimate = 100;
            viewmodel.PrimeCount = 10;

            viewmodel.StartPrimeCalulation.Execute();

        
            Assert.AreEqual(count, viewmodel.PrimeCount);
            Assert.AreEqual(viewmodel.PrimeNumbers.Length, viewmodel.PrimeCount);

            CollectionAssert.AreEqual(expectedResult, viewmodel.PrimeNumbers);
        }
    }
}
