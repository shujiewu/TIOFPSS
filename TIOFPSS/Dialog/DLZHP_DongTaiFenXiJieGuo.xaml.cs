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
    /// DLZHP_DongTaiFenXiJieGuo.xaml 的交互逻辑
    /// </summary>
    public partial class DLZHP_DongTaiFenXiJieGuo : Window
    {
        public DLZHP_DongTaiFenXiJieGuo()
        {
            InitializeComponent();
        }
       System.Collections.ObjectModel.ObservableCollection<DSFileList> fileList = new System.Collections.ObjectModel.ObservableCollection<DSFileList>();
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

        private void OnAddFileClick(object sender, RoutedEventArgs e)
        {
            fileList.Add(new DSFileList()
            {
                row=_rowValue.Text.ToString(),
                col = _columnValue.Text.ToString(),
                qhxs = _coefficientValue.Text.ToString(),
                path=_valueSelectPath.Text.ToString()

            });
            this.listView1.DataContext = fileList;
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            if(this.listView1.SelectedItem!=null)
            {
                //((CollectionViewSource)this.listView1.DataContext).Source
                ((System.Collections.ObjectModel.ObservableCollection<DSFileList>)this.listView1.DataContext).RemoveAt(this.listView1.SelectedIndex);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Helper.delgateDLZHP CallBackMethod;
        private void OnDangLiangZaiHePuClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (this.DialogResult.Value && CallBackMethod != null)
            {

                List<DSFileList> fileData = new List<DSFileList>(); ;
                foreach(DSFileList item in fileList)
                {
                    fileData.Add(item);
                }
                this.CallBackMethod(fileData);
                this.Close();
            }
        }
    }
    //public class DSFileList
    //{
    //    public string row { get; set; }
    //    public string col { get; set; }
    //    public string qhxs { get; set; }
    //    public string td { get; set; }
    //    public string path { get; set; }
    //}
}
