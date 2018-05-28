using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeTables.Core.ViewModels;
using PrimeTables.Core.Model;
using System.Linq;
using PrimeTables.Core.ExtensionMethods;

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

            var result = model.MakeSieve(100, 10).Where(p => p == true).ToList();

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
    }
}
