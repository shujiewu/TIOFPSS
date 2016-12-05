using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TIOFPSS.Dialog
{
    /// <summary>
    /// ShengChengBaoBiao.xaml 的交互逻辑
    /// </summary>
    public partial class ShengChengBaoBiao : Window
    {
        public ShengChengBaoBiao()
        {
            InitializeComponent();
        }
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateShengChengBaoBiaoMethod CallBackMethod;
        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
            if (CallBackMethod != null)
            {
                string LuJing = lujing.Text.ToString();
                string ResName = resName.Text.ToString();
                if (LuJing != "" && ResName != "")
                {
                    List<string> para = new List<string>();

                    para.Add(LuJing);
                    para.Add(ResName);
                    this.CallBackMethod(para);
                    this.Close();
                }
                else
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("参数信息不能为空值！", this);
                }
            }
        }

        private void path_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择Creo启动路径";
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
                this.lujing.Text = fbd.SelectedPath;
        }
    }
}
