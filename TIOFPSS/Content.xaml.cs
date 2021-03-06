﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Fluent;
using TIOFPSS.ViewModels;
using Button = Fluent.Button;
using System.Collections.Generic;
using TIOFPSS.Dialog;
using System.IO;
using TIOFPSS.DB;
using System.Data.SQLite;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock.Layout;
using MathWorks.MATLAB.NET.Arrays;
using draw;

using zsbd;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Matlab;
using System.Windows.Media;
using System.Globalization;
namespace TIOFPSS
{

    /// <summary>
    /// Content.xaml 的交互逻辑
    /// </summary>
    public partial class Content
    {
        MainViewModel mainViewModel;
        //Window2 win2;
        LayoutAnchorable anchorable;   
        public static string nowProjName=null;
        public static Dictionary<string, string> loadProj = new Dictionary<string, string>();
        public Content()
        {
            this.InitializeComponent();

            this.Loaded += this.HandleContentLoaded;

            //Ribbon.Localization.Culture = new CultureInfo("ru-RU");

            this.buttonBold.Checked += (s, e) => Debug.WriteLine("Checked");
            this.buttonBold.Unchecked += (s, e) => Debug.WriteLine("Unchecked");

            //win2 = new Window2();
            //FontsViewModel f = new FontsViewModel();
            //string sql = "select * from pepple order by id desc limit 10 offset 1";
            //SQLiteDBHelper db = new SQLiteDBHelper();
            //string []test=new string[50];
            //using (SQLiteDataReader reader = db.ExecuteReader(sql, null))
            //{
            //    int i=0;
            //    while (reader.Read())
            //    {


            //        test[i]=reader.GetString(1);
            //        i++;
            //    }
            //}
            //f.FontsData = test;
            // n = new MainViewModel();
            btnFalse();
            
            mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
            //DockManager.MouseLeftButtonUp += TabMouseClick;
        }
        private void btnFalse()
        {
            btnwjjwc.IsEnabled = false;
            btnyjjwc.IsEnabled = false;
            btnzsfx.IsEnabled = false;
            btnfxxssfx.IsEnabled = false;
            btndlzhpfx.IsEnabled = false;
            btnParaView.IsEnabled = false;
            btnSubmit.IsEnabled = false;
            btnView3DModel.IsEnabled = false;
            btnSavePara.IsEnabled = false;
            btnApplyLib.IsEnabled = false;
            btnYouJieJuChuTu.IsEnabled = false;

            btnXTFX.IsEnabled = false;
            btnJingTaiQiangDuFenXi.IsEnabled = false;
            btnDuCengShaoChiFenXi.IsEnabled = false;
            btnShaoChiDangLiangFenXi.IsEnabled = false;
            btnQuanChiPianXinJiSuan.IsEnabled = false;
            btnDongTaiFenXi.IsEnabled = false;
            btnDongTaiYingLiJiSuan.IsEnabled = false;
            btnMoCaPianMoTaiJiSuan.IsEnabled = false;
            btnMcpNgMoTaiJiSuan.IsEnabled = false;
            //btnMoTaiJieGuo.IsEnabled = false;

            btnAnalysisMonitor.IsEnabled = false;
            btnShengChengBaoBiao.IsEnabled = false;
            btnViewResult.IsEnabled = false;

            btnPicEdit.IsEnabled = false;
            btnDetailDraw.IsEnabled = false;
            btnPicEditOK.IsEnabled = false;
        }
        private void btnTrue()
        {
            btnwjjwc.IsEnabled = true;
            btnyjjwc.IsEnabled = true;
            btnzsfx.IsEnabled = true;
            btnfxxssfx.IsEnabled = true;
            btndlzhpfx.IsEnabled = true;
            btnParaView.IsEnabled = true;
            btnSubmit.IsEnabled = true;
            btnView3DModel.IsEnabled = true;
            btnSavePara.IsEnabled = true;
            btnApplyLib.IsEnabled = true;
            btnYouJieJuChuTu.IsEnabled = true;

            btnXTFX.IsEnabled = true;
            btnJingTaiQiangDuFenXi.IsEnabled = true;
            btnDuCengShaoChiFenXi.IsEnabled = true;
            btnShaoChiDangLiangFenXi.IsEnabled = true;
            btnQuanChiPianXinJiSuan.IsEnabled = true;
            btnDongTaiFenXi.IsEnabled = true;
            btnDongTaiYingLiJiSuan.IsEnabled = true;
            btnMoCaPianMoTaiJiSuan.IsEnabled = true;
            btnMcpNgMoTaiJiSuan.IsEnabled = true;
            //btnMoTaiJieGuo.IsEnabled = true;

            btnAnalysisMonitor.IsEnabled = true;
            btnShengChengBaoBiao.IsEnabled = true;
            btnViewResult.IsEnabled = true;

            btnPicEdit.IsEnabled = true;
            btnDetailDraw.IsEnabled = true;
            btnPicEditOK.IsEnabled = true;
        }
        //private void TabMouseClick(object sender, MouseButtonEventArgs e)
        //{
        //    //处理逻辑
        //    foreach (var paneItem in DocumentPane.Children)
        //    {
        //        if (paneItem.Title == "项目参数" && paneItem.IsSelected == true)
        //        {
        //            btnwjjwc.IsEnabled = true;
        //            btnyjjwc.IsEnabled = true;
        //            btnzsfx.IsEnabled = true;
        //            btnfxxssfx.IsEnabled = true;
        //            btndlzhpfx.IsEnabled = true;                       
        //            break;
        //        }
        //        if (paneItem.Title == "分析结果" && paneItem.IsSelected == true)
        //        {
        //            btnwjjwc.IsEnabled = false;
        //            btnyjjwc.IsEnabled = false;
        //            btnzsfx.IsEnabled = false;
        //            btnfxxssfx.IsEnabled = false;
        //            btndlzhpfx.IsEnabled = false;
        //            break;
        //        }
        //        if (paneItem.Title == "项目查找" && paneItem.IsSelected == true)
        //        {
        //            btnwjjwc.IsEnabled = false;
        //            btnyjjwc.IsEnabled = false;
        //            btnzsfx.IsEnabled = false;
        //            btnfxxssfx.IsEnabled = false;
        //            btndlzhpfx.IsEnabled = false;
        //            break;
        //        }
        //        if (paneItem.Title == "噪声优化方法" && paneItem.IsSelected == true)
        //        {
        //            btnwjjwc.IsEnabled = false;
        //            btnyjjwc.IsEnabled = false;
        //            btnzsfx.IsEnabled = false;
        //            btnfxxssfx.IsEnabled = false;
        //            btndlzhpfx.IsEnabled = false;
        //            break;
        //        }
        //        if (paneItem.Title == "项目对比" && paneItem.IsSelected == true)
        //        {
        //            btnwjjwc.IsEnabled = false;
        //            btnyjjwc.IsEnabled = false;
        //            btnzsfx.IsEnabled = false;
        //            btnfxxssfx.IsEnabled = false;
        //            btndlzhpfx.IsEnabled = false;
        //            break;
        //        }
        //    }
        //}
        private static void OnScreenTipHelpPressed(object sender, ScreenTipHelpEventArgs e)
        {
            Process.Start((string)e.HelpTopic);
        }

        private void HandleContentLoaded(object sender, RoutedEventArgs e)
        {
            ScreenTip.HelpPressed += OnScreenTipHelpPressed;
        }

        private void OnLauncherButtonClick(object sender, RoutedEventArgs e)
        {
            var groupBox = (RibbonGroupBox)sender;

            var wnd = new Window
            {
                Content = string.Format("Launcher-Window for: {0}", groupBox.Header),
                Owner = Window.GetWindow(this)
            };

            wnd.Show();
        }

        //private void OnSplitClick(object sender, RoutedEventArgs e)
        //{
        //    TIOFPSS.Resources.MessageBoxX.Warning("Split Clicked!!!");
        //}


        private void OnReduceClick(object sender, RoutedEventArgs e)
        {
            //this.InRibbonGallery.Reduce();
        }

        public Button CreateRibbonButton()
        {
            var button = new Button();
            var fooCommand1 = new FooCommand1();
            button.Command = fooCommand1.ItemCommand;

            button.Header = "Foo";

            this.CommandBindings.Add(fooCommand1.ItemCommandBinding);
            return button;
        }

        #region Theming

        private enum Theme
        {
            Office2010,
            Office2013
        }

        private Theme? currentTheme;

        private void OnOffice2013Click(object sender, RoutedEventArgs e)
        {
            this.ChangeTheme(Theme.Office2013, "pack://application:,,,/Fluent;component/Themes/Office2013/Generic.xaml");
        }

        private void OnOffice2010SilverClick(object sender, RoutedEventArgs e)
        {
            this.ChangeTheme(Theme.Office2010, "pack://application:,,,/Fluent;component/Themes/Office2010/Silver.xaml");
        }

        private void OnOffice2010BlackClick(object sender, RoutedEventArgs e)
        {
            this.ChangeTheme(Theme.Office2010, "pack://application:,,,/Fluent;component/Themes/Office2010/Black.xaml");
        }

        private void OnOffice2010BlueClick(object sender, RoutedEventArgs e)
        {
            this.ChangeTheme(Theme.Office2010, "pack://application:,,,/Fluent;component/Themes/Office2010/Blue.xaml");
        }

        private void ChangeTheme(Theme theme, string color)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (ThreadStart)(() =>
            {
                var owner = Window.GetWindow(this);
                if (owner != null)
                {
                    owner.Resources.BeginInit();

                    if (owner.Resources.MergedDictionaries.Count > 0)
                    {
                        owner.Resources.MergedDictionaries.RemoveAt(0);
                    }

                    if (string.IsNullOrEmpty(color) == false)
                    {
                        owner.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri(color) });
                    }

                    owner.Resources.EndInit();
                }

