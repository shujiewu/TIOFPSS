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
        public ViewResult(string projectName,string path)
        {
            InitializeComponent();
            this.DataContext = new TIOFPSS.ViewModels.ResultPicViewModel(projectName,path);
        }
    }
}
