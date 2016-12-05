using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TIOFPSS.ViewModels
{
    public class ResultPicViewModel : ViewModel
    {
        private string picPath;
        public string PicPath
        {
            get { return this.picPath; }
            set
            {
                picPath = value;
                this.OnPropertyChanged("PicPath");
            }
        }
        private ImageSource moCaPianChonJiLi;
        public ImageSource MoCaPianChonJiLi
        {
            get { return moCaPianChonJiLi; }
            set
            {
                moCaPianChonJiLi = value;
                this.OnPropertyChanged("MoCaPianChonJiLi");
            }
        }
        private ImageSource moCaPianChonJiLiPinPuTu;
        public ImageSource MoCaPianChonJiLiPinPuTu
        {
            get { return moCaPianChonJiLiPinPuTu; }
            set
            {
                moCaPianChonJiLiPinPuTu = value;
                this.OnPropertyChanged("MoCaPianChonJiLiPinPuTu");
            }
        }
        private ImageSource moCaPianJiaSuDuPinPuTu;
        public ImageSource MoCaPianJiaSuDuPinPuTu
        {
            get { return moCaPianJiaSuDuPinPuTu; }
            set
            {
                moCaPianJiaSuDuPinPuTu = value;
                this.OnPropertyChanged("MoCaPianJiaSuDuPinPuTu");
            }
        }
        private ImageSource moCaPianJiaoJiaSuDu;
        public ImageSource MoCaPianJiaoJiaSuDu
        {
            get { return moCaPianJiaoJiaSuDu; }
            set
            {
                moCaPianJiaoJiaSuDu = value;
                this.OnPropertyChanged("MoCaPianJiaoJiaSuDu");
            }
        }
        private ImageSource moCaPianJiaoSuDu;
        public ImageSource MoCaPianJiaoSuDu
        {
            get { return moCaPianJiaoSuDu; }
            set
            {
                moCaPianJiaoSuDu = value;
                this.OnPropertyChanged("MoCaPianJiaoSuDu");
            }
        }
        private ImageSource moCaPianSuDuPinPuTu;
        public ImageSource MoCaPianSuDuPinPuTu
        {
            get { return moCaPianSuDuPinPuTu; }
            set
            {
                moCaPianSuDuPinPuTu = value;
                this.OnPropertyChanged("MoCaPianSuDuPinPuTu");
            }
        }
        private ImageSource moCaPianWeiYi;
        public ImageSource MoCaPianWeiYi
        {
            get { return moCaPianWeiYi; }
            set
            {
                moCaPianWeiYi = value;
                this.OnPropertyChanged("MoCaPianWeiYi");
            }
        }
        private ImageSource moCaPianYuNeiGuXiangDuiNiuZhuan;
        public ImageSource MoCaPianYuNeiGuXiangDuiNiuZhuan
        {
            get { return moCaPianYuNeiGuXiangDuiNiuZhuan; }
            set
            {
                moCaPianYuNeiGuXiangDuiNiuZhuan = value;
                this.OnPropertyChanged("MoCaPianYuNeiGuXiangDuiNiuZhuan");
            }
        }
        private ImageSource moCaPianYuNeiGuXiangDuiXuanZhuan;
        public ImageSource MoCaPianYuNeiGuXiangDuiXuanZhuan
        {
            get { return moCaPianYuNeiGuXiangDuiXuanZhuan; }
            set
            {
                moCaPianYuNeiGuXiangDuiXuanZhuan = value;
                this.OnPropertyChanged("MoCaPianYuNeiGuXiangDuiXuanZhuan");
            }
        }
        private ImageSource neiGuJiaSuDuPinPuTu;
        public ImageSource NeiGuJiaSuDuPinPuTu
        {
            get { return neiGuJiaSuDuPinPuTu; }
            set
            {
                neiGuJiaSuDuPinPuTu = value;
                this.OnPropertyChanged("NeiGuJiaSuDuPinPuTu");
            }
        }
        private ImageSource neiGuJiaoJiaSuDu;
        public ImageSource NeiGuJiaoJiaSuDu
        {
            get { return neiGuJiaoJiaSuDu; }
            set
            {
                neiGuJiaoJiaSuDu = value;
                this.OnPropertyChanged("NeiGuJiaoJiaSuDu");
            }
        }
        private ImageSource neiGuJiaoSuDu;
        public ImageSource NeiGuJiaoSuDu
        {
            get { return neiGuJiaoSuDu; }
            set
            {
                neiGuJiaoSuDu = value;
                this.OnPropertyChanged("NeiGuJiaoSuDu");
            }
        }
        private ImageSource neiGuSuDuPinPuTu;
        public ImageSource NeiGuSuDuPinPuTu
        {
            get { return neiGuSuDuPinPuTu; }
            set
            {
                neiGuSuDuPinPuTu = value;
                this.OnPropertyChanged("NeiGuSuDuPinPuTu");
            }
        }
        private ImageSource neiGuWeiYi;
        public ImageSource NeiGuWeiYi
        {
            get { return neiGuWeiYi; }
            set
            {
                neiGuWeiYi = value;
                this.OnPropertyChanged("NeiGuWeiYi");
            }
        }
        private ImageSource xiangDuiNiuZhuanJiaoDuPinPuTu;
        public ImageSource XiangDuiNiuZhuanJiaoDuPinPuTu
        {
            get { return xiangDuiNiuZhuanJiaoDuPinPuTu; }
            set
            {
                xiangDuiNiuZhuanJiaoDuPinPuTu = value;
                this.OnPropertyChanged("XiangDuiNiuZhuanJiaoDuPinPuTu");
            }
        }
        private ImageSource xiangDuiXuanZhuanJiaoDuPinPuTu;
        public ImageSource XiangDuiXuanZhuanJiaoDuPinPuTu
        {
            get { return xiangDuiXuanZhuanJiaoDuPinPuTu; }
            set
            {
                xiangDuiXuanZhuanJiaoDuPinPuTu = value;
                this.OnPropertyChanged("XiangDuiXuanZhuanJiaoDuPinPuTu");
            }
        }
        private ImageSource zaoShengFenXi;
        public ImageSource ZaoShengFenXi
        {
            get { return zaoShengFenXi; }
            set
            {
                zaoShengFenXi = value;
                this.OnPropertyChanged("ZaoShengFenXi");
            }
        }
        //协同分析
        private ImageSource pianxinweiyiyuntu;
        public ImageSource PianXinWeiYiYunTu
        {
            get { return pianxinweiyiyuntu; }
            set
            {
                pianxinweiyiyuntu = value;
                this.OnPropertyChanged("PianXinWeiYiYunTu");
            }
        }
        private ImageSource pianxinyingliyuntu;
        public ImageSource PianXinYingLiYunTu
        {
            get { return pianxinyingliyuntu; }
            set
            {
                pianxinyingliyuntu = value;
                this.OnPropertyChanged("PianXinYingLiYunTu");
            }
        }
        private ImageSource yuyingliweiyiyuntu;
        public ImageSource YuYingLiWeiYiYunTu
        {
            get { return yuyingliweiyiyuntu; }
            set
            {
                yuyingliweiyiyuntu = value;
                this.OnPropertyChanged("YuYingLiWeiYiYunTu");
            }
        }
        private ImageSource yuyingliyingliyuntu;
        public ImageSource YuYingLiYingLiYunTu
        {
            get { return yuyingliyingliyuntu; }
            set
            {
                yuyingliyingliyuntu = value;
                this.OnPropertyChanged("YuYingLiYingLiYunTu");
            }
        }
        private ImageSource danchiyingliyuntu;
        public ImageSource DangChiYingLiYunTu
        {
            get { return danchiyingliyuntu; }
            set
            {
                danchiyingliyuntu = value;
                this.OnPropertyChanged("DangChiYingLiYunTu");
            }
        }
        private ImageSource ducengweiyiyuntu;
        public ImageSource DuCengWeiYiYunTu
        {
            get { return ducengweiyiyuntu; }
            set
            {
                ducengweiyiyuntu = value;
                this.OnPropertyChanged("DuCengWeiYiYunTu");
            }
        }
        private ImageSource ducengyingli;
        public ImageSource DuCengYingLi
        {
            get { return ducengyingli; }
            set
            {
                ducengyingli = value;
                this.OnPropertyChanged("DuCengYingLi");
            }
        }
        private ImageSource danchiweiyiyuntu;
        public ImageSource DangChiWeiYiYunTu
        {
            get { return danchiweiyiyuntu; }
            set
            {
                danchiweiyiyuntu = value;
                this.OnPropertyChanged("DangChiWeiYiYunTu");
            }
        }
       
        private ImageSource dongtaiyingliyuntu;
        public ImageSource DongTaiYingLiYunTu
        {
            get { return dongtaiyingliyuntu; }
            set
            {
                dongtaiyingliyuntu = value;
                this.OnPropertyChanged("DongTaiYingLiYunTu");
            }
        }
        private ImageSource dongtaiweiyiyuntu;
        public ImageSource DongTaiWeiYiYunTu
        {
            get { return dongtaiweiyiyuntu; }
            set
            {
                dongtaiweiyiyuntu = value;
                this.OnPropertyChanged("DongTaiWeiYiYunTu");
            }
        }
        private ImageSource moChaPianChiGenYingLiShiYuBoXing;
        public ImageSource MoChaPianChiGenYingLiShiYuBoXing
        {
            get { return moChaPianChiGenYingLiShiYuBoXing; }
            set
            {
                moChaPianChiGenYingLiShiYuBoXing = value;
                this.OnPropertyChanged("MoChaPianChiGenYingLiShiYuBoXing");
            }
        }

        private ImageSource moChaPianChiGenYingLiPinYuBoXing;
        public ImageSource MoChaPianChiGenYingLiPinYuBoXing
        {
            get { return moChaPianChiGenYingLiPinYuBoXing; }
            set
            {
                moChaPianChiGenYingLiPinYuBoXing = value;
                this.OnPropertyChanged("MoChaPianChiGenYingLiPinYuBoXing");
            }
        }

        private ImageSource moChaPianLeiJiSunShang;
        public ImageSource MoChaPianLeiJiSunShang
        {
            get { return moChaPianLeiJiSunShang; }
            set
            {
                moChaPianLeiJiSunShang = value;
                this.OnPropertyChanged("MoChaPianLeiJiSunShang");
            }
        }
        private ImageSource dangLiangZaiHePu;
        public ImageSource DangLiangZaiHePu
        {
            get { return dangLiangZaiHePu; }
            set
            {
                dangLiangZaiHePu = value;
                this.OnPropertyChanged("DangLiangZaiHePu");
            }
        }
        private ImageSource yuLiuJiShuJieGuo;
        public ImageSource YuLiuJiShuJieGuo
        {
            get { return yuLiuJiShuJieGuo; }
            set
            {
                yuLiuJiShuJieGuo = value;
                this.OnPropertyChanged("YuLiuJiShuJieGuo");
            }
        }
        
      
        private string projectName;
        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                this.OnPropertyChanged("ProjectName");
            }
        }

        private string DLZHPfileName;
        public string DLZHPFileName
        {
            get { return DLZHPfileName; }
            set
            {
                DLZHPfileName = value;
                this.OnPropertyChanged("DLZHPFileName");
            }
        }

        private string FXXSSfileName;
        public string FXXSSFileName
        {
            get { return FXXSSfileName; }
            set
            {
                FXXSSfileName = value;
                this.OnPropertyChanged("FXXSSFileName");
            }
        }

       public static BitmapImage LoadImg(string fileName)
       {
           if (!System.IO.File.Exists(fileName))
           {
               return null;
           }
           using (var stream = new FileStream(fileName, FileMode.Open))
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

        public ResultPicViewModel(string projectName,string path)
        {
            ProjectName = projectName;
            PicPath = path;
            BitmapImage Img = new BitmapImage();
            
            if(path!=null)
            {
                //无节距误差分析
                MoCaPianChonJiLi = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片冲击力.png");
                MoCaPianChonJiLiPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片冲击力频谱图.png");
                MoCaPianJiaSuDuPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片加速度频谱图.png");
                MoCaPianJiaoJiaSuDu = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片角加速度.png");
                MoCaPianJiaoSuDu = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片角速度.png");

                MoCaPianSuDuPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片速度频谱图.png");

                MoCaPianWeiYi = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片位移.png");
                MoCaPianYuNeiGuXiangDuiNiuZhuan = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片与内毂相对扭转角度.png");
                MoCaPianYuNeiGuXiangDuiXuanZhuan = LoadImg(PicPath + "\\冲击动力学分析结果\\摩擦片与内毂相对旋转速度.png");
                NeiGuJiaSuDuPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\内毂加速度频谱图.png");
                NeiGuJiaoJiaSuDu = LoadImg(PicPath + "\\冲击动力学分析结果\\内毂角加速度.png");
                NeiGuJiaoSuDu = LoadImg(PicPath + "\\冲击动力学分析结果\\内毂角速度.png");
                NeiGuSuDuPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\内毂速度频谱图.png");
                NeiGuWeiYi = LoadImg(PicPath + "\\冲击动力学分析结果\\内毂位移.png");
                XiangDuiNiuZhuanJiaoDuPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\相对扭转角度频谱图.png");
                XiangDuiXuanZhuanJiaoDuPinPuTu = LoadImg(PicPath + "\\冲击动力学分析结果\\相对旋转速度频谱图.png");

                ZaoShengFenXi = LoadImg(PicPath + "\\噪声分析结果\\噪声分析.png");
                //协同分析
                PianXinWeiYiYunTu = LoadImg(PicPath + "\\QuanChi\\pianxinweiyiyuntu.jpeg");
                PianXinYingLiYunTu = LoadImg(PicPath + "\\QuanChi\\pianxinyingliyuntu.jpeg");
                YuYingLiWeiYiYunTu = LoadImg(PicPath + "\\CuiHuo\\cuihuoweiyiyuntu.jpeg");
                YuYingLiYingLiYunTu = LoadImg(PicPath + "\\CuiHuo\\cuihuoyingliyuntu.jpeg");
                DuCengWeiYiYunTu = LoadImg(PicPath + "\\DuCeng\\ducengweiyiyuntu.jpeg");
                DuCengYingLi = LoadImg(PicPath + "\\DuCeng\\ducengyingliyuntu.jpeg");
                DangChiWeiYiYunTu = LoadImg(PicPath + "\\ShaoChi\\danchiweiyiyuntu.jpeg");
                DangChiYingLiYunTu = LoadImg(PicPath + "\\ShaoChi\\danchiyingliyuntu.jpeg");
                //DongTaiYingLiYunTu = LoadImg(PicPath + "\\dynamicyingliyutu.jpeg");
                //DongTaiWeiYiYunTu = LoadImg(PicPath + "\\dynamicweiyiyuntu.jpeg");
                //非线性损伤分析
                MoChaPianChiGenYingLiShiYuBoXing = LoadImg(PicPath + "\\非线性损伤分析结果\\摩擦片齿根应力时域波形.png");
                MoChaPianChiGenYingLiPinYuBoXing = LoadImg(PicPath + "\\非线性损伤分析结果\\摩擦片齿根应力频域波形.png");
                MoChaPianLeiJiSunShang = LoadImg(PicPath + "\\非线性损伤分析结果\\摩擦片累计损伤.png");
                //当量载荷谱分析结果
                DangLiangZaiHePu = LoadImg(PicPath + "\\当量载荷谱分析结果\\当量载荷谱.png");
                YuLiuJiShuJieGuo = LoadImg(PicPath + "\\当量载荷谱分析结果\\雨流计数结果.png");

                if(System.IO.File.Exists(PicPath + "\\当量载荷谱分析结果\\当量载荷谱.png"))
                {
                    string Section = "analysis";
                    string iniPath = PicPath.Substring(0, PicPath.LastIndexOf("tempData"))+"project\\参数文件\\project.ini";
                    DLZHPFileName = Dialog.Configure.IniReadValueWithPath(Section, "DLZHP", iniPath);
                }

                if (System.IO.File.Exists(PicPath + "\\非线性损伤分析结果\\摩擦片齿根应力时域波形.png"))
                {
                    string Section = "analysis";
                    string iniPath = PicPath.Substring(0, PicPath.LastIndexOf("tempData")) + "project\\参数文件\\project.ini";
                    FXXSSFileName = Dialog.Configure.IniReadValueWithPath(Section, "FXXSS", iniPath);
                }
            }
            //else
            //{
            //    //PicPath = @"D:\proj\11.73\tempData";
            //    //MoCaPianChonJiLi = PicPath + "\\噪声分析.png";
            //    //MoCaPianChonJiLiPinPuTu = PicPath + "\\噪声分析.png";
            //    //MoCaPianJiaSuDuPinPuTu = PicPath + "\\噪声分析.png";
            //    //MoCaPianJiaoJiaSuDu = PicPath + "\\噪声分析.png";
            //    //MoCaPianJiaoSuDu = PicPath + "\\噪声分析.png";
            //    //MoCaPianSuDuPinPuTu = PicPath + "\\噪声分析.png";
            //    //MoCaPianWeiYi = PicPath + "\\噪声分析.png";
            //    //MoCaPianYuNeiGuXiangDuiNiuZhuan = PicPath + "\\噪声分析.png";
            //    //MoCaPianYuNeiGuXiangDuiXuanZhuan = PicPath + "\\噪声分析.png";
            //    //NeiGuJiaoJiaSuDu = PicPath + "\\噪声分析.png";
            //    //NeiGuJiaoSuDu = PicPath + "\\噪声分析.png";
            //    //NeiGuSuDuPinPuTu = PicPath + "\\噪声分析.png";
            //    //NeiGuWeiYi = PicPath + "\\噪声分析.png";
            //    //XiangDuiNiuZhuanJiaoDuPinPuTu = PicPath + "\\噪声分析.png";
            //    //XiangDuiXuanZhuanJiaoDuPinPuTu = PicPath + "\\噪声分析.png";

            //    //ZaoShengFenXi = PicPath + "\\噪声分析.png";
            //}

        }



    }
}