                if (this.currentTheme != theme)
                {
                    Application.Current.Resources.BeginInit();
                    switch (theme)
                    {
                        case Theme.Office2010:
                            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Fluent;component/Themes/Generic.xaml") });
                            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                            break;
                        case Theme.Office2013:
                            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Fluent;component/Themes/Office2013/Generic.xaml") });
                            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                            break;
                    }

                    this.currentTheme = theme;
                    Application.Current.Resources.EndInit();

                    if (owner != null)
                    {
                        owner.Style = null;
                        owner.Style = owner.FindResource("RibbonWindowStyle") as Style;
                        owner.Style = null;
                    }
                }
            }));
        }

        private void HandleDontUseDwmClick(object sender, RoutedEventArgs e)
        {
            //var control = sender as UIElement;

            //if (control == null)
            //{
            //    return;
            //}

            //var window = Window.GetWindow(control) as RibbonWindow;

            //if (window == null)
            //{
            //    return;
            //}

            //window.DontUseDwm = this.DontUseDwm.IsChecked.GetValueOrDefault();
        }

        #endregion Theming

        #region Logical tree

        private void OnShowLogicalTreeClick(object sender, RoutedEventArgs e)
        {
            this.CheckLogicalTree(this.ribbon);
            //this.logicalTreeView.Items.Clear();
            //this.BuildLogicalTree(this.ribbon, this.logicalTreeView);
        }

        private static string GetDebugInfo(DependencyObject element)
        {
            if (element == null)
            {
                return "NULL";
            }

            var header = element is IRibbonControl
                           ? (element as IRibbonControl).Header
                           : string.Empty;

            var name = element is FrameworkElement
                           ? (element as FrameworkElement).Name
                           : string.Empty;

            return string.Format("[{0}] (Header: {1} || Name: {2})", element, header, name);
        }

        private void CheckLogicalTree(DependencyObject root)
        {
            var children = LogicalTreeHelper.GetChildren(root);
            foreach (var child in children.OfType<DependencyObject>())
            {
                if (LogicalTreeHelper.GetParent(child) != root)
                {
                    Debug.WriteLine(string.Format("Incorrect logical parent for {0}", GetDebugInfo(child)));
                    Debug.WriteLine(string.Format("\tExpected: {0}", GetDebugInfo(root)));
                    Debug.WriteLine(string.Format("\tFound: {0}", GetDebugInfo(LogicalTreeHelper.GetParent(child))));
                }

                this.CheckLogicalTree(child);
            }
        }

        private void BuildLogicalTree(DependencyObject current, ItemsControl parentControl)
        {
            var newItem = new TreeViewItem
            {
                Header = GetDebugInfo(current),
                Tag = current
            };

            parentControl.Items.Add(newItem);

            var children = LogicalTreeHelper.GetChildren(current);
            foreach (var child in children.OfType<DependencyObject>())
            {
                this.BuildLogicalTree(child, newItem);
            }
        }

        

        private void BuildBackLogicalTree(DependencyObject current, StringBuilder stringBuilder)
        {
            if (current == null
                || current == this.ribbon)
            {
                return;
            }

            stringBuilder.AppendFormat(" -> {0}\n", GetDebugInfo(current));

            var parent = LogicalTreeHelper.GetParent(current);

            this.BuildBackLogicalTree(parent, stringBuilder);
        }

        #endregion Logical tree

        //private void OnFormatPainterClick(object sender, RoutedEventArgs e)
        //{
        //    TIOFPSS.Resources.MessageBoxX.Warning("FP");
        //}

        private void OnHelpClick(object sender, RoutedEventArgs e)
        {
            if (this.tabGroup1.Visibility == Visibility.Visible)
            {
                this.tabGroup1.Visibility = Visibility.Collapsed;
                this.tabGroup2.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.tabGroup1.Visibility = Visibility.Visible;
                this.tabGroup2.Visibility = Visibility.Visible;
            }
        }

        private void OnSpinnerValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // MessageBox.Show(String.Format("Changed from {0} to {1}", e.OldValue, e.NewValue));
        }

        private void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            var wnd = new MainWindow
            {
                Owner = Window.GetWindow(this)
            };
            wnd.Show();
        }

        private void OnPrintVisualClick(object sender, RoutedEventArgs e)
        {
            var printDlg = new PrintDialog();

            if (printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(this, "Main Window");
            }
        }

        private void AddRibbonTab_OnClick(object sender, RoutedEventArgs e)
        {
            var tab = new RibbonTabItem
            {
                Header = "Test"
            };

            var group = new RibbonGroupBox();
            group.Items.Add(this.CreateRibbonButton());
            tab.Groups.Add(group);

            this.ribbon.Tabs.Add(tab);
        }

        private void HandleSaveAsClick(object sender, RoutedEventArgs e)
        {
            var w = new Window();
            w.ShowDialog();
        }

        //新建项目
        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            NewProject aw = new NewProject();
            aw.CallBackMethod = NewProjOKClick;
            aw.ShowDialog();
        }
        private void NewLibProject_Click(object sender, RoutedEventArgs e)
        {
            paraProperty aw = new paraProperty();
            aw.Title = "参数库";
            aw.CallBackMethod = NewProjectApplyLib;
            aw.ShowDialog();

            //NewProject aw = new NewProject();
            //aw.CallBackMethod = NewProjOKClick;
            //aw.ShowDialog();
        }
        private void NewProjectApplyLib(List<string> para)
        {
            para.RemoveAt(0);//删除名字
            string sourcePath= System.Windows.Forms.Application.StartupPath;
            string sourceFile = System.IO.Path.Combine(sourcePath, "paraLibTemple.xml");
            DB.XmlHelper.UpdatePara(sourceFile,para);
            NewProject aw = new NewProject(false, sourceFile);
            aw.CallBackMethod = NewProjOKClick;
            aw.ShowDialog();
            //foreach (var item in DocumentPane.Children)
            //{
            //    if (item.IsSelected == true && item.Title == "项目参数")
            //    {

            //        TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
            //        ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);
            //        tempPara.loopSetLibValue(para);
            //    }
            //}
        }

        private void NewNowProject_Click(object sender, RoutedEventArgs e)
        {
            if(nowProjName!=null)
            {
                string path = loadProj[nowProjName] + "\\project\\参数文件\\parameter.xml";
                NewProject aw = new NewProject(false, path);
                aw.CallBackMethod = NewProjOKClick;
                aw.Title = "优化当前项目";
                aw.ShowDialog();
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择当前项目！",this.Parent as Window);
            }

        }
        private void NewProjOKClick(string projectName, string pathString)
        {
            loadProj.Add(projectName, pathString);  //添加项目
            if (nowProjName == null)  //第一个项目
            {
                nowProjName = TIOFPSS.ViewModels.TreeViewData.Data.RootNodes[0].Label;
                TIOFPSS.ViewModels.TreeViewData.Data.RootNodes[0].Label += "（当前项目）";
                Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
                document.Title = "项目参数";
                document.Content = new TIOFPSS.Dialog.InputPara(pathString, projectName);
                document.IsActive = true;
                document.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                DocumentPane.Children.Add(document);
                btnTrue();
            }
            insertLatestProj(pathString, projectName); //插入到最近使用的项目

            insertProj(pathString, projectName);
        }
        //打开项目
        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            string tempPath = Dialog.Configure.IniReadValue("system", "ProjectPath");
            fbd.SelectedPath = tempPath;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            
            if (fbd.SelectedPath!=string.Empty)//&&!fbd.SelectedPath.Equals(tempPath)
            {
                string projectPath = fbd.SelectedPath;
                string projectName = projectPath.Substring(projectPath.LastIndexOf('\\') + 1);

                if (loadProj.ContainsKey(projectName))
                {

                    TIOFPSS.Resources.MessageBoxX.Warning("不能加载同名项目",this.Parent as Window);
                    return;
                }

                string projectReadPath = System.IO.Path.Combine(projectPath, "project");
                if (!System.IO.File.Exists(projectReadPath + "\\参数文件\\parameter.xml"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("xml文件读取出错！");
                    return;
                }
                if(TIOFPSS.ViewModels.TreeViewData.add(projectReadPath, projectName))
                {
                    loadProj.Add(projectName, projectPath);  //上面保证了不会加载到已经存在的项目
                    if (nowProjName == null)  //第一个项目
                    {
                        nowProjName = TIOFPSS.ViewModels.TreeViewData.Data.RootNodes[0].Label;
                        TIOFPSS.ViewModels.TreeViewData.Data.RootNodes[0].Label += "（当前项目）";
                        Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
                        document.Title = "项目参数";
                        document.Content = new TIOFPSS.Dialog.InputPara(projectPath, projectName);
                        document.IsActive = true;
                        document.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                        DocumentPane.Children.Add(document);
                        btnTrue();

                    }
                    insertLatestProj(projectPath, projectName);

                    insertProj(projectPath, projectName);
                }
                else
                {
                    //TIOFPSS.Resources.MessageBoxX.Warning("创建树目录出错！");
                    return;
                }

            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("项目路径不能为空！",this.Parent as Window);
                return;
            }


        }
        private void insertProj(string projectPath, string projectName)
        {
            ParaViewModel tempPara = new ParaViewModel(projectPath, projectName);
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            bll.Add(tempPara.UserProject);

        }

        private void insertLatestProj(string projectPath,string projectName)
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            if (!bll.AddLatestProject(projectPath, projectName, DateTime.Now.ToFileTimeUtc().ToString()))
            {
                TIOFPSS.Resources.MessageBoxX.Error("插入最近使用的项目失败！", this.Parent as Window);
                return;
            }
            mainViewModel.LatestProjectViewModel = new LatestProjectViewModel();
           
        }

        private void OnOpenLatestProjClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem item = sender as System.Windows.Controls.MenuItem;
            string projectName = item.Header.ToString();

            if (loadProj.ContainsKey(projectName))
            {
                TIOFPSS.Resources.MessageBoxX.Warning("不能加载同名项目", this.Parent as Window);
                return;
            }

            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            string projectPath = bll.GetLatestProjectPath(projectName);

            if(projectPath!=null)
            {
                string projectReadPath = System.IO.Path.Combine(projectPath, "project");

                if (!System.IO.File.Exists(projectReadPath + "\\参数文件\\parameter.xml"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("xml文件读取出错！");
                    bll.DeleteLatestProject(projectName);
                    mainViewModel.LatestProjectViewModel = new LatestProjectViewModel();
                    return;
                }
                if(TIOFPSS.ViewModels.TreeViewData.add(projectReadPath, projectName))
                {
                    loadProj.Add(projectName, projectPath);
                    if (nowProjName == null)  //第一个项目
                    {
                        nowProjName = TIOFPSS.ViewModels.TreeViewData.Data.RootNodes[0].Label;
                        TIOFPSS.ViewModels.TreeViewData.Data.RootNodes[0].Label += "（当前项目）";
                        Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
                        document.Title = "项目参数";
                        document.Content = new TIOFPSS.Dialog.InputPara(projectPath, projectName);
                        document.IsActive = true;
                        document.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                        DocumentPane.Children.Add(document);
                        btnTrue();

                    }
                    insertLatestProj(projectPath, projectName);

                    insertProj(projectPath, projectName);
                }
                else
                {
                    bll.DeleteLatestProject(projectName);
                    mainViewModel.LatestProjectViewModel = new LatestProjectViewModel();
                }

            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Error("数据库读取失败！", this.Parent as Window);

                ///此处添加删除数据库代码

                return;
            }
        }
        System.Windows.Controls.ContextMenu GetItemRightContextMenu()
        {

            System.Windows.Controls.ContextMenu menu = new System.Windows.Controls.ContextMenu();

            System.Windows.Controls.MenuItem menuItem1 = new System.Windows.Controls.MenuItem();
            menuItem1.Header = "删除";
            System.Windows.Controls.MenuItem menuItem2 = new System.Windows.Controls.MenuItem();
            menuItem2.Header = "重命名";
            System.Windows.Controls.MenuItem menuItem3 = new System.Windows.Controls.MenuItem();
            menuItem3.Header = "刷新";
            System.Windows.Controls.MenuItem menuItem4 = new System.Windows.Controls.MenuItem();
            menuItem4.Header = "移除";

            menuItem1.Click += new RoutedEventHandler(OnDeleteProjClick);
            menuItem2.Click += new RoutedEventHandler(OnReNameProjClick);
            menuItem3.Click += new RoutedEventHandler(OnUpdateProjClick);
            
            menuItem4.Click += new RoutedEventHandler(OnRemoveProjClick);
            
            menu.Items.Add(menuItem1);
            menu.Items.Add(menuItem2);
            menu.Items.Add(menuItem3);
            menu.Items.Add(menuItem4);
            return menu;

        }
        TreeViewItem itemTemp=null;
        private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            //if (treeViewItem != null)
            //{

            //    treeViewItem.Focus();
                
            //}

            itemTemp = GetParentObjectEx<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;

            if (itemTemp != null)
            {

                itemTemp.Focus();
                e.Handled = true;

            }

            var item = treeView1.SelectedItem as TIOFPSS.ViewModels.TreeViewData.TreeNode;
            if (item == null)
            {
                return;
            }
            if (item.Level == 1)
            {
                // treeView1.ContextMenu.IsEnabled = true;
                //e.Handled = true;
                //ContextMenu.Visibility = Visibility.Visible;
                treeView1.ContextMenu = GetItemRightContextMenu();
                
            }
            else
            {
                //treeView1.ContextMenu.IsEnabled = false;

                treeView1.ContextMenu = null;
                // e.Handled = true;
            }


        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = System.Windows.Media.VisualTreeHelper.GetParent(source);

            return source;
        }
        private void OnDeleteProjClick(object sender, RoutedEventArgs e)
        {
            var treeView = treeView1;

            if (treeView == null)
            {
                return;
            }


            var item = treeView.SelectedItem as TIOFPSS.ViewModels.TreeViewData.TreeNode;
            if (item == null)
            {
                return;
            }

            if (item.Level == 1)
            {
                string itemName = item.Label;
                if (itemName.Equals(nowProjName + "（当前项目）"))
                {
                    nowProjName = null;
                    itemName = itemName.Substring(0, itemName.LastIndexOf("（当前项目）"));

                    foreach (var paneItem in DocumentPane.Children)
                    {
                        if (paneItem.Title == "项目参数")
                        {
                            paneItem.Close();
                            //;
                            break;
                        }
                    }
                    foreach (var paneItem in DocumentPane.Children)
                    {
                        if (paneItem.Title == "分析结果")
                        {
                            paneItem.Close();
                            break;
                        }
                    }
                    btnFalse();
                }
                if (!DeleteDB(loadProj[itemName]))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("数据库信息删除失败！", this.Parent as Window);
                }

                try
                {
                    DirectoryInfo di = new DirectoryInfo(loadProj[itemName]);
                    di.Delete(true);
                }
                catch (System.IO.IOException err)
                {
                    Console.WriteLine(err.Message);
                    TIOFPSS.Resources.MessageBoxX.Error("项目文件删除失败！", this.Parent as Window);
                    return;
                }

                loadProj.Remove(itemName);
                if (loadProj.Count == 0)
                {
                    btnFalse();
                }
                TIOFPSS.ViewModels.TreeViewData.delete(item.Label);
            }
        }

        private bool DeleteDB(string proPath)
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            if (bll.Delete(proPath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public TreeViewItem GetParentObjectEx<TreeViewItem>(DependencyObject obj) where TreeViewItem : FrameworkElement
        {
            DependencyObject parent = System.Windows.Media.VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is TreeViewItem)
                {
                    return (TreeViewItem)parent;
                }
                parent = System.Windows.Media.VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        System.Windows.Controls.TextBox tempTextBox = new System.Windows.Controls.TextBox();

        System.Windows.Controls.TextBlock tempTextBlock = new System.Windows.Controls.TextBlock();
        private void renametextbox_LostFous(object sender, RoutedEventArgs e)
        {
            tempTextBox.Visibility = Visibility.Collapsed;
            tempTextBlock.Visibility = Visibility.Visible;

            string newName = tempTextBox.Text;
            if(newName!=changeItemName)
            {
                if (changeItemName.Contains("（当前项目）"))
                {
                    if (!tempTextBox.Text.Contains("（当前项目）"))
                    {
                        tempTextBlock.Text = changeItemName;
                        TIOFPSS.Resources.MessageBoxX.Warning("重命名不合法！", this.Parent as Window);
                        return;
                    }
                }
                string oldPath = null;
                string newpath = null;
                string oldName = null;
                UserProject userProject = new UserProject();
                if (changeItemName.Contains("（当前项目）"))
                {
                    newName = newName.Substring(0, newName.LastIndexOf("（当前项目）"));
                    oldPath = loadProj[nowProjName];
                    oldName = nowProjName;
                    userProject = GetProjectPara(oldPath, nowProjName);
                }
                else
                {
                    oldPath=loadProj[changeItemName];
                    oldName = changeItemName;
                    userProject=GetProjectPara(oldPath,changeItemName);
                }
                newpath = oldPath.Substring(0, oldPath.LastIndexOf("\\"));
                newpath = newpath + "\\" + newName;
                userProject.ProjectName = newName;
                userProject.ProjectPath = newpath;
                if(loadProj.ContainsKey(newName))
                {
                    tempTextBlock.Text = changeItemName;
                    //MyComputer.FileSystem.RenameDirectory(newpath, oldPath);
                    TIOFPSS.Resources.MessageBoxX.Warning("重命名冲突！", this.Parent as Window);
                    return;
                }

                Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
                if (System.IO.Directory.Exists(oldPath) && !System.IO.Directory.Exists(newpath))
                {
                    try
                    {
                        //int i = 1;
                        //string[] sDirectories = Directory.GetDirectories(oldPath);
                        //foreach (string sDirectory in sDirectories)
                        //{
                        //    string sDirectoryName = Path.GetFileName(sDirectory);
                        //    string sNewDirectoryName = string.Format(newpath, i++);
                        //    string sNewDirectory = Path.Combine(oldPath, sNewDirectoryName);
                        //    Directory.Move(sDirectory, sNewDirectory);
                        //}
                        
                        //System.IO.Directory.Move(oldPath, newpath);

                        MyComputer.FileSystem.RenameDirectory(oldPath, newName);
                        if (UpdateDB(userProject, oldPath))
                        {
                            TIOFPSS.Resources.MessageBoxX.Info("保存成功！", this.Parent as Window);
                            //changeItemName = null;
                        }
                        else
                        {
                            tempTextBlock.Text = changeItemName;
                            MyComputer.FileSystem.RenameDirectory(newpath,oldName);
                            TIOFPSS.Resources.MessageBoxX.Warning("重命名不合法！", this.Parent as Window);
                            return;
                        }
                    }
                    catch
                    {
                        tempTextBlock.Text = changeItemName;
                        //MyComputer.FileSystem.RenameDirectory(newpath, oldPath);
                        TIOFPSS.Resources.MessageBoxX.Warning("重命名出错！", this.Parent as Window);
                        return;
                    }
                    if (changeItemName.Contains("（当前项目）"))
                    {
                        loadProj.Remove(nowProjName);
                        nowProjName = newName;
                        loadProj.Add(newName, newpath);
                    }
                    else
                    {
                        loadProj.Remove(changeItemName);
                        loadProj.Add(newName, newpath);
                        //改的哪个
                    }
                    foreach (var paneItem in DocumentPane.Children)
                    {
                        if (paneItem.Title == "项目参数")
                        {
                            paneItem.Content = new TIOFPSS.Dialog.InputPara(loadProj[nowProjName], nowProjName);
                            paneItem.IsActive = true;
                            paneItem.IsSelected = true;
                            //paneItem.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                            //;
                            //break;
                        }
                        if (paneItem.Title == "分析结果")
                        {
                            string path = loadProj[nowProjName] + "\\tempData";
                            paneItem.Content = new TIOFPSS.Dialog.ViewResult(nowProjName, path);
                            paneItem.IsActive = true;
                        }
                    }
                }
                else
                {
                    tempTextBlock.Text = changeItemName;
                    //MyComputer.FileSystem.RenameDirectory(newpath, oldPath);
                    TIOFPSS.Resources.MessageBoxX.Warning("重命名冲突！", this.Parent as Window);
                    return;
                }






                //foreach (var item in DocumentPane.Children)
                //{
                //    if (item.Title == "项目参数")
                //    {
                //        UserProject userProject = new UserProject();
                //        TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
                //        ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);

                //        userProject = tempPara.UserProject;
                //        userProject.ProjectName = newName;
                //        userProject.ProjectPath = loadProj[newName];

                //        tempPara.UserProject = userProject;
                //        //tempPara.UserProject.ProjectName = newName;
                //        //tempPara.UserProject.ProjectPath = loadProj[newName];

                
                //        if (UpdateDB(tempPara.UserProject, oldPath))
                //        {
                //            TIOFPSS.Resources.MessageBoxX.Info("保存成功！", this.Parent as Window);
                //            //changeItemName = null;
                //            break;
                //        }
                //        else
                //        {
                //            tempTextBlock.Text = changeItemName;
                //            TIOFPSS.Resources.MessageBoxX.Warning("重命名不合法！", this.Parent as Window);
                //            return;
                //        }
                //    }
                //}


            }
        }
        string changeItemName = null;
        private void OnReNameProjClick(object sender, RoutedEventArgs e)
        {
            var treeView = treeView1;

            if (treeView == null)
            {
                return;
            }
            var item = treeView.SelectedItem as TIOFPSS.ViewModels.TreeViewData.TreeNode;
            if (item == null)
            {
                return;
            }
            string itemName=null;

            changeItemName = item.Label;

            if (item.Level == 1)
            {
                
                itemName= item.Label;
                if (itemName.Equals(nowProjName + "（当前项目）"))
                {
                    itemName = itemName.Substring(0, itemName.LastIndexOf("（当前项目）"));
                }
                //TIOFPSS.ViewModels.TreeViewData.update(loadProj[itemName] + "\\project", itemName);
            }
            
            //获取在TreeView.ItemTemplate中定义的TextBox控件
            //System.Windows.Controls.TextBox tempTextBox = new System.Windows.Controls.TextBox();
            tempTextBox = FindVisualChild<System.Windows.Controls.TextBox>(itemTemp as DependencyObject);
            //设置该TextBox的Visibility 属性为Visible
            tempTextBox.Visibility = Visibility.Visible;
            tempTextBox.Focus();
            tempTextBox.Select(0, itemName.Length);

            tempTextBlock = FindVisualChild<System.Windows.Controls.TextBlock>(itemTemp as DependencyObject);
            tempTextBlock.Visibility = Visibility.Collapsed;
        }
         private void  OntbTextChange(object sender, EventArgs e)
        {
            //tempTextBox.Width = tempTextBox.Text.Length * 10;
        }

       
        private void OnUpdateProjClick(object sender, RoutedEventArgs e)
        {
            var treeView = treeView1;

            if (treeView == null)
            {
                return;
            }


            var item = treeView.SelectedItem as TIOFPSS.ViewModels.TreeViewData.TreeNode;
            if (item == null)
            {
                return;
            }

            if (item.Level == 1)
            {
                string itemName = item.Label;
                if (itemName.Equals(nowProjName + "（当前项目）"))
                {
                    itemName = itemName.Substring(0, itemName.LastIndexOf("（当前项目）"));
                }
                if (!System.IO.File.Exists(loadProj[itemName] + "\\project\\参数文件\\parameter.xml"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("xml文件读取出错！");
                    return;
                }
                TIOFPSS.ViewModels.TreeViewData.update(loadProj[itemName]+"\\project",itemName);
            }
        }

        private void OnRemoveProjClick(object sender, RoutedEventArgs e)
        {
            var treeView = treeView1;

            if (treeView == null)
            {
                return;
            }


            var item = treeView.SelectedItem as TIOFPSS.ViewModels.TreeViewData.TreeNode;
            if (item == null)
            {
                return;
            }

            if (item.Level == 1)
            {
                string itemName=item.Label;
                if (itemName.Equals(nowProjName + "（当前项目）"))
                {
                    nowProjName = null;
                    itemName = itemName.Substring(0, itemName.LastIndexOf("（当前项目）"));

                    foreach (var paneItem in DocumentPane.Children)
                    {
                        if (paneItem.Title == "项目参数")
                        {
                            paneItem.Close();
                            //;
                            break;
                        }
                    }
                    foreach (var paneItem in DocumentPane.Children)
                    {
                        if (paneItem.Title == "分析结果")
                        {
                            paneItem.Close();
                            break;
                        }
                    }
                    btnFalse();
                }
                loadProj.Remove(itemName);
                if(loadProj.Count==0)
                {
                    btnFalse();
                }
                TIOFPSS.ViewModels.TreeViewData.delete(item.Label);


            }
        }
        private void OnTreeDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var treeView = sender as TreeView;

            if (treeView == null)
            {
                return;
            }


            var item = treeView.SelectedItem as TIOFPSS.ViewModels.TreeViewData.TreeNode;
            if (item == null)
            {
                return;
            }

            if (item.Level == 1)
            {
                //TIOFPSS.Resources.MessageBoxX.Warning(item.Label);
                if (item.Label.Contains("（当前项目）"))
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("已经是当前项目", this.Parent as Window);
                }
                else
                {
                    TIOFPSS.ViewModels.TreeViewData.clear(nowProjName);
                    nowProjName = item.Label;

                    item.Label += "（当前项目）";
                    foreach (var paneItem in DocumentPane.Children)
                    {
                        if (paneItem.Title == "项目参数")
                        {
                            paneItem.Content = new TIOFPSS.Dialog.InputPara(loadProj[nowProjName], nowProjName);
                            paneItem.IsActive = true;
                            paneItem.IsSelected = true;
                            //paneItem.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                            //;
                            //break;
                        }
                        if(paneItem.Title == "分析结果")
                        {
                            string path = loadProj[nowProjName] + "\\tempData";
                            paneItem.Content = new TIOFPSS.Dialog.ViewResult(nowProjName, path);
                            paneItem.IsActive = true;
                        }
                    }

                    btnTrue();
                }

            }
        }

        //参数输入
        private void OnParaViewClick(object sender, RoutedEventArgs e)
        {
            //this.InRibbonGallery.Enlarge();
            //Window1 aw = new Window1();
            //aw.ShowDialog();
            if (nowProjName != null)
            {
                bool hasParaPane = false;
                foreach (var paneItem in DocumentPane.Children)
                {
                    if (paneItem.Title == "项目参数")
                    {
                        paneItem.Content = new TIOFPSS.Dialog.InputPara(loadProj[nowProjName], nowProjName);
                        paneItem.IsActive = true;
                        hasParaPane = true;
                        paneItem.IsSelected = true;
                        //paneItem.Closing
                        paneItem.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                        //;
                        break;
                    }
                }
                if (hasParaPane == false)
                {
                    Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
                    document.Title = "项目参数";
                    document.Content = new TIOFPSS.Dialog.InputPara(loadProj[nowProjName], nowProjName);
                    document.IsActive = true;
                    document.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(OnCloseParaView);
                    DocumentPane.Children.Add(document);
                    //;
                }

            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择项目！", this.Parent as Window);
            }
        }
        private void OnCloseParaView(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LayoutContent item = sender as LayoutContent;
            DB.UserProject proj = new UserProject();
            ViewModels.ParaViewModel Para = new ViewModels.ParaViewModel(loadProj[nowProjName], nowProjName);
            List<string> viewPara = new List<string>();
            List<string> xmlPara = new List<string>();
            xmlPara = Para.loopGetValue();
            proj = Para.UserProject;
            //foreach (var item in DocumentPane.Children)
            //{
                if (item.Title == "项目参数")
                {
                    TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
                    ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);
                    viewPara = tempPara.loopGetValue();
                    for (int i = 0; i < xmlPara.Count; i++)
                    {
                        if (xmlPara[i] != viewPara[i])
                        {
                            if(TIOFPSS.Resources.MessageBoxX.Question("还有修改的参数未保存，确定退出？", this.Parent as Window))
                            {
                                e.Cancel = false;
                            }
                            else
                            {
                                e.Cancel = true;
                            }

                        }
                    }
                    //proj = tempPara.UserProject;
                    //break;
                }
            //}
        }
        //保存参数
        private void OnSubmitClick(object sender, RoutedEventArgs e)
        {
            bool success = false;
            if(nowProjName!=null)
            {
                foreach (var item in DocumentPane.Children)
                {
                    if (item.IsSelected == true && item.Title == "项目参数")
                    {
                        if (TIOFPSS.Resources.MessageBoxX.Question("修改参数将删除以前的分析结果，确定修改？") == false)
                        {
                            return;
                        }
                        
                        string pathString = loadProj[nowProjName];
                        try
                        {
                            System.IO.Directory.Delete(pathString+"\\", true);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("保存失败！");
                            return;
                        }
                        //删除原有项目
                        string projectPath = System.IO.Path.Combine(pathString, "project");
                        string tempDataPath = System.IO.Path.Combine(pathString, "tempData");
                        if (!System.IO.Directory.Exists(pathString))//查看项目是否存在
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                            System.IO.Directory.CreateDirectory(tempDataPath);
                            System.IO.Directory.CreateDirectory(projectPath);
                        }
                        else
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("项目已存在！", this.Parent as Window);
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

                        string sourcePath = null;
                        string sourceFile = null;
                        sourcePath = System.Windows.Forms.Application.StartupPath;
                        sourceFile = System.IO.Path.Combine(sourcePath, "paraTemple.xml");
                        string targetPath = System.IO.Path.Combine(projectPath, Helper.str_FloderPath[0]);
                        string destFile = System.IO.Path.Combine(targetPath, "parameter.xml");
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
                            TIOFPSS.Resources.MessageBoxX.Error("参数文件创建出错！");
                            return;
                        }

                        TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
                        ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);
                        tempPara.saveValue();

                        if (UpdateDB(tempPara.UserProject, null))
                        {
                            TIOFPSS.Resources.MessageBoxX.Info("保存成功！");
                            success = true;
                            break;
                        }
                    }
                }
                if (!success)
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("请打开项目参数界面！", this.Parent as Window);
                }
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择当前项目！", this.Parent as Window);
            }


        }
        private bool UpdateDB(UserProject userProject,string oldPath)
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            if(bll.Update(userProject,oldPath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //查看3d模型
        private void OnView3DModelClick(object sender, RoutedEventArgs e)
        {
            //
            if (nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                if(!System.IO.File.Exists(startPath+"\\Show3DModel.exe"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到Show3DModel.exe！", this.Parent as Window);
                    return;
                }
                if (!System.IO.File.Exists(startPath + "\\proe\\frictionplate.prt"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到frictionplate.prt！", this.Parent as Window);
                    return;
                }

                string start = "\"" + startPath + "\\proe\\frictionplate.prt" + "\"";
                string proePath = "\"" + Configure.IniReadValue("system", "CreoPath") + "\\parametric.bat" + "\"";
                string para = proj.YaLiJiao + " " +proj.ChiShu + " " +proj.WaiJing + " "
                         +proj.KongJing + " " +proj.NgHouDu + " " +proj.MoShu + " "
                         +proj.NgGFXCDGC + " " +proj.NgChiDingGao + " " +proj.NgChiGenGao + " "
                         +proj.McpChiGenYuanJiao + " " +proj.McpHouDu + " " +proj.MccHouDu + " "
                         +proj.MccJingKuan + " " +proj.McpGFXDGC + " " +proj.McpChiDingGao + " "
                         + proj.McpChiGenGao + " " + proj.NgChiGenYuanJiao + " " + proePath+" "+start;

                string workPath = proj.ProjectPath + "\\project\\参数文件";
                    Process p = new Process();

                    p.StartInfo.FileName = @"Show3DModel.exe";           //程序名
                    p.StartInfo.WorkingDirectory = workPath;
                    p.StartInfo.Arguments = para;    //程式执行参数
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    btnView3DModel.IsEnabled = false;
                    try
                    {
                        WaitingBox.Show(() =>
                        {
                            p.Start();
                            p.WaitForExit();
                            
                        }, "正在生成模型，请稍后...");
                        if(p.ExitCode != 0)
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("3D模型生成失败！", this.Parent as Window);
                        }
                        else
                        {
                            TIOFPSS.Resources.MessageBoxX.Info("3D模型生成成功！", this.Parent as Window);
                        }
                        
                    }
                    catch
                    {
                        TIOFPSS.Resources.MessageBoxX.Error("3D模型生成失败！", this.Parent as Window);
                    }
                    btnView3DModel.IsEnabled = true;
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择项目！", this.Parent as Window);
            }
        }
        //添加库数据
        private void OnSaveParaClick(object sender, RoutedEventArgs e)
        {
            bool success = false;
            foreach (var item in DocumentPane.Children)
            {
                if (item.IsSelected == true && item.Title == "项目参数")
                {

                    TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
                    ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);
                    SavePara dlgSavePara = new SavePara(tempPara.UserProject);
                    dlgSavePara.ShowDialog();
                    success = true;
                    break;
                }
                
            }
            if (!success)
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请打开项目参数界面！", this.Parent as Window);
            }


        }

        //应用数据库
        private void OnApplyLibClick(object sender, RoutedEventArgs e)
        {
            if(nowProjName!=null)
            {
                bool success = false;
                foreach (var item in DocumentPane.Children)
                {
                    if (item.IsSelected == true && item.Title == "项目参数")
                    {
                        paraProperty aw = new paraProperty();
                        aw.Title = "参数库";
                        aw.CallBackMethod = ApplyLib;
                        aw.ShowDialog();
                        success = true;
                        break;
                    }
                }
                if (!success)
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("请打开项目参数界面！", this.Parent as Window);
                }

            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择项目！", this.Parent as Window);
            }

            
        }
        private void OnAnalysisMonitorClick(object sender, RoutedEventArgs e)
        {
            AddMonitor();
        }
        
        private void ApplyLib(List<string> para)
        {
            foreach (var item in DocumentPane.Children)
            {
                if (item.IsSelected == true && item.Title == "项目参数")
                {

                    TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
                    ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);
                    tempPara.loopSetLibValue(para);
                }
            }
        }
        void AddMonitor()
        {
            if (anchorable == null)
            {
                try
                {
                    LayoutAnchorablePane pane = new LayoutAnchorablePane();
                    anchorable = new LayoutAnchorable();
                    anchorable.Title = "分析监视";
                    anchorable.Content = new AnalysisMonitor();
                    pane.Children.Add(anchorable);
                    LeftAnchorableGroup.Children.Add(pane);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "[MainWindow][miAnchorVerticalPane_Click_1]");
                }
            }
            else
            {
                try
                {
                    LayoutAnchorablePane pane = new LayoutAnchorablePane();
                    pane.Children.Add(anchorable);
                    LeftAnchorableGroup.Children.Add(pane);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "[MainWindow][miAnchorVerticalPane_Click_1]");
                }
            }
        }
        void UpdateResultPane()
        {
            foreach (var item in DocumentPane.Children)
            {
                if (item.Title == "分析结果")
                {
                    string path = loadProj[nowProjName] + "\\tempData";

                    item.Content = new TIOFPSS.Dialog.ViewResult(nowProjName, path);
                    break;
                }
            }
        }
        UserProject GetProjectPara(string projPath,string projName)
        {
            DB.UserProject proj = new UserProject();
            ViewModels.ParaViewModel Para = new ViewModels.ParaViewModel(projPath, projName);
            List<string> viewPara = new List<string>();
            List<string> xmlPara = new List<string>();
            xmlPara = Para.loopGetValue();
            proj = Para.UserProject;
            return proj;
        }
        UserProject GetNowProjectPara()
        {
            DB.UserProject proj = new UserProject(); 


            ViewModels.ParaViewModel Para = new ViewModels.ParaViewModel(loadProj[nowProjName], nowProjName);
            List<string> viewPara = new List<string>();
            List<string> xmlPara = new List<string>();
            xmlPara = Para.loopGetValue();
            proj =Para.UserProject;
            foreach (var item in DocumentPane.Children)
            {
                if (item.Title == "项目参数")
                {
                    TIOFPSS.Dialog.InputPara temp = ((TIOFPSS.Dialog.InputPara)(item.Content));
                    ViewModels.ParaViewModel tempPara = (ViewModels.ParaViewModel)(temp.DataContext);
                    viewPara = tempPara.loopGetValue();
                    for (int i = 0; i < xmlPara.Count;i++ )
                    {
                        if(xmlPara[i]!=viewPara[i])
                        {
                            TIOFPSS.Resources.MessageBoxX.Warning("修改的参数未保存！", this.Parent as Window);
                            return null;
                        }
                    }
                    //proj = tempPara.UserProject;
                    break;
                }
            }
            return proj;
        }
        private void OnWuJieJuWuChaClick(object sender, RoutedEventArgs e)
        {
            if(nowProjName!=null)
            {
                DB.UserProject proj = new UserProject();

                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                if (!System.IO.File.Exists(startPath + "\\main_program_v1.dll"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到main_program_v1.dll！", this.Parent as Window);
                    return;
                }

                double[] para = new double[54];
                para[0] = Convert.ToDouble(proj.TingZhiShiJIan);//0.5   停止时间  1
                para[1] = Convert.ToDouble(proj.NgChuShiJiaoWeiYi);//0  内毂初始角位移 0
                para[2] = Convert.ToDouble(proj.McpChuShiJiaoWeiYi);//0 摩擦片初始角位移 0
                para[3] = Convert.ToDouble(proj.NgChuShiSuDu);//0   內毂初始速度   0
                para[4] = 0;//没用
                para[5] = Convert.ToDouble(proj.YaLiJiao);//20   压力角  20   
                para[6] = Convert.ToDouble(proj.FanTanXiShu);//0.8   回弹系数  0.8
                para[7] = Convert.ToDouble(proj.ChiCeJianXi);//0.0014   齿侧间隙  0.25
                para[8] = Convert.ToDouble(proj.PianXinJu);//0  偏心距  0
                para[9] = Convert.ToDouble(proj.NgTXML);//205  內毂弹性模量  210
                para[10] = Convert.ToDouble(proj.NgBSB);//0.3  內毂泊松比  0.3
                para[11] = Convert.ToDouble(proj.QiDongShiJian);//0.01  启动时  0.01
                para[12] = Convert.ToDouble(proj.ZengSuShiJian);//0.11  增速时间  0.05
                para[13] = Convert.ToDouble(proj.WenDingShiJian);//0.25  稳定时间 0.1
                para[14] = Convert.ToDouble(proj.NgZhuanSu);//1598  內毂转速 0
                para[15] = Convert.ToDouble(proj.NgZhenFu);//5.702  內毂振幅 3.7
                para[16] = 0.0;//0    t21 t22 t23 M2 A2
                para[17] = 0.0;//0
                para[18] = 0.0;//0
                para[19] = 0.0;//0                                                                                                                                                                                                                                     
                para[20] = 0.0;//0 
                para[21] = Convert.ToDouble(proj.NgZhuanDongGuanLiang);//0.05134       ！！！内毂转动惯量
                para[22] = Convert.ToDouble(proj.McpZhuanDongGuanLiang);//0.54;//0.054     ！！！芯板转动惯量
                para[23] = Convert.ToDouble(proj.ChiShu);//122 齿数 4
                para[24] = Convert.ToDouble(proj.MoShu);//3  模数    10
                para[25] = Convert.ToDouble(proj.ShiJiJieChuChiShu);//122  实际接触齿数 2
                para[26] = Convert.ToDouble(proj.JieGouZuNi);//0  结构阻尼  0
                para[27] = Convert.ToDouble(proj.NgZhenPin);//160  內毂振频 25
                para[28] = 0.0;///0
                //para[29]=Convert.ToDouble(proj.xinBanTanXingMoLiang);//0.0;///
                para[30] = Convert.ToDouble(proj.McpBSB);//0.3  芯板泊松比  0.3
                para[31] = Convert.ToDouble(proj.JieJuZuiDaWuCha);///0  节距最大误差 0
                para[32] = Convert.ToDouble(proj.JieJuZuiXiaoWuCha);//0  节距最小误差 0
                para[33] = 4;//4  齿宽
                //para[34]=Convert.ToDouble(proj.zuNiCaoChangDu);//0  阻尼槽长度   0 
                //para[35]=Convert.ToDouble(proj.zuNiCaoKuangDu);//0  阻尼槽宽度 0
                para[36] = Convert.ToDouble(proj.WenDu);//25  温度  25
                para[37] = Convert.ToDouble(proj.YouMoHouDu);//0  油膜厚度   0.025


                //para[38]=Convert.ToDouble(proj.chiGenGao);//1.25  齿根高    0.0821  芯板转动惯量  mei yong
                //para[39]=Convert.ToDouble(proj.chiDingGao);//1 齿顶高         0.37    内毂转动惯量
                //字体属性设置
                para[40] = 0.0;//0坐标轴字体RGB
                para[41] = 0.0;//0
                para[42] = 0.0;//1projectPath
                para[43] = 0.0;//0 绘图颜色
                para[44] = 1.0;//1
                para[45] = 0.0;//0
                para[46] = 1.0;//1
                para[47] = 12.0;//12
                para[48] = 1.0;//1
                para[49] = Convert.ToDouble(proj.YouYeNianDu);
                para[50] = Convert.ToDouble(proj.JieChuQuZhouXiangChangDu);
                para[51] = Convert.ToDouble(proj.JieChuQuJinXiangChuangDu);  //接触区径向长度
                para[52] = 0.748;  //端泄系数
                para[53] = 0;  //端泄系数

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
                string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

                if (!DeleteDongLiXueResult(proj.ProjectPath))
                {
                    return;
                }

                Analysis.WuJieJuWuChaThreadParamter a = new Analysis.WuJieJuWuChaThreadParamter(path, proPath, para);
                Analysis.WuJieJuWuChaFenXiThread t = new Analysis.WuJieJuWuChaFenXiThread(a);
                t.CallBackMethod = WuJieJuWuChaFenXiFinish;
                btnwjjwc.IsEnabled = false;
                btnyjjwc.IsEnabled = false;
                AddMonitor();
                t.Start();
                ((AnalysisMonitor)anchorable.Content).dongLiXue_start("无节距误差分析");
            }


        }
        private void WuJieJuWuChaFenXiFinish(bool finish)
        {
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).dongLiXue_stop("无节距误差分析");
                //win2.dongLiXue_stop();
                UpdateResultPane();
                btnwjjwc.IsEnabled = true;
                btnyjjwc.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Info("无节距误差分析完成！",this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).dongLiXue_stop("无节距误差分析");
                btnwjjwc.IsEnabled = true;
                btnyjjwc.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Error("无节距误差分析失败！", this.Parent as Window);
            }
        }
        private void OnZaoshengFenXi(object sender, RoutedEventArgs e)
        {
            if(nowProjName!=null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                if (!System.IO.File.Exists(startPath + "\\noise.dll"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到noise.dll！", this.Parent as Window);
                    return;
                }

                string tempDataPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");
                string dynmicMat = System.IO.Path.Combine(tempDataPath, "冲击动力学分析结果\\Dynamic.mat");

                if (!System.IO.File.Exists(dynmicMat))
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("还未进行冲击动力学分析！", this.Parent as Window);
                    return;
                }
                string picPath = tempDataPath;
                double wendingshijian = Convert.ToDouble(proj.WenDingShiJian);
                Analysis.ZaoShengFenXiThread t = new Analysis.ZaoShengFenXiThread(new Analysis.NoiseThreadParamter(picPath, dynmicMat, wendingshijian));



                t.CallBackMethod = ZaoShengFenXiFinish;
                
                t.Start();

                AddMonitor();
                ((AnalysisMonitor)anchorable.Content).zaoSheng_start();
                btnzsfx.IsEnabled = false;
            }
        }
        private void ZaoShengFenXiFinish(bool finish)
        {
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).zaoSheng_stop();
                UpdateResultPane();
                btnzsfx.IsEnabled = true; ;
                TIOFPSS.Resources.MessageBoxX.Info("噪声分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).zaoSheng_stop();
                TIOFPSS.Resources.MessageBoxX.Error("噪声分析失败！", this.Parent as Window);
            }
        }
        private bool DeleteDongLiXueResult(string path)
        {
            string tempPath = System.IO.Path.Combine(path, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(path, "project\\");//+"\\";
            if(System.IO.File.Exists(proPath+"冲击动力学分析文件\\Dynamic.mat"))
            {
                System.IO.File.Delete(proPath + "冲击动力学分析文件\\Dynamic.mat");
            }
            

            if(System.IO.Directory.Exists(tempPath+"冲击动力学分析结果"))
            {
                try
                {
                    System.IO.Directory.Delete(tempPath + "冲击动力学分析结果\\", true);
                    System.IO.Directory.CreateDirectory(tempPath + "冲击动力学分析结果");
                }
                catch
                {
                    TIOFPSS.Resources.MessageBoxX.Error("删除原结果失败！");
                    return false;
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(tempPath + "冲击动力学分析结果");
            }
            if (System.IO.File.Exists(tempPath + "ZhunDongTai\\force+.txt"))
            {
                try
                {
                    System.IO.File.Delete(tempPath + "ZhunDongTai\\force+.txt");
                }
                catch
                {
                    TIOFPSS.Resources.MessageBoxX.Error("删除原结果失败！");
                    return false;
                }
            }
            if (System.IO.File.Exists(tempPath + "ZhunDongTai\\force-.txt"))
            {
                try
                {
                    System.IO.File.Delete(tempPath + "ZhunDongTai\\force-.txt");
                }
                catch
                {
                    TIOFPSS.Resources.MessageBoxX.Error("删除原结果失败！");
                    return false;
                }
            }
            return true;

        }

        private void OnYouJieJuWuChaClick(object sender, RoutedEventArgs e)
        {
            if (nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                if (!System.IO.File.Exists(startPath + "\\pitch.dll"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到pitch.dll！", this.Parent as Window);
                    return;
                }
                proj = GetNowProjectPara();
                if (proj == null)
                    return;

               
                double[] para = new double[54];
                para[0] = Convert.ToDouble(proj.TingZhiShiJIan);//0.5   停止时间  1
                para[1] = Convert.ToDouble(proj.NgChuShiJiaoWeiYi);//0  内毂初始角位移 0
                para[2] = Convert.ToDouble(proj.McpChuShiJiaoWeiYi);//0 摩擦片初始角位移 0
                para[3] = Convert.ToDouble(proj.NgChuShiSuDu);//0   內毂初始速度   0
                para[4] = 0;//没用
                para[5] = Convert.ToDouble(proj.YaLiJiao);//20   压力角  20   
                para[6] = Convert.ToDouble(proj.FanTanXiShu);//0.8   回弹系数  0.8
                para[7] = Convert.ToDouble(proj.ChiCeJianXi);//0.0014   齿侧间隙  0.25
                para[8] = Convert.ToDouble(proj.PianXinJu);//0  偏心距  0
                para[9] = Convert.ToDouble(proj.NgTXML);//205  內毂弹性模量  210
                para[10] = Convert.ToDouble(proj.NgBSB);//0.3  內毂泊松比  0.3
                para[11] = Convert.ToDouble(proj.QiDongShiJian);//0.01  启动时  0.01
                para[12] = Convert.ToDouble(proj.ZengSuShiJian);//0.11  增速时间  0.05
                para[13] = Convert.ToDouble(proj.WenDingShiJian);//0.25  稳定时间 0.1
                para[14] = Convert.ToDouble(proj.NgZhuanSu);//1598  內毂转速 0
                para[15] = Convert.ToDouble(proj.NgZhenFu);//5.702  內毂振幅 3.7
                para[16] = 0.0;//0    t21 t22 t23 M2 A2
                para[17] = 0.0;//0
                para[18] = 0.0;//0
                para[19] = 0.0;//0                                                                                                                                                                                                                                     
                para[20] = 0.0;//0 
                para[21] = Convert.ToDouble(proj.NgZhuanDongGuanLiang);//0.05134       ！！！内毂转动惯量
                para[22] = Convert.ToDouble(proj.McpZhuanDongGuanLiang);//0.54;//0.054     ！！！芯板转动惯量
                para[23] = Convert.ToDouble(proj.ChiShu);//122 齿数 4
                para[24] = Convert.ToDouble(proj.MoShu);//3  模数    10
                para[25] = Convert.ToDouble(proj.ShiJiJieChuChiShu);//122  实际接触齿数 2
                para[26] = Convert.ToDouble(proj.JieGouZuNi);//0  结构阻尼  0
                para[27] = Convert.ToDouble(proj.NgZhenPin);//160  內毂振频 25
                para[28] = 0.0;///0
                para[29] = 0;//0.0;///
                para[30] = Convert.ToDouble(proj.McpBSB);//0.3  芯板泊松比  0.3
                para[31] = Convert.ToDouble(proj.JieJuZuiDaWuCha);///0  节距最大误差 0
                para[32] = Convert.ToDouble(proj.JieJuZuiXiaoWuCha);//0  节距最小误差 0
                para[33] = Convert.ToDouble(proj.McpHouDu);//4  齿宽
                para[34] = Convert.ToDouble(proj.ZuNiCaoChang);//0  阻尼槽长度   0 
                para[35] = Convert.ToDouble(proj.ZuNiCaoKuan);//0  阻尼槽宽度 0
                para[36] = Convert.ToDouble(proj.WenDu);//25  温度  25
                para[37] = Convert.ToDouble(proj.YouMoHouDu);//0  油膜厚度   0.025


                //para[38]=Convert.ToDouble(proj.chiGenGao);//1.25  齿根高    0.0821  芯板转动惯量  mei yong
                //para[39]=Convert.ToDouble(proj.chiDingGao);//1 齿顶高         0.37    内毂转动惯量
                //字体属性设置
                para[40] = 0.0;//0坐标轴字体RGB
                para[41] = 0.0;//0
                para[42] = 0.0;//1projectPath
                para[43] = 0.0;//0 绘图颜色
                para[44] = 1.0;//1
                para[45] = 0.0;//0
                para[46] = 1.0;//1
                para[47] = 12.0;//12
                para[48] = 1.0;//1
                para[49] = Convert.ToDouble(proj.YouYeNianDu);
                para[50] = Convert.ToDouble(proj.JieChuQuZhouXiangChangDu);
                para[51] = Convert.ToDouble(proj.JieChuQuJinXiangChuangDu);  //接触区径向长度
                if (para[50] > para[51])
                {
                    double tp = para[50];
                    para[50] = para[51];
                    para[51] = tp;
                }
                para[52] = 0.748;  //端泄系数
                para[53] = Convert.ToDouble(proj.ZuNiCaoBanJing);  //阻尼槽半径

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
                string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

                if(!DeleteDongLiXueResult(proj.ProjectPath))
                {
                    return;
                }

                Analysis.WuJieJuWuChaThreadParamter a = new Analysis.WuJieJuWuChaThreadParamter(path, proPath, para);
                Analysis.YouJieJuWuChaFenXiThread t = new Analysis.YouJieJuWuChaFenXiThread(a);
                t.CallBackMethod = YouJieJuWuChaFenXiFinish;
                btnwjjwc.IsEnabled = false;
                btnyjjwc.IsEnabled = false;
                AddMonitor();
                
                t.Start();

                ((AnalysisMonitor)anchorable.Content).dongLiXue_start("有节距误差分析");
                //if (t._Thread.ThreadState == System.Threading.ThreadState.Stopped)
                //{
                //    MessageBox.Show("线程结束");
                //}
            }

        }
        private void YouJieJuWuChaFenXiFinish(bool finish)
        {
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).dongLiXue_stop("有节距误差分析");
                UpdateResultPane();

                btnwjjwc.IsEnabled = true;
                btnyjjwc.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Info("有节距误差分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).dongLiXue_stop("有节距误差分析");

                btnwjjwc.IsEnabled = true;
                btnyjjwc.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Error("有节距误差分析失败！", this.Parent as Window);
            }


        }
        string startPath=System.Windows.Forms.Application.StartupPath;
        private bool ModifyParaPath(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到" + fileName, this.Parent as Window);
                return false;
            }
            List<string> fileContent = new List<string>();
            int i = 0;
            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName, Encoding.GetEncoding("GB2312")))
            {              
                string line;                
                while((line=file.ReadLine())!=null)
                {
                    i++;
                    if(i==2)
                    {
                        line="/INPUT,'parameter','txt','"+startPath+"\\APDLcode\\"+"',, 0   !路径";
                    }
                    fileContent.Add(line);
                }             
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName,false,Encoding.GetEncoding("GB2312")))
            {
                foreach(string line in fileContent)
                {
                    file.WriteLine(line);
                }                
            }
            return true;
        }

        private void OnJingTaiQiangDuFenXiClick(object sender, RoutedEventArgs e)
        {
            Dialog.JingTaiQiangDuFenXi aw = new Dialog.JingTaiQiangDuFenXi();
            aw.CallBackMethod = JingTaiQiangDuFenXiAnalysis;
            aw.ShowDialog();
        }
        private void JingTaiQiangDuFenXiAnalysis(List<string> para)
        {
            if(para!=null&&nowProjName!=null)
            {
                DB.UserProject proj = new UserProject();

                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string chongjili = para[0];
                string resName =para[1];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\ShaoChi");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";

                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }

                string []dataname={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","偏心量"};
	            string [] filename={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"pxl="+proj.PianXinJu};
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }
                    temp = "n3=" + proj.ShiJiJieChuChiShu + "   !实际接触齿数";
                    file.WriteLine(temp);
                    temp = "Fc=" + chongjili + "*1000/n3/rd1    !内毂转矩";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\ShaoChi.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }
                string proPath = proj.ProjectPath + "\\" + Helper.str_FloderPath[6];
                Analysis.XT_jiangTaiQiangDuThreadParamter threadPara = new Analysis.XT_jiangTaiQiangDuThreadParamter(null, path, apdlfilepath, proPath);
                Analysis.XT_jiangTaiQiangDuThread t = new Analysis.XT_jiangTaiQiangDuThread(threadPara);
                //Window2.dongLiXue_start();
                t.CallBackMethod = JingTaiQiangDuFenXiFinish;
                AddMonitor();


                t.Start();
                ((AnalysisMonitor)anchorable.Content).JingTaiQiangDuFenXi_start();
                btnJingTaiQiangDuFenXi.IsEnabled = false;
            }
        }
        private void JingTaiQiangDuFenXiFinish(bool finish)
        {
            btnJingTaiQiangDuFenXi.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).JingTaiQiangDuFenXi_stop();
                UpdateResultPane();
                TIOFPSS.Resources.MessageBoxX.Info("少齿当量静态强度分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).JingTaiQiangDuFenXi_stop();
                TIOFPSS.Resources.MessageBoxX.Error("少齿当量静态强度分析失败！", this.Parent as Window);
            }
        }




        public void OnDuCengShaoChiFenXiClick(object sender, RoutedEventArgs e)
        {
            Dialog.DuCengShaoChiFenXi aw = new Dialog.DuCengShaoChiFenXi();
            aw.CallBackMethod = DuCengShaoChiDangLiangAnalysis;
            aw.ShowDialog();
        }
        private void DuCengShaoChiDangLiangAnalysis(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();

                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string chongjili = para[0];
                string resName = para[1];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\DuCeng");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";

                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }

                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","偏心量"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"pxl="+proj.PianXinJu};

                string ducenghoudu = proj.DuCengHouDu;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }
                    temp = "dchd=" + ducenghoudu + "   !镀层厚度";
                    file.WriteLine(temp);
                    temp = "n3=" + proj.ShiJiJieChuChiShu + "   !实际接触齿数";
                    file.WriteLine(temp);
                    temp = "Fc=" + chongjili + "*1000/n3/rd1    !内毂转矩";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\DuCeng.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }
                Analysis.XT_DuCengShaoChiThreadParamter threadPara = new Analysis.XT_DuCengShaoChiThreadParamter(null, path, apdlfilepath, null);
                Analysis.XT_DuCengShaoChiThread t = new Analysis.XT_DuCengShaoChiThread(threadPara);
                t.CallBackMethod = DuCengFenXiFinish;
                AddMonitor();

                t.Start();
                ((AnalysisMonitor)anchorable.Content).DuCengFenXi_start();

                btnDuCengShaoChiFenXi.IsEnabled = false;
            }
        }

        private void DuCengFenXiFinish(bool finish)
        {
            btnDuCengShaoChiFenXi.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).DuCengFenXi_stop();
                UpdateResultPane();
                TIOFPSS.Resources.MessageBoxX.Info("镀层少齿当量静态强度分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).DuCengFenXi_stop();
                TIOFPSS.Resources.MessageBoxX.Error("镀层少齿当量静态强度分析失败！", this.Parent as Window);
            }
        }
        public void OnShaoChiDangLiangFenXiClick(object sender, RoutedEventArgs e)
        {
            Dialog.ShaoChiYuYingLiFenXi aw = new Dialog.ShaoChiYuYingLiFenXi();
            aw.CallBackMethod = ShaoChiYuYingLiAnalysis;
            aw.ShowDialog();
        }
        private void ShaoChiYuYingLiAnalysis(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string chongjili = para[0];
                string chiMianLi = para[1];
                string chigenLi = para[2];
                string chiDingLi = para[3];
                string resName = para[4];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\CuiHuo");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";
                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }
                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","偏心量"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"pxl="+proj.PianXinJu};

                string ducenghoudu = proj.DuCengHouDu;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }
                    temp = "tquench1=" + chigenLi + "   !淬火前温度";
                    file.WriteLine(temp);
                    temp = "tquench2=" + chiMianLi + "   !淬火后温度";
                    file.WriteLine(temp);
                    temp = "quench=" + chiDingLi + "   !淬火深度";
                    file.WriteLine(temp);

                    temp = "n3=" + proj.ShiJiJieChuChiShu + "   !实际接触齿数";
                    file.WriteLine(temp);
                    temp = "Fc=" + chongjili + "*1000/n3/rd1    !内毂转矩";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\CuiHuo.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }
                Analysis.XT_ShaoChiYuYingLiThreadParamter threadPara = new Analysis.XT_ShaoChiYuYingLiThreadParamter(null, path, apdlfilepath, null);
                Analysis.XT_ShaoChiYuYingLiThread t = new Analysis.XT_ShaoChiYuYingLiThread(threadPara);
                t.CallBackMethod = ShaoChiYuYingLiFinish;
                AddMonitor();

                t.Start();
                ((AnalysisMonitor)anchorable.Content).YuYingLiFenXi_start();

                btnShaoChiDangLiangFenXi.IsEnabled = false;
            }
        }

        private void ShaoChiYuYingLiFinish(bool finish)
        {
            btnShaoChiDangLiangFenXi.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).YuYingLiFenXi_stop();
                UpdateResultPane();
                TIOFPSS.Resources.MessageBoxX.Info("淬火少齿当量静态强度分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).YuYingLiFenXi_stop();
                TIOFPSS.Resources.MessageBoxX.Error("淬火少齿当量静态强度分析失败！", this.Parent as Window);
            }
        }
        public void OnQuanChiPianXinJiSuanClick(object sender, RoutedEventArgs e)
        {
            Dialog.QuanChiPianXinJiSuan aw = new Dialog.QuanChiPianXinJiSuan();
            aw.CallBackMethod = QuanChiPianXinJiSuan;
            aw.ShowDialog();
        }
        private void QuanChiPianXinJiSuan(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string chongjili = para[0];

                string resName = para[1];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\QuanChi");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";
                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }
                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","偏心量"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"pxl="+proj.PianXinJu};

                string ducenghoudu = proj.DuCengHouDu;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }

                    temp = "Fc=" + chongjili + "*1000/z/rd1    !内毂转矩";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\QuanChi.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }
                Analysis.XT_QuanChiPianXinThreadParamter threadPara = new Analysis.XT_QuanChiPianXinThreadParamter(null, path, apdlfilepath, null);
                Analysis.XT_QuanChiPianXinThread t = new Analysis.XT_QuanChiPianXinThread(threadPara);
                t.CallBackMethod = QuanChiPianXinJiSuanFinish;
                AddMonitor();

                t.Start();
                ((AnalysisMonitor)anchorable.Content).QuanChiPianXin_start();

                btnQuanChiPianXinJiSuan.IsEnabled = false;
            }
        }

        private void QuanChiPianXinJiSuanFinish(bool finish)
        {
            btnQuanChiPianXinJiSuan.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).QuanChiPianXin_stop();
                UpdateResultPane();
                TIOFPSS.Resources.MessageBoxX.Info("全齿静态强度分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).QuanChiPianXin_stop();
                TIOFPSS.Resources.MessageBoxX.Error("全齿静态强度分析失败！", this.Parent as Window);
            }

        }
        public void OnDongTaiFenXiClick(object sender, RoutedEventArgs e)
        {
            Dialog.DongTaiFenXi aw = new Dialog.DongTaiFenXi();
            aw.CallBackMethod = DongTaiFenXi;
            aw.ShowDialog();
        }
        private void DongTaiFenXi(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();

                proj = GetNowProjectPara();
                if (proj == null)
                    return;

                double zengsushijian = Convert.ToDouble(para[0]);
                MWNumericArray zenSuShiJian = new MWNumericArray(zengsushijian);

                double wendingshijian = Convert.ToDouble(para[1]);
                MWNumericArray wendingShiJian = new MWNumericArray(wendingshijian);
                double tingzhishijian = Convert.ToDouble(para[2]);
                MWNumericArray tingZhiShiJian = new MWNumericArray(tingzhishijian);
                double neiguzhuansu = Convert.ToDouble(proj.NgZhuanSu);
                MWNumericArray neiGuZhuanSu = new MWNumericArray(neiguzhuansu);
                double neiguzhenfu = Convert.ToDouble(proj.NgZhenFu);
                MWNumericArray neiGuZhenFu = new MWNumericArray(neiguzhenfu);
                double neiguzhenpin = Convert.ToDouble(proj.NgZhenPin);
                MWNumericArray neiGuZhenPin = new MWNumericArray(neiguzhenpin);



                string resName = para[4];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\DongTai");

                string location = tempPath + "\\";    ///////////////////////////////////////////路径如何设置
                MWCharArray locc = new MWCharArray(location);//
                try
                {
                    zsbd.ShengChengShuJuClass z = new ShengChengShuJuClass();
                    z.zsbd(zenSuShiJian, wendingShiJian, tingZhiShiJian, neiGuZhuanSu, neiGuZhenFu, neiGuZhenPin, locc);
                }
                catch
                {
                    TIOFPSS.Resources.MessageBoxX.Error("动态分析出错！");
                }///////////////////////////////////////////////////
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";
                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }
                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","偏心量"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"pxl="+proj.PianXinJu};

                string ducenghoudu = proj.DuCengHouDu;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }

                    temp = "fzsj=" + para[2]+"    !仿真时间";
                    file.WriteLine(temp);
                    temp = "MASSoNG=" + para[3] + "    !与内毂连接轴的质量";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\DongTai.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }
                Analysis.XT_DongTaiFenXiThreadParamter threadPara = new Analysis.XT_DongTaiFenXiThreadParamter(null, path, apdlfilepath, null);
                Analysis.XT_DongTaiFenXiThread t = new Analysis.XT_DongTaiFenXiThread(threadPara);
                t.CallBackMethod = DongTaiFenXiFinish;
                AddMonitor();

                t.Start();
                ((AnalysisMonitor)anchorable.Content).DongTaiFenXi_start();
                btnDongTaiFenXi.IsEnabled = false;

            }
        }
        private void DongTaiFenXiFinish(bool finish)
        {
            btnDongTaiFenXi.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).DongTaiFenXi_stop();
                UpdateResultPane();
                TIOFPSS.Resources.MessageBoxX.Info("动态分析完成！",this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).DongTaiFenXi_stop();
                TIOFPSS.Resources.MessageBoxX.Error("动态分析失败！", this.Parent as Window);
            }
        }

        public void OnDongTaiYingLiJiSuanClick(object sender, RoutedEventArgs e)
        {
            Dialog.DongTaiYingLiJiSuan aw = new Dialog.DongTaiYingLiJiSuan();
            aw.CallBackMethod = DongTaiYingLiJiSuan;
            aw.ShowDialog();
        }
        private void DongTaiYingLiJiSuan(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string resName = para[0];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\ZhunDongTai");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";
                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }
                if (!System.IO.File.Exists(startPath + "\\NIHE.dll"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到NIHE.dll", this.Parent as Window);
                    return;
                }
                string matPath = proj.ProjectPath + "\\tempData\\冲击动力学分析结果\\lengthforce+.mat";
                string matPath2 = proj.ProjectPath + "\\tempData\\冲击动力学分析结果\\lengthforce-.mat";
                if (!System.IO.File.Exists(matPath) || !System.IO.File.Exists(matPath2))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("缺少force文件");
                    return;
                }

                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","偏心量"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"pxl="+proj.PianXinJu};

                string ducenghoudu = proj.DuCengHouDu;
                //string n1, n2;//force+y与force-的行数
                //n1 = System.IO.File.ReadAllText(proj.ProjectPath + "\\tempData\\lengthforce+.mat");
                //n2 = System.IO.File.ReadAllText(proj.ProjectPath + "\\tempData\\lengthforce-.mat");

                Matrix<double> m1 = MatlabReader.Read<double>(proj.ProjectPath + "\\tempData\\冲击动力学分析结果\\lengthforce+.mat");
                Matrix<double> m2 = MatlabReader.Read<double>(proj.ProjectPath + "\\tempData\\冲击动力学分析结果\\lengthforce-.mat");
                string n1, n2;
                // double [,] tt = ;
                n1 = m1.ToArray()[0, 0].ToString();
                n2 = m2.ToArray()[0, 0].ToString();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }
                    temp = "n1=" + n1 + "    !force+";
                    file.WriteLine(temp);
                    temp = "n2=" + n2 + "    !force-";
                    file.WriteLine(temp);
                    temp = "n3=" + proj.ShiJiJieChuChiShu + "    !实际接触齿数";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\ZhunDongTai.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }

                string proPath = proj.ProjectPath + "\\project\\协同分析\\准动态分析文件\\";
                Analysis.XT_DongTaiYingLiThreadParamter threadPara = new Analysis.XT_DongTaiYingLiThreadParamter(null, path, apdlfilepath, proPath);
                Analysis.XT_DongTaiYingLiThread t = new Analysis.XT_DongTaiYingLiThread(threadPara);
                t.CallBackMethod = DongTaiYingLiJiSuanFinish;
                AddMonitor();
                t.Start();
                ((AnalysisMonitor)anchorable.Content).DongTaiYingLiJiSuan_start();
                btnDongTaiYingLiJiSuan.IsEnabled = false;

            }
        }
        private void DongTaiYingLiJiSuanFinish(bool finish)
        {
            btnDongTaiYingLiJiSuan.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).DongTaiYingLiJiSuan_stop();
                UpdateResultPane();

                TIOFPSS.Resources.MessageBoxX.Info("准动态分析完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).DongTaiYingLiJiSuan_stop();
                TIOFPSS.Resources.MessageBoxX.Error("准动态分析失败！", this.Parent as Window);
            }


        }
        private void OnMoCaPianMoTaiJiSuanClick(object sender, RoutedEventArgs e)
        {
            Dialog.MoCaPianMoTaiJiSuan aw = new Dialog.MoCaPianMoTaiJiSuan();
            aw.CallBackMethod = MoCaPianMoTaiJiSuan;
            aw.ShowDialog();
        }
        private void MoCaPianMoTaiJiSuan(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string moTaiJieShu = para[0];
                string resName = para[1];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\MoChaPianMoTai");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";
                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }
                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao};
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 29; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }

                    temp = "dom=" + moTaiJieShu + "   !模态阶数";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\MoChaPianMoTai.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }

                Analysis.XT_MoCaPianMoTaiThreadParamter threadPara = new Analysis.XT_MoCaPianMoTaiThreadParamter(null, path, apdlfilepath, null);
                Analysis.XT_MoCaPianMoTaiThread t = new Analysis.XT_MoCaPianMoTaiThread(threadPara);
                t.CallBackMethod = MoCaPianMoTaiJiSuanFinish;
                AddMonitor();

                t.Start();
                ((AnalysisMonitor)anchorable.Content).McpModel_start();
                btnMoCaPianMoTaiJiSuan.IsEnabled = false;

            }
        }
        private void MoCaPianMoTaiJiSuanFinish(bool finish)
        {
            btnMoCaPianMoTaiJiSuan.IsEnabled = true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).McpModel_stop();
                UpdateResultPane();
                TIOFPSS.Resources.MessageBoxX.Info("摩擦片模态计算完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).McpModel_stop();
                TIOFPSS.Resources.MessageBoxX.Error("摩擦片模态计算失败！", this.Parent as Window);
            }
        }
        private void OnMcpNgMoTaiJiSuanClick(object sender, RoutedEventArgs e)
        {
            Dialog.McpNgMoTaiJiSuan aw = new Dialog.McpNgMoTaiJiSuan();
            aw.CallBackMethod = McpNgMoTaiJiSuan;
            aw.ShowDialog();
        }
        private void McpNgMoTaiJiSuan(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string moTaiJieShu = para[0];
                string resName = para[1];
                string APDLPath, tempPath;
                tempPath = System.IO.Path.Combine(proj.ProjectPath, "tempData\\MoChaPianNeiGuMoTai");
                APDLPath = startPath + "\\APDLcode";
                string praa = APDLPath + "\\parameter.txt";
                if (!System.IO.File.Exists(praa))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到parameter.txt", this.Parent as Window);
                    return;
                }
                string[] dataname ={"模数","齿数","压力角","内毂齿顶高","摩擦片齿顶高","内毂齿根高","摩擦片齿根高","内毂厚度","摩擦片厚度","内毂齿厚单边削薄量","摩擦片齿厚单边削薄量","内毂弹性模量","内毂泊松比",
		"内毂材料密度","摩擦片弹性模量","摩擦片泊松比","摩擦片材料密度","摩擦层弹性模量","摩擦层泊松比","摩擦层密度","镀层弹性模量","镀层泊松比","镀层密度","内毂孔径","摩擦片外径","摩擦层内径","摩擦层厚度","内毂齿根圆角","摩擦片齿根圆角","实际接触齿数"};
                string[] filename ={"m="+proj.MoShu,"z="+proj.ChiShu,"angle1="+proj.YaLiJiao+"*pi/180.0","ha1="+proj.NgChiDingGao,"ha2="+proj.McpChiDingGao,"c1="+proj.NgChiGenGao,"c2="+proj.McpChiGenGao,"b1="+proj.NgHouDu,
		"bx="+proj.McpHouDu,"gap1="+proj.NgGFXCDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)*(-1)/2","gap2="+proj.McpGFXDGC+"*cos("+proj.YaLiJiao+"*2*pi/360)/2","ex1="+proj.NgTXML+"e3","prxy1="+proj.NgBSB,"dens1="+proj.NgCLMD+"e-12",
		"ex2="+proj.McpTXML+"e3","prxy2="+proj.McpBSB,"dens2="+proj.McpCLMD+"e-12","ex3="+proj.MccTXML+"e3","prxy3="+proj.MccBSB,
		"dens3="+proj.MccCLMD+"e-12","ex4="+proj.DcTXML+"e3","prxy4="+proj.DcBSB,"dens4="+proj.DcCLMD+"e-12","rd1="+proj.KongJing+"/2","rd2="+proj.WaiJing+"/2","rdc=rd2-"+proj.MccJingKuan,"bc="+proj.MccHouDu,"rff1="+proj.NgChiGenYuanJiao,"rff2="+proj.McpChiGenYuanJiao,"n3="+proj.ShiJiJieChuChiShu};
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(praa))
                {
                    string temp;
                    temp = "pi=3.14159265358979";
                    file.WriteLine(temp);
                    for (int i = 0; i < 30; ++i)
                    {
                        file.Write(filename[i]);
                        file.Write("        !");
                        file.WriteLine(dataname[i]);
                    }

                    temp = "dom=" + moTaiJieShu + "    !模态阶数";
                    file.WriteLine(temp);
                    temp = "jobname=\'" + resName + "\'    !结果文件命名名称";
                    file.WriteLine(temp);
                    temp = "filepath=\'" + tempPath + "\'  !计算结果路径";
                    file.WriteLine(temp);
                    file.Close();
                }

                string path = System.IO.Path.Combine(proj.ProjectPath, "tempData");
                string apdlfilepath = APDLPath + "\\MoChaPianNeiGuMoTai.txt";
                if (!ModifyParaPath(apdlfilepath))
                {
                    return;
                }
                Analysis.XT_McpNgMoTaiJiSuanParamter threadPara = new Analysis.XT_McpNgMoTaiJiSuanParamter(null, path, apdlfilepath, null);
                Analysis.XT_McpNgMoTaiJiSuan t = new Analysis.XT_McpNgMoTaiJiSuan(threadPara);
                t.CallBackMethod = McpNgMoTaiJiSuanFinish;
                AddMonitor();

                t.Start();
                ((AnalysisMonitor)anchorable.Content).McpNgModel_start();
                btnMcpNgMoTaiJiSuan.IsEnabled = false;

            }
        }
        private void McpNgMoTaiJiSuanFinish(bool finish)
        {
            btnMcpNgMoTaiJiSuan.IsEnabled =true;
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).McpNgModel_stop();
                UpdateResultPane();

                TIOFPSS.Resources.MessageBoxX.Info("摩擦片内毂模态计算完成！", this.Parent as Window);
            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).McpNgModel_stop();
                TIOFPSS.Resources.MessageBoxX.Error("摩擦片内毂模态计算失败！", this.Parent as Window);
            }
        }

        private void OnYouJieJuChuTuClick(object sender, RoutedEventArgs e)
        {
            if(nowProjName!=null)
            {
                string matPath = loadProj[nowProjName] + "\\tempData\\冲击动力学分析结果\\Pitch.mat";
                if (!System.IO.File.Exists(matPath))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("还未进行有节距误差分析！");
                    //this.Close();
                    return;
                }
                YouJieJuChuTu aw = new YouJieJuChuTu(loadProj[nowProjName]);
                aw.ShowDialog();
            }
        }
        private void FSywj_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\fatigue_final.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到fatigue_final.dll", this.Parent as Window);
                return;
            }
            FXXSS_ShiYanWenJian aw = new FXXSS_ShiYanWenJian();
            aw.CallBackMethod = FSywjAnalysis;
            aw.ShowDialog();
        }
        private void FDTFXJG_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\fatigue_final.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到fatigue_final.dll", this.Parent as Window);
                return;
            }
            FXXSS_DongTaiFenXi aw = new FXXSS_DongTaiFenXi();
            aw.CallBackMethod = FDTJGAnalysis;
            aw.ShowDialog();
        }
        private void FZDTFXJG_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\fatigue_final.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到fatigue_final.dll", this.Parent as Window);
                return;
            }
            FXXSS_ZhunDongTaiJieGuo aw = new FXXSS_ZhunDongTaiJieGuo();
            aw.CallBackMethod = FZDTJSAnalysis;
            aw.ShowDialog();
        }
        string FXXSSfileList = "";
        private void FSywjAnalysis(FXXSSFile para)
        {
            FXXSSfileList = "";
            DB.UserProject proj = new UserProject();
            proj = GetNowProjectPara();
            if (proj == null)
                return;

            int isShiYanFile = 1;//shiyanwenjian

            string row = "21";
            string col = "2";
            string tongdao = "3";
            string dcol = "2";
            string row1 = "0";
            string row2 = "0";
            double iszidingyi = 0;
            row = para.row;
            col = para.col;
            tongdao = para.td;
            FXXSSfileList = para.path;
            string clcs1, clcs2, clcs3;
            clcs1 = Configure.IniReadValue("canshu", "clcs1");
            clcs2 = Configure.IniReadValue("canshu", "clcs2");
            clcs3 = Configure.IniReadValue("canshu", "clcs3");

            double[] Para = new double[23];

            Para[0] = Convert.ToDouble(proj.PiLaoJiXian);
            Para[1] = Convert.ToDouble(proj.YinLiYingBianZhuanHuanXiShu);
            Para[2] = Convert.ToDouble(tongdao);
            Para[3] = Convert.ToDouble(proj.CaiYangPinLv);
            Para[4] = 12;
            Para[5] = 0;
            Para[6] = 0;
            Para[7] = 0;
            Para[8] = 1;
            Para[9] = 1;
            Para[10] = 0;
            Para[11] = 0;
            Para[12] = 1;
            Para[13] = Convert.ToDouble(row);
            Para[14] = Convert.ToDouble(col);
            Para[15] = isShiYanFile;//判断用什么数据
            Para[16] = Convert.ToDouble(clcs1);//1.2*1e-11;
            Para[17] = Convert.ToDouble(clcs2);//3.6;
            Para[18] = Convert.ToDouble(clcs3);//0.3;

            Para[19] = Convert.ToDouble(dcol);//第几列 （动态分析结果文件用）
            Para[20] = Convert.ToDouble(row1);//从多少行开始
            Para[21] = Convert.ToDouble(row2);//到多少行截止
            Para[22] = iszidingyi;//时候用户自定义

            string file = para.path;
            string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

            Analysis.FeiXianXingSunShangThreadParamter threadPara = new Analysis.FeiXianXingSunShangThreadParamter(path, proPath, Para, file, isShiYanFile);
            Analysis.FeiXianXingSunShangThread t = new Analysis.FeiXianXingSunShangThread(threadPara);
            t.CallBackMethod = FXXSSFinish;
            btnfxxssfx.IsEnabled = false;
            AddMonitor();

            t.Start();

            ((AnalysisMonitor)anchorable.Content).FXXSS_start("实验文件");
        }
        private void FDTJGAnalysis(FXXSSFile para)
        {
            FXXSSfileList = "";
            DB.UserProject proj = new UserProject();
            proj = GetNowProjectPara();
            if (proj == null)
                return;
            int isShiYanFile = -1;//shiyanwenjian

            string row = "21";
            string col = "2";
            string tongdao = "3";
            string dcol = "2";
            string row1 = "0";
            string row2 = "0";
            double iszidingyi = 0;
            row1 = para.row1;
            row2 = para.row2;
            col = para.col;
            FXXSSfileList = para.path;

            string clcs1, clcs2, clcs3;
            clcs1 = Configure.IniReadValue("canshu", "clcs1");
            clcs2 = Configure.IniReadValue("canshu", "clcs2");
            clcs3 = Configure.IniReadValue("canshu", "clcs3");

            double[] Para = new double[23];

            Para[0] = Convert.ToDouble(proj.PiLaoJiXian);
            Para[1] = Convert.ToDouble(proj.YinLiYingBianZhuanHuanXiShu);
            Para[2] = Convert.ToDouble(tongdao);
            Para[3] = Convert.ToDouble(proj.CaiYangPinLv);
            Para[4] = 12;
            Para[5] = 0;
            Para[6] = 0;
            Para[7] = 0;
            Para[8] = 1;
            Para[9] = 1;
            Para[10] = 0;
            Para[11] = 0;
            Para[12] = 1;
            Para[13] = Convert.ToDouble(row);
            Para[14] = Convert.ToDouble(col);
            Para[15] = isShiYanFile;//判断用什么数据
            Para[16] = Convert.ToDouble(clcs1);//1.2*1e-11;
            Para[17] = Convert.ToDouble(clcs2);//3.6;
            Para[18] = Convert.ToDouble(clcs3);//0.3;
            Para[19] = Convert.ToDouble(dcol);//第几列 （动态分析结果文件用）
            Para[20] = Convert.ToDouble(row1);//从多少行开始
            Para[21] = Convert.ToDouble(row2);//到多少行截止
            Para[22] = iszidingyi;//时候用户自定义

            string file = para.path;
            string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

            Analysis.FeiXianXingSunShangThreadParamter threadPara = new Analysis.FeiXianXingSunShangThreadParamter(path, proPath, Para, file, isShiYanFile);
            Analysis.FeiXianXingSunShangThread t = new Analysis.FeiXianXingSunShangThread(threadPara);
            t.CallBackMethod = FXXSSFinish;
            btnfxxssfx.IsEnabled = false;
            AddMonitor();

            t.Start();

            ((AnalysisMonitor)anchorable.Content).FXXSS_start("动态分析结果文件");
        }
        private void FZDTJSAnalysis(FXXSSFile para)
        {
            FXXSSfileList = "";
            DB.UserProject proj = new UserProject();

            proj = GetNowProjectPara();
            if (proj == null)
                return;
            int isShiYanFile = 0;//shiyanwenjian

            string row = "21";
            string col = "2";
            string tongdao = "3";
            string dcol = "2";
            string row1 = "0";
            string row2 = "0";
            double iszidingyi = 0;
            FXXSSfileList = para.path;
            string clcs1, clcs2, clcs3;
            clcs1 = Configure.IniReadValue("canshu", "clcs1");
            clcs2 = Configure.IniReadValue("canshu", "clcs2");
            clcs3 = Configure.IniReadValue("canshu", "clcs3");

            double[] Para = new double[23];

            Para[0] = Convert.ToDouble(proj.PiLaoJiXian);
            Para[1] = Convert.ToDouble(proj.YinLiYingBianZhuanHuanXiShu);
            Para[2] = Convert.ToDouble(tongdao);
            Para[3] = Convert.ToDouble(proj.CaiYangPinLv);
            Para[4] = 12;
            Para[5] = 0;
            Para[6] = 0;
            Para[7] = 0;
            Para[8] = 1;
            Para[9] = 1;
            Para[10] = 0;
            Para[11] = 0;
            Para[12] = 1;
            Para[13] = Convert.ToDouble(row);
            Para[14] = Convert.ToDouble(col);
            Para[15] = isShiYanFile;//判断用什么数据
            Para[16] = Convert.ToDouble(clcs1);//1.2*1e-11;
            Para[17] = Convert.ToDouble(clcs2);//3.6;
            Para[18] = Convert.ToDouble(clcs3);//0.3;

            Para[19] = Convert.ToDouble(dcol);//第几列 （动态分析结果文件用）
            Para[20] = Convert.ToDouble(row1);//从多少行开始
            Para[21] = Convert.ToDouble(row2);//到多少行截止
            Para[22] = iszidingyi;//时候用户自定义

            string file = para.path;
            string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

            Analysis.FeiXianXingSunShangThreadParamter threadPara = new Analysis.FeiXianXingSunShangThreadParamter(path, proPath, Para, file, isShiYanFile);
            Analysis.FeiXianXingSunShangThread t = new Analysis.FeiXianXingSunShangThread(threadPara);
            t.CallBackMethod = FXXSSFinish;
            btnfxxssfx.IsEnabled = false;
            AddMonitor();
            t.Start();

            ((AnalysisMonitor)anchorable.Content).FXXSS_start("准动态计算文件");
        }

        private void FXXSSFinish(bool finish, string fileType)
        {
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).FXXSS_stop(fileType);
                string inipath = loadProj[nowProjName] + "\\project\\参数文件\\project.ini";
                string Section = "analysis";
                Configure.IniWriteValue(Section, "FXXSS", FXXSSfileList, inipath);
                UpdateResultPane();
                btnfxxssfx.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Info("非线性损伤" + fileType + "分析完成！",this.Parent as Window);


            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).FXXSS_stop(fileType);
                btnfxxssfx.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Error("非线性损伤" + fileType + "分析失败！", this.Parent as Window);
            }
        }


        private void DSywj_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\final_loadspectrumprograming_2.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到final_loadspectrumprograming_2.dll", this.Parent as Window);
                return;
            }
            DLZHP_ShiYanWenjian aw = new DLZHP_ShiYanWenjian();
            aw.CallBackMethod = DSywjAnalysis;
            aw.ShowDialog();
        }


        private void DDTFXJG_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\final_loadspectrumprograming_2.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到final_loadspectrumprograming_2.dll", this.Parent as Window);
                return;
            }
            DLZHP_DongTaiFenXiJieGuo aw = new DLZHP_DongTaiFenXiJieGuo();
            aw.CallBackMethod = DDTJGAnalysis;
            aw.ShowDialog();
        }

        private void DZDTFXJG_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\final_loadspectrumprograming_2.dll"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到final_loadspectrumprograming_2.dll", this.Parent as Window);
                return;
            }
            DLZHP_ZhunDongTaiJiSuanWenJian aw = new DLZHP_ZhunDongTaiJiSuanWenJian();
            aw.CallBackMethod = DZDTJSAnalysis;
            aw.ShowDialog();
        }

        string DLZHPfileList = "";
        private void DDTJGAnalysis(List<DSFileList> para)
        {
            DLZHPfileList = "";
            DB.UserProject proj = new UserProject();
            proj = GetNowProjectPara();
            if (proj == null)
                return;
            List<string> tds = new List<string>();
            List<string> qhxs = new List<string>();
            List<string> file = new List<string>();
            List<string> hang = new List<string>();
            int sum = 0;
            foreach (DSFileList item in para)
            {
                tds.Add(item.col);
                qhxs.Add(item.qhxs);
                file.Add(item.path);
                hang.Add(item.row);
                sum++;

                DLZHPfileList = DLZHPfileList + item.path + " ";
            }
            double[] Para = new double[5];
            Para[0] = Convert.ToDouble(proj.KangLaQDJX);
            Para[1] = Convert.ToDouble(proj.YinLiYingBianZhuanHuanXiShu);
            Para[2] = Convert.ToDouble(proj.CaiYangPinLv);
            Para[3] = Convert.ToDouble(para[0].row);
            Para[4] = Convert.ToDouble(para[0].col);
            int isShiYanFile = -1;//shiyanwenjian
            string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

            Analysis.DangLiangZaiHePuThreadParamter threadPara = new Analysis.DangLiangZaiHePuThreadParamter(path, proPath, Para, tds, qhxs, file, hang, sum, isShiYanFile);
            Analysis.DangLiangZaiHePuFenXiThread t = new Analysis.DangLiangZaiHePuFenXiThread(threadPara);
            t.CallBackMethod = DLZHPFinish;
            btndlzhpfx.IsEnabled = false;
            AddMonitor();

            t.Start();

            ((AnalysisMonitor)anchorable.Content).DLZHP_start("动态分析结果文件");
        }



        private void DZDTJSAnalysis(List<DSFileList> para)
        {
            DLZHPfileList = "";
            DB.UserProject proj = new UserProject();
            proj = GetNowProjectPara();
            if (proj == null)
                return;
            List<string> tds = new List<string>();
            List<string> qhxs = new List<string>();
            List<string> file = new List<string>();
            List<string> hang = new List<string>();
            int sum = 0;
            foreach (DSFileList item in para)
            {
                tds.Add("6");
                qhxs.Add(item.qhxs);
                file.Add(item.path);
                hang.Add("0");
                sum++;

                DLZHPfileList = DLZHPfileList + item.path + " ";
            }
            double[] Para = new double[5];
            Para[0] = Convert.ToDouble(proj.KangLaQDJX);
            Para[1] = Convert.ToDouble(proj.YinLiYingBianZhuanHuanXiShu);
            Para[2] = Convert.ToDouble(proj.CaiYangPinLv);
            Para[3] = Convert.ToDouble(para[0].row);
            Para[4] = Convert.ToDouble(para[0].col);
            int isShiYanFile = 0;//shiyanwenjian
            string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

            Analysis.DangLiangZaiHePuThreadParamter threadPara = new Analysis.DangLiangZaiHePuThreadParamter(path, proPath, Para, tds, qhxs, file, hang, sum, isShiYanFile);
            Analysis.DangLiangZaiHePuFenXiThread t = new Analysis.DangLiangZaiHePuFenXiThread(threadPara);
            t.CallBackMethod = DLZHPFinish;
            btndlzhpfx.IsEnabled = false;
            AddMonitor();

            t.Start();

            ((AnalysisMonitor)anchorable.Content).DLZHP_start("准动态计算文件");
        }
        private void DSywjAnalysis(List<DSFileList> para)
        {
            DLZHPfileList = "";
            DB.UserProject proj = new UserProject();
            proj = GetNowProjectPara();
            if (proj == null)
                return;
            List<string> tds = new List<string>();
            List<string> qhxs = new List<string>();
            List<string> file = new List<string>();
            List<string> hang = new List<string>();
            int sum = 0;
            foreach (DSFileList item in para)
            {
                tds.Add(item.td);
                qhxs.Add(item.qhxs);
                file.Add(item.path);
                hang.Add("0");
                sum++;

                DLZHPfileList = DLZHPfileList + item.path + " ";
            }
            double[] Para = new double[5];
            Para[0] = Convert.ToDouble(proj.KangLaQDJX);
            Para[1] = Convert.ToDouble(proj.YinLiYingBianZhuanHuanXiShu);
            Para[2] = Convert.ToDouble(proj.CaiYangPinLv);
            Para[3] = Convert.ToDouble(para[0].row);
            Para[4] = Convert.ToDouble(para[0].col);
            int isShiYanFile = 1;//shiyanwenjian
            string path = System.IO.Path.Combine(proj.ProjectPath, "tempData\\");//@"D:\proj\10.31\tempData\";
            string proPath = System.IO.Path.Combine(proj.ProjectPath, "project\\");//+"\\";

            Analysis.DangLiangZaiHePuThreadParamter threadPara = new Analysis.DangLiangZaiHePuThreadParamter(path, proPath, Para, tds, qhxs, file, hang, sum, isShiYanFile);
            Analysis.DangLiangZaiHePuFenXiThread t = new Analysis.DangLiangZaiHePuFenXiThread(threadPara);
            t.CallBackMethod = DLZHPFinish;
            btndlzhpfx.IsEnabled = false;
            AddMonitor();

            t.Start();

            ((AnalysisMonitor)anchorable.Content).DLZHP_start("实验文件");
        }
        private void DLZHPFinish(bool finish, string fileType)
        {
            if (finish == true)
            {
                ((AnalysisMonitor)anchorable.Content).DLZHP_stop(fileType);
                string inipath = loadProj[nowProjName] + "\\project\\参数文件\\project.ini";
                string Section = "analysis";
                Configure.IniWriteValue(Section, "DLZHP", DLZHPfileList, inipath);
                UpdateResultPane();
                btndlzhpfx.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Info("当量载荷谱" + fileType + "分析完成！", this.Parent as Window);


            }
            else
            {
                ((AnalysisMonitor)anchorable.Content).DLZHP_stop(fileType);
                btndlzhpfx.IsEnabled = true;
                TIOFPSS.Resources.MessageBoxX.Error("当量载荷谱" + fileType + "分析失败！", this.Parent as Window);
            }
        }
        private void OnViewResultClick(object sender, RoutedEventArgs e)
        {
            if (nowProjName != null)
            {
                bool hasResultPane = false;
                string path = loadProj[nowProjName] + "\\tempData";
                foreach (var paneItem in DocumentPane.Children)
                {
                    if (paneItem.Title == "分析结果")
                    {
                        paneItem.Content = new TIOFPSS.Dialog.ViewResult(nowProjName,path);
                        paneItem.IsActive = true;
                        paneItem.IsSelected = true;
                        hasResultPane = true;

                        //;
                        break;
                    }
                }
                if (hasResultPane == false)
                {
                    
                    Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
                    document.Title = "分析结果";
                    document.Content = new TIOFPSS.Dialog.ViewResult(nowProjName, path);
                    document.IsActive = true;
                    DocumentPane.Children.Add(document);

                    //;
                }

            }
        }
        private void OnShengChengBaoBiao(object sender, RoutedEventArgs e)
        {
            Dialog.ShengChengBaoBiao aw = new Dialog.ShengChengBaoBiao();
            aw.CallBackMethod = ShengChengBaoBiao;
            aw.ShowDialog();
        }
        private void ShengChengBaoBiao(List<string> para)
        {
            if (para != null && nowProjName != null)
            {
                DB.UserProject proj = new UserProject();
                if (!System.IO.File.Exists(startPath + "\\Report.exe"))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("找不到Report.exe", this.Parent as Window);
                    return;
                }
                proj = GetNowProjectPara();
                if (proj == null)
                    return;
                string LuJing = "\"" + para[0] + "\"";
                string resName = "\"" + para[1] + "\"";
                string xmlPath = "\"" + proj.ProjectPath + "\"";
                //string LuJing = para[0];
                //string resName = para[1];
                //string xmlPath = proj.ProjectPath + "\\";
                string fileparameter = xmlPath + " " + LuJing + " " + resName;

                Process p = new Process();

                p.StartInfo.FileName = @"Report.exe";           //程序名

                p.StartInfo.Arguments = fileparameter;    //程式执行参数
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                //p.Start();
                try
                {
                    btnShengChengBaoBiao.IsEnabled = false;
                    WaitingBox.Show(() =>
                    {
                        p.Start();
                        p.WaitForExit();
                    }, "正在生成报表，请稍后...");
                    TIOFPSS.Resources.MessageBoxX.Info("报表生成成功！", this.Parent as Window);

                }
                catch
                {
                    //TIOFPSS.Resources.MessageBoxX.Warning("生成报表失败！");
                    TIOFPSS.Resources.MessageBoxX.Error("报表生成失败！", this.Parent as Window);
                }
                btnShengChengBaoBiao.IsEnabled = true;
            }
        }
        private void OnConfigureClick(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(startPath + "\\config.ini"))
            {
                TIOFPSS.Resources.MessageBoxX.Error("找不到config.ini", this.Parent as Window);
                return;
            }
            Dialog.Configure conWindow = new Dialog.Configure();
            conWindow.ShowDialog();
        }

        private void OnZaoShengYouHuaClick(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
            document.Title = "噪声优化方法";
            document.Content = new Dialog.ZaoShengYouHuaFangFa();
            document.IsActive = true;
            DocumentPane.Children.Add(document);

            //;
        }
        private void OnPicEditClick(object sender, RoutedEventArgs e)
        {
            var selectItem = sender as Fluent.MenuItem;
            string picName = selectItem.Header.ToString();
            string picPath = loadProj[nowProjName] + "\\tempData\\冲击动力学分析结果\\" + picName + ".png";
            if (!System.IO.File.Exists(picPath))
            {
                TIOFPSS.Resources.MessageBoxX.Error("还未进行冲击动力学分析！", this.Parent as Window);
                return;
            }
            PictureEdit picEdit = new PictureEdit(picPath);
            Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
            document.Title = "图片修改";
            document.Content = picEdit;
            document.IsActive = true;
            DocumentPane.Children.Add(document);
        }
        private void OnPicEditOKClick(object sender, RoutedEventArgs e)
        {
            string picPath = null;
            TIOFPSS.Dialog.PictureEdit picEdit = null;
            foreach (var item in DocumentPane.Children)
            {
                if (item.Title == "图片修改" &&item.IsSelected)
                {

                    picEdit = (TIOFPSS.Dialog.PictureEdit)(item.Content);
                    picPath = picEdit.PicPath;
                    break;
                }
            }
            if(picPath==null)
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择一张图片！");
                return;
            }

            System.Windows.Media.Color lineColor=new Color();
       
            if(LineColor.SelectedColor!=null)
            {
                lineColor = (System.Windows.Media.Color)LineColor.SelectedColor;
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择线段颜色！");
                return;
            }
            string picName=picPath.Substring(picPath.LastIndexOf("\\")+1);            //"摩擦片冲击力";
            System.Windows.Media.Color fontColor = new Color();
            if(FontColor.SelectedColor!=null)
            {
                fontColor = (System.Windows.Media.Color)FontColor.SelectedColor;
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择字体颜色！");
                return;
            }
            if(xmin.Value==xmax.Value || ymin.Value==ymax.Value)
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择合适区间！");
                return;
            }

            int bold = 1;
            if(buttonBold.IsChecked==true)
            {
                bold = 2;
            }

            double []ii=new double[18];//蓝色和红色
            TextBlock tb = (TextBlock)comboBoxFontSize.SelectedItem;
            string fontsize = tb.Text;
	        ii[0]=(double)lineColor.R/255;//线条颜色1R
            ii[1] = (double)lineColor.G / 255;//线条颜色1G
            ii[2] = (double)lineColor.B / 255;//线条颜色1B
	        ii[3]=1;//线条颜色2R
	        ii[4]=0;//线条颜色2G
	        ii[5]=0;//线条颜色2B
            ii[6] = Convert.ToDouble(fontsize);//字体大小
	        ii[7]=xmin.Value;//x坐标
	        ii[8]=xmax.Value;//x坐标
	        ii[9]=ymin.Value;//Y坐标
	        ii[10]=ymax.Value;//Y坐标
	        ii[11]=5;//<0:细化绘图   0<x<10 保存一张图片  >10 保存所有图片
	        ii[12]=1;//判断是否需要标题>0 需要 <0不需要
            ii[13] = bold;//字体加粗选择：1、2、3、4  {'normal','bold','light','demi'}
            ii[14] = (double)fontColor.R / 255;//字体颜色R
            ii[15] = (double)fontColor.G / 255;//字体颜色G
            ii[16] = (double)fontColor.B / 255;//字体颜色B
	        ii[17]=1;//

            string path = loadProj[nowProjName] + "\\project\\冲击动力学分析文件\\Dynamic.mat";
            string m11 = loadProj[nowProjName] + "\\tempData\\冲击动力学分析结果\\";
            string fontName = comboBoxFontName.SelectedItem.ToString();
            MWArray locc=new MWCharArray(path);
	        MWArray dra=new MWCharArray(m11);
	        MWArray font=new MWCharArray(fontName);
            MWArray typ = new MWNumericArray(1, 18, ii); 
            
            string name;
	        if(picName=="摩擦片冲击力.png")
	        {
		        name="force";
	        }
	        else if(picName=="摩擦片与内毂相对扭转角度.png")
	        {
		        name="relative_angle";
	        }
	        else if(picName=="摩擦片与内毂相对旋转速度.png")
	        {
		        name="relative_rotating_velocity";
	        }
	        else if(picName=="内毂角加速度.png")
	        {
		        name="inner_acceleration";
	        }
	        else if(picName=="摩擦片角加速度.png")
	        {
		        name="outer_acceleration";
	        }
	        else if(picName=="内毂角速度.png")
	        {
		        name="inner_speed";
	        }
	        else if(picName=="摩擦片角速度.png")
	        {
		        name="outer_speed";
	        }
            //else if(picName=="角速度.png")
            //{
            //    name="speed";
            //}
            //else if(picName=="角加速度.png")
            //{
            //    name="acceleration";
            //}
	        else
	        {
		        return;
	        }
            MWArray filename = new MWCharArray(name);
            draw.HuiTuClass drawClass=new HuiTuClass();

            try
            {
                drawClass.draw(locc, dra, filename, font, typ);
                picEdit = new PictureEdit(picPath);
                foreach (var item in DocumentPane.Children)
                {
                    if (item.Title == "图片修改" && item.IsSelected)
                    {
                        item.Content = picEdit;
                        break;
                    }
                }

                TIOFPSS.Resources.MessageBoxX.Info("图片修改完成！", this.Parent as Window);
                
            }
            catch
            {
                TIOFPSS.Resources.MessageBoxX.Error("图片修改失败！", this.Parent as Window);
            }


            //string picEdit = loadProj[nowProjName] + "\\tempData\\摩擦片冲击力.png";
            //Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
            //document.Title = "图片修改";
            //document.Content = new PictureEdit(picEdit);
            //document.IsActive = true;
            //DocumentPane.Children.Add(document);
            
        }
        private void OnDetailDrawClick(object sender, RoutedEventArgs e)
        {
            if (nowProjName != null)
            {
                string path = loadProj[nowProjName] + "\\project\\冲击动力学分析文件\\Dynamic.mat";
                if (!System.IO.File.Exists(path))
                {
                    TIOFPSS.Resources.MessageBoxX.Error("还未进行冲击动力学分析！", this.Parent as Window);
                    return;
                }

                MWArray loc = new MWCharArray(path);
                string picPath = loadProj[nowProjName] + "\\tempData\\冲击动力学分析结果";
                MWArray dra = new MWCharArray(picPath);
                MWArray fontName = new MWCharArray("宋体");
                double []ii=new double[18];

                ii[0] = 0;//线条颜色1R
                ii[1] = 0;//线条颜色1G
                ii[2] = 1;//线条颜色1B
                ii[3] = 1;//线条颜色2R
                ii[4] = 0;//线条颜色2G
                ii[5] = 0;//线条颜色2B
                ii[6] = 12;//字体大小
                ii[7] = 0.2;//x坐标
                ii[8] = 0.4;//x坐标
                ii[9] = 0;//Y坐标
                ii[10] = 500;//Y坐标
                ii[11] = -5;//<0:细化绘图   0<x<10 保存一张图片  >10 保存所有图片
                ii[12] = 1;//判断是否需要标题>0 需要 <0不需要
                ii[13] = 1;//字体加粗选择：1、2、3、4  {'normal','bold','light','demi'}
                ii[14] = 0;//字体颜色R
                ii[15] = 0;//字体颜色G
                ii[16] = 0;//字体颜色B

                ii[17] = 1;//////canshu1
                MWArray typ = new MWNumericArray(1, 18, ii);

                //MWArray filename = new MWCharArray("force");
                draw.HuiTuClass htClass=new draw.HuiTuClass();
                bool hasCheck = false;
		            if(mcpcjjCHK.IsChecked==true)
                    {
                        hasCheck = true;
                        MWArray filename = new MWCharArray("force");
                        try
                        {
                            htClass.draw(loc, dra, filename, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                        
                    }
            		if(mcpngxdnzjdCHK.IsChecked==true)
		            {
                        hasCheck = true;
				        MWArray filename2 = new MWCharArray("relative_angle");
                        try
                        {
                             htClass.draw(loc,dra,filename2,fontName,typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                    }
                    if(mcpngxdxzsdCHK.IsChecked==true)
                    {
                        hasCheck = true;
                        MWArray filename3 = new MWCharArray("relative_rotating_velocity");
                        try
                        {
                            htClass.draw(loc, dra, filename3, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                    }
            		if(ngjjsdCHK.IsChecked==true)
		            {
                        hasCheck = true;
				        MWArray filename4 = new MWCharArray("inner_acceleration");
                        try
                        {
                            htClass.draw(loc,dra,filename4,fontName,typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                        
                    }
                    if(mcpjjsdCHK.IsChecked==true)
                    {
                        hasCheck = true;
                        MWArray filename5 = new MWCharArray("outer_acceleration");
                        try
                        {
                            htClass.draw(loc, dra, filename5, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                       
                    }
            		if(ngjsdCHK.IsChecked==true)
		            {
                        hasCheck = true;
				        MWArray filename6 = new MWCharArray("inner_speed");
                        try
                        {
                            htClass.draw(loc, dra, filename6, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                        
                    }
                    if(mcpjsdCHK.IsChecked==true)
                    {
                        hasCheck = true;
                        MWArray filename7 = new MWCharArray("outer_speed");
                        try
                        {
                            htClass.draw(loc, dra, filename7, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                        
                    }
            		if(ngmcpjsdCHK.IsChecked==true)
		            {
                        hasCheck = true;
				        MWArray filename8 = new MWCharArray("speed");
                        try
                        {
                            htClass.draw(loc, dra, filename8, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                        
                    }
                    if(ngmcpjjsdCHK.IsChecked==true)
		            {
                        hasCheck = true;
				        MWArray filename9 = new MWCharArray("acceleration");
                        try
                        {
                            htClass.draw(loc, dra, filename9, fontName, typ);
                        }
                        catch
                        {
                            TIOFPSS.Resources.MessageBoxX.Error("绘图失败！", this.Parent as Window);
                        }
                        
                    }
                if(hasCheck==false)
                {
                    TIOFPSS.Resources.MessageBoxX.Warning("请选择要绘图类型！", this.Parent as Window);
                }

                
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Warning("请选择要绘图的项目", this.Parent as Window);
            }        
        }

        private void OnProQueryClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in DocumentPane.Children)
            {
                if (item.Title == "项目查找")
                {
                    item.Content = new Dialog.ProjectQuery();
                    item.IsActive = true;
                    item.IsSelected = true;
                    //;
                    return;
                }
            }


            Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
            document.Title = "项目查找";
            document.Content = new Dialog.ProjectQuery();
            document.IsActive = true;
            DocumentPane.Children.Add(document);
            //;
        }

        private void OnProjCmpClick(object sender, RoutedEventArgs e)
        {
            ProjectCompareSelect aw = new ProjectCompareSelect();
            aw.CallBackMethod = ProjectCompareMethod;
            aw.ShowDialog();



            //;
        }
        private void ProjectCompareMethod(List<TIOFPSS.Dialog.ProjectPara> para)
        {
            List<string> path = new List<string>();
            foreach(ProjectPara item in para)
            {
                path.Add(item.projPath);
            }                        
            //path.Add("D:\\proj\\11.11");
            //path.Add("D:\\proj\\11.111");
            //path.Add("D:\\proj\\11.14");
            Xceed.Wpf.AvalonDock.Layout.LayoutDocument document = new Xceed.Wpf.AvalonDock.Layout.LayoutDocument();
            document.Title = "项目对比";
            document.Content = new Dialog.ProjectCompare(path);
            document.IsActive = true;
            DocumentPane.Children.Add(document);
        }
         //<xctk:ColorPicker x:Name="_colorPicker"
         //                  Grid.Row="2"
         //                  VerticalAlignment="Top" />


    }

    public class FooCommand1
    {
        public static RoutedCommand TestPresnterCommand = new RoutedCommand("TestPresnterCommand", typeof(FooCommand1));

        public ICommand ItemCommand
        {
            get { return TestPresnterCommand; }
        }

        public CommandBinding ItemCommandBinding
        {
            get { return new CommandBinding(TestPresnterCommand, this.OnTestCommandExecuted, this.CanExecuteTestCommand); }
        }

        private void CanExecuteTestCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnTestCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TIOFPSS.Resources.MessageBoxX.Warning("Test Module Command");
        }
    }

    /// <summary>
    /// 计算 <see cref="System.Windows.Controls.TreeViewItem"/> 的缩进的转换器。
    /// </summary>
    [ValueConversion(typeof(TreeViewItem), typeof(Thickness))]
    public sealed class IndentConverter : IValueConverter
    {
        /// <summary>
        /// 获取或设置缩进的像素个数。
        /// </summary>
        public double Indent { get; set; }
        /// <summary>
        /// 获取或设置初始的左边距。
        /// </summary>
        public double MarginLeft { get; set; }
        /// <summary>
        /// 转换值。
        /// </summary>
        /// <param name="value">绑定源生成的值。</param>
        /// <param name="targetType">绑定目标属性的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        /// <returns>转换后的值。如果该方法返回 <c>null</c>，则使用有效的 <c>null</c> 值。</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TreeViewItem item = value as TreeViewItem;
            if (item == null)
            {
                return new Thickness(0);
            }
            return new Thickness(this.MarginLeft + this.Indent * 2, 0, 0, 0);
        }
        /// <summary>
        /// 转换值。
        /// </summary>
        /// <param name="value">绑定目标生成的值。</param>
        /// <param name="targetType">要转换到的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        /// <returns>转换后的值。如果该方法返回 <c>null</c>，则使用有效的 <c>null</c> 值。</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LevelToMarginConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var level = (int)value;
            return new System.Windows.Thickness(8 * level + 10 * (level - 1), 0, 0, 0);
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public sealed class TrueToFalseConverter : IValueConverter
    {
        static TrueToFalseConverter()
        {
        }
        private TrueToFalseConverter()
        {
        }
        public static TrueToFalseConverter Instance
        {
            get
            {
                return _instance;
            }
         }
        private static readonly TrueToFalseConverter _instance = new TrueToFalseConverter();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var v = (bool)value;
            return !v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 常用转换器的静态引用
    /// 使用实例：Converter={x:Static local:XConverter.TrueToFalseConverter}
    /// </summary>
    public sealed class XConverter
    {
        public static BooleanToVisibilityConverter BooleanToVisibilityConverter
        {
            get { return BooleanToVisibilityConverter; }
        }

        public static TrueToFalseConverter TrueToFalseConverter
        {
            get { return TrueToFalseConverter.Instance; }
        }

        //public static ThicknessToDoubleConverter ThicknessToDoubleConverter
        //{
        //    get { return Singleton<ThicknessToDoubleConverter>.GetInstance(); }
        //}
        //public static BackgroundToForegroundConverter BackgroundToForegroundConverter
        //{
        //    get { return Singleton<BackgroundToForegroundConverter>.GetInstance(); }
        //}
        //public static TreeViewMarginConverter TreeViewMarginConverter
        //{
        //    get { return Singleton<TreeViewMarginConverter>.GetInstance(); }
        //}

        //public static PercentToAngleConverter PercentToAngleConverter
        //{
        //    get { return Singleton<PercentToAngleConverter>.GetInstance(); }
        //}
    }
}
