using System.Collections.Generic;
using System.Windows.Markup;
using System.Windows.Media;
namespace TIOFPSS.ViewModels
{
    public class FontsViewModel : ViewModel
    {
        private List<string> data = new List<string>();//{ "Tahoma", "Segoe UI", "Arial", "Courier New", "Symbol" };

        public List<string> FontsData
        {
            get { return this.data; }
            set
            {
                data = value;
                this.OnPropertyChanged("FontsData");
            }
        }
        public FontsViewModel()
        {
            FontsData = new List<string>();
            //foreach (FontFamily _f in System.Windows.Media.Fonts.SystemFontFamilies)
            //{

            //    LanguageSpecificStringDictionary _fontDic = _f.FamilyNames;
            //    if (_fontDic.ContainsKey(XmlLanguage.GetLanguage("zh-cn")))
            //    {
            //        string _fontName = null;
            //        if (_fontDic.TryGetValue(XmlLanguage.GetLanguage("zh-cn"), out _fontName))
            //        {
            //            FontsData.Add(_fontName);
            //            cbo_Demo.Items.Add(_fontName);
            //        }
            //    }
            //}
            //int I;
            System.Drawing.Text.InstalledFontCollection font = new System.Drawing.Text.InstalledFontCollection();
            System.Drawing.FontFamily[] array = font.Families;
            foreach (System.Drawing.FontFamily item in array)
            {

                FontsData.Add(item.Name);
            }
            //int I;
        }
        //private readonly string[] data = { "Tahoma", "Segoe UI", "Arial", "Courier New", "Symbol" };

        //public string[] FontsData
        //{
        //    get { return this.data; }
        //}

    }
}
