using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterWorkingPageViewModel : WorkingPageViewModel
    {
        private ObservableCollection<VideoConverterWorkingItemViewModel> workingItems = new();
        public new ObservableCollection<VideoConverterWorkingItemViewModel> WorkingItems
        {
            get { return workingItems; }
            set { workingItems = value; RaisePropertyChanged(); }
        }

        public VideoConverterWorkingPageViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoConverter;
            ea.GetEvent<AddVideoConverterWorkingFileEvent>().Subscribe(AddVideoFileReceived);
        }

        public override void AddVideoFileReceived(VideoFileInfo fileinfo)
        {
            WorkingItems.Add(new VideoConverterWorkingItemViewModel(ea, rm));
        }
    }

    public class VideoCompressWorkingPageViewModel : WorkingPageViewModel
    {
        private ObservableCollection<VideoCompressWorkingItemViewModel> workingItems = new();
        public new ObservableCollection<VideoCompressWorkingItemViewModel> WorkingItems
        {
            get { return workingItems; }
            set { workingItems = value; RaisePropertyChanged(); }
        }

        public VideoCompressWorkingPageViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoCompress;
            ea.GetEvent<AddVideoCompressWorkingFileEvent>().Subscribe(AddVideoFileReceived);
        }

        public override void AddVideoFileReceived(VideoFileInfo fileinfo)
        {
            WorkingItems.Add(new VideoCompressWorkingItemViewModel(ea, rm));
        }
    }

    public class WorkingPageViewModel : BindableBase
    {
        protected readonly IEventAggregator ea;
        protected readonly IRegionManager rm;

        private VideoFuncEnum videoFunc;

        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        private ObservableCollection<WorkingItemViewModel> workingItems = new();
        public ObservableCollection<WorkingItemViewModel> WorkingItems
        {
            get { return workingItems; }
            set { workingItems = value; RaisePropertyChanged(); }
        }

        public WorkingPageViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
        }

        public virtual void AddVideoFileReceived(VideoFileInfo fileinfo)
        { 
        }
    }
}
