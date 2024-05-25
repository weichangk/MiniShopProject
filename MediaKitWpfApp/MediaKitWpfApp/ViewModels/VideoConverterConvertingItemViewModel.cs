using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterConvertingItemViewModel : BindableBase
    {
        private readonly IEventAggregator ea;
        private readonly IRegionManager rm;
        public VideoConverterConvertingItemViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
        }
    }
}
