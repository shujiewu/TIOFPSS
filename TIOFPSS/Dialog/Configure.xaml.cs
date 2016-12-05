using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TIOFPSS.Dialog
{
    /// <summary>
    /// Configure.xaml 的交互逻辑
    /// </summary>
    public partial class Configure : Window
    {
        public Configure()
        {
            InitializeComponent();
            string Section = "system";
            this.ProjPath.Text = IniReadValue(Section, "ProjectPath");
            this.AnsysPath.Text = IniReadValue(Section, "AnsysPath");
            this.CreoPath.Text = IniReadValue(Section, "CreoPath");
        }


        static string inipath = System.Windows.Forms.Application.StartupPath + @"\config.ini";
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary>
        /// 读取配置ini文件
        /// </summary>
        /// <param name="Section">配置段</param>
        /// <param name="Key">键</param>
        /// <param name="innpath">存放物理路径</param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return temp.ToString();
        }

        public static string IniReadValueWithPath(string Section, string Key,string Path)
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString(Section, Key, "", temp, 500, Path);
            return temp.ToString();
        }
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);


        /// <summary>
        /// 写入ini文件的操作
        /// </summary>
        /// <param name="Section">配置段</param>
        /// <param name="Key">键</param>
        /// <param name="Value">键值</param>
        /// <param name="inipath">物理路径</param>
        public static void IniWriteValue(string Section, string Key, string Value, string inipath)
        {
            WritePrivateProfileString(Section, Key, Value, inipath);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择项目默认路径";
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
                this.ProjPath.Text = fbd.SelectedPath;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择Creo启动路径";
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
                this.CreoPath.Text = fbd.SelectedPath;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择Ansys启动路径";
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
                this.AnsysPath.Text = fbd.SelectedPath;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string Section="system";

            IniWriteValue(Section, "ProjectPath", this.ProjPath.Text, inipath);
            IniWriteValue(Section, "CreoPath", this.CreoPath.Text, inipath);
            IniWriteValue(Section, "AnsysPath", this.AnsysPath.Text, inipath);

            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
