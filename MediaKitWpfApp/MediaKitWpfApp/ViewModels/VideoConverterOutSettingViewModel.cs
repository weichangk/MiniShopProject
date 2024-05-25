using MediaKitWpfApp.Common;
using MediaKitWpfApp.Repositores;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterOutSettingViewModel : BindableBase
    {
        private readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;
        public DelegateCommand OpenFormatCommand { get; private set; }

        private OutputFolderViewModel outputFolderViewModel;
        public OutputFolderViewModel OutputFolderViewModel
        {
            get { return outputFolderViewModel; }
            set { outputFolderViewModel = value; }
        }

        public VideoConverterOutSettingViewModel(Lazy<ISysParmBaseRepository> sysParmBaseRepository)
        {
            this.sysParmBaseRepository = sysParmBaseRepository;

            OpenFormatCommand = new DelegateCommand(OpenFormat);
            outputFolderViewModel = new OutputFolderViewModel(VideoFuncEnum.VideoConverter, sysParmBaseRepository);
        }

        private void OpenFormat()
        { 

        }
    }
}
