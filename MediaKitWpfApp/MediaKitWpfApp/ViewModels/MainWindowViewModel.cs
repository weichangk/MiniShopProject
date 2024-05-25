using MediaKitWpfApp.Common;
using MediaKitWpfApp.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MediaKitWpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase, ITopWidgetOper
    {
        private readonly IEventAggregator ea;
        private readonly IRegionManager rm;

        public DelegateCommand<string> TopWidgetOperCommand { get; private set; }
        public Action Home { get; set; } = () => { };
        public Action Menu { get; set; } = () => { };
        public Action Min { get; set; } = () => { };
        public Action Close { get; set; } = () => { };

        public MainWindowViewModel(IRegionManager _rm, IEventAggregator _ea)
        {
            rm = _rm;
            ea = _ea;

            TopWidgetOperCommand = new DelegateCommand<string>(TopWidgetOper);

            rm.RegisterViewWithRegion(PrismRegionNameManager.MainRegionName, typeof(MainButtonPage));
            ea.GetEvent<OpenFuncEvent>().Subscribe(OpenFuncReceived);
        }

        private void TopWidgetOper(string oper)
        {
            switch (oper)
            {
                case "Home":
                    DoHome();
                    break;
                case "Menu":
                    DoMenu();
                    break;
                case "Min":
                    Min?.Invoke();
                    break;
                case "Close":
                    Close?.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void DoHome()
        {
            rm.RequestNavigate(PrismRegionNameManager.MainRegionName, nameof(MainButtonPage));
        }

        private void DoMenu()
        {
            //Menu?.Invoke();
        }

        private void OpenFuncReceived(string func)
        {
            switch (func)
            {
                case nameof(VideoFuncEnum.VideoConverter):
                    rm.RequestNavigate(PrismRegionNameManager.MainRegionName, nameof(VideoConverterPage));
                    break;
                case nameof(VideoFuncEnum.VideoCompress):
                    rm.RequestNavigate(PrismRegionNameManager.MainRegionName, nameof(VideoCompressWorkAreaPage));
                    break;
                default:
                    break;
            }

        }

    }
}
