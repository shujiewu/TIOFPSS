using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TIOFPSS.DB
{
    class XmlHelper
    {
        public static void CreateDocument()
        {

        }
        public static bool LoadPara(string path, List<string> values)
        {
            if(System.IO.File.Exists(path))
            {
                XElement root = XElement.Load(path);
                foreach (var item in root.Elements("item"))
                {
                    values.Add(item.Element("val").Value.ToString());
                    
                    //Console.WriteLine(item.Element("val").Value);
                }
                return true;
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Error("xml文件读取出错！");
                //TIOFPSS.Resources.MessageBoxX.Warning("xml文件读取出错！");
                return false;
            }

        }
        public static void UpdatePara(string path, List<string> values)
        {
            XElement root = XElement.Load(path);
            int i = 0;
            foreach (var item in root.Elements("item"))
            {
                //values.Add(item.Element("val").Value.ToString());
                item.SetElementValue("val",values[i]);
                i++;
            }
            root.Save(path);
        }

    }
}
