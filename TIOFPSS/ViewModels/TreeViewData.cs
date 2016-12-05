using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.ViewModels
{
    public class TreeViewData 
    {
        private static TreeViewData _Data = null;
        private static bool GetMultiNode(TreeNode treeNode, string path, int level)
        {
            level++;
            //TreeNode treeNode = new TreeNode();
            if (Directory.Exists(path) == false)
            { return false; }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            { return false; }
            TreeNode rn1;
            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                string pathNodeB = path + "\\" + dir[j].Name;
                rn1 = new TreeNode() { Label = dir[j].Name, Level = level, Type = @"pack://application:,,,/TIOFPSS;component/Images/folder.png" };
                GetMultiNode(rn1, pathNodeB, level);
                treeNode.ChildNodes.Add(rn1);
                //treeNode.ChildNodes.Add(new TreeNode() { Label = dir[j].Name, Level = level }); 

            }

            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                treeNode.ChildNodes.Add(new TreeNode() { Label = file[j].Name, Level = level, Type = @"pack://application:,,,/TIOFPSS;component/Images/file.png" }); ;
            }

            //if(dircount!=0||filecount!=0)
            //{
            //    rn1.ChildNodes.Add(treeNode);
            //}
            return true;
        }
        public static bool add(string path,string projectName)
        {
            string fullPath = path;
            if (fullPath != null && System.IO.Directory.Exists(fullPath) && System.IO.File.Exists(fullPath+"\\参数文件\\parameter.xml"))
            {
                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量

                var rn1 = new TreeNode() { Label = projectName, Level = 1, Type = @"pack://application:,,,/TIOFPSS;component/Images/folder.png" };
                TreeNode rn22;
                for (int i = 0; i < dircount; i++)
                {
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    rn22 = new TreeNode() { Label = dir[i].Name, Level = 2, Type = @"pack://application:,,,/TIOFPSS;component/Images/folder.png" };
                    GetMultiNode(rn22, pathNode, 2);

                    rn1.ChildNodes.Add(rn22);

                    //treeView.Nodes.Add(dir[i].Name);                                                
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {

                    rn1.ChildNodes.Add(new TreeNode() { Label = file[j].Name, Level = 2, Type = @"pack://application:,,,/TIOFPSS;component/Images/file.png" });
                }
                Data.RootNodes.Add(rn1);
                return true;
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("加载路径出错！请重新选择项目路径！");
                return false;
            }

        }

        public static bool update(string path, string projectName)
        {
            string fullPath = path;
            if (fullPath != null && System.IO.Directory.Exists(fullPath))
            {
                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量

                var rn1 = new TreeNode() { Label = projectName, Level = 1, Type = @"pack://application:,,,/TIOFPSS;component/Images/folder.png" };
                TreeNode rn22;
                for (int i = 0; i < dircount; i++)
                {
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    rn22 = new TreeNode() { Label = dir[i].Name, Level = 2, Type = @"pack://application:,,,/TIOFPSS;component/Images/folder.png" };
                    GetMultiNode(rn22, pathNode, 2);

                    rn1.ChildNodes.Add(rn22);

                    //treeView.Nodes.Add(dir[i].Name);                                                
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {

                    rn1.ChildNodes.Add(new TreeNode() { Label = file[j].Name, Level = 2, Type = @"pack://application:,,,/TIOFPSS;component/Images/file.png" });
                }

                for (int i = 0; i < Data.RootNodes.Count;i++ )
                {
                    if(Data.RootNodes[i].Label.Equals(projectName))
                    {
                        Data.RootNodes[i] = rn1;
                        return true;
                    }
                    if (Data.RootNodes[i].Label.Equals(projectName + "（当前项目）"))
                    {
                        rn1.Label += "（当前项目）";
                        Data.RootNodes[i] = rn1;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("加载路径出错！请重新选择项目路径！");
                return false;
            }

        }

        public static void delete(string label)
        {
            
            foreach(TreeNode item in Data.RootNodes)
            {
                if(item.Label.Equals(label))
                {
                    Data.RootNodes.Remove(item);
                    return;
                }
            }
        }
        public static void clear(string label)
        {
            label += "（当前项目）";
            foreach (TreeNode item in Data.RootNodes)
            {
                if (item.Label.Equals(label))
                {
                    item.Label = item.Label.Replace("（当前项目）", "");
                    return;
                }
            }
        }
        public static TreeViewData Data
        {
            get
            {
                if (_Data == null)
                {
                    _Data = new TreeViewData();
                }
                return _Data;
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<TreeNode> _RootNodes = null;

        public IList<TreeNode> RootNodes { get { return _RootNodes ?? (_RootNodes = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()); } }

        public class TreeNode : ViewModel
        {
            private string label;
            public string Label
            {
                get 
                {
                    return this.label; 
                }
                set
                {
                 label = value;
                this.OnPropertyChanged("Label");
            
                }    
            }

            public int Level { get; set; }

            public string Type { get; set; }

            private System.Collections.ObjectModel.ObservableCollection<TreeNode> _ChildNodes = null;

            public IList<TreeNode> ChildNodes { get { return _ChildNodes ?? (_ChildNodes = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()); } }
        }
    }
}
