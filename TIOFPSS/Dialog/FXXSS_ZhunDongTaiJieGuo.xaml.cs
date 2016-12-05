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
    /// FXXSS_ZhunDongTaiJieGuo.xaml 的交互逻辑
    /// </summary>
    public partial class FXXSS_ZhunDongTaiJieGuo : Window
    {
        public FXXSS_ZhunDongTaiJieGuo()
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
            openFileDialog1.InitialDirectory = "e:\\";
            openFileDialog1.Filter = "Worksheet Files(*.csv)|*.csv|All Files(*.*)|*.*||";
            openFileDialog1.FilterIndex = 0;
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
            //this.DialogResult = true;
            //if (this.DialogResult.Value && CallBackMethod != null)
            //{

                FXXSSFile fileData = new FXXSSFile()
                {
                    path = _valueSelectPath.Text.ToString()
                };
                if (fileData.path != "")
                {
                    this.CallBackMethod(fileData);
                    this.Close();
                }
                else
                {
                    TIOFPSS.Resources.MessageBoxX.Error("参数输入有误!", this);
                }

            //}
        }
    }
}
