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
                TIOFPSS.Resources.MessageBoxX.Error("缺少paraTemple.xml!");
            }
            if (!System.IO.File.Exists(startPath + "\\paraLibTemple.xml"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("缺少paraLibTemple.xml!");
            }
            if (!System.IO.File.Exists(startPath + "\\config.ini"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("缺少config.ini");
            }
            if (!System.IO.File.Exists(startPath + "\\zsbd.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到zsbd.dll,无法进行动态分析");
            }
        }
    }
}
