using WPF_study.Interfaces;
using WPF_study.Models;

namespace WPF_study.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly IDateTime _iDateTime;
        private readonly IDatabase<GangnamguPopulation> gangnamDatabase;

        [ObservableProperty]
        private string currentTime = string.Empty;

        [ObservableProperty]
        private int _counter = 0;

        public DashboardViewModel(IDateTime dateTime, IDatabase<GangnamguPopulation> database)
        {
            this._iDateTime = dateTime;
            gangnamDatabase = database;
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            var datas = gangnamDatabase?.Get();

            Counter++;
        }

        [RelayCommand]
        private void OnTextChanged()
        {
            this.currentTime = this._iDateTime.GetCurrentTime().ToString();
        }
    }
}
