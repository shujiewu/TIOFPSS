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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TIOFPSS.Dialog
{
    /// <summary>
    /// ViewResult.xaml 的交互逻辑
    /// </summary>
    public partial class ViewResult : UserControl
    {
        public ViewResult()
        {
            InitializeComponent();
        }
        string Path;
        string ProjectName;
        public ViewResult(string projectName,string path)
        {
            InitializeComponent();
            Path = path;
            ProjectName = projectName;
            this.DataContext = new TIOFPSS.ViewModels.ResultPicViewModel(projectName,path);
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewMoTaiResult MoTaiDialog = new ViewMoTaiResult(Path);
            MoTaiDialog.CallBackMethod = MoTaiResultShow;
            MoTaiDialog.Show();
        }
        private void MoTaiResultShow(int selection,List<int> selectIndex)
        {
            MoTaiResult.Children.Clear();
            string type;
            string yingliname;
            if(selection==1)
            {
                type = "MoChaPianMoTai";
                yingliname = "modal_m_s_";
            }
            else if (selection == 2)
            {
                type = "MoChaPianNeiGuMoTai";
                yingliname = "modal_s_";
            }
            else
            {
                type = null;
                yingliname = null;
            }
                for(int i=0;i<selectIndex.Count;++i)
                {
                    Image imgtemp1 = new Image();
                    Image imgtemp2 = new Image();

                    int index = selectIndex[i];
                    string yinglipicpath = "\\" + type + "\\" + yingliname + index + ".jpeg";
                    imgtemp1.Source = TIOFPSS.ViewModels.ResultPicViewModel.LoadImg(Path + yinglipicpath);
                    imgtemp1.Margin = new Thickness(30, 0, 30, 0);

                    Style myStyle = (Style)this.FindResource("ExpanderStyle");
                    Expander ex = new Expander();
                    ex.Header = type+"第" + index + "阶应力云图";
                    ex.Style = myStyle;
                    ex.Margin = new Thickness(10, 10, 0, 0);
                    ex.Content = imgtemp1;
                    MoTaiResult.Children.Add(ex);


                    string weiyipicpath = "\\" + type + "\\modal_u_" + index + ".jpeg";
                    imgtemp2.Source = TIOFPSS.ViewModels.ResultPicViewModel.LoadImg(Path + weiyipicpath);
                    imgtemp2.Margin = new Thickness(30, 0, 30, 0);
                    Expander ex2 = new Expander();
                    ex2.Header = type + "第" + index + "阶位移云图";
                    ex2.Style = myStyle;
                    ex2.Margin = new Thickness(10, 10, 0, 0);
                    ex2.Content = imgtemp2;
                    MoTaiResult.Children.Add(ex2);

                }
            


        }
    }
}
