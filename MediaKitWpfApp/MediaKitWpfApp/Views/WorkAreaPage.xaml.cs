using System.Windows.Controls;

namespace MediaKitWpfApp.Views
{
    /// <summary>
    /// WorkAreaPage.xaml 的交互逻辑
    /// </summary>
    public partial class WorkAreaPage : UserControl
    {
        public WorkAreaPage()
        {
            InitializeComponent();
        }
    }

    public partial class VideoConverterWorkAreaPage : WorkAreaPage
    {
        public VideoConverterWorkAreaPage() : base()
        {
        }
    }

    public partial class VideoCompressWorkAreaPage : WorkAreaPage
    {
        public VideoCompressWorkAreaPage() : base()
        {
        }
    }
}
