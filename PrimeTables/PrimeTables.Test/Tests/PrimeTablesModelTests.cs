using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables.Core.ViewModels;
using PrimeTables.Core.Model;
using System.Linq;
using PrimeTables.Core.ExtensionMethods;
using PrimeTables.Core.Constants;

namespace PrimeTables.Test
{
    [TestClass]
    public class PrimeTablesModelTests
    {
        [TestMethod]
        public void PrimeTables_MakeSieve_Returns_10Primes()
        {
            var expectedPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            var model = new PrimeTablesModel();

            var result = model.MakeSieve(PrimeConstants.StartEstimate, 10).Where(p => p == true).ToList();

            Assert.AreEqual(result.Count, expectedPrimes.Length);
        }

        [TestMethod]
        public void PrimeTables_MakeSieve_Returns_PrimeTable()
        {
            var expectedPrimes = new int[] { 2, 3};

            var expectedTables = new int[,] {
            {0,2,3},
            {2,4,6},
            {3,6,9}, };

            var model = new PrimeTablesModel();

            var result = model.ReturnTable(expectedPrimes);

            CollectionAssert.AreEqual(result, expectedTables);
        }

        [TestMethod]
        public void PrimeTables_MakeSieve_Returns_NullPrimeTable()
        {
            var expectedPrimes = new int[0];

            var model = new PrimeTablesModel();

            var result = model.ReturnTable(expectedPrimes);

            CollectionAssert.AreEqual(null, result);
        }

        [TestMethod]
        public void PrimeTables_Returns_FindAllIndexTrueAndFalse()
        {
            var expectedResult = 5;
            var expectedPrimes = new bool[]
            {
                 true, false, true, false, true, false, true, false, true, false
            };

           var resultTrue = expectedPrimes.FindAllIndexof(true);
           var resulFalse = expectedPrimes.FindAllIndexof(false);

            Assert.AreEqual(resultTrue.Length, expectedResult);
            Assert.AreEqual(resulFalse.Length, expectedResult);
        }

        [TestMethod]
        public void PrimeTables_MakeSieve_Returns_InValidPrime_ReturnsNull()
        {
            var model = new PrimeTablesModel();

            var result = model.MakeSieve(10, -1);

            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void PrimeTables_MakeSieve_Returns_EstimateAboveStartEstimate_Null()
        {
            var model = new PrimeTablesModel();

            var result = model.MakeSieve(PrimeConstants.StartEstimate+1 ,1);

            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void PrimeTables_MakeSieve_Returns_EstimateBelowStartEstimate_Null()
        {
            var model = new PrimeTablesModel();

            var result = model.MakeSieve(-1, 100);

            Assert.AreEqual(result, null);
        }
    }
}
