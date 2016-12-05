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
            //    TIOFPSS.Resources.MessageBoxX.Warning("缺少数据库文件!");
            //}
            this.InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            string startPath = System.Windows.Forms.Application.StartupPath;
            if (!System.IO.File.Exists(startPath + "\\paraTemple.xml"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("缺少参数文件!");
            }
            if (!System.IO.File.Exists(startPath + "\\paraLibTemple.xml"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("缺少参数文件!");
            }
        }
    }
}
