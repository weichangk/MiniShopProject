using System.Windows.Controls;

namespace MediaKitWpfApp.Views
{
    /// <summary>
    /// WorkfinishPage.xaml 的交互逻辑
    /// </summary>
    public partial class WorkfinishPage : UserControl
    {
        public WorkfinishPage()
        {
            InitializeComponent();
        }
    }

    public partial class VideoConverterWorkfinishPage : WorkfinishPage
    {
        public VideoConverterWorkfinishPage() : base()
        {
        }
    }

    public partial class VideoCompressWorkfinishPage : WorkfinishPage
    {
        public VideoCompressWorkfinishPage() : base()
        {
        }
    }
}
