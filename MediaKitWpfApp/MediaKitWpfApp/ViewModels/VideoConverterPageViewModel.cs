using MediaKitWpfApp.Common;
using MediaKitWpfApp.Models;
using MediaKitWpfApp.Repositores;
using MediaKitWpfApp.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterPageViewModel : BindableBase
    {
        private bool bAutoSelectionChanged;
        private readonly IEventAggregator ea;
        private readonly IRegionManager rm;
        private readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;
        public string ContentRegionName { get; set; } = PrismRegionNameManager.VideoConverterConvertingRegionName;
        private string currentOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
        public string CurrentOutputFolder
        {
            get { return currentOutputFolder; }
            set { SetProperty(ref currentOutputFolder, value); }
        }
        private ObservableCollection<string> outputFolderList = new();
        public ObservableCollection<string> OutputFolderList
        {
            get { return outputFolderList; }
            set { SetProperty(ref outputFolderList, value); }
        }
        public DelegateCommand OpenFileCommand { get; private set; }
        public DelegateCommand OpenFormatCommand { get; private set; }
        public DelegateCommand<string> SelectOutputFolderCommand { get; private set; }
        public DelegateCommand<string> OpenOutputFolderCommand { get; private set; }
        public VideoConverterPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository)
        {
            this.ea = ea;
            this.rm = rm;
            this.sysParmBaseRepository = sysParmBaseRepository;
            OpenFileCommand = new DelegateCommand(OpenFile);
            OpenFormatCommand = new DelegateCommand(OpenFormat);
            SelectOutputFolderCommand = new DelegateCommand<string>(SelectOutputFolder);
            OpenOutputFolderCommand = new DelegateCommand<string>(OpenOutputFolder);

            InitOutputFolderList();
        }
        private void InitOutputFolderList()
        {
            if (!Directory.Exists(currentOutputFolder))
                Directory.CreateDirectory(currentOutputFolder);

            var taskResultModel = sysParmBaseRepository.Value.GetByKeyAndTypeAsync(FieldNameManager.OutputFolder, VideoFuncEnum.VideoConverter.ToString());
            var resultModel = (ResultModel<SysParm>)taskResultModel.Result;
            if (resultModel != null && resultModel.Success && resultModel.Data != null)
            {
                currentOutputFolder = resultModel.Data.Value;
            }
            outputFolderList.Clear();
            outputFolderList.Add(currentOutputFolder);
            outputFolderList.Add("...");
        }
        public void OpenFile()
        {
            ContentRegionName = PrismRegionNameManager.VideoConverterConvertingRegionName;
            rm.RequestNavigate(ContentRegionName, nameof(VideoConverterConvertingItemList));
            ea.GetEvent<AddVideoConverterWorkingFileEvent>().Publish(new VideoFileInfo());
        }
        private void OpenFormat()
        {

        }
        private void SelectOutputFolder(string folder)
        {
            if (bAutoSelectionChanged) 
                return;
            if (folder == "...")
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    bAutoSelectionChanged = true;
                    OutputFolderList[0] = fbd.SelectedPath;
                    CurrentOutputFolder = fbd.SelectedPath;
                    bAutoSelectionChanged = false;
                    sysParmBaseRepository.Value.InsertOrUpdateValueByKeyAndTypeAsync(FieldNameManager.OutputFolder, VideoFuncEnum.VideoConverter.ToString(), currentOutputFolder);
                }
            }
        }
        private void OpenOutputFolder(string folder)
        {
            if (!Directory.Exists(currentOutputFolder))
                Directory.CreateDirectory(currentOutputFolder);

            System.Diagnostics.Process.Start("Explorer.exe", currentOutputFolder);
        }
    }
}
