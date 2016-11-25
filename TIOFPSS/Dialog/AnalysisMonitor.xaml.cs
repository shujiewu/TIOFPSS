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
    /// AnalysisMonitor.xaml 的交互逻辑
    /// </summary>
    public partial class AnalysisMonitor : UserControl
    {
        int dongLiXue_h;
        int dongLiXue_m;
        int dongLiXue_s;
        int analysisCount = 0;
        int finishCount = 0;
        TextBlock tb;
        TextBlock tb2;

        TextBlock tbZaoSheng;
        TextBlock tb2ZaoSheng;
        int zaoSheng_h, zaoSheng_m, zaoSheng_s;

        TextBlock tbDLZHP;
        TextBlock tb2DLZHP;
        int dangLiang_h,dangLiang_m, dangLiang_s;

        TextBlock tbFXXSS;
        TextBlock tb2FXXSS;
        int feiXian_h, feiXian_m, feiXian_s;

        bool b_dangLiang, b_dongLiXue, b_feiXian, b_xieTong, b_zaoSheng;

        public AnalysisMonitor()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(analysisCount>0)
            {
                proBar.Visibility = Visibility.Visible;
            }
            else
            {
                proBar.Visibility = Visibility.Collapsed;
                return;
            }
            if(b_dongLiXue)
            {
                dongLiXue_s++;
                if (dongLiXue_s > 59)
                {
                    dongLiXue_m++;
                    dongLiXue_s = 0;
                    if (dongLiXue_m > 59)
                    {
                        dongLiXue_m = 0;
                        dongLiXue_h++;
                    }
                }
                tb2.Text = string.Format("{0}：{1}：{2}", dongLiXue_h.ToString().PadLeft(2, '0'), dongLiXue_m.ToString().PadLeft(2, '0'), dongLiXue_s.ToString().PadLeft(2, '0'));
            }
            if (b_zaoSheng)
            {
                zaoSheng_s++;
                if (zaoSheng_s > 59)
                {
                    zaoSheng_m++;
                    zaoSheng_s = 0;
                    if (zaoSheng_m > 59)
                    {
                        zaoSheng_m = 0;
                        zaoSheng_h++;
                    }
                }
                tb2ZaoSheng.Text = string.Format("{0}：{1}：{2}", zaoSheng_h.ToString().PadLeft(2, '0'), zaoSheng_m.ToString().PadLeft(2, '0'), zaoSheng_s.ToString().PadLeft(2, '0'));
                //m_time_ZaoSheng.Format("%d:%d:%d", zaoSheng_h, zaoSheng_m, zaoSheng_s);
            }
            if (b_dangLiang)
            {
                dangLiang_s++;
                if (dangLiang_s > 59)
                {
                    dangLiang_m++;
                    dangLiang_s = 0;
                    if (dangLiang_m > 59)
                    {
                        dangLiang_m = 0;
                        dangLiang_h++;
                    }
                }
                tb2DLZHP.Text = string.Format("{0}：{1}：{2}", dangLiang_h.ToString().PadLeft(2, '0'), dangLiang_m.ToString().PadLeft(2, '0'), dangLiang_s.ToString().PadLeft(2, '0'));
                //m_time_ZaoSheng.Format("%d:%d:%d", zaoSheng_h, zaoSheng_m, zaoSheng_s);
            }
            if (b_feiXian)
            {
                feiXian_s++;
                if (feiXian_s > 59)
                {
                    feiXian_m++;
                    feiXian_s = 0;
                    if (feiXian_m > 59)
                    {
                        feiXian_m = 0;
                        feiXian_h++;
                    }
                }
                tb2FXXSS.Text = string.Format("{0}：{1}：{2}", feiXian_h.ToString().PadLeft(2, '0'), feiXian_m.ToString().PadLeft(2, '0'), feiXian_s.ToString().PadLeft(2, '0'));
                //m_time_ZaoSheng.Format("%d:%d:%d", zaoSheng_h, zaoSheng_m, zaoSheng_s);
            }

        }
        public void dongLiXue_start(string analysisName)
        {
	        dongLiXue_h=0;
	        dongLiXue_m=0;
	        dongLiXue_s=0;


            tb = new TextBlock();
            tb.Text = analysisName;
            tb.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tb, analysisCount);
            Grid.SetColumn(tb, 0);
            grid.Children.Add(tb);

            tb2 = new TextBlock();
            tb2.Text = "00：00：00";
            tb2.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2, analysisCount);
            Grid.SetColumn(tb2, 1);
            grid.Children.Add(tb2);


            analysisCount++;
            b_dongLiXue = true;
            
        }
        public void dongLiXue_stop(string analysisName)
        {
	        b_dongLiXue=false;
            analysisCount--;




            if (grid.Children.Count > 0)
            {
                int removeIndex=0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals(analysisName))
                    {
                        grid.Children.RemoveRange(removeIndex, 2);
                        grid.RowDefinitions.RemoveAt(removeIndex); //删除行定义
                        break;
                    }
                    removeIndex++;
                    
                }
                foreach (TextBlock item in grid.Children)
                {
                    if (Grid.GetRow(item)>removeIndex)
                    {
                        Grid.SetRow(item, (Grid.GetRow(item) - 1));//减1
                    }
                }
            }

            RowDefinition row = new RowDefinition();
            gridFinish.RowDefinitions.Add(row);
            Grid.SetRow(tb, finishCount);
            Grid.SetColumn(tb, 0);
            gridFinish.Children.Add(tb);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2, finishCount);
            Grid.SetColumn(tb2, 1);
            gridFinish.Children.Add(tb2);

            finishCount++;               
        }
        public void zaoSheng_start()
        {
	        zaoSheng_h=0;
	        zaoSheng_m=0;
	        zaoSheng_s=0;

            tbZaoSheng = new TextBlock();
            tbZaoSheng.Text = "噪声分析";
            tbZaoSheng.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbZaoSheng, analysisCount);
            Grid.SetColumn(tbZaoSheng, 0);
            grid.Children.Add(tbZaoSheng);

            tb2ZaoSheng = new TextBlock();
            tb2ZaoSheng.Text = "00：00：00";
            tb2ZaoSheng.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2ZaoSheng, analysisCount);
            Grid.SetColumn(tb2ZaoSheng, 1);
            grid.Children.Add(tb2ZaoSheng);


            analysisCount++;
	        b_zaoSheng=true;
        }
        public void zaoSheng_stop()
        {
	        b_zaoSheng=false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex=0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {
                    
                    if (item.Text.Equals("噪声分析"))
                    {
                        grid.Children.RemoveRange(removeIndex, 2);
                        grid.RowDefinitions.RemoveAt(removeIndex); //删除行定义
                        break;
                    }
                    removeIndex++;
                    
                }
                foreach (TextBlock item in grid.Children)
                {
                    if (Grid.GetRow(item)>removeIndex)
                    {
                        Grid.SetRow(item, (Grid.GetRow(item) - 1));//减1
                    }
                }
            }

            RowDefinition row = new RowDefinition();
            gridFinish.RowDefinitions.Add(row);
            Grid.SetRow(tbZaoSheng, finishCount);
            Grid.SetColumn(tbZaoSheng, 0);
            gridFinish.Children.Add(tbZaoSheng);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2ZaoSheng, finishCount);
            Grid.SetColumn(tb2ZaoSheng, 1);
            gridFinish.Children.Add(tb2ZaoSheng);

            finishCount++;   
        }


        public void DLZHP_start(string fileType)
        {
            dangLiang_h = 0;
            dangLiang_m = 0;
            dangLiang_s = 0;

            tbDLZHP = new TextBlock();
            tbDLZHP.Text = "当量载荷谱分析：" + fileType;
            tbDLZHP.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbDLZHP, analysisCount);
            Grid.SetColumn(tbDLZHP, 0);
            grid.Children.Add(tbDLZHP);

            tb2DLZHP = new TextBlock();
            tb2DLZHP.Text = "00：00：00";
            tb2DLZHP.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DLZHP, analysisCount);
            Grid.SetColumn(tb2DLZHP, 1);
            grid.Children.Add(tb2DLZHP);


            analysisCount++;
            b_dangLiang = true;
        }
        public void DLZHP_stop(string fileType)
        {
            b_dangLiang = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("当量载荷谱分析：" + fileType))
                    {
                        grid.Children.RemoveRange(removeIndex, 2);
                        grid.RowDefinitions.RemoveAt(removeIndex); //删除行定义
                        break;
                    }
                    removeIndex++;

                }
                foreach (TextBlock item in grid.Children)
                {
                    if (Grid.GetRow(item) > removeIndex)
                    {
                        Grid.SetRow(item, (Grid.GetRow(item) - 1));//减1
                    }
                }
            }

            RowDefinition row = new RowDefinition();
            gridFinish.RowDefinitions.Add(row);
            Grid.SetRow(tbDLZHP, finishCount);
            Grid.SetColumn(tbDLZHP, 0);
            gridFinish.Children.Add(tbDLZHP);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DLZHP, finishCount);
            Grid.SetColumn(tb2DLZHP, 1);
            gridFinish.Children.Add(tb2DLZHP);

            finishCount++;
        }

        public void FXXSS_start(string fileType)
        {
            feiXian_h = 0;
            feiXian_m = 0;
            feiXian_s = 0;

            tbFXXSS = new TextBlock();
            tbFXXSS.Text = "非线性损伤分析：" + fileType;
            tbFXXSS.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbFXXSS, analysisCount);
            Grid.SetColumn(tbFXXSS, 0);
            grid.Children.Add(tbFXXSS);

            tb2FXXSS = new TextBlock();
            tb2FXXSS.Text = "00：00：00";
            tb2FXXSS.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2FXXSS, analysisCount);
            Grid.SetColumn(tb2FXXSS, 1);
            grid.Children.Add(tb2FXXSS);


            analysisCount++;
            b_feiXian = true;
        }
        public void FXXSS_stop(string fileType)
        {
            b_feiXian = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("非线性损伤分析：" + fileType))
                    {
                        grid.Children.RemoveRange(removeIndex, 2);
                        grid.RowDefinitions.RemoveAt(removeIndex); //删除行定义
                        break;
                    }
                    removeIndex++;

                }
                foreach (TextBlock item in grid.Children)
                {
                    if (Grid.GetRow(item) > removeIndex)
                    {
                        Grid.SetRow(item, (Grid.GetRow(item) - 1));//减1
                    }
                }
            }

            RowDefinition row = new RowDefinition();
            gridFinish.RowDefinitions.Add(row);
            Grid.SetRow(tbFXXSS, finishCount);
            Grid.SetColumn(tbFXXSS, 0);
            gridFinish.Children.Add(tbFXXSS);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2FXXSS, finishCount);
            Grid.SetColumn(tb2FXXSS, 1);
            gridFinish.Children.Add(tb2FXXSS);

            finishCount++;
        }
    }
}
