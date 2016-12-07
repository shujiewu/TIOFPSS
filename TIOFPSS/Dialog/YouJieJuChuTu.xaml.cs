using MathNet.Numerics.Data.Matlab;
using MathNet.Numerics.LinearAlgebra;
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
using MathWorks.MATLAB.NET.Arrays;
using jjwc;

namespace TIOFPSS.Dialog
{
    /// <summary>
    /// YouJieJuChuTu.xaml 的交互逻辑
    /// </summary>
    public partial class YouJieJuChuTu : Window
    {
        System.Collections.ObjectModel.ObservableCollection<YouJieJuChuTuPara> paraList = new System.Collections.ObjectModel.ObservableCollection<YouJieJuChuTuPara>();
        int shinum=0;
        int founum=0;
        double maxyingli = 0;//获取最大应力
        string nowProjPath=null;
        string tempPath;
        string filePath;
        public YouJieJuChuTu(string NowProjPath)
        {
            InitializeComponent();
            nowProjPath = NowProjPath;

            tempPath = nowProjPath + "\\tempData\\冲击动力学分析结果\\";

            filePath = nowProjPath + "\\tempData\\冲击动力学分析结果\\Dynamic.mat";

            string matPath = nowProjPath + "\\tempData\\冲击动力学分析结果\\Pitch.mat";
            //if(!System.IO.File.Exists(matPath))
            //{
            //    TIOFPSS.Resources.MessageBoxX.Error("还未进行有节距误差分析！");
            //    //this.Close();
            //    return;
            //}

            Matrix<double> pitchLeft = MatlabReader.Read<double>(matPath, "pitchleft");
            Matrix<double> pitchRight = MatlabReader.Read<double>(matPath, "pitchright");
            Matrix<double> pMaxForce = MatlabReader.Read<double>(matPath, "maxforce");
            Matrix<double> pContact = MatlabReader.Read<double>(matPath, "contact");
            int n=pMaxForce.ColumnCount;
            int m = pMaxForce.RowCount;
            double[,] dPitchLeft = pitchLeft.ToArray();
            double[,] dPitchRight = pitchRight.ToArray();
            double[,] dMaxForce = pMaxForce.ToArray();
            double[,] dContact = pContact.ToArray();
            
            for (int i = 0; i < m; ++i)
            {
                double d1, d2, d3, d4;
                d1 = dPitchLeft[i,0];
                d2 = dPitchRight[i,0];
                d3 = dMaxForce[i,0];
                d4 = dContact[i,0];
                if (d3 > maxyingli)
                {
                    maxyingli = d3;
                }
                string strContact = null;
                if (d4 == 1)
                {
                    strContact = "是";
                    shinum++;
                }
                else
                {
                    strContact = "否";
                    founum++;
                }
                paraList.Add(new YouJieJuChuTuPara()
                {
                    Number=(i+1).ToString(),
                    PitchLeft=d1.ToString(),
                    PitchRight=d2.ToString(),
                    MaxForce=d3.ToString(),
                    Contact = strContact
                });
            }
            maxChongjili.Text = maxyingli.ToString();
            jiechugeshu.Text = shinum.ToString();
            meiyoujiechugeshu.Text = founum.ToString();
            this.DataContext = paraList;
        }

        private void OnChuTuClick(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\jjwc.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("缺少jjwc.dll！");
                //this.Close();
                return;
            }
            YouJieJuChuTuPara selectItem = this.listView1.SelectedItem as YouJieJuChuTuPara;
            if (selectItem != null)
            {
                //((CollectionViewSource)this.listView1.DataContext).Source
                if (selectItem.Contact == "否")
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("冲击力为0，不需要出图", this);
                    
                    return;
                }
                MWArray locc = new MWCharArray(filePath);
                MWArray loc = new MWCharArray(tempPath);

                int a = Convert.ToInt32(selectItem.Number);

                MWArray i = new MWNumericArray(a);
                jjwc.YouJieJuWuChaChuTuClass yjjct = new jjwc.YouJieJuWuChaChuTuClass();
                try
                {
                    WaitingBox.Show(() =>
                    {
                        yjjct.jjwc(locc, loc, i);
                        string force_source1 = tempPath+ "force+.txt"; //inf->path + "force+.txt";
                        string force_source2 = tempPath+ "force-.txt"; //inf->path + "force-.txt";
                        string dest_s1 = System.IO.Path.Combine(nowProjPath, "tempData\\ZhunDongTai\\force+.txt"); //inf->path + "fdynamic\\force+.txt";
                        string dest_s2 = System.IO.Path.Combine(nowProjPath, "tempData\\ZhunDongTai\\force-.txt"); //inf->path + "fdynamic\\force-.txt";
                        System.IO.File.Copy(force_source1, dest_s1, true);
                        System.IO.File.Copy(force_source2, dest_s2, true);
                    }, "正在出图，请稍后...");
                    TIOFPSS.Resources.MessageBoxX.Info("出图完成！",this);
                }
                catch
                {
                    TIOFPSS.Resources.MessageBoxX.Error("出图失败！");
                }
                 
                //((System.Collections.ObjectModel.ObservableCollection<DSFileList>)this.listView1.DataContext).RemoveAt(this.listView1.SelectedIndex);
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("未选择齿！", this);
            }
        }
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


       
    }
    public class YouJieJuChuTuPara
    {
        public string Number { get; set; }
        public string PitchLeft { get; set; }
        public string PitchRight { get; set; }
        public string MaxForce { get; set; }
        public string Contact { get; set; }
    }
}
