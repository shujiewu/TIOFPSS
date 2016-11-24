using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.ViewModels
{
    public class LatestProjectViewModel : ViewModel
    {
        private List<string> latestProjectName = new List<string>();
        //private List<List<string>> data = new List<List<string>>();

        public LatestProjectViewModel()
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();
            //DataSet result = new DataSet();
            latestProjectName = bll.GetLatestProjectList();
            //if (result.Tables[0].Rows.Count > 0)
            //{
            //    //Xceed.Wpf.Toolkit.MessageBox.Show("取值成功");

            //    foreach (DataRow row in result.Tables[0].Rows)
            //    {
            //        List<string> tempRow = new List<string>();
            //        foreach (DataColumn mDc in result.Tables[0].Columns)
            //        {

            //            tempRow.Add(row[mDc].ToString());
            //            //data[i].Add(row[mDc].ToString())
            //        }
            //        //data.Add(tempRow);
            //        latestProjectName.Add(tempRow[0]);
            //        //tempRow.Clear();
            //    }
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("取值失败");
            //}
        }
        //public List<List<string>> Data
        //{
        //    get { return this.data; }
        //    set
        //    {
        //        data = value;
        //        this.OnPropertyChanged("Data");
        //    }
        //}
        public List<string> LatestProjectName
        {
            get { return this.latestProjectName; }
            set
            {
                latestProjectName = value;
                this.OnPropertyChanged("LatestProjectName");
            }
        }
    }
}
