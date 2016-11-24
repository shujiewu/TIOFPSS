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
    /// ShaoChiYuYingLi.xaml 的交互逻辑
    /// </summary>
    public partial class ShaoChiYuYingLiFenXi : Window
    {
        public ShaoChiYuYingLiFenXi()
        {
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateShaoChiYuYingLiFenXiMethod CallBackMethod;
        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (this.DialogResult.Value && CallBackMethod != null)
            {
                string Chongjili = chongjili.Text.ToString();
                string ChiMianYu = chiMianYu.Text.ToString();
                string ChiGenYu = chiGenYu.Text.ToString();
                string ChiDingYu = chiDingYu.Text.ToString();
                string ResName = resName.Text.ToString();
                if (Chongjili != "" && ResName != ""&&ChiMianYu!= ""&&ChiGenYu !="" &&ChiDingYu !="")
                {
                    List<string> para = new List<string>();

                    para.Add(Chongjili);
                    para.Add(ChiMianYu);
                    para.Add(ChiGenYu);
                    para.Add(ChiDingYu);
                    para.Add(ResName);
                    this.CallBackMethod(para);
                    this.Close();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("参数信息不能为空值！");
                }
            }
        }
    }
}
