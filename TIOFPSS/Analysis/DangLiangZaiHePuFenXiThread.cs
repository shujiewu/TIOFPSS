using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MathWorks.MATLAB.NET.Arrays;
using final_loadspectrumprograming_2;

namespace TIOFPSS.Analysis
{
    class DangLiangZaiHePuFenXiThread
    {
        private DangLiangZaiHePuThreadParamter threadParamter;
        private Thread thread;
        public Helper.delgateDLZHPFinish CallBackMethod;
        private delegate void DoTask();
        private bool success;
        public DangLiangZaiHePuFenXiThread(DangLiangZaiHePuThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            thread = new Thread(new ThreadStart(Run));
            thread.Name = "ZaoShengFenXiThread";
        }

        public void Start()
        {
            if (thread != null)
            {
                thread.Start();
            }
        }

        private void Run()
        {
           
            //MWArray A = new MWNumericArray(1,53,threadParamter.Para);
            //MWArray loc = new MWCharArray(threadParamter.Path);
            
            //MWArray fontName = new MWCharArray("宋体");
           

            int i = threadParamter.sum;
            MWArray LeiXing = new MWNumericArray(threadParamter.isShiYan);


            double[] td = new double[i];
            double[] qhxs = new double[i];
            double[] hang = new double[i];
            string[] file = new string[i];
            MWCellArray FILES = new MWCellArray(1, i);
            for(int j=0;j<i;j++)
            {
                td[j] = Convert.ToDouble(threadParamter.tds[j]);
                qhxs[j] = Convert.ToDouble(threadParamter.qhxss[j]);
                hang[j] = Convert.ToDouble(threadParamter.hang[j]);
                //FILES[j] = threadParamter.files[j];
                FILES[1,j+1] = threadParamter.files[j];
            }
            
            MWArray TD = new MWNumericArray(1,i,td);
            MWArray HANG = new MWNumericArray(1,i,hang);
            MWArray QHXS = new MWNumericArray(1,i,qhxs);
            MWArray SUM = new MWNumericArray(i);
            MWArray ff = new MWNumericArray(1, 5,threadParamter.Para);
            MWArray locc = new MWCharArray(threadParamter.Path+"当量载荷谱分析结果\\");
            
            
            MWArray leixing = new MWNumericArray(threadParamter.isShiYan);
            //main_program_v1.WuJieJuWuChaClass wjj = new WuJieJuWuChaClass();
            //wjj.main_program_v1(A, loc, fontName);
            final_loadspectrumprograming_2.DangLiangZaiHePuFenXiClass dlzhp = new DangLiangZaiHePuFenXiClass();
            try
            {
                dlzhp.final_loadspectrumprograming_2(ff, locc, FILES, SUM, TD, QHXS, leixing, HANG);

                string finame1 = threadParamter.Path + "当量载荷谱分析结果\\多工况均值化零当量载荷谱.mat";//项目临时文件目录
                string newpath1 = threadParamter.ProPath + "\\" + "当量载荷谱分析文件" + "\\" + "多工况均值化零当量载荷谱.mat";//项目文件保存路径
                //CopyFile(finame1, newpath1, false);
                System.IO.File.Copy(finame1, newpath1, true);
                string finame2 = threadParamter.Path + "当量载荷谱分析结果\\多工况双参数雨流计数结果.mat";//项目临时文件目录
                string newpath2 = threadParamter.ProPath + "\\" + "当量载荷谱分析文件" + "\\" + "多工况双参数雨流计数结果.mat";//项目文件保存路径
                System.IO.File.Copy(finame2, newpath2, true);
                success = true;
                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
    new DoTask(Func));
            }
            catch
            {
                success = false;
                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
                
            }




           // TIOFPSS.Resources.MessageBoxX.Warning("当量载荷谱分析分析完成");
        }
        public void Func()
        {
            //Window2 aw = new Window2();
            //aw.ShowDialog();
            //使用ui元素
            if(this.threadParamter.isShiYan>0)
            {
                this.CallBackMethod(success,"实验文件" );
            }
            else if(this.threadParamter.isShiYan==0)
            {
                this.CallBackMethod(success, "准动态计算文件");
            }
            else
            {
                this.CallBackMethod(success, "动态分析结果文件");
            }
            
        }

    }
     public class DangLiangZaiHePuThreadParamter
    {
        public string Path { get; set; }//分析得到的文件的存放位置
        public string ProPath { get; set; }//项目路径（mat文件的保存路径）
        public double[] Para = new double[5];
        public List<string> tds { get; set; } //通道队列
        public List<string> qhxss { get; set; }//强化系数数组
        public List<string> files { get; set; }//数据文件数组
        public List<string> hang { get; set; }//数据文件数组
        public int sum;//数据文件个数
        public int isShiYan;
         

        public DangLiangZaiHePuThreadParamter()
        { }

        public DangLiangZaiHePuThreadParamter(string path, string proPath, double[] para, List<string> Tds, List<string> Qhxss, List<string> File, List<string> Hang, int Sum, int IsShiYan)
        {
            this.Path = path;
            this.ProPath = proPath;
            this.Para = para;
            this.tds = Tds;
            this.qhxss = Qhxss;
            this.files = File;
            this.hang = Hang;
            this.sum = Sum;
            this.isShiYan = IsShiYan;
        }
    }
}
