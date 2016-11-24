using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TIOFPSS.Analysis
{
    class XT_QuanChiPianXinThread
    {

         private XT_QuanChiPianXinThreadParamter threadParamter;
        private Thread thread;


        public XT_QuanChiPianXinThread(XT_QuanChiPianXinThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            thread = new Thread(new ThreadStart(Run));
            thread.Name = "XT_QuanChiPianXinThread";
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
            string fileLock = path + "\\pianxin\\file.lock";
            //fileLock.Format("%s\\single\\file.lock", path);
            //删除错误文件
            if (System.IO.File.Exists(fileLock))
            {
                System.IO.File.Delete(fileLock);
            }
            ansysPath = Dialog.Configure.IniReadValue("system", "AnsysPath") + "\\ansys160.exe";
            //ansysPath = @"D:\Program Files\ANSYS Inc\v160\ansys\bin\winx64\ansys160.exe";
            m_direction = ansysPath;
            m_outputfile = path + "\\pianxin\\output.out";
            string workPath = path + "\\pianxin";

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
            bool success = false;
            // process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            // Start the process
            if (process.Start())
            {
                process.WaitForExit();

                if (System.IO.File.Exists(fileLock))
                {
                    success = false;

                }
                else
                {
                    success = true;
                }
            }
            if (success)
            {
                string source1, source2;
                string dest1, dest2;
                source1 = path + "\\pianxin\\pianxinyingliyuntu.jpeg";//产生的结果文件
                dest1 = path + "\\pianxinyingliyuntu.jpeg";
                source2 = path + "\\pianxin\\pianxinweiyiyuntu.jpeg";//
                dest2 = path + "\\pianxinweiyiyuntu.jpeg";
                System.IO.File.Copy(source1, dest1, true);
                System.IO.File.Copy(source2, dest2, true);
                //Xceed.Wpf.Toolkit.MessageBox.Show("少齿当量静态强度分析完成");
            }
            else
            {
                string f1 = path + "\\pianxinyingliyuntu.jpeg";
                string f2 = path + "\\pianxinweiyiyuntu.jpeg"; ;
                if (System.IO.File.Exists(f1))
                {
                    System.IO.File.Delete(f1);
                }
                if (System.IO.File.Exists(f2))
                {
                    System.IO.File.Delete(f2);
                }
                //Xceed.Wpf.Toolkit.MessageBox.Show("少齿当量静态强度分析中断");
            }
            

        }
    }
    public class XT_QuanChiPianXinThreadParamter
    {


        public string asyName { get; set; }//协同分析的类型要分析的类型
        public string path { get; set; }//临时文件夹存放路径
        public string sysPath { get; set; }//分析文件的路径
        public string proPath { get; set; }//项目文件夹路径
        public XT_QuanChiPianXinThreadParamter()
        { }

        public XT_QuanChiPianXinThreadParamter(string AsyName, string Path, string SysPath, string ProPath)
        {
            this.asyName = AsyName;
            this.path = Path;
            this.sysPath = SysPath;
            this.proPath = ProPath;
        }
    }
}
