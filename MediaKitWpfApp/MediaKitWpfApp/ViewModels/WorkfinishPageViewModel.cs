using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterWorkfinishPageViewModel : WorkfinishPageViewModel
    {
        public VideoConverterWorkfinishPageViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoConverter;
        }
    }

    public class VideoCompressWorkfinishPageViewModel : WorkfinishPageViewModel
    {
        public VideoCompressWorkfinishPageViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoCompress;
        }
    }

    public class WorkfinishPageViewModel : BindableBase
    {
        protected readonly IEventAggregator ea;
        protected readonly IRegionManager rm;

        private VideoFuncEnum videoFunc;
        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        private ObservableCollection<WorkfinishItemViewModel> workfinishItems = new();

        public ObservableCollection<WorkfinishItemViewModel> WorkfinishItems
        {
            get { return workfinishItems; }
            set { workfinishItems = value; RaisePropertyChanged(); }
        }

        public WorkfinishPageViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
        }
    }
}
