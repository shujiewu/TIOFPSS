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
    /// FXXSS_Dong.xaml 的交互逻辑
    /// </summary>
    public partial class FXXSS_DongTaiFenXi : Window
    {
        public FXXSS_DongTaiFenXi()
        {
            InitializeComponent();
            rbA.Checked += new RoutedEventHandler(radio_Checked);
            rbB.Checked += new RoutedEventHandler(radio_Checked);
            rbA.Unchecked += new RoutedEventHandler(radio_Unchecked);
            rbB.Unchecked += new RoutedEventHandler(radio_Unchecked);
            rbA.IsChecked = true;
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
                string rowValue1,rowValue2;
                if(rbA.IsChecked==true)
                {
                    rowValue1 = "0";
                    rowValue2 = "0";
                }
                else
                {
                    rowValue1 = _rowValue.Text.ToString();
                    rowValue2 =  _rowValue2.Text.ToString();
                }

                FXXSSFile fileData = new FXXSSFile()
                {
                    row1 =rowValue1 ,
                    row2 = rowValue2,
                    col = _columnValue.Text.ToString(),
                    path = _valueSelectPath.Text.ToString()
                };
                if (fileData.row1 != "" && fileData.row2 != "" && fileData.col != "" && fileData.path != "")
                {
                    this.CallBackMethod(fileData);
                    this.Close();
                }
                else
                {
                    TIOFPSS.Resources.MessageBoxX.Error("参数输入有误!");
                    return;
                    //Xceed.Wpf.Toolkit.MessageBox.Show("参数输入有误!");
                }

            //}
        }
        private void radio_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn == null)
                return;
            if (btn.Name == "rbA")
            {
                dao.Visibility = Visibility.Hidden;
                _rowValue.Visibility = Visibility.Hidden;
                _rowValue2.Visibility = Visibility.Hidden;
            }
            if (btn.Name == "rbB")
            {
                dao.Visibility = Visibility.Visible;
                _rowValue.Visibility = Visibility.Visible;
                _rowValue2.Visibility = Visibility.Visible;
            }
        }

        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn == null)
                return;
            if (btn.Name == "rbA")
            {
                dao.Visibility = Visibility.Hidden;
                _rowValue.Visibility = Visibility.Hidden;
                _rowValue2.Visibility = Visibility.Hidden;
            }
            if (btn.Name == "rbB")
            {
                dao.Visibility = Visibility.Visible;
                _rowValue.Visibility = Visibility.Visible;
                _rowValue2.Visibility = Visibility.Visible;
            }
        }
    }
}
