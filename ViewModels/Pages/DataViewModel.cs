using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;
using WPF_study.Interfaces;
using WPF_study.Models;

namespace WPF_study.ViewModels.Pages
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private readonly IDatabase<GangnamguPopulation?>? _database;

        public DataViewModel(IDatabase<GangnamguPopulation?>? database)
        {
            this._database = database;
        }

        [ObservableProperty]
        private IEnumerable<DataColor> _colors;
        [ObservableProperty]
        private IEnumerable<GangnamguPopulation?>? gangnamguPopulations;
        [ObservableProperty]
        private IEnumerable<string?>? administrativeAgency;
        [ObservableProperty]
        private string? selectedAdministrativeAgency;

        public void OnNavigatedTo()
        {
            Console.WriteLine("DataViewModel OnNavigatedTo");
            if (!_isInitialized)
                InitializeViewModel();
        }

        public Task OnNavigatedToAsync()
        {
            Console.WriteLine("DataViewModel OnNavigatedToAsync");
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void OnSelectAdministrativeAgency()
        {
            var selectedData = selectedAdministrativeAgency;
        }

        private void InitializeViewModel()
        {
            this.GangnamguPopulations = _database.Get();
            this.AdministrativeAgency = gangnamguPopulations?.Select(x => x.AdministrativeAgency).ToList();
            _isInitialized = true;
        }
    }
}
