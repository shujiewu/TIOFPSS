﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TIOFPSS.Analysis
{
    class XT_ShaoChiDongTaiFenXiThread
    {

        private XT_ShaoChiDongTaiFenXiThreadParamter threadParamter;
        private Thread thread;
        private bool success;

        public XT_ShaoChiDongTaiFenXiThread(XT_ShaoChiDongTaiFenXiThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            thread = new Thread(new ThreadStart(Run));
            thread.Name = "XT_ShaoChiDongTaiFenXiThread";
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
            string fileLock = path + "\\sdynamic\\file.lock";
            //fileLock.Format("%s\\single\\file.lock", path);
            //删除错误文件
            if (System.IO.File.Exists(fileLock))
            {
                System.IO.File.Delete(fileLock);
            }
            ansysPath = Dialog.Configure.IniReadValue("system", "AnsysPath") + "\\" + Dialog.Configure.IniReadValue("system", "AnsysName");
            //ansysPath = @"D:\Program Files\ANSYS Inc\v160\ansys\bin\winx64\ansys160.exe";
            m_direction = ansysPath;
            m_outputfile = path + "\\sdynamic\\output.out";
            string workPath = path + "\\sdynamic";

            string sCommondLine;
            sCommondLine = m_direction + " -b -p ane3fl -i " + m_inputfile + " -o " + m_outputfile;



            Process process = new Process();
            string appPath = m_direction;
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = " -b -p ane3fl -i " + m_inputfile + " -o " + m_outputfile;
            process.StartInfo.WorkingDirectory = workPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.RedirectStandardOutput = true;
            bool success = false;
         
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

                //string source1, source2;
                //string dest1, dest2;
                //source1 = path + "\\duceng\\ducengyingliyuntu.jpeg";//产生的结果文件
                //dest1 = path + "\\ducengyingliyuntu.jpeg";
                //source2 = path + "\\duceng\\ducengweiyiyuntu.jpeg";//
                //dest2 = path + "\\ducengweiyiyuntu.jpeg";
                //System.IO.File.Copy(source1, dest1, true);
                //System.IO.File.Copy(source2, dest2, true);
                //TIOFPSS.Resources.MessageBoxX.Warning("少齿当量静态强度分析完成");
            }
            else
            {
                //string f1 = path + "\\ducengyingliyuntu.jpeg";
                //string f2 = path + "\\ducengweiyiyuntu.jpeg"; ;
                //if (System.IO.File.Exists(f1))
                //{
                //    System.IO.File.Delete(f1);
                //}
                //if (System.IO.File.Exists(f2))
                //{
                //    System.IO.File.Delete(f2);
                //}
                ////TIOFPSS.Resources.MessageBoxX.Warning("少齿当量静态强度分析中断");
            }
           

        }

    }

      public class XT_ShaoChiDongTaiFenXiThreadParamter
    {


        public string asyName { get; set; }//协同分析的类型要分析的类型
        public string path { get; set; }//临时文件夹存放路径
        public string sysPath { get; set; }//分析文件的路径
        public string proPath { get; set; }//项目文件夹路径
        public XT_ShaoChiDongTaiFenXiThreadParamter()
        { }

        public XT_ShaoChiDongTaiFenXiThreadParamter(string AsyName, string Path,string SysPath,string ProPath)
        {
            this.asyName = AsyName;
            this.path = Path;
            this.sysPath = SysPath;
            this.proPath = ProPath;
        }
    }
}
