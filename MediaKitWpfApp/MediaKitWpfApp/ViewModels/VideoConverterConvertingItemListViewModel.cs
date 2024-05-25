using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterConvertingItemListViewModel : BindableBase
    {
        private readonly IEventAggregator ea;
        private readonly IRegionManager rm;
        private ObservableCollection<VideoConverterConvertingItemViewModel> items = new();
        public ObservableCollection<VideoConverterConvertingItemViewModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
        public VideoConverterConvertingItemListViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
            ea.GetEvent<AddVideoConverterWorkingFileEvent>().Subscribe(AddVideoFileReceived);
        }
        public void AddVideoFileReceived(VideoFileInfo fileinfo)
        {
            Items.Add(new VideoConverterConvertingItemViewModel(ea, rm));
        }
    }
}
