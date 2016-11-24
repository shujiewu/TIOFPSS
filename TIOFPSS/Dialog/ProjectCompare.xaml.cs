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
using TIOFPSS.ViewModels;

namespace TIOFPSS.Dialog
{
    /// <summary>
    /// ProjectCompare.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectCompare : UserControl
    {
        BitmapImage LoadImg(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                return null;
            }
            using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // just in case you want to load the image in another thread
                return bitmapImage;
            }

        }
        public ProjectCompare(List<string> path)
        {
            InitializeComponent();
            ProjCmpViewModel projCmpViewModel = new ProjCmpViewModel(path);


            MCPSJCS.SetValue(Grid.ColumnSpanProperty, path.Count+1);
            NGSJCS.SetValue(Grid.ColumnSpanProperty, path.Count+1);
            MCPQHCS.SetValue(Grid.ColumnSpanProperty,  path.Count+1);
            CSTJ.SetValue(Grid.ColumnSpanProperty, path.Count+1);
            JSTJ.SetValue(Grid.ColumnSpanProperty,path.Count+1);
            CLCS.SetValue(Grid.ColumnSpanProperty, path.Count+1);
            SYSJBD.SetValue(Grid.ColumnSpanProperty, path.Count+1);
            WCTJ.SetValue(Grid.ColumnSpanProperty, path.Count+1);

            //int width = (path.Count+1) * 200;
            ParaHeader.Width = (path.Count + 1) * 200;


            MoCaPianChonJiLi.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianChonJiLiPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianJiaoJiaSuDu.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianJiaSuDuPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianJiaoSuDu.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianSuDuPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianYuNeiGuXiangDuiNiuZhuan.SetValue(Grid.ColumnSpanProperty, path.Count);
            XiangDuiNiuZhuanJiaoDuPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianYuNeiGuXiangDuiXuanZhuan.SetValue(Grid.ColumnSpanProperty, path.Count);
            XiangDuiXuanZhuanJiaoDuPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            NeiGuJiaoJiaSuDu.SetValue(Grid.ColumnSpanProperty, path.Count);
            NeiGuJiaSuDuPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            NeiGuJiaoSuDu.SetValue(Grid.ColumnSpanProperty, path.Count);
            NeiGuSuDuPinPuTu.SetValue(Grid.ColumnSpanProperty, path.Count);
            NeiGuWeiYi.SetValue(Grid.ColumnSpanProperty, path.Count);
            MoCaPianWeiYi.SetValue(Grid.ColumnSpanProperty, path.Count);
            CJDLXHeader.Width = (path.Count + 1) * 400;
            
            
            
            FXXSSHeader.Width = (path.Count + 1) * 400;
            moChaPianChiGenYingLiShiYuBoXing.SetValue(Grid.ColumnSpanProperty, path.Count);
            moChaPianLeiJiSunShang.SetValue(Grid.ColumnSpanProperty, path.Count);
            DLZHPHeader.Width = (path.Count + 1) * 400;
            dangLiangZaiHePu.SetValue(Grid.ColumnSpanProperty, path.Count);
            yuLiuJiShuJieGuo.SetValue(Grid.ColumnSpanProperty, path.Count);
            ZSFXHeader.Width = (path.Count + 1) * 400;
            zaoShengFenXi.SetValue(Grid.ColumnSpanProperty, path.Count);
            XTFXHeader.Width = (path.Count + 1) * 400;
            pianxinyingliyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);
            pianxinweiyiyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);
            danchiyingliyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);
            danchiweiyiyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);
            ducengyingli.SetValue(Grid.ColumnSpanProperty, path.Count);
            ducengweiyiyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);
            yuyinliyiyingliyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);
            yuyingliweiyiyuntu.SetValue(Grid.ColumnSpanProperty, path.Count);

            for (int i = 0; i < path.Count; i++)
            {
                Label lb = new Label();

                Style myStyle = (Style)this.FindResource("ProductNameStyle");
                lb.Style = myStyle;
                lb.Content = projCmpViewModel.projects[i].ProjectName;
                if (i == 0)
                {
                    lb.Margin = new Thickness(0, 10, 0, 0);
                }
                else
                {
                    lb.Margin = new Thickness(1, 10, 0, 0);
                }
                ColumnDefinition col = new ColumnDefinition();
                FXXSSHeader.ColumnDefinitions.Add(col);
                Grid.SetRow(lb, 0);
                Grid.SetColumn(lb, i);
                FXXSSHeader.Children.Add(lb);
            }

            for (int i = 0; i < path.Count; i++)
            {
                Label lb = new Label();

                Style myStyle = (Style)this.FindResource("ProductNameStyle");
                lb.Style = myStyle;
                lb.Content = projCmpViewModel.projects[i].ProjectName;
                if (i == 0)
                {
                    lb.Margin = new Thickness(0, 10, 0, 0);
                }
                else
                {
                    lb.Margin = new Thickness(1, 10, 0, 0);
                }
                ColumnDefinition col = new ColumnDefinition();
                DLZHPHeader.ColumnDefinitions.Add(col);
                Grid.SetRow(lb, 0);
                Grid.SetColumn(lb, i);
                DLZHPHeader.Children.Add(lb);
            }

            for (int i = 0; i < path.Count; i++)
            {
                Label lb = new Label();

                Style myStyle = (Style)this.FindResource("ProductNameStyle");
                lb.Style = myStyle;
                lb.Content = projCmpViewModel.projects[i].ProjectName;
                if (i == 0)
                {
                    lb.Margin = new Thickness(0, 10, 0, 0);
                }
                else
                {
                    lb.Margin = new Thickness(1, 10, 0, 0);
                }
                ColumnDefinition col = new ColumnDefinition();
                ZSFXHeader.ColumnDefinitions.Add(col);
                Grid.SetRow(lb, 0);
                Grid.SetColumn(lb, i);
                ZSFXHeader.Children.Add(lb);

                GridzaoShengFenXi.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < path.Count; i++)
            {
                Label lb = new Label();

                Style myStyle = (Style)this.FindResource("ProductNameStyle");
                lb.Style = myStyle;
                lb.Content = projCmpViewModel.projects[i].ProjectName;
                if (i == 0)
                {
                    lb.Margin = new Thickness(0, 10, 0, 0);
                }
                else
                {
                    lb.Margin = new Thickness(1, 10, 0, 0);
                }
                ColumnDefinition col = new ColumnDefinition();
                XTFXHeader.ColumnDefinitions.Add(col);
                Grid.SetRow(lb, 0);
                Grid.SetColumn(lb, i);
                XTFXHeader.Children.Add(lb);
            }








            /////////////2222222222222222222
            for (int i = 0; i < path.Count; i++)
            {
                Label lb = new Label();

                Style myStyle = (Style)this.FindResource("ProductNameStyle");
                lb.Style = myStyle;
                lb.Content = projCmpViewModel.projects[i].ProjectName;
                if(i==0)
                {
                    lb.Margin = new Thickness(0, 10, 0, 0);
                }
                else
                {
                    lb.Margin = new Thickness(1, 10, 0, 0);
                }
                ColumnDefinition col = new ColumnDefinition();
                CJDLXHeader.ColumnDefinitions.Add(col);
                Grid.SetRow(lb, 0);
                Grid.SetColumn(lb, i);
                CJDLXHeader.Children.Add(lb);

                GridMoCaPianChonJiLi.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianChonJiLiPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianJiaoJiaSuDu.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianJiaSuDuPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianJiaoSuDu.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianSuDuPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianYuNeiGuXiangDuiNiuZhuan.ColumnDefinitions.Add(new ColumnDefinition());
                GridXiangDuiNiuZhuanJiaoDuPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianYuNeiGuXiangDuiXuanZhuan.ColumnDefinitions.Add(new ColumnDefinition());
                GridXiangDuiXuanZhuanJiaoDuPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridNeiGuJiaoJiaSuDu.ColumnDefinitions.Add(new ColumnDefinition());
                GridNeiGuJiaSuDuPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridNeiGuJiaoSuDu.ColumnDefinitions.Add(new ColumnDefinition());
                GridNeiGuSuDuPinPuTu.ColumnDefinitions.Add(new ColumnDefinition());
                GridNeiGuWeiYi.ColumnDefinitions.Add(new ColumnDefinition());
                GridMoCaPianWeiYi.ColumnDefinitions.Add(new ColumnDefinition());

            }
            GridMoCaPianChonJiLi.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianChonJiLiPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianJiaoJiaSuDu.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianJiaSuDuPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianJiaoSuDu.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianSuDuPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianYuNeiGuXiangDuiNiuZhuan.RowDefinitions.Add(new RowDefinition());
            GridXiangDuiNiuZhuanJiaoDuPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianYuNeiGuXiangDuiXuanZhuan.RowDefinitions.Add(new RowDefinition());
            GridXiangDuiXuanZhuanJiaoDuPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridNeiGuJiaoJiaSuDu.RowDefinitions.Add(new RowDefinition());
            GridNeiGuJiaSuDuPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridNeiGuJiaoSuDu.RowDefinitions.Add(new RowDefinition());
            GridNeiGuSuDuPinPuTu.RowDefinitions.Add(new RowDefinition());
            GridNeiGuWeiYi.RowDefinitions.Add(new RowDefinition());
            GridMoCaPianWeiYi.RowDefinitions.Add(new RowDefinition());
            
            for (int i = 0; i < path.Count; i++)
            {
                string PicPath = projCmpViewModel.projects[i].ProjectName+"\\tempData";
                Image imgtemp1 = new Image();
                imgtemp1.Source = LoadImg(PicPath + "\\摩擦片冲击力.png");
                if(i==0)
                {
                    imgtemp1.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp1.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp1, 0);
                Grid.SetColumn(imgtemp1, i);

                GridMoCaPianChonJiLi.Children.Add(imgtemp1);


 
                Image imgtemp2 = new Image();
                imgtemp2.Source = LoadImg(PicPath + "\\摩擦片冲击力频谱图.png");
                if (i == 0)
                {
                    imgtemp2.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp2.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp2, 0);
                Grid.SetColumn(imgtemp2, i);

                GridMoCaPianChonJiLiPinPuTu.Children.Add(imgtemp2);

                Image imgtemp3 = new Image();
                imgtemp3.Source = LoadImg(PicPath + "\\摩擦片加速度频谱图.png");
                if (i == 0)
                {
                    imgtemp3.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp3.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp3, 0);
                Grid.SetColumn(imgtemp3, i);

                GridMoCaPianJiaSuDuPinPuTu.Children.Add(imgtemp3);


                Image imgtemp4 = new Image();
                imgtemp4.Source = LoadImg(PicPath + "\\摩擦片角加速度.png");
                if (i == 0)
                {
                    imgtemp4.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp4.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp4, 0);
                Grid.SetColumn(imgtemp4, i);

                GridMoCaPianJiaoJiaSuDu.Children.Add(imgtemp4);


                Image imgtemp5 = new Image();
                imgtemp5.Source = LoadImg(PicPath + "\\摩擦片角速度.png");
                if (i == 0)
                {
                    imgtemp5.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp5.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp5, 0);
                Grid.SetColumn(imgtemp5, i);

                GridMoCaPianJiaoSuDu.Children.Add(imgtemp5);

                Image imgtemp6 = new Image();
                imgtemp6.Source = LoadImg(PicPath + "\\摩擦片速度频谱图.png");
                if (i == 0)
                {
                    imgtemp6.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp6.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp6, 0);
                Grid.SetColumn(imgtemp6, i);

                GridMoCaPianSuDuPinPuTu.Children.Add(imgtemp6);


                Image imgtemp7 = new Image();
                imgtemp7.Source = LoadImg(PicPath + "\\摩擦片位移.png");
                if (i == 0)
                {
                    imgtemp7.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp7.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp7, 0);
                Grid.SetColumn(imgtemp7, i);

                GridMoCaPianWeiYi.Children.Add(imgtemp7);


                Image imgtemp8 = new Image();
                imgtemp8.Source = LoadImg(PicPath + "\\摩擦片与内毂相对扭转角度.png");
                if (i == 0)
                {
                    imgtemp8.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp8.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp8, 0);
                Grid.SetColumn(imgtemp8, i);

                GridMoCaPianYuNeiGuXiangDuiNiuZhuan.Children.Add(imgtemp8);


                Image imgtemp9 = new Image();
                imgtemp9.Source = LoadImg(PicPath + "\\摩擦片与内毂相对旋转速度.png");
                if (i == 0)
                {
                    imgtemp9.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp9.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp9, 0);
                Grid.SetColumn(imgtemp9, i);

                GridMoCaPianYuNeiGuXiangDuiXuanZhuan.Children.Add(imgtemp9);


                Image imgtemp10 = new Image();
                imgtemp10.Source = LoadImg(PicPath + "\\内毂加速度频谱图.png");
                if (i == 0)
                {
                    imgtemp10.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp10.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp10, 0);
                Grid.SetColumn(imgtemp10, i);

                GridNeiGuJiaSuDuPinPuTu.Children.Add(imgtemp10);


                Image imgtemp11 = new Image();
                imgtemp11.Source = LoadImg(PicPath + "\\内毂角加速度.png");
                if (i == 0)
                {
                    imgtemp11.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp11.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp11, 0);
                Grid.SetColumn(imgtemp11, i);

                GridNeiGuJiaoJiaSuDu.Children.Add(imgtemp11);


                Image imgtemp12 = new Image();
                imgtemp12.Source = LoadImg(PicPath + "\\内毂角速度.png");
                if (i == 0)
                {
                    imgtemp12.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp12.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp12, 0);
                Grid.SetColumn(imgtemp12, i);

                GridNeiGuJiaoSuDu.Children.Add(imgtemp12);


                Image imgtemp13 = new Image();
                imgtemp13.Source = LoadImg(PicPath + "\\内毂速度频谱图.png");
                if (i == 0)
                {
                    imgtemp13.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp13.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp13, 0);
                Grid.SetColumn(imgtemp13, i);

                GridNeiGuSuDuPinPuTu.Children.Add(imgtemp13);

                Image imgtemp14 = new Image();
                imgtemp14.Source = LoadImg(PicPath + "\\内毂位移.png");
                if (i == 0)
                {
                    imgtemp14.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp14.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp14, 0);
                Grid.SetColumn(imgtemp14, i);
                GridNeiGuWeiYi.Children.Add(imgtemp14);

                Image imgtemp15 = new Image();
                imgtemp15.Source = LoadImg(PicPath + "\\相对扭转角度频谱图.png");
                if (i == 0)
                {
                    imgtemp15.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp15.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp15, 0);
                Grid.SetColumn(imgtemp15, i);

                GridXiangDuiNiuZhuanJiaoDuPinPuTu.Children.Add(imgtemp15);

                Image imgtemp16 = new Image();
                imgtemp16.Source = LoadImg(PicPath + "\\相对旋转速度频谱图.png");
                if (i == 0)
                {
                    imgtemp16.Margin = new Thickness(1, 2, 2, 2);
                }
                else
                {
                    imgtemp16.Margin = new Thickness(2, 2, 2, 2);
                }
                Grid.SetRow(imgtemp16, 0);
                Grid.SetColumn(imgtemp16, i);

                GridXiangDuiXuanZhuanJiaoDuPinPuTu.Children.Add(imgtemp16);
            }




            //111111
             for(int i=0;i<path.Count;i++)
             {
                 Label lb =new Label();

                 Style myStyle = (Style)this.FindResource("ProductNameStyle");
                 lb.Style = myStyle;
                 lb.Content=projCmpViewModel.projects[i].ProjectName;
                 lb.Margin = new Thickness(1,10,0,0);
                 ColumnDefinition col=new ColumnDefinition();
                 ParaHeader.ColumnDefinitions.Add(col);                
                 Grid.SetRow(lb, 0);
                 Grid.SetColumn(lb, i+1);
                 ParaHeader.Children.Add(lb);

                 GridMCPSJCS.ColumnDefinitions.Add(new ColumnDefinition());
                 GridNGSJCS.ColumnDefinitions.Add(new ColumnDefinition());
                 GridMCPQHCS.ColumnDefinitions.Add(new ColumnDefinition());
                 GridCSTJ.ColumnDefinitions.Add(new ColumnDefinition());
                 GridJSTJ.ColumnDefinitions.Add(new ColumnDefinition());
                 GridCLCS.ColumnDefinitions.Add(new ColumnDefinition());
                 GridSYSJBD.ColumnDefinitions.Add(new ColumnDefinition());
                 GridWCTJ.ColumnDefinitions.Add(new ColumnDefinition());
                


                 //for (int j = 0; j < 9; j++)
                 //{
                 //    Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 //    Label lbtemp = new Label();
                 //    lbtemp.Style = myStyletemp;
                 //    lbtemp.Content = projCmpViewModel.projects[i].NgBSB;
                 //    lbtemp.Margin = new Thickness(1,1, 0, 0);

                 //    Grid.SetRow(lbtemp, j);
                 //    Grid.SetColumn(lbtemp, i + 3);
                 //    GridNGSJCS.Children.Add(lbtemp);E:\学习\实习\TIOFPSS\TIOFPSS\Dialog\InputPara.xaml

                 //}
                             
             }
             GridMCPSJCS.ColumnDefinitions.Add(new ColumnDefinition());
             string[] mcpsjcs = { "齿数", "模数(mm)", "压力角(°)", "齿顶高(mm)", "齿根高(mm)", "齿根圆角(mm)", "外径(mm)", "公法线长度公差(mm)", "厚度(mm)", "齿侧间隙(mm)" };
             for (int k = 0; k < 10;k++ )
             {                
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = mcpsjcs[k];
                 if(k==0)
                 {
                     lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 }
                 else
                 {
                     lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 }
                 GridMCPSJCS.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridMCPSJCS.Children.Add(lbtemp);
             }

             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].ChiShu;
                 if (projCmpViewModel.projects[i].ChiShu != projCmpViewModel.projects[0].ChiShu)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }
                 lbtemp1.Margin = new Thickness(1, 1, 0, 0);       
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i+1);
                 GridMCPSJCS.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].MoShu;
                 if (projCmpViewModel.projects[i].MoShu != projCmpViewModel.projects[0].MoShu)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].YaLiJiao;
                 if (projCmpViewModel.projects[i].YaLiJiao != projCmpViewModel.projects[0].YaLiJiao)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp3);

                 Label lbtemp4 = new Label();
                 lbtemp4.Style = myStyletemp;
                 lbtemp4.Margin = new Thickness(1,1, 0, 0);
                 lbtemp4.Content = projCmpViewModel.projects[i].McpChiDingGao;
                 if (projCmpViewModel.projects[i].McpChiDingGao != projCmpViewModel.projects[0].McpChiDingGao)
                 {
                     lbtemp4.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp4, 3);
                 Grid.SetColumn(lbtemp4, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp4);

                 Label lbtemp5 = new Label();
                 lbtemp5.Style = myStyletemp;
                 lbtemp5.Margin = new Thickness(1,1, 0, 0);
                 lbtemp5.Content = projCmpViewModel.projects[i].McpChiGenGao;
                 if (projCmpViewModel.projects[i].McpChiGenGao != projCmpViewModel.projects[0].McpChiGenGao)
                 {
                     lbtemp5.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp5, 4);
                 Grid.SetColumn(lbtemp5, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp5);

                 Label lbtemp6 = new Label();
                 lbtemp6.Style = myStyletemp;
                 lbtemp6.Margin = new Thickness(1,1, 0, 0);
                 lbtemp6.Content = projCmpViewModel.projects[i].McpChiGenYuanJiao;
                 if (projCmpViewModel.projects[i].McpChiGenYuanJiao != projCmpViewModel.projects[0].McpChiGenYuanJiao)
                 {
                     lbtemp6.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp6, 5);
                 Grid.SetColumn(lbtemp6, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp6);


                 Label lbtemp7 = new Label();
                 lbtemp7.Style = myStyletemp;
                 lbtemp7.Margin = new Thickness(1,1, 0, 0);
                 lbtemp7.Content = projCmpViewModel.projects[i].WaiJing;
                 if (projCmpViewModel.projects[i].WaiJing != projCmpViewModel.projects[0].WaiJing)
                 {
                     lbtemp7.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp7, 6);
                 Grid.SetColumn(lbtemp7, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp7);

                 Label lbtemp8 = new Label();
                 lbtemp8.Style = myStyletemp;
                 lbtemp8.Margin = new Thickness(1,1, 0, 0);
                 lbtemp8.Content = projCmpViewModel.projects[i].McpGFXDGC;
                 if (projCmpViewModel.projects[i].McpGFXDGC != projCmpViewModel.projects[0].McpGFXDGC)
                 {
                     lbtemp8.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp8, 7);
                 Grid.SetColumn(lbtemp8, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp8);

                 Label lbtemp9 = new Label();
                 lbtemp9.Style = myStyletemp;
                 lbtemp9.Margin = new Thickness(1,1, 0, 0);
                 lbtemp9.Content = projCmpViewModel.projects[i].McpHouDu;
                 if (projCmpViewModel.projects[i].McpHouDu != projCmpViewModel.projects[0].McpHouDu)
                 {
                     lbtemp9.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp9, 8);
                 Grid.SetColumn(lbtemp9, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp9);

                 Label lbtemp10 = new Label();
                 lbtemp10.Style = myStyletemp;
                 lbtemp10.Margin = new Thickness(1,1, 0, 0);
                 lbtemp10.Content = projCmpViewModel.projects[i].ChiCeJianXi;
                 if (projCmpViewModel.projects[i].ChiCeJianXi != projCmpViewModel.projects[0].ChiCeJianXi)
                 {
                     lbtemp10.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp10, 9);
                 Grid.SetColumn(lbtemp10, i + 1);
                 GridMCPSJCS.Children.Add(lbtemp10);
             }


             GridNGSJCS.ColumnDefinitions.Add(new ColumnDefinition());
             string[] ngsjcs = { "齿数", "模数(mm)", "压力角(°)", "齿顶高(mm)", "齿根高(mm)", "齿根圆角(mm)", "孔径(mm)", "公法线长度公差(mm)", "厚度(mm)"};

             for (int k = 0; k < 9; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = ngsjcs[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridNGSJCS.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridNGSJCS.Children.Add(lbtemp);
             }
             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].ChiShu;
                 if (projCmpViewModel.projects[i].ChiShu != projCmpViewModel.projects[0].ChiShu)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }  
                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridNGSJCS.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].MoShu;
                 if (projCmpViewModel.projects[i].MoShu != projCmpViewModel.projects[0].MoShu)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridNGSJCS.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].YaLiJiao;
                 if (projCmpViewModel.projects[i].YaLiJiao != projCmpViewModel.projects[0].YaLiJiao)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridNGSJCS.Children.Add(lbtemp3);

                 Label lbtemp4 = new Label();
                 lbtemp4.Style = myStyletemp;
                 lbtemp4.Margin = new Thickness(1,1, 0, 0);
                 lbtemp4.Content = projCmpViewModel.projects[i].NgChiDingGao;
                 if (projCmpViewModel.projects[i].NgChiDingGao != projCmpViewModel.projects[0].NgChiDingGao)
                 {
                     lbtemp4.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp4, 3);
                 Grid.SetColumn(lbtemp4, i + 1);
                 GridNGSJCS.Children.Add(lbtemp4);

                 Label lbtemp5 = new Label();
                 lbtemp5.Style = myStyletemp;
                 lbtemp5.Margin = new Thickness(1,1, 0, 0);
                 lbtemp5.Content = projCmpViewModel.projects[i].NgChiGenGao;
                 if (projCmpViewModel.projects[i].NgChiGenGao != projCmpViewModel.projects[0].NgChiGenGao)
                 {
                     lbtemp5.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp5, 4);
                 Grid.SetColumn(lbtemp5, i + 1);
                 GridNGSJCS.Children.Add(lbtemp5);

                 Label lbtemp6 = new Label();
                 lbtemp6.Style = myStyletemp;
                 lbtemp6.Margin = new Thickness(1,1, 0, 0);
                 lbtemp6.Content = projCmpViewModel.projects[i].NgChiGenYuanJiao;
                 if (projCmpViewModel.projects[i].NgChiGenYuanJiao != projCmpViewModel.projects[0].NgChiGenYuanJiao)
                 {
                     lbtemp6.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp6, 5);
                 Grid.SetColumn(lbtemp6, i + 1);
                 GridNGSJCS.Children.Add(lbtemp6);


                 Label lbtemp7 = new Label();
                 lbtemp7.Style = myStyletemp;
                 lbtemp7.Margin = new Thickness(1,1, 0, 0);
                 lbtemp7.Content = projCmpViewModel.projects[i].KongJing;
                 if (projCmpViewModel.projects[i].KongJing != projCmpViewModel.projects[0].KongJing)
                 {
                     lbtemp7.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp7, 6);
                 Grid.SetColumn(lbtemp7, i + 1);
                 GridNGSJCS.Children.Add(lbtemp7);

                 Label lbtemp8 = new Label();
                 lbtemp8.Style = myStyletemp;
                 lbtemp8.Margin = new Thickness(1,1, 0, 0);
                 lbtemp8.Content = projCmpViewModel.projects[i].NgGFXCDGC;
                 if (projCmpViewModel.projects[i].NgGFXCDGC != projCmpViewModel.projects[0].NgGFXCDGC)
                 {
                     lbtemp8.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp8, 7);
                 Grid.SetColumn(lbtemp8, i + 1);
                 GridNGSJCS.Children.Add(lbtemp8);

                 Label lbtemp9 = new Label();
                 lbtemp9.Style = myStyletemp;
                 lbtemp9.Margin = new Thickness(1,1, 0, 0);
                 lbtemp9.Content = projCmpViewModel.projects[i].NgHouDu;
                 if (projCmpViewModel.projects[i].NgHouDu != projCmpViewModel.projects[0].NgHouDu)
                 {
                     lbtemp9.Background = Brushes.Yellow;
                 }  
                 Grid.SetRow(lbtemp9, 8);
                 Grid.SetColumn(lbtemp9, i + 1);
                 GridNGSJCS.Children.Add(lbtemp9);
             }



             GridMCPQHCS.ColumnDefinitions.Add(new ColumnDefinition());
             string[] mcpqhcs = { "摩擦层厚度(mm)", "摩擦层径宽(mm)", "镀层厚度(mm)" };

             for (int k = 0; k < 3; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = mcpqhcs[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridMCPQHCS.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridMCPQHCS.Children.Add(lbtemp);
             }
             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].MccHouDu;
                 if (projCmpViewModel.projects[i].MccHouDu != projCmpViewModel.projects[0].MccHouDu)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }

                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridMCPQHCS.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].MccJingKuan;
                 if (projCmpViewModel.projects[i].MccJingKuan != projCmpViewModel.projects[0].MccJingKuan)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridMCPQHCS.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].DuCengHouDu;
                 if (projCmpViewModel.projects[i].DuCengHouDu != projCmpViewModel.projects[0].DuCengHouDu)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridMCPQHCS.Children.Add(lbtemp3);
             }



             GridCLCS.ColumnDefinitions.Add(new ColumnDefinition());
             string[] clcs = { "摩擦片弹性模量(GPa)", "摩擦片材料密度(kg/m^3)", "摩擦片泊松比", "摩擦片抗拉强度极限(MPa)", "摩擦片疲劳极限(MPa)", "内毂弹性模量(GPa)", "内毂材料密度(kg/m^3)", "内毂泊松比", "摩擦层弹性模量(GPa)", "摩擦层材料密度(kg/m^3)", "摩擦层泊松比", "镀层弹性模量(GPa)", "镀层材料密度(kg/m^3)", "镀层泊松比" };
             for (int k = 0; k < 14; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = clcs[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridCLCS.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridCLCS.Children.Add(lbtemp);
             }

             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].McpTXML;
                 if (projCmpViewModel.projects[i].McpTXML != projCmpViewModel.projects[0].McpTXML)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }
                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridCLCS.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].McpCLMD;
                 if (projCmpViewModel.projects[i].McpCLMD != projCmpViewModel.projects[0].McpCLMD)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridCLCS.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].McpBSB;
                 if (projCmpViewModel.projects[i].McpBSB != projCmpViewModel.projects[0].McpBSB)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridCLCS.Children.Add(lbtemp3);

                 Label lbtemp4 = new Label();
                 lbtemp4.Style = myStyletemp;
                 lbtemp4.Margin = new Thickness(1,1, 0, 0);
                 lbtemp4.Content = projCmpViewModel.projects[i].KangLaQDJX;
                 if (projCmpViewModel.projects[i].KangLaQDJX != projCmpViewModel.projects[0].KangLaQDJX)
                 {
                     lbtemp4.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp4, 3);
                 Grid.SetColumn(lbtemp4, i + 1);
                 GridCLCS.Children.Add(lbtemp4);

                 Label lbtemp5 = new Label();
                 lbtemp5.Style = myStyletemp;
                 lbtemp5.Margin = new Thickness(1,1, 0, 0);
                 lbtemp5.Content = projCmpViewModel.projects[i].PiLaoJiXian;
                 if (projCmpViewModel.projects[i].PiLaoJiXian != projCmpViewModel.projects[0].PiLaoJiXian)
                 {
                     lbtemp5.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp5, 4);
                 Grid.SetColumn(lbtemp5, i + 1);
                 GridCLCS.Children.Add(lbtemp5);

                 Label lbtemp6 = new Label();
                 lbtemp6.Style = myStyletemp;
                 lbtemp6.Margin = new Thickness(1,1, 0, 0);
                 lbtemp6.Content = projCmpViewModel.projects[i].NgTXML;
                 if (projCmpViewModel.projects[i].NgTXML != projCmpViewModel.projects[0].NgTXML)
                 {
                     lbtemp6.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp6, 5);
                 Grid.SetColumn(lbtemp6, i + 1);
                 GridCLCS.Children.Add(lbtemp6);


                 Label lbtemp7 = new Label();
                 lbtemp7.Style = myStyletemp;
                 lbtemp7.Margin = new Thickness(1,1, 0, 0);
                 lbtemp7.Content = projCmpViewModel.projects[i].NgCLMD;
                 if (projCmpViewModel.projects[i].NgCLMD != projCmpViewModel.projects[0].NgCLMD)
                 {
                     lbtemp7.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp7, 6);
                 Grid.SetColumn(lbtemp7, i + 1);
                 GridCLCS.Children.Add(lbtemp7);

                 Label lbtemp8 = new Label();
                 lbtemp8.Style = myStyletemp;
                 lbtemp8.Margin = new Thickness(1,1, 0, 0);
                 lbtemp8.Content = projCmpViewModel.projects[i].NgBSB;
                 if (projCmpViewModel.projects[i].NgBSB != projCmpViewModel.projects[0].NgBSB)
                 {
                     lbtemp8.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp8, 7);
                 Grid.SetColumn(lbtemp8, i + 1);
                 GridCLCS.Children.Add(lbtemp8);

                 Label lbtemp9 = new Label();
                 lbtemp9.Style = myStyletemp;
                 lbtemp9.Margin = new Thickness(1,1, 0, 0);
                 lbtemp9.Content = projCmpViewModel.projects[i].MccTXML;
                 if (projCmpViewModel.projects[i].MccTXML != projCmpViewModel.projects[0].MccTXML)
                 {
                     lbtemp9.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp9, 8);
                 Grid.SetColumn(lbtemp9, i + 1);
                 GridCLCS.Children.Add(lbtemp9);

                 Label lbtemp10 = new Label();
                 lbtemp10.Style = myStyletemp;
                 lbtemp10.Margin = new Thickness(1,1, 0, 0);
                 lbtemp10.Content = projCmpViewModel.projects[i].MccCLMD;
                 if (projCmpViewModel.projects[i].MccCLMD != projCmpViewModel.projects[0].MccCLMD)
                 {
                     lbtemp10.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp10, 9);
                 Grid.SetColumn(lbtemp10, i + 1);
                 GridCLCS.Children.Add(lbtemp10);


                 Label lbtemp11 = new Label();
                 lbtemp11.Style = myStyletemp;
                 lbtemp11.Margin = new Thickness(1,1, 0, 0);
                 lbtemp11.Content = projCmpViewModel.projects[i].MccBSB;
                 if (projCmpViewModel.projects[i].MccBSB != projCmpViewModel.projects[0].MccBSB)
                 {
                     lbtemp11.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp11, 10);
                 Grid.SetColumn(lbtemp11, i + 1);
                 GridCLCS.Children.Add(lbtemp11);

                 Label lbtemp12 = new Label();
                 lbtemp12.Style = myStyletemp;
                 lbtemp12.Margin = new Thickness(1,1, 0, 0);
                 lbtemp12.Content = projCmpViewModel.projects[i].DcTXML;
                 if (projCmpViewModel.projects[i].DcTXML != projCmpViewModel.projects[0].DcTXML)
                 {
                     lbtemp12.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp12, 11);
                 Grid.SetColumn(lbtemp12, i + 1);
                 GridCLCS.Children.Add(lbtemp12);

                 Label lbtemp13 = new Label();
                 lbtemp13.Style = myStyletemp;
                 lbtemp13.Margin = new Thickness(1,1, 0, 0);
                 lbtemp13.Content = projCmpViewModel.projects[i].DcCLMD;
                 if (projCmpViewModel.projects[i].DcCLMD != projCmpViewModel.projects[0].DcCLMD)
                 {
                     lbtemp13.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp13, 12);
                 Grid.SetColumn(lbtemp13, i + 1);
                 GridCLCS.Children.Add(lbtemp13);

                 Label lbtemp14 = new Label();
                 lbtemp14.Style = myStyletemp;
                 lbtemp14.Margin = new Thickness(1,1, 0, 0);
                 lbtemp14.Content = projCmpViewModel.projects[i].DcBSB;
                 if (projCmpViewModel.projects[i].DcBSB != projCmpViewModel.projects[0].DcBSB)
                 {
                     lbtemp14.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp14, 13);
                 Grid.SetColumn(lbtemp14, i + 1);
                 GridCLCS.Children.Add(lbtemp14);
             }


             GridCSTJ.ColumnDefinitions.Add(new ColumnDefinition());
             string[] cstj = { "内毂初始角位移(rad)", "内毂初始速度(rad/s)", "摩擦片初始角位移(rad)", "摩擦片初始速度(rad/s)", "油膜厚度(mm)", "油膜粘度(Pa.s)", "温度(℃)"};
             for (int k = 0; k < 7; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = cstj[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridCSTJ.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridCSTJ.Children.Add(lbtemp);
             }

             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].NgChuShiJiaoWeiYi;
                 if (projCmpViewModel.projects[i].NgChuShiJiaoWeiYi != projCmpViewModel.projects[0].NgChuShiJiaoWeiYi)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }
                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridCSTJ.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].NgChuShiSuDu;
                 if (projCmpViewModel.projects[i].NgChuShiSuDu != projCmpViewModel.projects[0].NgChuShiSuDu)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridCSTJ.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].McpChuShiJiaoWeiYi;
                 if (projCmpViewModel.projects[i].McpChuShiJiaoWeiYi != projCmpViewModel.projects[0].McpChuShiJiaoWeiYi)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridCSTJ.Children.Add(lbtemp3);

                 Label lbtemp4 = new Label();
                 lbtemp4.Style = myStyletemp;
                 lbtemp4.Margin = new Thickness(1,1, 0, 0);
                 lbtemp4.Content = projCmpViewModel.projects[i].McpChuShiSuDu;
                 if (projCmpViewModel.projects[i].McpChuShiSuDu != projCmpViewModel.projects[0].McpChuShiSuDu)
                 {
                     lbtemp4.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp4, 3);
                 Grid.SetColumn(lbtemp4, i + 1);
                 GridCSTJ.Children.Add(lbtemp4);

                 Label lbtemp5 = new Label();
                 lbtemp5.Style = myStyletemp;
                 lbtemp5.Margin = new Thickness(1,1, 0, 0);
                 lbtemp5.Content = projCmpViewModel.projects[i].YouMoHouDu;
                 if (projCmpViewModel.projects[i].YouMoHouDu != projCmpViewModel.projects[0].YouMoHouDu)
                 {
                     lbtemp5.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp5, 4);
                 Grid.SetColumn(lbtemp5, i + 1);
                 GridCSTJ.Children.Add(lbtemp5);

                 Label lbtemp6 = new Label();
                 lbtemp6.Style = myStyletemp;
                 lbtemp6.Margin = new Thickness(1,1, 0, 0);
                 lbtemp6.Content = projCmpViewModel.projects[i].YouYeNianDu;
                 if (projCmpViewModel.projects[i].YouYeNianDu != projCmpViewModel.projects[0].YouYeNianDu)
                 {
                     lbtemp6.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp6, 5);
                 Grid.SetColumn(lbtemp6, i + 1);
                 GridCSTJ.Children.Add(lbtemp6);


                 Label lbtemp7 = new Label();
                 lbtemp7.Style = myStyletemp;
                 lbtemp7.Margin = new Thickness(1,1, 0, 0);
                 lbtemp7.Content = projCmpViewModel.projects[i].WenDu;
                 if (projCmpViewModel.projects[i].WenDu != projCmpViewModel.projects[0].WenDu)
                 {
                     lbtemp7.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp7, 6);
                 Grid.SetColumn(lbtemp7, i + 1);
                 GridCSTJ.Children.Add(lbtemp7);
             }

             GridJSTJ.ColumnDefinitions.Add(new ColumnDefinition());
             string[] jstj = { "实际接触齿数", "反弹系数", "内毂转速(r/min)", "内毂振幅(rad/s)", "内毂振频(Hz)", "结构阻尼(N/(m/s))", "摩擦片转动惯量(kg*m^2)", "内毂转动惯量(kg*m^2)", "接触区径向长度(mm)", "接触区轴向长度(mm)", "阻尼槽长(mm)", "阻尼槽宽(mm)", "阻尼槽半径(mm)", "启动时间(s)", "增速时间(s)", "稳定时间(s)", "停止时间(s)" };
             for (int k = 0; k < 17; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = jstj[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridJSTJ.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridJSTJ.Children.Add(lbtemp);
             }

             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].ShiJiJieChuChiShu;
                 if (projCmpViewModel.projects[i].ShiJiJieChuChiShu != projCmpViewModel.projects[0].ShiJiJieChuChiShu)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }
                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridJSTJ.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].FanTanXiShu;
                 if (projCmpViewModel.projects[i].FanTanXiShu != projCmpViewModel.projects[0].FanTanXiShu)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridJSTJ.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].NgZhuanSu;
                 if (projCmpViewModel.projects[i].NgZhuanSu != projCmpViewModel.projects[0].NgZhuanSu)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridJSTJ.Children.Add(lbtemp3);

                 Label lbtemp4 = new Label();
                 lbtemp4.Style = myStyletemp;
                 lbtemp4.Margin = new Thickness(1,1, 0, 0);
                 lbtemp4.Content = projCmpViewModel.projects[i].NgZhenFu;
                 if (projCmpViewModel.projects[i].NgZhenFu != projCmpViewModel.projects[0].NgZhenFu)
                 {
                     lbtemp4.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp4, 3);
                 Grid.SetColumn(lbtemp4, i + 1);
                 GridJSTJ.Children.Add(lbtemp4);

                 Label lbtemp5 = new Label();
                 lbtemp5.Style = myStyletemp;
                 lbtemp5.Margin = new Thickness(1,1, 0, 0);
                 lbtemp5.Content = projCmpViewModel.projects[i].NgZhenPin;
                 if (projCmpViewModel.projects[i].NgZhenPin != projCmpViewModel.projects[0].NgZhenPin)
                 {
                     lbtemp5.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp5, 4);
                 Grid.SetColumn(lbtemp5, i + 1);
                 GridJSTJ.Children.Add(lbtemp5);

                 Label lbtemp6 = new Label();
                 lbtemp6.Style = myStyletemp;
                 lbtemp6.Margin = new Thickness(1,1, 0, 0);
                 lbtemp6.Content = projCmpViewModel.projects[i].JieGouZuNi;
                 if (projCmpViewModel.projects[i].JieGouZuNi != projCmpViewModel.projects[0].JieGouZuNi)
                 {
                     lbtemp6.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp6, 5);
                 Grid.SetColumn(lbtemp6, i + 1);
                 GridJSTJ.Children.Add(lbtemp6);


                 Label lbtemp7 = new Label();
                 lbtemp7.Style = myStyletemp;
                 lbtemp7.Margin = new Thickness(1,1, 0, 0);
                 lbtemp7.Content = projCmpViewModel.projects[i].McpZhuanDongGuanLiang;
                 if (projCmpViewModel.projects[i].McpZhuanDongGuanLiang != projCmpViewModel.projects[0].McpZhuanDongGuanLiang)
                 {
                     lbtemp7.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp7, 6);
                 Grid.SetColumn(lbtemp7, i + 1);
                 GridJSTJ.Children.Add(lbtemp7);

                 Label lbtemp8 = new Label();
                 lbtemp8.Style = myStyletemp;
                 lbtemp8.Margin = new Thickness(1,1, 0, 0);
                 lbtemp8.Content = projCmpViewModel.projects[i].NgZhuanDongGuanLiang;
                 if (projCmpViewModel.projects[i].NgZhuanDongGuanLiang != projCmpViewModel.projects[0].NgZhuanDongGuanLiang)
                 {
                     lbtemp8.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp8, 7);
                 Grid.SetColumn(lbtemp8, i + 1);
                 GridJSTJ.Children.Add(lbtemp8);

                 Label lbtemp9 = new Label();
                 lbtemp9.Style = myStyletemp;
                 lbtemp9.Margin = new Thickness(1,1, 0, 0);
                 lbtemp9.Content = projCmpViewModel.projects[i].JieChuQuJinXiangChuangDu;
                 if (projCmpViewModel.projects[i].JieChuQuJinXiangChuangDu != projCmpViewModel.projects[0].JieChuQuJinXiangChuangDu)
                 {
                     lbtemp9.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp9, 8);
                 Grid.SetColumn(lbtemp9, i + 1);
                 GridJSTJ.Children.Add(lbtemp9);

                 Label lbtemp10 = new Label();
                 lbtemp10.Style = myStyletemp;
                 lbtemp10.Margin = new Thickness(1,1, 0, 0);
                 lbtemp10.Content = projCmpViewModel.projects[i].JieChuQuZhouXiangChangDu;
                 if (projCmpViewModel.projects[i].JieChuQuZhouXiangChangDu != projCmpViewModel.projects[0].JieChuQuZhouXiangChangDu)
                 {
                     lbtemp10.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp10, 9);
                 Grid.SetColumn(lbtemp10, i + 1);
                 GridJSTJ.Children.Add(lbtemp10);


                 Label lbtemp11 = new Label();
                 lbtemp11.Style = myStyletemp;
                 lbtemp11.Margin = new Thickness(1,1, 0, 0);
                 lbtemp11.Content = projCmpViewModel.projects[i].ZuNiCaoChang;
                 if (projCmpViewModel.projects[i].ZuNiCaoChang != projCmpViewModel.projects[0].ZuNiCaoChang)
                 {
                     lbtemp11.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp11, 10);
                 Grid.SetColumn(lbtemp11, i + 1);
                 GridJSTJ.Children.Add(lbtemp11);

                 Label lbtemp12 = new Label();
                 lbtemp12.Style = myStyletemp;
                 lbtemp12.Margin = new Thickness(1,1, 0, 0);
                 lbtemp12.Content = projCmpViewModel.projects[i].ZuNiCaoKuan;
                 if (projCmpViewModel.projects[i].ZuNiCaoKuan != projCmpViewModel.projects[0].ZuNiCaoKuan)
                 {
                     lbtemp12.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp12, 11);
                 Grid.SetColumn(lbtemp12, i + 1);
                 GridJSTJ.Children.Add(lbtemp12);

                 Label lbtemp13 = new Label();
                 lbtemp13.Style = myStyletemp;
                 lbtemp13.Margin = new Thickness(1,1, 0, 0);
                 lbtemp13.Content = projCmpViewModel.projects[i].ZuNiCaoBanJing;
                 if (projCmpViewModel.projects[i].ZuNiCaoBanJing != projCmpViewModel.projects[0].ZuNiCaoBanJing)
                 {
                     lbtemp13.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp13, 12);
                 Grid.SetColumn(lbtemp13, i + 1);
                 GridJSTJ.Children.Add(lbtemp13);

                 Label lbtemp14 = new Label();
                 lbtemp14.Style = myStyletemp;
                 lbtemp14.Margin = new Thickness(1,1, 0, 0);
                 lbtemp14.Content = projCmpViewModel.projects[i].QiDongShiJian;
                 if (projCmpViewModel.projects[i].QiDongShiJian != projCmpViewModel.projects[0].QiDongShiJian)
                 {
                     lbtemp14.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp14, 13);
                 Grid.SetColumn(lbtemp14, i + 1);
                 GridJSTJ.Children.Add(lbtemp14);


                 Label lbtemp15 = new Label();
                 lbtemp15.Style = myStyletemp;
                 lbtemp15.Margin = new Thickness(1,1, 0, 0);
                 lbtemp15.Content = projCmpViewModel.projects[i].ZengSuShiJian;
                 if (projCmpViewModel.projects[i].ZengSuShiJian != projCmpViewModel.projects[0].ZengSuShiJian)
                 {
                     lbtemp15.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp15, 14);
                 Grid.SetColumn(lbtemp15, i + 1);
                 GridJSTJ.Children.Add(lbtemp15);

                 Label lbtemp16 = new Label();
                 lbtemp16.Style = myStyletemp;
                 lbtemp16.Margin = new Thickness(1,1, 0, 0);
                 lbtemp16.Content = projCmpViewModel.projects[i].WenDingShiJian;
                 if (projCmpViewModel.projects[i].WenDingShiJian != projCmpViewModel.projects[0].WenDingShiJian)
                 {
                     lbtemp16.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp16, 15);
                 Grid.SetColumn(lbtemp16, i + 1);
                 GridJSTJ.Children.Add(lbtemp16);

                 Label lbtemp17 = new Label();
                 lbtemp17.Style = myStyletemp;
                 lbtemp17.Margin = new Thickness(1,1, 0, 0);
                 lbtemp17.Content = projCmpViewModel.projects[i].TingZhiShiJIan;
                 if (projCmpViewModel.projects[i].TingZhiShiJIan != projCmpViewModel.projects[0].TingZhiShiJIan)
                 {
                     lbtemp17.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp17, 16);
                 Grid.SetColumn(lbtemp17, i + 1);
                 GridJSTJ.Children.Add(lbtemp17);
             }

             GridWCTJ.ColumnDefinitions.Add(new ColumnDefinition());
             string[] wctj = { "偏心距(mm)", "节距最大误差(mm)", "节距最小误差(mm)" };

             for (int k = 0; k < 3; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = wctj[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridWCTJ.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridWCTJ.Children.Add(lbtemp);
             }
             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].PianXinJu;
                 if (projCmpViewModel.projects[i].PianXinJu != projCmpViewModel.projects[0].PianXinJu)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }
                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridWCTJ.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].JieJuZuiDaWuCha;
                 if (projCmpViewModel.projects[i].JieJuZuiDaWuCha != projCmpViewModel.projects[0].JieJuZuiDaWuCha)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridWCTJ.Children.Add(lbtemp2);


                 Label lbtemp3 = new Label();
                 lbtemp3.Style = myStyletemp;
                 lbtemp3.Margin = new Thickness(1,1, 0, 0);
                 lbtemp3.Content = projCmpViewModel.projects[i].JieJuZuiXiaoWuCha;
                 if (projCmpViewModel.projects[i].JieJuZuiXiaoWuCha != projCmpViewModel.projects[0].JieJuZuiXiaoWuCha)
                 {
                     lbtemp3.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp3, 2);
                 Grid.SetColumn(lbtemp3, i + 1);
                 GridWCTJ.Children.Add(lbtemp3);
             }


             GridSYSJBD.ColumnDefinitions.Add(new ColumnDefinition());
             string[] sysjbd = { "采样频率(Hz)", "应力应变转换系数(rad/s)"};

             for (int k = 0; k < 2; k++)
             {
                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp = new Label();
                 lbtemp.Style = myStyletemp;
                 lbtemp.Content = sysjbd[k];
                 lbtemp.Margin = new Thickness(0, 1, 0, 0);
                 GridSYSJBD.RowDefinitions.Add(new RowDefinition());
                 Grid.SetRow(lbtemp, k);
                 Grid.SetColumn(lbtemp, 0);
                 GridSYSJBD.Children.Add(lbtemp);
             }
             for (int i = 0; i < path.Count; i++)
             {

                 Style myStyletemp = (Style)this.FindResource("ExceptionCellStyle");
                 Label lbtemp1 = new Label();
                 lbtemp1.Style = myStyletemp;
                 lbtemp1.Content = projCmpViewModel.projects[i].CaiYangPinLv;
                 if (projCmpViewModel.projects[i].CaiYangPinLv != projCmpViewModel.projects[0].CaiYangPinLv)
                 {
                     lbtemp1.Background = Brushes.Yellow;
                 }
                 lbtemp1.Margin = new Thickness(1,1, 0, 0);
                 Grid.SetRow(lbtemp1, 0);
                 Grid.SetColumn(lbtemp1, i + 1);
                 GridSYSJBD.Children.Add(lbtemp1);

                 Label lbtemp2 = new Label();
                 lbtemp2.Style = myStyletemp;
                 lbtemp2.Margin = new Thickness(1,1, 0, 0);
                 lbtemp2.Content = projCmpViewModel.projects[i].YinLiYingBianZhuanHuanXiShu;
                 if (projCmpViewModel.projects[i].YinLiYingBianZhuanHuanXiShu != projCmpViewModel.projects[0].YinLiYingBianZhuanHuanXiShu)
                 {
                     lbtemp2.Background = Brushes.Yellow;
                 }
                 Grid.SetRow(lbtemp2, 1);
                 Grid.SetColumn(lbtemp2, i + 1);
                 GridSYSJBD.Children.Add(lbtemp2);
             }
        }
    }
}
