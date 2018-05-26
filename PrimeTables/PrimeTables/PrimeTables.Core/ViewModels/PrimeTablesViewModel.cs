///-----------------------------------------------------------------
///   Description:   Prime Tables view Model
///-----------------------------------------------------------------
namespace PrimeTables.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;
    using PrimeTables.Core.ExtensionMethods;

    public class PrimeTablesViewModel
        : MvxViewModel
    {

        private int primeCount = 1;

        private MvxCommand _startPrimeCalulation;
        private IPrimeTablesModel _primeTablesModel;

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

        public int[] PrimeNumbers { get; private set; }

        private void StartCalulation()
        {
           var result = _primeTablesModel.MakeSieve(Extimate, PrimeCount);

           PrimeNumbers = result.FindAllIndexof(true);
        }
    }
}
