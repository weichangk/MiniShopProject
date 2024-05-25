using System.Windows.Controls;

namespace MediaKitWpfApp.Views
{
    /// <summary>
    /// WorkingPage.xaml 的交互逻辑
    /// </summary>
    public partial class WorkingPage : UserControl
    {
        public WorkingPage()
        {
            InitializeComponent();
        }
    }

    public partial class VideoConverterWorkingPage : WorkingPage
    {
        public VideoConverterWorkingPage() : base()
        {
        }
    }

    public partial class VideoCompressWorkingPage : WorkingPage
    {
        public VideoCompressWorkingPage() : base()
        {
        }
    }
}
