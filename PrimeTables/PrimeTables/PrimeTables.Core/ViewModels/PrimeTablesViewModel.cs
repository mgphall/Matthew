///-----------------------------------------------------------------
///   Description:   Prime Tables view Model
///-----------------------------------------------------------------
namespace PrimeTables.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;
    using PrimeTables.Core.ExtensionMethods;
    using System.Threading.Tasks;

    public class PrimeTablesViewModel
        : MvxViewModel
    {

        private int primeCount = 1;

        private MvxCommand _startPrimeCalulation;
        private IPrimeTablesModel _primeTablesModel;
        private int[] _primeNumbers;
        private int[,] _primeTable;
        private bool isEnabled = true;

        public IMvxCommand StartPrimeCalulation => _startPrimeCalulation;

        public PrimeTablesViewModel(IPrimeTablesModel primeTablesModel)
        {
            _primeTablesModel = primeTablesModel;

            _startPrimeCalulation = new MvxCommand( () => 
            {
                StartCalulationAsync();
            });
        }

        public int Extimate { get; set; } = 1000000;

        public int PrimeCount
        {
            get { return primeCount; }
            set { SetProperty(ref primeCount, value); }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
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

        private async void StartCalulationAsync()
        {
            PrimeTable = null;

            IsEnabled = false;

          var table =  await Task.Factory.StartNew(() =>
            {
                var result = _primeTablesModel.MakeSieve(Extimate, PrimeCount);

                PrimeNumbers = result.FindAllIndexof(true);
                return _primeTablesModel.ReturnTable(PrimeNumbers);
            });

            PrimeTable = table;

            IsEnabled = true;
        }
    }
}
