using MathWorks.MATLAB.NET.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using main_program_v1;
using pitch;
using TIOFPSS.Dialog;

namespace TIOFPSS.Analysis
{
    public class WuJieJuWuChaFenXiThread
    {
        private WuJieJuWuChaThreadParamter threadParamter;
        private Thread thread;
        private bool success;
        public Thread _Thread
        {
            get
            {
                return thread;
            }
            set
            {
                thread = value;
            }
        }

        public Helper.delgateWuJieJuWuChaFenXiFinish CallBackMethod; 

        public WuJieJuWuChaFenXiThread(WuJieJuWuChaThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            _Thread = new Thread(new ThreadStart(Run));
            _Thread.Name = "wujiejuThread";
        }

        public void Start()
        {
            if (thread != null)
            {
                thread.Start();
            }
        }
        private delegate void DoTask();
        private void Run()
        {
           
            MWArray A = new MWNumericArray(1,54,threadParamter.Para);
            MWArray loc = new MWCharArray(threadParamter.Path+"冲击动力学分析结果\\");
            
            MWArray fontName = new MWCharArray("宋体");



            main_program_v1.WuJieJuWuChaClass wjj = new WuJieJuWuChaClass();

            try
            {
                wjj.main_program_v1(A, loc, fontName);

                string force_source1 = System.IO.Path.Combine(threadParamter.Path, "冲击动力学分析结果\\force+.txt"); //inf->path + "force+.txt";
                string force_source2 = System.IO.Path.Combine(threadParamter.Path, "冲击动力学分析结果\\force-.txt"); //inf->path + "force-.txt";
                string dest_s1 = System.IO.Path.Combine(threadParamter.Path, "ZhunDongTai\\force+.txt"); //inf->path + "fdynamic\\force+.txt";
                string dest_s2 = System.IO.Path.Combine(threadParamter.Path, "ZhunDongTai\\force-.txt"); //inf->path + "fdynamic\\force-.txt";
                System.IO.File.Copy(force_source1, dest_s1, true);
                System.IO.File.Copy(force_source2, dest_s2, true);

                //复制结果
                string finame = System.IO.Path.Combine(threadParamter.Path, "冲击动力学分析结果\\Dynamic.mat"); //inf->path + "Dynamic.mat";//项目临时文件目录
                string newpath = System.IO.Path.Combine(threadParamter.ProPath, "冲击动力学分析文件\\Dynamic.mat"); //inf->proPath + str_FloderPath[1] + "\\" + "Dynamic.mat";//项目文件保存路径
                System.IO.File.Copy(finame, newpath, true);
                success = true;
                //CallBackMethod finish = new CallBackMethod();
                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
    new DoTask(Func));
            }
            catch
            {
                success = false;
                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
            }

