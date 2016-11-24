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
    /// InputPara.xaml 的交互逻辑
    /// </summary>
    public partial class InputPara : UserControl
    {
        private string _projectName;//项目名
        public string ProjectName
        {
            set { _projectName = value; }
            get { return _projectName; }
        }

        private string _projectPath;//项目名
        public string ProjectPath
        {
            set { _projectPath = value; }
            get { return _projectPath; }
        }

        public InputPara(string ProjPath, string ProjName)
        {
            ProjectPath = ProjPath;
            ProjectName = ProjName;

            this.DataContext = new ViewModels.ParaViewModel(ProjectPath, ProjName);
            InitializeComponent();

        }
        public void getPara(List<string> para, string parap)
        {
            //string paraPath = System.IO.Path.Combine(this.ProjectPath, "参数文件\\parameter.xml");
            para.Add(txtChiShu.Text.ToString());
            para.Add(parap);
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            para.Add(txtChiShu.Text.ToString());
            //para[0]=txtChiShu.Text.ToString();
        }
        // public List<string> para=new List<string>();
        public InputPara()
        {
            InitializeComponent();
        }
    }
}
