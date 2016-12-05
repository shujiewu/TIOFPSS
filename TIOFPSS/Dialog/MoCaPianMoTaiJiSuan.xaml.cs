using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// MoCaPianMoTaiJiSuan.xaml 的交互逻辑
    /// </summary>
    public partial class MoCaPianMoTaiJiSuan : Window
    {
        public MoCaPianMoTaiJiSuan()
        {
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateMoCaPianMoTaiJiSuanMethod CallBackMethod;
        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
            if (CallBackMethod != null)
            {
                string Motaijieshu = motaijieshu.Text.ToString();
                string ResName = resName.Text.ToString();
                if (Motaijieshu != "" && ResName != "")
                {
                    List<string> para = new List<string>();

                    para.Add(Motaijieshu);
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
    }
}