            //System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
//new CallBackMethod(true));
            //this.CallBackMethod(true);
            //TIOFPSS.Resources.MessageBoxX.Warning("无节距误差分析完成");
        }
        public void Func()
        {
            //Window2 aw = new Window2();
            //aw.ShowDialog();
            //使用ui元素    
            this.CallBackMethod(success);
        }
        
    }
    public class WuJieJuWuChaThreadParamter
    {
        public string Path { get; set; }//分析得到的文件的存放位置
        public string ProPath { get; set; }//项目路径（mat文件的保存路径）
        public double[] Para = new double[54];

        public WuJieJuWuChaThreadParamter()
        { }

        public WuJieJuWuChaThreadParamter(string path, string proPath,double [] para)
        {
            this.Path = path;
            this.ProPath = proPath;
            this.Para = para;
        }
    }
    public class YouJieJuWuChaFenXiThread
    {
        private WuJieJuWuChaThreadParamter threadParamter;
        private Thread thread;
        public Helper.delgateYouJieJuWuChaFenXiFinish CallBackMethod;
        private delegate void DoTask();
        private bool success;
        public Thread _Thread
        {
            get
            {
                return thread;
            }
            set
            {
                thread = value;
            }
        }

        public YouJieJuWuChaFenXiThread(WuJieJuWuChaThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            _Thread = new Thread(new ThreadStart(Run));
            _Thread.Name = "ZaoShengFenXiThread";
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

           
            MWArray A = new MWNumericArray(1, 54, threadParamter.Para);
            MWArray loc = new MWCharArray(threadParamter.Path+"冲击动力学分析结果\\");

            MWArray fontName = new MWCharArray("宋体");


            pitch.YouJieJuWuChaClass yjj = new YouJieJuWuChaClass();

            try
            {
                yjj.pitch(A, loc, fontName);
                string finame = System.IO.Path.Combine(threadParamter.Path, "冲击动力学分析结果\\Dynamic.mat"); //inf->path + "Dynamic.mat";//项目临时文件目录
                string newpath = System.IO.Path.Combine(threadParamter.ProPath, "冲击动力学分析文件\\Dynamic.mat"); //inf->proPath + str_FloderPath[1] + "\\" + "Dynamic.mat";//项目文件保存路径
                System.IO.File.Copy(finame, newpath, true);
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
           
            //main_program_v1.WuJieJuWuChaClass wjj = new WuJieJuWuChaClass();
            //wjj.main_program_v1(A, loc, fontName);

            //string force_source1 = System.IO.Path.Combine(threadParamter.Path, "force+.txt"); //inf->path + "force+.txt";
            //string force_source2 = System.IO.Path.Combine(threadParamter.Path, "force-.txt"); //inf->path + "force-.txt";
            //string dest_s1 = System.IO.Path.Combine(threadParamter.Path, "fdynamic\\force+.txt"); //inf->path + "fdynamic\\force+.txt";
            //string dest_s2 = System.IO.Path.Combine(threadParamter.Path, "fdynamic\\force-.txt"); //inf->path + "fdynamic\\force-.txt";
            //System.IO.File.Copy(force_source1, dest_s1, true);
            //System.IO.File.Copy(force_source2, dest_s2, true);

            //复制结果
            //string force_source1 = System.IO.Path.Combine(threadParamter.Path, "force+.txt"); //inf->path + "force+.txt";
            //string force_source2 = System.IO.Path.Combine(threadParamter.Path, "force-.txt"); //inf->path + "force-.txt";
            //string dest_s1 = System.IO.Path.Combine(threadParamter.Path, "fdynamic\\force+.txt"); //inf->path + "fdynamic\\force+.txt";
            //string dest_s2 = System.IO.Path.Combine(threadParamter.Path, "fdynamic\\force-.txt"); //inf->path + "fdynamic\\force-.txt";
            //System.IO.File.Copy(force_source1, dest_s1, true);
            //System.IO.File.Copy(force_source2, dest_s2, true);

            //复制结果

            // TIOFPSS.Resources.MessageBoxX.Warning("有节距误差分析完成");
            //if()
            //{

            //}
            //else{
            //    string file1=threadParamter.Path+"摩擦片冲击力.png";
            //    string file2=threadParamter.Path+"摩擦片冲击力频谱图.png";
            //    string file3=threadParamter.Path+"摩擦片加速度频谱图.png";
            //    string file4=threadParamter.Path+"摩擦片角加速度.png";
            //    string file5=threadParamter.Path+"摩擦片角速度.png";
            //    string file6=threadParamter.Path+"摩擦片速度频谱图.png";
            //    string file7=threadParamter.Path+"摩擦片位移.png";
            //    string file8=threadParamter.Path+"摩擦片与内毂相对扭转角度.png";
            //    string file9=threadParamter.Path+"摩擦片与内毂相对旋转速度.png";
            //    string file10=threadParamter.Path+"内毂加速度频谱图.png";
            //    string file11=threadParamter.Path+"内毂角加速度.png";
            //    string file12=threadParamter.Path+"内毂角速度.png";
            //    string file13=threadParamter.Path+"内毂速度频谱图.png";
            //    string file14=threadParamter.Path+"内毂位移.png";
            //    string file15=threadParamter.Path+"相对扭转角度频谱图.png";
            //    string file16=threadParamter.Path+"相对旋转速度频谱图.png";
                
            //}
        }
        public void Func()
        {
            //Window2 aw = new Window2();
            //aw.ShowDialog();
            //使用ui元素    
            this.CallBackMethod(success);
        }
    }
}
