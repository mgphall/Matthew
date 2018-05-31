///-----------------------------------------------------------------
///   Description:   Prime Tables view Model
///-----------------------------------------------------------------
namespace PrimeTables.Core.ViewModels
{
    using MvvmCross.Core.ViewModels;
    using PrimeTables.Core.Constants;
    using PrimeTables.Core.ExtensionMethods;
    using System.Diagnostics;
    using System.Linq;

    public class PrimeTablesViewModel
        : MvxViewModel
    {

        private int primeCount = 1;

        private MvxCommand _startPrimeCalulation;
        private IPrimeTablesModel _primeTablesModel;
        private int[] _primeNumbers;
        private int[,] _primeTable;
        private bool isEnabled = true;
        private string _displayError = string.Empty;

        public IMvxCommand StartPrimeCalulation => _startPrimeCalulation;

        public PrimeTablesViewModel(IPrimeTablesModel primeTablesModel)
        {
            _primeTablesModel = primeTablesModel;

            _startPrimeCalulation = new MvxCommand( () => 
            {
                StartCalulation();
            });
        }

        public int Min { get; set; } = PrimeConstants.MinPrimes;
        public int Max { get; set; } = PrimeConstants.MaxPrimes;
        public int Estimate { get; set; } = PrimeConstants.StartEstimate;

        public int PrimeCount
        {
            get { return primeCount; }
            set { SetProperty(ref primeCount, value); }
        }

        public string DisplayError
        {
            get { return _displayError; }
            set { SetProperty(ref _displayError, value); }
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

        private void StartCalulation()
        {
            DisplayError = string.Empty;

            var validator = new Validation.PrimeTablesViewModelValidator();

            var results = validator.Validate(this);

            IsEnabled = false;

            if (results.IsValid)
            {
                PerformPrimeCalulation();
            }
            else
            {
                DisplayError = results.Errors.FirstOrDefault().ErrorMessage;
            }

            IsEnabled = true;
        }

        private void PerformPrimeCalulation()
        {
            Stopwatch startPrime = new Stopwatch();
            startPrime.Start();

            PrimeTable = null;

            var result = _primeTablesModel.MakeSieve(Estimate, PrimeCount);

            if (result != null)
            {
                PrimeNumbers = result.FindAllIndexof(true);

                if (PrimeNumbers.Length > 0)
                {
                    PrimeTable = _primeTablesModel.ReturnTable(PrimeNumbers);
                }
            }
            Debug.WriteLine($"Primes found in {startPrime.Elapsed}");
            startPrime.Stop();

            
        }
    }
}
