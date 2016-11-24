using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.ViewModels
{
    public class ParaLibViewModel : ViewModel
    {
        private List<string> libName = new List<string>();
        private List<List<string>> data = new List<List<string>>();
        public ParaLibViewModel()
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层

            DataSet result = new DataSet();
            result = bll.GetLibList();
            if (result.Tables[0].Rows.Count > 0)
            {
                //Xceed.Wpf.Toolkit.MessageBox.Show("取值成功");
                
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    List<string> tempRow = new List<string>();
                    foreach (DataColumn mDc in result.Tables[0].Columns)
                    {
                        
                        tempRow.Add(row[mDc].ToString());
                        //data[i].Add(row[mDc].ToString())
                    }  
                    data.Add(tempRow);
                    libName.Add(tempRow[0]);
                    //tempRow.Clear();
                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("取值失败");
            }

        }

        public List<List<string>> LibData
        {
            get { return this.data; }
            set
            {
                data = value;
                this.OnPropertyChanged("LibData");
            }
        }
        public List<string> LibName
        {
            get { return this.libName; }
            set
            {
                libName = value;
                this.OnPropertyChanged("LibData");
            }
        }
    }
}
