using System.Threading.Tasks;
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


        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModelAsync();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void OnSelectAdministrativeAgency()
        {
            var selectedData = this.SelectedAdministrativeAgency;
        }

        private async Task InitializeViewModelAsync()
        {
            this.GangnamguPopulations = await Task.Run(() => _database?.Get());
            if( this.GangnamguPopulations != null)
            {
                this.AdministrativeAgency = gangnamguPopulations?.Select(x => x.AdministrativeAgency).ToList();
            }
            _isInitialized = true;
        }
    }
}
