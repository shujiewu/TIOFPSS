﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MathWorks.MATLAB.NET.Arrays;
using fatigue_final;
namespace TIOFPSS.Analysis
{
    class FeiXianXingSunShangThread
    {
        private FeiXianXingSunShangThreadParamter threadParamter;
        private Thread thread;
        public Helper.delgateFXXSSFinish CallBackMethod;
        private delegate void DoTask();
        private bool success;
        public FeiXianXingSunShangThread(FeiXianXingSunShangThreadParamter threadParamter)
        {
            this.threadParamter = threadParamter;
            thread = new Thread(new ThreadStart(Run));
            thread.Name = "FeiXianXingSunShangFenXiThread";
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
                      
            MWArray ff = new MWNumericArray(1, 23,threadParamter.Para);
            MWArray locc = new MWCharArray(threadParamter.Path + "非线性损伤分析结果\\");
            MWArray dataname = new MWCharArray(threadParamter.filePath);
            MWArray fontnm = new MWCharArray("宋体");
            

            //main_program_v1.WuJieJuWuChaClass wjj = new WuJieJuWuChaClass();
            //wjj.main_program_v1(A, loc, fontName);
            fatigue_final.PiLaoFenXiClass fxxss = new PiLaoFenXiClass();
            //try
            //{
            //    fxxss.fatigue_final(ff, locc, dataname, fontnm);
            //}
            //catch
            //{
            //    return;
            //}
            try
            {
                fxxss.fatigue_final(ff, locc, dataname, fontnm);


                string finame1 = threadParamter.Path + "非线性损伤分析结果\\疲劳损伤.mat";//项目临时文件目录
                string newpath1 = threadParamter.ProPath + "\\" + "非线性损伤分析文件" + "\\" + "疲劳损伤.mat";//项目文件保存路径
                //CopyFile(finame1, newpath1, false);
                System.IO.File.Copy(finame1, newpath1, true);
                string finame2 = threadParamter.Path + "非线性损伤分析结果\\寿命.mat";//项目临时文件目录
                string newpath2 = threadParamter.ProPath + "\\" + "非线性损伤分析文件" + "\\" + "寿命.mat";//项目文件保存路径
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
            if (this.threadParamter.isShiYan > 0)
            {
                this.CallBackMethod(success, "实验文件");
            }
            else if (this.threadParamter.isShiYan == 0)
            {
                this.CallBackMethod(success, "准动态计算文件");
            }
            else
            {
                this.CallBackMethod(success, "动态分析结果文件");
            }

        }

    }
     public class FeiXianXingSunShangThreadParamter
    {
        public string Path { get; set; }//分析得到的文件的存放位置
        public string ProPath { get; set; }//项目路径（mat文件的保存路径）
        public double[] Para = new double[23];
        public string filePath { get; set; }//数据文件数组
        public int isShiYan;
        public FeiXianXingSunShangThreadParamter()
        { }

        public FeiXianXingSunShangThreadParamter(string path, string proPath, double[] para,string File ,int IsShiYan)
        {
            this.Path = path;
            this.ProPath = proPath;
            this.Para = para;
            this.filePath = File;
            this.isShiYan = IsShiYan;
        }
    }
}
