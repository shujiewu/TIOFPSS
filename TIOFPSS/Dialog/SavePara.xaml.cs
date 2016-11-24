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
    /// SavePara.xaml 的交互逻辑
    /// </summary>
    public partial class SavePara : Window
    {
        public SavePara()
        {
            InitializeComponent();
        }
        DB.UserProject userProject;
        public SavePara(DB.UserProject userProj)
        {
            userProject = userProj;
            InitializeComponent();
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            userProject.ProjectName = libName.Text.ToString();
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            if (bll.AddLib(userProject) == true)//将用户信息添加到数据库中，根据返回值判断是否添加成功
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("数据添加成功");
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("数据添加失败");
            }
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
