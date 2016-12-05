using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TIOFPSS.Analysis
{
    class XT_ShaoChiYuYingLiThread
    {

        private XT_ShaoChiYuYingLiThreadParamter threadParamter;
        private Thread thread;
        public Helper.delgateShaoChiYuYingLiFenXiFinish CallBackMethod;
        private delegate void DoTask();
        private bool success;
        public XT_ShaoChiYuYingLiThread(XT_ShaoChiYuYingLiThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            thread = new Thread(new ThreadStart(Run));
            thread.Name = "XT_ShaoChiYuYingLiThread";
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
            string m_inputfile = threadParamter.sysPath;//分析文件路径
            string m_direction, m_outputfile;//ansys软件路径 和 中间文件输出路径
            string path = threadParamter.path;//结果保存路径
            string ansysPath;//
            string fileLock = path + "\\CuiHuo\\file.lock";
            //fileLock.Format("%s\\single\\file.lock", path);
            //删除错误文件
            if (System.IO.File.Exists(fileLock))
            {
                System.IO.File.Delete(fileLock);
            }
            ansysPath = Dialog.Configure.IniReadValue("system", "AnsysPath") + "\\" + Dialog.Configure.IniReadValue("system", "AnsysName");
            //ansysPath = @"D:\Program Files\ANSYS Inc\v160\ansys\bin\winx64\ansys160.exe";
            m_direction = ansysPath;
            m_outputfile = path + "\\CuiHuo\\output.out";
            string workPath = path + "\\CuiHuo";

            string sCommondLine;
            sCommondLine = m_direction + " -b -p ane3fl -i " + m_inputfile + " -o " + m_outputfile;


            //string appPath = m_direction;
            //ProcessStartInfo process = new ProcessStartInfo();
            //process.FileName = appPath;
            //process.Arguments = " -b -p ane3fl -i " + m_inputfile + " -o " + m_outputfile;

            //process.UseShellExecute = false;
            //process.CreateNoWindow = true;

            //process.RedirectStandardOutput = true;
            //Process.Start(process);



            Process process = new Process();
            string appPath = m_direction;
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = " -b -p ane3fl -i " + m_inputfile + " -o " + m_outputfile;
            process.StartInfo.WorkingDirectory = workPath;

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.RedirectStandardOutput = true;
            //bool success = false;
            // process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            // Start the process
            try
            {
                if (process.Start())
                {
                    process.WaitForExit();

                    if (System.IO.File.Exists(fileLock))
                    {
                        success = false;
                        System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
                        return;
                    }
                    else
                    {
                        success = true;
                    }
                }
            }
            catch
            {
                success = false;
                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
                return;
            }
            if (success)
            {
                //string source1, source2;
                //string dest1, dest2;
                //source1 = path + "\\yuyingli\\yuyingliyingliyuntu.jpeg";//产生的结果文件
                //dest1 = path + "\\yuyingliyingliyuntu.jpeg";
                //source2 = path + "\\yuyingli\\yuyingliweiyiyuntu.jpeg";//
                //dest2 = path + "\\yuyingliweiyiyuntu.jpeg";
                //System.IO.File.Copy(source1, dest1, true);
                //System.IO.File.Copy(source2, dest2, true);

                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
                //TIOFPSS.Resources.MessageBoxX.Warning("少齿当量静态强度分析完成");
            }
            else
            {
                string f1 = path + "\\CuiHuo\\cuihuoyingliyuntu.jpeg";
                string f2 = path + "\\CuiHuo\\cuihuoweiyiyuntu.jpeg"; ; 
                if (System.IO.File.Exists(f1))
                {
                    System.IO.File.Delete(f1);
                }
                if (System.IO.File.Exists(f2))
                {
                    System.IO.File.Delete(f2);
                }

                System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
new DoTask(Func));
                //TIOFPSS.Resources.MessageBoxX.Warning("少齿当量静态强度分析中断");
            }
            

        }
        public void Func()
        {
            //Window2 aw = new Window2();
            //aw.ShowDialog();
            this.CallBackMethod(success);
            //使用ui元素            
        }
    }

     public class XT_ShaoChiYuYingLiThreadParamter
    {


        public string asyName { get; set; }//协同分析的类型要分析的类型
        public string path { get; set; }//临时文件夹存放路径
        public string sysPath { get; set; }//分析文件的路径
        public string proPath { get; set; }//项目文件夹路径
        public XT_ShaoChiYuYingLiThreadParamter()
        { }

        public XT_ShaoChiYuYingLiThreadParamter(string AsyName, string Path, string SysPath, string ProPath)
        {
            this.asyName = AsyName;
            this.path = Path;
            this.sysPath = SysPath;
            this.proPath = ProPath;
        }
    }
}
