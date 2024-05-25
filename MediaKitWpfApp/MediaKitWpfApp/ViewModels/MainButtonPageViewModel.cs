using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class MainButtonPageViewModel : BindableBase
    {
        private readonly IEventAggregator ea;

        private ObservableCollection<MainButtonViewModel> mainButtons = new();

        public ObservableCollection<MainButtonViewModel> MainButtons
        {
            get { return mainButtons; }
            set { mainButtons = value; RaisePropertyChanged(); }
        }

        public MainButtonPageViewModel(IEventAggregator _ea)
        {
            ea = _ea;

            mainButtons = new ObservableCollection<MainButtonViewModel>()
            {
                new MainButtonViewModel(this.ea, "VideoConverter", "111", "1111111111"),
                new MainButtonViewModel(this.ea, "VideoCompress", "222", "1111111111"),
                new MainButtonViewModel(this.ea, "", "333", "1111111111"),
                new MainButtonViewModel(this.ea, "", "444", "1111111111"),
                new MainButtonViewModel(this.ea, "", "555", "1111111111"),
                new MainButtonViewModel(this.ea, "", "666", "1111111111"),
                new MainButtonViewModel(this.ea, "", "777", "1111111111"),
                new MainButtonViewModel(this.ea, "", "888", "1111111111"),
                new MainButtonViewModel(this.ea, "", "999", "1111111111"),
                new MainButtonViewModel(this.ea, "", "000", "1111111111"),
            };
        }
    }
}
