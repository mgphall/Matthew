///-----------------------------------------------------------------
///   Description:   Prime Tables view Model
///-----------------------------------------------------------------
namespace PrimeTables.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;
    using PrimeTables.Core.Model;

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

        public int PrimeCount
        {
            get { return primeCount; }
            set { SetProperty(ref primeCount, value); }
        }

        private void StartCalulation()
        {
          //// start Prime Calulations here
        }
    }
}
