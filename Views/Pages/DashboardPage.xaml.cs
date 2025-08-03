using System.ComponentModel;
using System.Windows.Media;
using Wpf.Ui.Abstractions.Controls;
using WPF_study.ViewModels.Pages;

namespace WPF_study.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            ViewModel.PropertyChanged += ViewModel_PropertyChnaged;

            InitializeComponent();
        }

        private void ViewModel_PropertyChnaged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Text":
                    this.btnClickMe.Background = new SolidColorBrush(Colors.Red);
                    break;
            }
        }
    }
}
