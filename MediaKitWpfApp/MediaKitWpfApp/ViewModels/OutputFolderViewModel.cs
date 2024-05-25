using MediaKitWpfApp.Common;
using MediaKitWpfApp.Models;
using MediaKitWpfApp.Repositores;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.ViewModels
{
    public class OutputFolderViewModel : BindableBase
    {
        private const string OutputFolder = "OutputFolder";


        private readonly VideoFuncEnum videoFunc;
        private readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;

        public DelegateCommand<string> OpenOutputFolderCommand { get; private set; }
        public DelegateCommand<string> SaveOutputFolderCommand { get; private set; }

        private string currentOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
        public string CurrentOutputFolder
        {
            get { return currentOutputFolder; }
            set { SaveOutputFolder(value); }
        }
        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        private ObservableCollection<string> outputFolderList = new();
        public ObservableCollection<string> OutputFolderList
        {
            get { return outputFolderList; }
            set { outputFolderList = value; }
        }


        public OutputFolderViewModel(VideoFuncEnum videoFunc, Lazy<ISysParmBaseRepository> sysParmBaseRepository)
        {
            this.videoFunc = videoFunc;
            this.sysParmBaseRepository = sysParmBaseRepository;

            currentOutputFolder = Path.Combine(currentOutputFolder, videoFunc.ToString());

            OpenOutputFolderCommand = new DelegateCommand<string>(OpenOutputFolder);
            SaveOutputFolderCommand = new DelegateCommand<string>(SaveOutputFolder);
            InitOutputFolderList();
        }


        private void OpenOutputFolder(string folder)
        {
            if (!Directory.Exists(currentOutputFolder))
                Directory.CreateDirectory(currentOutputFolder);

            System.Diagnostics.Process.Start("Explorer.exe", currentOutputFolder);
        }

        private void InitOutputFolderList()
        {
            if(!Directory.Exists(currentOutputFolder))
                Directory.CreateDirectory(currentOutputFolder);

            var taskResultModel = sysParmBaseRepository.Value.GetByKeyAndTypeAsync(OutputFolder, videoFunc.ToString());
            var resultModel = (ResultModel<SysParm>)taskResultModel.Result;
            if (resultModel != null && resultModel.Success && resultModel.Data != null)
            {
                currentOutputFolder = resultModel.Data.Value;
            }
            outputFolderList.Clear();
            outputFolderList.Add(currentOutputFolder);
            outputFolderList.Add("...");
        }

        private void SaveOutputFolder(string folder)
        {
            if (folder == "...")
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    //outputFolderList[0] = fbd.SelectedPath;
                    currentOutputFolder = fbd.SelectedPath;
                    outputFolderList.Clear();
                    outputFolderList.Add(currentOutputFolder);
                    outputFolderList.Add("...");
                    selectedIndex = 0;
                }
            }
            else
            {
                currentOutputFolder = folder;
            }
            sysParmBaseRepository.Value.InsertOrUpdateValueByKeyAndTypeAsync(OutputFolder, videoFunc.ToString(), currentOutputFolder);
        }
    }
}
