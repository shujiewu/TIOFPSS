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


        TextBlock tbJingTaiQiangDuFenXi;
        TextBlock tb2JingTaiQiangDuFenXi;
        int JingTaiQiangDuFenXi_h, JingTaiQiangDuFenXi_m, JingTaiQiangDuFenXi_s;

        TextBlock tbDuCengFenXi;
        TextBlock tb2DuCengFenXi;
        int DuCengFenXi_h, DuCengFenXi_m, DuCengFenXi_s;

        TextBlock tbYuYingLiFenXi;
        TextBlock tb2YuYingLiFenXi;
        int YuYingLiFenXi_h, YuYingLiFenXi_m, YuYingLiFenXi_s;

        TextBlock tbQuanChiPianXin;
        TextBlock tb2QuanChiPianXin;
        int QuanChiPianXin_h, QuanChiPianXin_m, QuanChiPianXin_s;

        TextBlock tbDongTaiFenXi;
        TextBlock tb2DongTaiFenXi;
        int DongTaiFenXi_h, DongTaiFenXi_m, DongTaiFenXi_s;

        TextBlock tbDongTaiYingLiJiSuan;
        TextBlock tb2DongTaiYingLiJiSuan;
        int DongTaiYingLiJiSuan_h, DongTaiYingLiJiSuan_m, DongTaiYingLiJiSuan_s;

        TextBlock tbMcpModel;
        TextBlock tb2McpModel;
        int McpModel_h, McpModel_m, McpModel_s;

        TextBlock tbMcpNgModel;
        TextBlock tb2McpNgModel;
        int McpNgModel_h, McpNgModel_m, McpNgModel_s;



        bool b_dangLiang, b_dongLiXue, b_feiXian, b_xieTong, b_zaoSheng;
        bool b_JingTaiQiangDuFenXi, b_DuCengFenXi, b_YuYingLiFenXi, b_QuanChiPianXin, b_DongTaiFenXi, b_DongTaiYingLiJiSuan, b_McpModel, b_McpNgModel;
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
            if (b_JingTaiQiangDuFenXi)
            {
                JingTaiQiangDuFenXi_s++;
                if (JingTaiQiangDuFenXi_s > 59)
                {
                    JingTaiQiangDuFenXi_m++;
                    JingTaiQiangDuFenXi_s = 0;
                    if (JingTaiQiangDuFenXi_m > 59)
                    {
                        JingTaiQiangDuFenXi_m = 0;
                        JingTaiQiangDuFenXi_h++;
                    }
                }
                tb2JingTaiQiangDuFenXi.Text = string.Format("{0}：{1}：{2}", JingTaiQiangDuFenXi_h.ToString().PadLeft(2, '0'), JingTaiQiangDuFenXi_m.ToString().PadLeft(2, '0'), JingTaiQiangDuFenXi_s.ToString().PadLeft(2, '0'));          
            }
            if (b_DuCengFenXi)
            {
                DuCengFenXi_s++;
                if (DuCengFenXi_s > 59)
                {
                    DuCengFenXi_m++;
                    DuCengFenXi_s = 0;
                    if (DuCengFenXi_m > 59)
                    {
                        DuCengFenXi_m = 0;
                        DuCengFenXi_h++;
                    }
                }
                tb2DuCengFenXi.Text = string.Format("{0}：{1}：{2}", DuCengFenXi_h.ToString().PadLeft(2, '0'), DuCengFenXi_m.ToString().PadLeft(2, '0'), DuCengFenXi_s.ToString().PadLeft(2, '0'));
            }
            if (b_YuYingLiFenXi)
            {
                YuYingLiFenXi_s++;
                if (YuYingLiFenXi_s > 59)
                {
                    YuYingLiFenXi_m++;
                    YuYingLiFenXi_s = 0;
                    if (YuYingLiFenXi_m > 59)
                    {
                        YuYingLiFenXi_m = 0;
                        YuYingLiFenXi_h++;
                    }
                }
                tb2YuYingLiFenXi.Text = string.Format("{0}：{1}：{2}", YuYingLiFenXi_h.ToString().PadLeft(2, '0'), YuYingLiFenXi_m.ToString().PadLeft(2, '0'), YuYingLiFenXi_s.ToString().PadLeft(2, '0'));
            }
            if (b_QuanChiPianXin)
            {
                QuanChiPianXin_s++;
                if (QuanChiPianXin_s > 59)
                {
                    QuanChiPianXin_m++;
                    QuanChiPianXin_s = 0;
                    if (QuanChiPianXin_m > 59)
                    {
                        QuanChiPianXin_m = 0;
                        QuanChiPianXin_h++;
                    }
                }
                tb2QuanChiPianXin.Text = string.Format("{0}：{1}：{2}", QuanChiPianXin_h.ToString().PadLeft(2, '0'), QuanChiPianXin_m.ToString().PadLeft(2, '0'), QuanChiPianXin_s.ToString().PadLeft(2, '0'));
            }
            if (b_DongTaiFenXi)
            {
                DongTaiFenXi_s++;
                if (DongTaiFenXi_s > 59)
                {
                    DongTaiFenXi_m++;
                    DongTaiFenXi_s = 0;
                    if (DongTaiFenXi_m > 59)
                    {
                        DongTaiFenXi_m = 0;
                        DongTaiFenXi_h++;
                    }
                }
                tb2DongTaiFenXi.Text = string.Format("{0}：{1}：{2}", DongTaiFenXi_h.ToString().PadLeft(2, '0'), DongTaiFenXi_m.ToString().PadLeft(2, '0'), DongTaiFenXi_s.ToString().PadLeft(2, '0'));
            }
            if (b_DongTaiYingLiJiSuan)
            {
                DongTaiYingLiJiSuan_s++;
                if (DongTaiYingLiJiSuan_s > 59)
                {
                    DongTaiYingLiJiSuan_m++;
                    DongTaiYingLiJiSuan_s = 0;
                    if (DongTaiYingLiJiSuan_m > 59)
                    {
                        DongTaiYingLiJiSuan_m = 0;
                        DongTaiYingLiJiSuan_h++;
                    }
                }
                tb2DongTaiYingLiJiSuan.Text = string.Format("{0}：{1}：{2}", DongTaiYingLiJiSuan_h.ToString().PadLeft(2, '0'), DongTaiYingLiJiSuan_m.ToString().PadLeft(2, '0'), DongTaiYingLiJiSuan_s.ToString().PadLeft(2, '0'));
            }
            if (b_McpModel)
            {
                McpModel_s++;
                if (McpModel_s > 59)
                {
                    McpModel_m++;
                    McpModel_s = 0;
                    if (McpModel_m > 59)
                    {
                        McpModel_m = 0;
                        McpModel_h++;
                    }
                }
                tb2McpModel.Text = string.Format("{0}：{1}：{2}", McpModel_h.ToString().PadLeft(2, '0'), McpModel_m.ToString().PadLeft(2, '0'), McpModel_s.ToString().PadLeft(2, '0'));
            }
            if (b_McpNgModel)
            {
                McpNgModel_s++;
                if (McpNgModel_s > 59)
                {
                    McpNgModel_m++;
                    McpNgModel_s = 0;
                    if (McpNgModel_m > 59)
                    {
                        McpNgModel_m = 0;
                        McpNgModel_h++;
                    }
                }
                tb2McpNgModel.Text = string.Format("{0}：{1}：{2}", McpNgModel_h.ToString().PadLeft(2, '0'), McpNgModel_m.ToString().PadLeft(2, '0'), McpNgModel_s.ToString().PadLeft(2, '0'));
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


        public void JingTaiQiangDuFenXi_start()
        {
            JingTaiQiangDuFenXi_h = 0;
            JingTaiQiangDuFenXi_m = 0;
            JingTaiQiangDuFenXi_s = 0;

            tbJingTaiQiangDuFenXi = new TextBlock();
            tbJingTaiQiangDuFenXi.Text = "少齿当量静态强度分析";
            tbJingTaiQiangDuFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbJingTaiQiangDuFenXi, analysisCount);
            Grid.SetColumn(tbJingTaiQiangDuFenXi, 0);
            grid.Children.Add(tbJingTaiQiangDuFenXi);

            tb2JingTaiQiangDuFenXi = new TextBlock();
            tb2JingTaiQiangDuFenXi.Text = "00：00：00";
            tb2JingTaiQiangDuFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2JingTaiQiangDuFenXi, analysisCount);
            Grid.SetColumn(tb2JingTaiQiangDuFenXi, 1);
            grid.Children.Add(tb2JingTaiQiangDuFenXi);


            analysisCount++;
            b_JingTaiQiangDuFenXi = true;
        }
        public void JingTaiQiangDuFenXi_stop()
        {
            b_JingTaiQiangDuFenXi = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("少齿当量静态强度分析"))
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
            Grid.SetRow(tbJingTaiQiangDuFenXi, finishCount);
            Grid.SetColumn(tbJingTaiQiangDuFenXi, 0);
            gridFinish.Children.Add(tbJingTaiQiangDuFenXi);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2JingTaiQiangDuFenXi,finishCount);
            Grid.SetColumn(tb2JingTaiQiangDuFenXi, 1);
            gridFinish.Children.Add(tb2JingTaiQiangDuFenXi);

            finishCount++;
        }



        public void DuCengFenXi_start()
        {
            DuCengFenXi_h = 0;
            DuCengFenXi_m = 0;
            DuCengFenXi_s = 0;

            tbDuCengFenXi = new TextBlock();
            tbDuCengFenXi.Text = "镀层少齿当量分析";
            tbDuCengFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbDuCengFenXi, analysisCount);
            Grid.SetColumn(tbDuCengFenXi, 0);
            grid.Children.Add(tbDuCengFenXi);

            tb2DuCengFenXi = new TextBlock();
            tb2DuCengFenXi.Text = "00：00：00";
            tb2DuCengFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DuCengFenXi, analysisCount);
            Grid.SetColumn(tb2DuCengFenXi, 1);
            grid.Children.Add(tb2DuCengFenXi);


            analysisCount++;
            b_DuCengFenXi = true;
        }
        public void DuCengFenXi_stop()
        {
            b_DuCengFenXi = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("镀层少齿当量分析"))
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
            Grid.SetRow(tbDuCengFenXi, finishCount);
            Grid.SetColumn(tbDuCengFenXi, 0);
            gridFinish.Children.Add(tbDuCengFenXi);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DuCengFenXi, finishCount);
            Grid.SetColumn(tb2DuCengFenXi, 1);
            gridFinish.Children.Add(tb2DuCengFenXi);

            finishCount++;
        }


        public void YuYingLiFenXi_start()
        {
            YuYingLiFenXi_h = 0;
            YuYingLiFenXi_m = 0;
            YuYingLiFenXi_s = 0;

            tbYuYingLiFenXi = new TextBlock();
            tbYuYingLiFenXi.Text = "淬火少齿当量分析";
            tbYuYingLiFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbYuYingLiFenXi, analysisCount);
            Grid.SetColumn(tbYuYingLiFenXi, 0);
            grid.Children.Add(tbYuYingLiFenXi);

            tb2YuYingLiFenXi = new TextBlock();
            tb2YuYingLiFenXi.Text = "00：00：00";
            tb2YuYingLiFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2YuYingLiFenXi, analysisCount);
            Grid.SetColumn(tb2YuYingLiFenXi, 1);
            grid.Children.Add(tb2YuYingLiFenXi);


            analysisCount++;
            b_YuYingLiFenXi = true;
        }
        public void YuYingLiFenXi_stop()
        {
            b_YuYingLiFenXi = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("淬火少齿当量分析"))
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
            Grid.SetRow(tbYuYingLiFenXi, finishCount);
            Grid.SetColumn(tbYuYingLiFenXi, 0);
            gridFinish.Children.Add(tbYuYingLiFenXi);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2YuYingLiFenXi, finishCount);
            Grid.SetColumn(tb2YuYingLiFenXi, 1);
            gridFinish.Children.Add(tb2YuYingLiFenXi);

            finishCount++;
        }


        public void QuanChiPianXin_start()
        {
            QuanChiPianXin_h = 0;
            QuanChiPianXin_m = 0;
            QuanChiPianXin_s = 0;

            tbQuanChiPianXin = new TextBlock();
            tbQuanChiPianXin.Text = "全齿静态强度分析";
            tbQuanChiPianXin.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbQuanChiPianXin, analysisCount);
            Grid.SetColumn(tbQuanChiPianXin, 0);
            grid.Children.Add(tbQuanChiPianXin);

            tb2QuanChiPianXin = new TextBlock();
            tb2QuanChiPianXin.Text = "00：00：00";
            tb2QuanChiPianXin.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2QuanChiPianXin, analysisCount);
            Grid.SetColumn(tb2QuanChiPianXin, 1);
            grid.Children.Add(tb2QuanChiPianXin);


            analysisCount++;
            b_QuanChiPianXin = true;
        }
        public void QuanChiPianXin_stop()
        {
            b_QuanChiPianXin = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("全齿静态强度分析"))
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
            Grid.SetRow(tbQuanChiPianXin, finishCount);
            Grid.SetColumn(tbQuanChiPianXin, 0);
            gridFinish.Children.Add(tbQuanChiPianXin);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2QuanChiPianXin, finishCount);
            Grid.SetColumn(tb2QuanChiPianXin, 1);
            gridFinish.Children.Add(tb2QuanChiPianXin);

            finishCount++;
        }


        public void DongTaiFenXi_start()
        {
            DongTaiFenXi_h = 0;
            DongTaiFenXi_m = 0;
            DongTaiFenXi_s = 0;

            tbDongTaiFenXi = new TextBlock();
            tbDongTaiFenXi.Text = "动态分析";
            tbDongTaiFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbDongTaiFenXi, analysisCount);
            Grid.SetColumn(tbDongTaiFenXi, 0);
            grid.Children.Add(tbDongTaiFenXi);

            tb2DongTaiFenXi = new TextBlock();
            tb2DongTaiFenXi.Text = "00：00：00";
            tb2DongTaiFenXi.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DongTaiFenXi, analysisCount);
            Grid.SetColumn(tb2DongTaiFenXi, 1);
            grid.Children.Add(tb2DongTaiFenXi);


            analysisCount++;
            b_DongTaiFenXi = true;
        }
        public void DongTaiFenXi_stop()
        {
            b_DongTaiFenXi = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("动态分析"))
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
            Grid.SetRow(tbDongTaiFenXi, finishCount);
            Grid.SetColumn(tbDongTaiFenXi, 0);
            gridFinish.Children.Add(tbDongTaiFenXi);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DongTaiFenXi, finishCount);
            Grid.SetColumn(tb2DongTaiFenXi, 1);
            gridFinish.Children.Add(tb2DongTaiFenXi);

            finishCount++;
        }


        public void DongTaiYingLiJiSuan_start()
        {
            DongTaiYingLiJiSuan_h = 0;
            DongTaiYingLiJiSuan_m = 0;
            DongTaiYingLiJiSuan_s = 0;

            tbDongTaiYingLiJiSuan = new TextBlock();
            tbDongTaiYingLiJiSuan.Text = "准动态分析";
            tbDongTaiYingLiJiSuan.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbDongTaiYingLiJiSuan, analysisCount);
            Grid.SetColumn(tbDongTaiYingLiJiSuan, 0);
            grid.Children.Add(tbDongTaiYingLiJiSuan);

            tb2DongTaiYingLiJiSuan = new TextBlock();
            tb2DongTaiYingLiJiSuan.Text = "00：00：00";
            tb2DongTaiYingLiJiSuan.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DongTaiYingLiJiSuan, analysisCount);
            Grid.SetColumn(tb2DongTaiYingLiJiSuan, 1);
            grid.Children.Add(tb2DongTaiYingLiJiSuan);


            analysisCount++;
            b_DongTaiYingLiJiSuan = true;
        }
        public void DongTaiYingLiJiSuan_stop()
        {
            b_DongTaiYingLiJiSuan = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("准动态分析"))
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
            Grid.SetRow(tbDongTaiYingLiJiSuan, finishCount);
            Grid.SetColumn(tbDongTaiYingLiJiSuan, 0);
            gridFinish.Children.Add(tbDongTaiYingLiJiSuan);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2DongTaiYingLiJiSuan, finishCount);
            Grid.SetColumn(tb2DongTaiYingLiJiSuan, 1);
            gridFinish.Children.Add(tb2DongTaiYingLiJiSuan);

            finishCount++;
        }


        public void McpModel_start()
        {
            McpModel_h = 0;
            McpModel_m = 0;
            McpModel_s = 0;

            tbMcpModel = new TextBlock();
            tbMcpModel.Text = "摩擦片模态计算";
            tbMcpModel.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbMcpModel, analysisCount);
            Grid.SetColumn(tbMcpModel, 0);
            grid.Children.Add(tbMcpModel);

            tb2McpModel = new TextBlock();
            tb2McpModel.Text = "00：00：00";
            tb2McpModel.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2McpModel, analysisCount);
            Grid.SetColumn(tb2McpModel, 1);
            grid.Children.Add(tb2McpModel);


            analysisCount++;
            b_McpModel = true;
        }
        public void McpModel_stop()
        {
            b_McpModel = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("摩擦片模态计算"))
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
            Grid.SetRow(tbMcpModel, finishCount);
            Grid.SetColumn(tbMcpModel, 0);
            gridFinish.Children.Add(tbMcpModel);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2McpModel, finishCount);
            Grid.SetColumn(tb2McpModel, 1);
            gridFinish.Children.Add(tb2McpModel);

            finishCount++;
        }


        public void McpNgModel_start()
        {
            McpNgModel_h = 0;
            McpNgModel_m = 0;
            McpNgModel_s = 0;

            tbMcpNgModel = new TextBlock();
            tbMcpNgModel.Text = "摩擦片内毂模态计算";
            tbMcpNgModel.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetRow(tbMcpNgModel, analysisCount);
            Grid.SetColumn(tbMcpNgModel, 0);
            grid.Children.Add(tbMcpNgModel);

            tb2McpNgModel = new TextBlock();
            tb2McpNgModel.Text = "00：00：00";
            tb2McpNgModel.Margin = new Thickness(20, 10, 5, 5);
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row2);
            Grid.SetRow(tb2McpNgModel, analysisCount);
            Grid.SetColumn(tb2McpNgModel, 1);
            grid.Children.Add(tb2McpNgModel);


            analysisCount++;
            b_McpNgModel = true;
        }
        public void McpNgModel_stop()
        {
            b_McpNgModel = false;
            analysisCount--;
            if (grid.Children.Count > 0)
            {
                int removeIndex = 0;
                //bool isRemove = false;
                foreach (TextBlock item in grid.Children)
                {

                    if (item.Text.Equals("摩擦片内毂模态计算"))
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
            Grid.SetRow(tbMcpNgModel, finishCount);
            Grid.SetColumn(tbMcpNgModel, 0);
            gridFinish.Children.Add(tbMcpNgModel);

            RowDefinition row2 = new RowDefinition();
            gridFinish.RowDefinitions.Add(row2);
            Grid.SetRow(tb2McpNgModel, finishCount);
            Grid.SetColumn(tb2McpNgModel, 1);
            gridFinish.Children.Add(tb2McpNgModel);

            finishCount++;
        }
    }
}
