///-----------------------------------------------------------------
///   Description:   Prime Tables view Model
///-----------------------------------------------------------------
namespace PrimeTables.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;
    using PrimeTables.Core.ExtensionMethods;
    using System.Data;
    using System.Linq;
    using System.Windows;

    public class PrimeTablesViewModel
        : MvxViewModel
    {

        private int primeCount = 1;

        private MvxCommand _startPrimeCalulation;
        private IPrimeTablesModel _primeTablesModel;
        private int[] _primeNumbers;
        private int[,] _primeTable;
        public IMvxCommand StartPrimeCalulation => _startPrimeCalulation;

        public PrimeTablesViewModel(IPrimeTablesModel primeTablesModel)
        {
            _primeTablesModel = primeTablesModel;

            _startPrimeCalulation = new MvxCommand(() => StartCalulation());
        }

        public int Extimate { get; set; } = 1000000;

        public int PrimeCount
        {
            get { return primeCount; }
            set { SetProperty(ref primeCount, value); }
        }

        public int[] PrimeNumbers {
            get { return _primeNumbers; }
             set { SetProperty(ref _primeNumbers, value); }
}

        public int[,] PrimeTable
        {
            get { return _primeTable; }
            set { SetProperty(ref _primeTable, value); }
        }

        private void StartCalulation()
        {
           var result = _primeTablesModel.MakeSieve(Extimate, PrimeCount);

           PrimeNumbers = result.FindAllIndexof(true);

           PrimeTable = _primeTablesModel.ReturnTable(PrimeNumbers);
        }
    }
}
