using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterWorkingItemViewModel : WorkingItemViewModel
    {
        public VideoConverterWorkingItemViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoConverter;
        }
    }

    public class VideoCompressWorkingItemViewModel : WorkingItemViewModel
    {
        public VideoCompressWorkingItemViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoCompress;
        }
    }

    public class WorkingItemViewModel : BindableBase
    {
        protected readonly IEventAggregator ea;
        protected readonly IRegionManager rm;

        private VideoFuncEnum videoFunc;
        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        public WorkingItemViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
        }
    }
}
