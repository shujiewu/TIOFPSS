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
    /// DongTaiShaoChiFenXi.xaml 的交互逻辑
    /// </summary>
    public partial class ShaoChiDongTaiFenXi : Window
    {
        public ShaoChiDongTaiFenXi()
        {
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateShaoChiDongTaiFenXiMethod CallBackMethod;
        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (this.DialogResult.Value && CallBackMethod != null)
            {

                string FangZhenShiJian = fangzhenjieshushijian.Text.ToString();
                string ZhiLiang = zhiliang.Text.ToString();
                string ResName = resName.Text.ToString();
                if (FangZhenShiJian != "" && ZhiLiang != "" && ResName != "" )
                {
                    List<string> para = new List<string>();

                   
                    para.Add(FangZhenShiJian);
                    para.Add(ZhiLiang);
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
