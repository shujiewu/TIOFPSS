using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TIOFPSS.Analysis
{
    class XT_DuCengShaoChiThread
    {
        private XT_DuCengShaoChiThreadParamter threadParamter;
        private Thread thread;


        public XT_DuCengShaoChiThread(XT_DuCengShaoChiThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            thread = new Thread(new ThreadStart(Run));
            thread.Name = "XT_DuCengShaoChiThread";
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
            string fileLock = path + "\\duceng\\file.lock";
            //fileLock.Format("%s\\single\\file.lock", path);
            //删除错误文件
            if (System.IO.File.Exists(fileLock))
            {
                System.IO.File.Delete(fileLock);
            }
            ansysPath = Dialog.Configure.IniReadValue("system", "AnsysPath") + "\\ansys160.exe";
            //ansysPath = @"D:\Program Files\ANSYS Inc\v160\ansys\bin\winx64\ansys160.exe";
            m_direction = ansysPath;
            m_outputfile = path + "\\duceng\\output.out";
            string workPath = path + "\\duceng";

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
                source1 = path + "\\duceng\\ducengyingliyuntu.jpeg";//产生的结果文件
                dest1 = path + "\\ducengyingliyuntu.jpeg";
                source2 = path + "\\duceng\\ducengweiyiyuntu.jpeg";//
                dest2 = path + "\\ducengweiyiyuntu.jpeg";
                System.IO.File.Copy(source1, dest1, true);
                System.IO.File.Copy(source2, dest2, true);
                //Xceed.Wpf.Toolkit.MessageBox.Show("少齿当量静态强度分析完成");
            }
            else
            {
                string f1 = path + "\\ducengyingliyuntu.jpeg";
                string f2 = path + "\\ducengweiyiyuntu.jpeg"; ;
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
            // Wait that the process exits


            //string force_source1 = System.IO.Path.Combine(threadParamter.Path, "force+.txt"); //inf->path + "force+.txt";
            //string force_source2 = System.IO.Path.Combine(threadParamter.Path, "force-.txt"); //inf->path + "force-.txt";
            //string dest_s1 = System.IO.Path.Combine(threadParamter.Path, "fdynamic\\force+.txt"); //inf->path + "fdynamic\\force+.txt";
            //string dest_s2 = System.IO.Path.Combine(threadParamter.Path, "fdynamic\\force-.txt"); //inf->path + "fdynamic\\force-.txt";
            //System.IO.File.Copy(force_source1, dest_s1, true);
            //System.IO.File.Copy(force_source2, dest_s2, true);

            ////复制结果
            //string finame = System.IO.Path.Combine(threadParamter.Path, "Dynamic.mat"); //inf->path + "Dynamic.mat";//项目临时文件目录
            //string newpath = System.IO.Path.Combine(threadParamter.ProPath, "冲击动力学分析文件\\Dynamic.mat"); //inf->proPath + str_FloderPath[1] + "\\" + "Dynamic.mat";//项目文件保存路径
            //System.IO.File.Copy(finame, newpath, true);


        }
    }
        public class XT_DuCengShaoChiThreadParamter
    {


        public string asyName { get; set; }//协同分析的类型要分析的类型
        public string path { get; set; }//临时文件夹存放路径
        public string sysPath { get; set; }//分析文件的路径
        public string proPath { get; set; }//项目文件夹路径
        public XT_DuCengShaoChiThreadParamter()
        { }

        public XT_DuCengShaoChiThreadParamter(string AsyName, string Path,string SysPath,string ProPath)
        {
            this.asyName = AsyName;
            this.path = Path;
            this.sysPath = SysPath;
            this.proPath = ProPath;
        }
    }
}
