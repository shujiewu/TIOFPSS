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
    /// DongTaiFenXi.xaml 的交互逻辑
    /// </summary>
    public partial class DongTaiFenXi : Window
    {
        public DongTaiFenXi()
        {
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateDongTaiFenXiMethod CallBackMethod;
        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (this.DialogResult.Value && CallBackMethod != null)
            {
                string ZengSuShiJian = zengsushijian.Text.ToString();
                string WenDingShiJian = wendnigshijian.Text.ToString();
                string FangZhenShiJian = fanzhengshijian.Text.ToString();
                string ZhiLiang = zhiLiang.Text.ToString();
                string ResName = resName.Text.ToString();
                if (ZengSuShiJian != "" && WenDingShiJian != "" && FangZhenShiJian != "" && ZhiLiang != "" && ResName != "")
                {
                    List<string> para = new List<string>();

                    para.Add(ZengSuShiJian);
                    para.Add(WenDingShiJian);
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
