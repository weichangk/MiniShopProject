using MediaKitWpfApp.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MediaKitWpfApp.ViewModels
{
    public class MainButtonViewModel : BindableBase
    {
        private readonly IEventAggregator ea;
        public DelegateCommand<string> OpenFuncCommand { get; private set; }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        private string detail = string.Empty;
        public string Detail
        {
            get { return detail; }
            set { detail = value; RaisePropertyChanged(); }
        }

        public MainButtonViewModel(IEventAggregator _ea, string _name, string _title, string _detail)
        {
            ea = _ea;
            name = _name;
            title = _title;
            detail = _detail;
            OpenFuncCommand = new DelegateCommand<string>(OpenFunc);
        }

        private void OpenFunc(string oper)
        {
            ea.GetEvent<OpenFuncEvent>().Publish(oper);
        }
    }
}
