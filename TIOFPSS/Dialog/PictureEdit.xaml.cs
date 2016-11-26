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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TIOFPSS.Dialog
{
    /// <summary>
    /// PictureEdit.xaml 的交互逻辑
    /// </summary>
    public partial class PictureEdit : UserControl
    {
        public string PicPath;
       
        public PictureEdit(string path)
        {
            InitializeComponent();
            PicPath = path;
            this.DataContext = new PicEditViewModel(path);
            //this.DataContext = PicPath;
        }

    }
    public class PicEditViewModel:ViewModels.ViewModel
    {
        public PicEditViewModel(string path)
        {
            PicPath = LoadImg(path);
        }
        public ImageSource picPath;
        public ImageSource PicPath
        {
            get { return picPath; }
            set
            {
                picPath = value;
                this.OnPropertyChanged("PicPath");
            }
        }
        BitmapImage LoadImg(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                return null;
            }
            using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // just in case you want to load the image in another thread
                return bitmapImage;
            }

        }
    }
}
