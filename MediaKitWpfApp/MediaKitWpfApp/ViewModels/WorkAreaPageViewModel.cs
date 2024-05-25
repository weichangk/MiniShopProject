using MediaKitWpfApp.Common;
using MediaKitWpfApp.Repositores;
using MediaKitWpfApp.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterWorkAreaPageViewModel : WorkAreaPageViewModel
    {
        public VideoConverterOutSettingViewModel VideoConverterOutSettingViewModel { get; set; }
        public DelegateCommand OpenFormatCommand
        {
            get { return VideoConverterOutSettingViewModel.OpenFormatCommand; }
        }
        public DelegateCommand<string> OpenOutputFolderCommand 
        {
            get { return VideoConverterOutSettingViewModel.OutputFolderViewModel.OpenOutputFolderCommand; }
        }
        public DelegateCommand<string> SaveOutputFolderCommand
        {
            get { return VideoConverterOutSettingViewModel.OutputFolderViewModel.SaveOutputFolderCommand; }
        }
        public ObservableCollection<string> OutputFolderList 
        {
            get { return VideoConverterOutSettingViewModel.OutputFolderViewModel.OutputFolderList; }
        }
        public string CurrentOutputFolder
        {
            get { return VideoConverterOutSettingViewModel.OutputFolderViewModel.CurrentOutputFolder; }
        }
        public int SelectedIndex
        {
            get { return VideoConverterOutSettingViewModel.OutputFolderViewModel.SelectedIndex; }
        }
        public VideoConverterWorkAreaPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository) : base(ea, rm, sysParmBaseRepository)
        {
            WorkAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;
            VideoConverterOutSettingViewModel = new VideoConverterOutSettingViewModel(sysParmBaseRepository);
        }

        protected override void OpenFile()
        {
            rm.RequestNavigate(WorkAreaRegionName, nameof(VideoConverterWorkingPage));
            ea.GetEvent<AddVideoConverterWorkingFileEvent>().Publish(new VideoFileInfo());
        }
    }

    public class VideoCompressWorkAreaPageViewModel : WorkAreaPageViewModel
    {
        public VideoCompressWorkAreaPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository) : base(ea, rm, sysParmBaseRepository)
        {
            WorkAreaRegionName = PrismRegionNameManager.VideoCompressWorkAreaRegionName;
        }

        protected override void OpenFile()
        {
            rm.RequestNavigate(WorkAreaRegionName, nameof(VideoCompressWorkingPage));
            ea.GetEvent<AddVideoCompressWorkingFileEvent>().Publish(new VideoFileInfo());
        }
    }

    public class WorkAreaPageViewModel : BindableBase
    {
        protected readonly IEventAggregator ea;
        protected readonly IRegionManager rm;
        protected readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;

        public DelegateCommand OpenFileCommand { get; private set; }


        private string workAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;
        public string WorkAreaRegionName
        {
            get { return workAreaRegionName; }
            set { workAreaRegionName = value; }
        }


        public WorkAreaPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository)
        {
            this.ea = ea;
            this.rm = rm;
            this.sysParmBaseRepository = sysParmBaseRepository;

            OpenFileCommand = new DelegateCommand(OpenFile);
        }

        protected virtual void OpenFile()
        {
            rm.RequestNavigate(workAreaRegionName, nameof(WorkingPage));
        }
    }
}
