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
    /// ProjectCompareSelect.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectCompareSelect : Window
    {
        System.Collections.ObjectModel.ObservableCollection<ProjectPara> paraList = new System.Collections.ObjectModel.ObservableCollection<ProjectPara>();
        public ProjectCompareSelect()
        {
            InitializeComponent();
        }
        private void OnAddAClick(object sender, RoutedEventArgs e)
        {
            if(_valueSelectPath.Text.Equals(""))
            {
                TIOFPSS.Resources.MessageBoxX.Error("选择路径不能为空！");
            }
            else
            {
                if (System.IO.Directory.Exists(_valueSelectPath.Text + "\\project") && System.IO.Directory.Exists(_valueSelectPath.Text + "\\tempData"))
                {
                    string ProjPath = _valueSelectPath.Text.ToString();
                    string ProjName = ProjPath.Substring(ProjPath.LastIndexOf("\\")+1);
                    paraList.Add(new ProjectPara()
                    {
                        projPath=ProjPath,
                        projName=ProjName
                    });
                    this.DataContext = paraList;
                }
                else
                {
                    TIOFPSS.Resources.MessageBoxX.Error("路径选择有误！");
                }
            }
        }
        public Helper.delgateProjectCompareMethod CallBackMethod;
        private void OnCompareClick(object sender, RoutedEventArgs e)
        {
            if(paraList.Count!=0)
            {
                this.CallBackMethod(paraList.ToList());
                this.Close();
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Error("未选择任何项目！");
                this.Close();
            }
        }
        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            if(listView1.SelectedItem!=null)
            {
                int index = listView1.SelectedIndex;
                paraList.RemoveAt(index);
                this.DataContext = paraList;
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择要移除的项目！", this);
            }
        }
        

            
    }
    public class ProjectPara
    {
        public string projPath { get; set; }
        public string projName { get; set; }
    }
}
