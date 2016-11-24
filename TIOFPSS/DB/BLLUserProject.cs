using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.DB
{
    class BLLUserProject
    {
        private readonly DALUserProject dal = new DALUserProject();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(UserProject model)
        {
            return dal.Add(model);
        }
        public bool AddLatestProject(string path, string projectName, string date)
        {
            if(dal.GetLatest(projectName))
            {
                return dal.UpdateLatestProject(path, projectName, date);
            }
            else
            {
                return dal.AddLatestProject(path, projectName, date);
            }
            
        }
        public bool AddLib(UserProject model)
        {
            return dal.AddLib(model);
        }

     

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserProject model, string oldPath)
        {
            return dal.Update(model, oldPath);
        }
        //public bool UpdateChangeName(UserProject model,string newPath)
        //{
        //    return dal.UpdateChangeName(model, newPath);
        //}


        public bool UpdateLatestProject(string path, string projectName, string date)
        {
            return dal.UpdateLatestProject(path, projectName, date);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string UserName)
        {
            return dal.Delete(UserName);
        }

        public bool DeleteLatestProject(string projectName)
        {
            return dal.DeleteLatestProject(projectName);
        }

        public bool DeleteLib(string libName)
        {
            return dal.DeleteLib(libName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<string> GetModel(string projectPath)
        {
            return dal.GetModel(projectPath);
        }
        public List<string> GetLibModel(string libName)
        {
            return dal.GetLibModel(libName);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList()
        //{
        //    return dal.GetList();
        //}
        public DataSet GetLibList()
        {
            return dal.GetLibList();
        }

        public List<string> GetLatestProjectList()
        {
            return dal.GetLatestProjectList();
        }
        public string GetLatestProjectPath(string projectName)
        {
            return dal.GetLatestProjectPath(projectName);
        }

    }
}
