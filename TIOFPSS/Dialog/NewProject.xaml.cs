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
using System.Windows.Shapes;
using System.Windows.Forms;
namespace TIOFPSS.Dialog
{
    /// <summary>
    /// NewProject.xaml 的交互逻辑
    /// </summary>
    public partial class NewProject : Window
    {
        public NewProject()
        {
            InitializeComponent();
        }
        private bool isNew=true;
        private string paraTempPath=null;
        public NewProject(bool IsNew,string path)
        {
            InitializeComponent();
            isNew = IsNew;
            if(isNew)
            {
                this.Title = "新建项目";
            }
            else
            {
                paraTempPath = path;
                //this.Title = "优化项目";
            }
        }
    //    string[] str_FloderPath = new string[]{//摩擦片项目文件的文件层次结构
    //"参数文件",
    //"冲击动力学分析文件",
    //"当量载荷谱分析文件",
    //"非线性损伤分析文件",
    //"噪声分析文件",
    //"协同分析文件",
    //"协同分析文件\\少齿当量静态强度分析",
    //"协同分析文件\\镀层少齿当量分析",
    //"协同分析文件\\少齿当量预应力分析",
    //"协同分析文件\\全齿偏心计算",
    //"协同分析文件\\动态分析",
    //"协同分析文件\\少齿动态分析",
    //"协同分析文件\\动态应力计算"};


    //    string[] str_AnsysTempPath = new string[]{
    //"single",
    //"duceng",
    //"yuyingli",
    //"pianxin",
    //"dynamic",
    //"fdynamic",
    //"sdynamic",
    //"mcpmodal",
    //"mcpngmodal"};


        public Helper.delgateNewProjMethod CallBackMethod; 
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    //此处做你想做的事 ...=openFileDialog1.FileName; 
            //}
            //打开文件
            // Specify a name for your top-level folder.
            if(this._valueSelectPath.Text!=""&&this._projectName.Text!="")
            {
                string folderName = this._valueSelectPath.Text;
                string pathString = System.IO.Path.Combine(folderName, this._projectName.Text);

                string projectPath = System.IO.Path.Combine(pathString, "project");

                if (TIOFPSS.Content.loadProj.ContainsKey(this._projectName.Text))
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("项目已存在！");
                    return;
                }

                string tempDataPath = System.IO.Path.Combine(pathString, "tempData");
                if (!System.IO.Directory.Exists(pathString))//查看项目是否存在
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    System.IO.Directory.CreateDirectory(tempDataPath);
                    System.IO.Directory.CreateDirectory(projectPath);
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("项目已存在！");
                    this.Close();
                    return;
                }
                for (int i = 0; i < 14; ++i)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(projectPath, Helper.str_FloderPath[i]));
                }

                for (int i = 0; i < 12; ++i)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(tempDataPath, Helper.str_AnsysTempPath[i]));
                }


                //string sourceFile = "paraTemple.xml";
                string sourcePath=null;
                string sourceFile = null;
                if(isNew)
                {
                   sourcePath= System.Windows.Forms.Application.StartupPath;
                   sourceFile = System.IO.Path.Combine(sourcePath, "paraTemple.xml");
                }
                else
                {
                    sourceFile = paraTempPath;
                }

                string targetPath = System.IO.Path.Combine(projectPath, Helper.str_FloderPath[0]);

                // Use Path class to manipulate file and directory paths.
                //string 
                string destFile = System.IO.Path.Combine(targetPath, "parameter.xml");
                
                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                    string inipath = System.IO.Path.Combine(targetPath, "project.ini");
                    string Section = "analysis";
                    string text = Convert.ToString(-1);
                    Configure.IniWriteValue(Section, "FXXSS", text, inipath);
                    Configure.IniWriteValue(Section, "DLZHP", text, inipath);
                }
                catch (System.IO.IOException err)
                {
                    Console.WriteLine(err.Message);
                    Xceed.Wpf.Toolkit.MessageBox.Show("参数文件创建出错！");
                    this.Close();
                    return;
                }

                //添加到树目录
                if(TIOFPSS.ViewModels.TreeViewData.add(projectPath, this._projectName.Text))
                {
                    this.CallBackMethod(this._projectName.Text, pathString);
                    this.Close();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("创建树目录出错！");
                    this.Close();
                }


            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("项目信息不能为空值");
            }

            //if (!System.IO.File.Exists(pathString))
            //{
            //    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
            //    {
            //        for (byte i = 0; i < 100; i++)
            //        {
            //            fs.WriteByte(i);
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("File \"{0}\" already exists.", fileName);
            //    return;
            //}

            //// Read and display the data from your file.
            //try
            //{
            //    byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
            //    foreach (byte b in readBuffer)
            //    {
            //        Console.Write(b + " ");
            //    }
            //    Console.WriteLine();
            //}
            //catch (System.IO.IOException err)
            //{
            //    Console.WriteLine(err.Message);
            //}

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //string userName = "111";
            //string userPassword = "2222";
            //string userType = "22222";

            //DB.UserProject model = new DB.UserProject();//实例化Model层
            //model.UserName = userName;
            //model.UserPassword = userPassword;
            //model.UserType = userType;

            //DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            //if (bll.Add(model) == true)//将用户信息添加到数据库中，根据返回值判断是否添加成功
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("数据添加成功");
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("数据添加失败");
            //}
            this.Close();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string tempPath = Configure.IniReadValue("system", "ProjectPath");
            fbd.SelectedPath = tempPath;
            fbd.Description = "请选择英文路径";
            fbd.ShowDialog();
            if (fbd.SelectedPath != string.Empty)
                this._valueSelectPath.Text = fbd.SelectedPath;
        }



    }
}
