using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.ViewModels
{
    public class ParaViewModel : ViewModel
    {
        private DB.UserProject userProject;
        public DB.UserProject UserProject
        {
            get { return this.userProject; }
            set
            {
                userProject = value;
                this.OnPropertyChanged("UserProject");
            }
        }

        public List<string> para = new List<string>();

        public ParaViewModel()
        {
            DB.BLLUserProject bll = new DB.BLLUserProject();//实例化BLL层
            bll.GetList();
            //para.Add("0");
            //para.Add(path);
            //para.Add(name);

        }
        public ParaViewModel(string path, string name)
        {
            string paraPath = System.IO.Path.Combine(path, "project\\参数文件\\parameter.xml");

            para.Add("0");
            para.Add(path);
            para.Add(name);
            DB.XmlHelper.LoadPara(paraPath, para);
            userProject = new DB.UserProject();
            //foreach (string item in para)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(para[3]);
            loopSetValue(para);

        }
        public void saveValue()
        {
            string paraPath = System.IO.Path.Combine(para[1], "project\\参数文件\\parameter.xml");
            List<string> value = new List<string>();
            value.Add(userProject.ChiShu);
            value.Add(userProject.MoShu);
            value.Add(userProject.YaLiJiao);
            value.Add(userProject.McpChiDingGao);
            value.Add(userProject.McpChiGenGao);
            value.Add(userProject.McpChiGenYuanJiao);
            value.Add(userProject.WaiJing);
            value.Add(userProject.ChiCeJianXi);
            value.Add(userProject.KongJing);
            value.Add(userProject.NgHouDu);


            value.Add(userProject.MccHouDu);
            value.Add(userProject.DuCengHouDu);

            value.Add(userProject.McpTXML);
            value.Add(userProject.McpCLMD);
            value.Add(userProject.McpBSB);
            value.Add(userProject.KangLaQDJX);
            value.Add(userProject.PiLaoJiXian);

            value.Add(userProject.NgTXML);
            value.Add(userProject.NgCLMD);
            value.Add(userProject.NgBSB);

            value.Add(userProject.MccTXML);
            value.Add(userProject.MccCLMD);
            value.Add(userProject.MccBSB);

            value.Add(userProject.DcTXML);
            value.Add(userProject.DcCLMD);
            value.Add(userProject.DcBSB);

            value.Add(userProject.NgChuShiJiaoWeiYi);
            value.Add(userProject.NgChuShiSuDu);
            value.Add(userProject.McpChuShiJiaoWeiYi);
            value.Add(userProject.McpChuShiSuDu);
            value.Add(userProject.YouMoHouDu);
            value.Add(userProject.YouYeNianDu);
            value.Add(userProject.WenDu);

            value.Add(userProject.ShiJiJieChuChiShu);
            value.Add(userProject.FanTanXiShu);
            value.Add(userProject.NgZhuanSu);
            value.Add(userProject.NgZhenFu);
            value.Add(userProject.NgZhenPin);
            value.Add(userProject.JieGouZuNi);
            value.Add(userProject.McpZhuanDongGuanLiang);
            value.Add(userProject.NgZhuanDongGuanLiang);
            value.Add(userProject.JieChuQuJinXiangChuangDu);
            value.Add(userProject.JieChuQuZhouXiangChangDu);
            value.Add(userProject.QiDongShiJian);
            value.Add(userProject.ZengSuShiJian);
            value.Add(userProject.WenDingShiJian);
            value.Add(userProject.TingZhiShiJIan);

            value.Add(userProject.PianXinJu);
            value.Add(userProject.JieJuZuiDaWuCha);
            value.Add(userProject.JieJuZuiXiaoWuCha);
            value.Add(userProject.CaiYangPinLv);
            value.Add(userProject.YinLiYingBianZhuanHuanXiShu);
            value.Add(userProject.MccJingKuan);
            value.Add(userProject.McpHouDu);

            value.Add(userProject.NgChiDingGao);
            value.Add(userProject.NgChiGenGao);
            value.Add(userProject.McpGFXDGC);
            value.Add(userProject.NgGFXCDGC);
            value.Add(userProject.ZuNiCaoChang);
            value.Add(userProject.ZuNiCaoKuan);
            value.Add(userProject.ZuNiCaoBanJing);
            value.Add(userProject.NgChiGenYuanJiao);
            DB.XmlHelper.UpdatePara(paraPath, value);
        }
        public  void loopSetValue(List<string> value)
        {
            //摩擦片设计参数 10                           
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
        }
        public void loopSetLibValue(List<string> libData)
        {
            //摩擦片设计参数 10                           
            //userProject.ProjectPath = value[1];
            //userProject.ProjectName = value[2];
            DB.UserProject temp = new DB.UserProject();

            temp.ProjectPath = UserProject.ProjectPath;
            temp.ProjectName = UserProject.ProjectName;
            temp.ChiShu = libData[1];//齿数          
            temp.MoShu = libData[2];//模数           
            temp.YaLiJiao = libData[3];//压力角      
            temp.McpChiDingGao = libData[4];//齿顶高 
            temp.McpChiGenGao = libData[5];//齿根高  
            temp.McpChiGenYuanJiao = libData[6];//齿根
            temp.WaiJing = libData[7];//外径         
            temp.ChiCeJianXi = libData[8];//齿侧间隙
            temp.KongJing = libData[9];//孔径
            temp.NgHouDu = libData[10];//厚度

            //摩擦片强化参数 2
            temp.MccHouDu = libData[11];//摩擦层厚度
            temp.DuCengHouDu = libData[12];//镀层厚度

            //材料参数 14
            //摩擦片
            temp.McpTXML = libData[13];//摩擦片弹性模量
            temp.McpCLMD = libData[14];//摩擦片材料密度
            temp.McpBSB = libData[15];//摩擦片泊松比
            temp.KangLaQDJX = libData[16];//抗拉强度极限
            temp.PiLaoJiXian = libData[17];//疲劳极限
            //内毂
            temp.NgTXML = libData[18];//内毂弹性模量
            temp.NgCLMD = libData[19];//内毂材料密度
            temp.NgBSB = libData[20];//内毂泊松比
            //摩擦层
            temp.MccTXML = libData[21];//摩擦层弹性模量
            temp.MccCLMD = libData[22];//摩擦层材料密度
            temp.MccBSB = libData[23];//摩擦层泊松比
            //镀层
            temp.DcTXML = libData[24];//镀层弹性模量
            temp.DcCLMD = libData[25];//镀层材料密度
            temp.DcBSB = libData[26];//镀层泊松比
            //仿真参数
            //初始条件 7
            temp.NgChuShiJiaoWeiYi = libData[27];//内毂初始角位移
            temp.NgChuShiSuDu = libData[28];//内毂初始速度
            temp.McpChuShiJiaoWeiYi = libData[29];//摩擦片初始角位移
            temp.McpChuShiSuDu = libData[30];//摩擦片初始速度
            temp.YouMoHouDu = libData[31];//油膜厚度
            temp.YouYeNianDu = libData[32];//油膜粘度
            temp.WenDu = libData[33];//温度
            //计算条件 14
            temp.ShiJiJieChuChiShu = libData[34];//实际接触齿数
            temp.FanTanXiShu = libData[35];//反弹系数
            temp.NgZhuanSu = libData[36];//内毂转速
            temp.NgZhenFu = libData[37];//内毂振幅
            temp.NgZhenPin = libData[38];//内毂振频
            temp.JieGouZuNi = libData[39];//结构阻尼
            temp.McpZhuanDongGuanLiang = libData[40];//摩擦片转动惯量
            temp.NgZhuanDongGuanLiang = libData[41];//内毂转动惯量
            temp.JieChuQuJinXiangChuangDu = libData[42];//接触区径向长度
            temp.JieChuQuZhouXiangChangDu = libData[43];//接触区轴向长度
            temp.QiDongShiJian = libData[44];//启动时间
            temp.ZengSuShiJian = libData[45];//增速时间
            temp.WenDingShiJian = libData[46];//稳定时间
            temp.TingZhiShiJIan = libData[47];//停止时间
            //误差条件 3
            temp.PianXinJu = libData[48];//偏心距
            temp.JieJuZuiDaWuCha = libData[49];//节距最大误差
            temp.JieJuZuiXiaoWuCha = libData[50];//节距最小误差
            //实验数据标定与转换系数 2
            temp.CaiYangPinLv = libData[51];//采样频率
            temp.YinLiYingBianZhuanHuanXiShu = libData[52];//应力应变转换系数
            temp.MccJingKuan = libData[53];
            temp.McpHouDu = libData[54];
            //增加的参数
            temp.NgChiDingGao = libData[55];//内毂齿顶高
            temp.NgChiGenGao = libData[56];//内毂齿根高
            temp.McpGFXDGC = libData[57];//摩擦片公法线长度公差
            temp.NgGFXCDGC = libData[58];//内毂公法线长度公差
            temp.ZuNiCaoChang = libData[59];//阻尼槽长
            temp.ZuNiCaoKuan = libData[60];//阻尼槽宽
            temp.ZuNiCaoBanJing = libData[61];//阻尼槽半径
            temp.NgChiGenYuanJiao = libData[62];//内毂齿根圆角
            UserProject = temp;
        }
    }
}
