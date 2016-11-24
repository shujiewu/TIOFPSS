using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;
using noise;

namespace TIOFPSS.Analysis
{
    public class ZaoShengFenXiThread
    {
        private NoiseThreadParamter threadParamter;
        private Thread thread;
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
        public Helper.delgateZaoShengFenXiFinish CallBackMethod;
        private delegate void DoTask();
        public ZaoShengFenXiThread(NoiseThreadParamter threadParamter)
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
            //String picPath = "D://";
            //String dataName = "project";
            //Double wendingshijian = 10.01;
            //double[] wending = new double[] { threadParamter.Wendingshijian };
            //MWNumericArray Wendingshijian = new MWNumericArray(threadParamter.Wendingshijian);
            //MWCharArray locc = new MWCharArray(threadParamter.Path);
            //MWCharArray dataname = new MWCharArray(threadParamter.FilePath);
            //MWCharArray fontName = new MWCharArray("宋体");
            MWArray Wendingshijian = new MWNumericArray(threadParamter.Wendingshijian);
            MWArray locc = new MWCharArray(threadParamter.Path);
            MWArray dataname = new MWCharArray(threadParamter.FilePath);
            MWArray fontName = new MWCharArray("宋体");

            

            noise.NoiseClass NoiseAnays = new noise.NoiseClass();
            NoiseAnays.noise(Wendingshijian,dataname,locc,fontName);

            System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
            //Xceed.Wpf.Toolkit.MessageBox.Show("噪声分析完成");
        }
        public void Func()
        {
            //Window2 aw = new Window2();
            //aw.ShowDialog();
            //使用ui元素    
            this.CallBackMethod(true);
        }
    }
    public class NoiseThreadParamter
    {


        public string Path { get; set; }//分析得到的文件的存放位置[temp下]
        //CString  maxFilePath;//noisemax.mat的绝对路径
        public string FilePath { get; set; }//输入文件绝对路径
        //CString maxZS;//最大噪声
        public double Wendingshijian { get; set; }
        public NoiseThreadParamter()
        { }

        public NoiseThreadParamter(string path, string filePath, double wendingshijian)
        {
            this.Path = path;
            this.FilePath = filePath;
            this.Wendingshijian = wendingshijian;
        }
    }

}
