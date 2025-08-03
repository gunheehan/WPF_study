using WPF_study.Interfaces;

namespace WPF_study.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly IDateTime _iDateTime;

        [ObservableProperty]
        private string currentTime = string.Empty;

        [ObservableProperty]
        private int _counter = 0;

        public DashboardViewModel(IDateTime dateTime)
        {
            this._iDateTime = dateTime;
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }

        [RelayCommand]
        private void OnTextChanged()
        {
            this.currentTime = this._iDateTime.GetCurrentTime().ToString();
        }
    }
}
