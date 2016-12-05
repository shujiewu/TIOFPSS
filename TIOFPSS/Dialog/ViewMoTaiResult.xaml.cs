using System;
using System.Collections.Generic;
using System.IO;
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
    /// ViewMoTaiResult.xaml 的交互逻辑
    /// </summary>
    public partial class ViewMoTaiResult : Window
    {
        public ViewMoTaiResult()
        {
            InitializeComponent();
        }
        string PicPath;
        System.Collections.ObjectModel.ObservableCollection<ModelResult> fileList = new System.Collections.ObjectModel.ObservableCollection<ModelResult>();
        public ViewMoTaiResult(string path)
        {
            InitializeComponent();
            PicPath=path;
        }

        private List<string> ReadCSV(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            //创建读这个流的对象，第一个参数是文件流，第二个参数是编码（其实里面的值是多少对我们这个读没有什么问题）  
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

            string str = "";
            List<string> result = new List<string>();
            while (str != null)
            {
                str = sr.ReadLine();//读取一行  
                if (str == null) break;//读完了就跳出循环  
                result.Add(str);
                //String[] eachLine = new String[1];//因为知道每一行excel有2个单元格，所以string[2]  
                //string ser = eachLine[0];//jieshu
                //foreach (string element in eachLine)//对于这行中的每个元素  
                //{
                //    result.Add(element);
                //}
            }
            return result;
        }

        private int selection=0;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;
            string selectItem=cmb.SelectedItem.ToString();
            string filepath;
            List<string> result = new List<string>();
            if(selectItem.Equals("摩擦片模态结果"))
            {
                filepath = PicPath + "\\MoChaPianMoTai\\modal_mcp.csv";
                if (!System.IO.File.Exists(filepath))
                {
                    fileList.Clear();
                    this.gridList1.ItemsSource = fileList;
                    return;
                }
                result = ReadCSV(filepath);
                fileList.Clear();
                selectIndex.Clear();
                foreach(string item in result)
                {
                    string temp;
                    string first, last;
                    temp = item.Trim(' ');
                    temp = temp.Replace(" ", "");
                    int index = temp.IndexOf(".");
                    first = temp.Substring(0, index);
                    last = temp.Substring(index + 1);
                    
                    fileList.Add(new ModelResult()
                    {
                        JieShu = first,
                        Pinlv = last

                    });
                }
                selection = 1;
                this.gridList1.ItemsSource = fileList;
            }
            else if(selectItem.Equals("摩擦片内毂模态结果"))
            {
                filepath = PicPath + "\\MoChaPianNeiGuMoTai\\modal.csv";
                if (!System.IO.File.Exists(filepath))
                {
                    fileList.Clear();
                    this.gridList1.ItemsSource = fileList;
                    return;
                }
                result = ReadCSV(filepath);
                fileList.Clear();
                selectIndex.Clear();
                foreach (string item in result)
                {
                    string temp;
                    string first, last;
                    temp = item.Trim(' ');
                    temp = temp.Replace(" ", "");
                    int index = temp.IndexOf(".");
                    first = temp.Substring(0, index);
                    last = temp.Substring(index + 1);

                    fileList.Add(new ModelResult()
                    {
                        JieShu = first,
                        Pinlv = last

                    });
                }
                selection = 2;
                this.gridList1.ItemsSource  = fileList;
            }
        }

        public Helper.delgateViewMoTaiResultOKMethod CallBackMethod;
        private List<int> selectIndex = new List<int>();
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if(selectIndex.Count!=0)
            {
                this.CallBackMethod(selection, selectIndex);
            }            
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            int index = Convert.ToInt32(cb.Content.ToString());
            if (cb.IsChecked == true)
            {
                selectIndex.Add(index);  //如果选中就保存id   
            }
            else
            {
                selectIndex.Remove(index);   //如果选中取消就删除里面的id   
            }    
        }
    }

    public class ModelResult
    {
        public string JieShu { get; set; }
        public string Pinlv { get; set; }

        bool IsSelected { get; set; }
    }
}
