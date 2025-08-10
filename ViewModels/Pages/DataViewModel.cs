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
        private IEnumerable<GangnamguPopulation?>? gangnamguPopulations;
        [ObservableProperty]
        private IEnumerable<string?>? administrativeAgency;
        [ObservableProperty]
        private string? selectedAdministrativeAgency;

        [ObservableProperty]
        private int? selectedTotalPopulation;

        [ObservableProperty]
        private int? selectedMalePopulation;

        [ObservableProperty]
        private int? selectedFemalePopulation;

        [ObservableProperty]
        private double? selectedSexRatio;

        [ObservableProperty]
        private int? selectedNumnerOfHouseholds;

        [ObservableProperty]
        private double? selectedNumverOfPeoplePerHouseHolds;


        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModelAsync();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        [RelayCommand]
        private void OnSelectAdministrativeAgency()
        {
            var selectedData = this.SelectedAdministrativeAgency;
        }

        [RelayCommand]
        private void CreateNewData()
        {
            GangnamguPopulation gangnamguPopulation = new GangnamguPopulation();

            gangnamguPopulation.AdministrativeAgency = this.SelectedAdministrativeAgency;
            gangnamguPopulation.TotalPopulation = this.selectedTotalPopulation;
            gangnamguPopulation.MalePopulation = this.SelectedMalePopulation;
            gangnamguPopulation.FemalePopulation = this.SelectedFemalePopulation;
            gangnamguPopulation.SexRatio = this.SelectedSexRatio;
            gangnamguPopulation.NumberOfHouseholds = this.SelectedNumnerOfHouseholds;
            gangnamguPopulation.NumberOfPeoplePerHousehold = this.SelectedNumverOfPeoplePerHouseHolds;

            _database?.Create(gangnamguPopulation);
        }

        [RelayCommand]
        private void ReadAllData()
        {
            this.GangnamguPopulations = _database?.Get();
            if (this.GangnamguPopulations != null)
            {
                this.AdministrativeAgency = gangnamguPopulations?.Select(x => x.AdministrativeAgency).ToList();
            }
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
