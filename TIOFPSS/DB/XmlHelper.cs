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
        public static void LoadPara(string path, List<string> values)
        {
            XElement root = XElement.Load(path);
            foreach (var item in root.Elements("item"))
            {
                values.Add(item.Element("val").Value.ToString());
                //Console.WriteLine(item.Element("val").Value);
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
