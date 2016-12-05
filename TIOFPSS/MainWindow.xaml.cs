namespace TIOFPSS
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            //string startPath = System.Windows.Forms.Application.StartupPath;
            //if (!System.IO.File.Exists(startPath + "\\project.db"))
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("缺少数据库文件!");
            //}
            this.InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            string startPath = System.Windows.Forms.Application.StartupPath;
            if (!System.IO.File.Exists(startPath + "\\paraTemple.xml"))
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("缺少参数文件!");
            }
            if (!System.IO.File.Exists(startPath + "\\paraLibTemple.xml"))
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("缺少参数文件!");
            }
        }
    }
}
