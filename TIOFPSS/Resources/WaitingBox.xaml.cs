using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace System.Windows
{
    /// <summary>
    /// 简单等待框
    /// </summary>
    public partial class WaitingBox : Window
    {
        public string Text { get { return this.txtMessage.Text; } set { this.txtMessage.Text = value; } }

        private Action _Callback;

        public WaitingBox(Action callback)
        {
            this._Callback = callback;
            this.Loaded += WaitingBox_Loaded;
            InitializeComponent();

        }

        void WaitingBox_Loaded(object sender, RoutedEventArgs e)
        {
            this._Callback.BeginInvoke(this.OnComplate, null);
        }

        private void OnComplate(IAsyncResult ar)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }



        /// <summary>
        /// 显示等待框，callback为需要执行的方法体（需要自己做异常处理）。
        /// 目前等等框为模式窗体
        /// </summary>
        public static void Show(Action callback, string mes = "有一种幸福，叫做等待...")
        {
            WaitingBox win = new WaitingBox(callback);
            //Window pwin = ControlHelper.GetTopWindow();
            //win.Owner = pwin;
            win.Text = mes;
            win.ShowDialog();
        }
    }
    //public static class ControlHelper
    //{
    //    //从Handle中获取Window对象
    //    private static Window GetWindowFromHwnd(IntPtr hwnd)
    //    {
    //        return (Window)System.Windows.Interop.HwndSource.FromHwnd(hwnd).RootVisual;
    //    }

    //    //GetForegroundWindow API
    //    [System.Runtime.InteropServices.DllImport("user32.dll")]
    //    static extern IntPtr GetForegroundWindow();

    //    /////调用GetForegroundWindow然后调用GetWindowFromHwnd

    //    /// <summary>
    //    /// 获取当前顶级窗体，若获取失败则返回主窗体
    //    /// </summary>
    //    public static Window GetTopWindow()
    //    {
    //        var hwnd = GetForegroundWindow();
    //        if (hwnd == IntPtr.Zero)
    //            return Application.Current.MainWindow;

    //        return GetWindowFromHwnd(hwnd);
    //    }
    //}
}
