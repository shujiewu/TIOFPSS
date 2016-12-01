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
    /// FXXSS_ShiYanWenJian.xaml 的交互逻辑
    /// </summary>
    public partial class FXXSS_ShiYanWenJian : Window
    {
        public FXXSS_ShiYanWenJian()
        {
            InitializeComponent();
        }
        private void OnFindClick(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            //fbd.ShowDialog();
            //if (fbd.SelectedPath != string.Empty)
            //    this._valueSelectPath.Text = fbd.SelectedPath;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "Worksheet Files(*.csv)|*.csv|All Files(*.*)|*.*||";
            openFileDialog1.FilterIndex =0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._valueSelectPath.Text = openFileDialog1.FileName;
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateFXXSS CallBackMethod;
        private void OnFXXSSClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (this.DialogResult.Value && CallBackMethod != null)
            {

                FXXSSFile fileData = new FXXSSFile(){
                row=_rowValue.Text.ToString(),
                col = _columnValue.Text.ToString(),
                td=_aisleValue.Text.ToString(),
                path=_valueSelectPath.Text.ToString()};
                if (fileData.row != null && fileData.col != null && fileData.td != null && fileData.path != null)
                {
                    this.CallBackMethod(fileData);
                    this.Close();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("参数输入有误!");
                }

            }
        }
    }
    public class FXXSSFile
    {
        public string row { get; set; }
        public string row1 { get; set; }
        public string row2 { get; set; }
        public string col { get; set; }
        public string td { get; set; }
        public string path { get; set; }
    }
}
