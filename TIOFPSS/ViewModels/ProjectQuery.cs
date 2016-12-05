using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIOFPSS.DB;
using System.Collections.ObjectModel;
using System.Data;
namespace TIOFPSS.ViewModels
{
    public class ProjectQuery : ViewModel
    {
        private ObservableCollection<UserProject> projects;
        public ObservableCollection<UserProject> Projects
        {
            get { return this.projects; }
            set
            {
                projects = value;
                this.OnPropertyChanged("Projects");
            }
        }

        private List<string> proPath = new List<string>();
        private List<List<string>> data = new List<List<string>>();
        public ProjectQuery()
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            Projects=new ObservableCollection<UserProject>();
            DataSet result = new DataSet();

            result = bll.GetList();

            if (result!=null&&result.Tables[0].Rows.Count > 0)
            {
                //TIOFPSS.Resources.MessageBoxX.Warning("取值成功");

                foreach (DataRow row in result.Tables[0].Rows)
                {
                    List<string> tempRow = new List<string>();
                    foreach (DataColumn mDc in result.Tables[0].Columns)
                    {

                        tempRow.Add(row[mDc].ToString());
                        //data[i].Add(row[mDc].ToString())
                       
                    }
                    Projects.Add(loopSetValue(tempRow));
                    data.Add(tempRow);
                    proPath.Add(tempRow[0]);
                    //tempRow.Clear();
                }
                
            }
            else
            {
                TIOFPSS.Resources.MessageBoxX.Error("取值失败");
            }
        }
        public  UserProject loopSetValue(List<string> value)
        {
            UserProject userProject = new UserProject();
            userProject.ProjectPath = value[1];
            userProject.ProjectName = value[2];
            userProject.ChiShu = value[3];//齿数          
            userProject.MoShu = value[4];//模数           
            userProject.YaLiJiao = value[5];//压力角      
            userProject.McpChiDingGao = value[6];//齿顶高 
            userProject.McpChiGenGao = value[7];//齿根高  
            userProject.McpChiGenYuanJiao = value[8];//齿根
            userProject.WaiJing = value[9];//外径         
            userProject.ChiCeJianXi = value[10];//齿侧间隙
            userProject.KongJing = value[11];//孔径
            userProject.NgHouDu = value[12];//厚度

            //摩擦片强化参数 2
            userProject.MccHouDu = value[13];//摩擦层厚度
            userProject.DuCengHouDu = value[14];//镀层厚度

            //材料参数 14
            //摩擦片
            userProject.McpTXML = value[15];//摩擦片弹性模量
            userProject.McpCLMD = value[16];//摩擦片材料密度
            userProject.McpBSB = value[17];//摩擦片泊松比
            userProject.KangLaQDJX = value[18];//抗拉强度极限
            userProject.PiLaoJiXian = value[19];//疲劳极限
            //内毂
            userProject.NgTXML = value[20];//内毂弹性模量
            userProject.NgCLMD = value[21];//内毂材料密度
            userProject.NgBSB = value[22];//内毂泊松比
            //摩擦层
            userProject.MccTXML = value[23];//摩擦层弹性模量
            userProject.MccCLMD = value[24];//摩擦层材料密度
            userProject.MccBSB = value[25];//摩擦层泊松比
            //镀层
            userProject.DcTXML = value[26];//镀层弹性模量
            userProject.DcCLMD = value[27];//镀层材料密度
            userProject.DcBSB = value[28];//镀层泊松比
            //仿真参数
            //初始条件 7
            userProject.NgChuShiJiaoWeiYi = value[29];//内毂初始角位移
            userProject.NgChuShiSuDu = value[30];//内毂初始速度
            userProject.McpChuShiJiaoWeiYi = value[31];//摩擦片初始角位移
            userProject.McpChuShiSuDu = value[32];//摩擦片初始速度
            userProject.YouMoHouDu = value[33];//油膜厚度
            userProject.YouYeNianDu = value[34];//油膜粘度
            userProject.WenDu = value[35];//温度
            //计算条件 14
            userProject.ShiJiJieChuChiShu = value[36];//实际接触齿数
            userProject.FanTanXiShu = value[37];//反弹系数
            userProject.NgZhuanSu = value[38];//内毂转速
            userProject.NgZhenFu = value[39];//内毂振幅
            userProject.NgZhenPin = value[40];//内毂振频
            userProject.JieGouZuNi = value[41];//结构阻尼
            userProject.McpZhuanDongGuanLiang = value[42];//摩擦片转动惯量
            userProject.NgZhuanDongGuanLiang = value[43];//内毂转动惯量
            userProject.JieChuQuJinXiangChuangDu = value[44];//接触区径向长度
            userProject.JieChuQuZhouXiangChangDu = value[45];//接触区轴向长度
            userProject.QiDongShiJian = value[46];//启动时间
            userProject.ZengSuShiJian = value[47];//增速时间
            userProject.WenDingShiJian = value[48];//稳定时间
            userProject.TingZhiShiJIan = value[49];//停止时间
            //误差条件 3
            userProject.PianXinJu = value[50];//偏心距
            userProject.JieJuZuiDaWuCha = value[51];//节距最大误差
            userProject.JieJuZuiXiaoWuCha = value[52];//节距最小误差
            //实验数据标定与转换系数 2
            userProject.CaiYangPinLv = value[53];//采样频率
            userProject.YinLiYingBianZhuanHuanXiShu = value[54];//应力应变转换系数
            userProject.MccJingKuan = value[55];
            userProject.McpHouDu = value[56];
            //增加的参数
            userProject.NgChiDingGao = value[57];//内毂齿顶高
            userProject.NgChiGenGao = value[58];//内毂齿根高
            userProject.McpGFXDGC = value[59];//摩擦片公法线长度公差
            userProject.NgGFXCDGC = value[60];//内毂公法线长度公差
            userProject.ZuNiCaoChang = value[61];//阻尼槽长
            userProject.ZuNiCaoKuan = value[62];//阻尼槽宽
            userProject.ZuNiCaoBanJing = value[63];//阻尼槽半径
            userProject.NgChiGenYuanJiao = value[64];//内毂齿根圆角
            return userProject;
        }
        

    }
}
