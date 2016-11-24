using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.DB
{
    public class UserProject
    {
        private string _username;
        private string _userpassword;
        private string _usertype;
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword
        {
            set { _userpassword = value; }
            get { return _userpassword; }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }




        //项目基本参数
        private string _projectID;//项目ID
        public string ProjectID
        {
            set { _projectID = value; }
            get { return _projectID; }
        }
        private string _projectPath;//项目路径
        public string ProjectPath
        {
            set { _projectPath = value; }
            get { return _projectPath; }
        }
        private string _projectName;//项目名
        public string ProjectName
        {
            set { _projectName = value; }
            get { return _projectName; }
        }

        //摩擦片设计参数
        private string _chiShu;//齿数
        public string ChiShu
        {
            set { _chiShu = value; }
            get { return _chiShu; }
        }
        private string _moShu;//模数
        public string MoShu
        {
            set { _moShu = value; }
            get { return _moShu; }
        }
        private string _yaLiJiao;//压力角
        public string YaLiJiao
        {
            set { _yaLiJiao = value; }
            get { return _yaLiJiao; }
        }
        private string _mcpChiDingGao;//摩擦片齿顶高
        public string McpChiDingGao
        {
            set { _mcpChiDingGao = value; }
            get { return _mcpChiDingGao; }
        }
        private string _mcpChiGenGao;//摩擦片齿根高
        public string McpChiGenGao
        {
            set { _mcpChiGenGao = value; }
            get { return _mcpChiGenGao; }
        }
        private string _mcpChiGenYuanJiao;//摩擦片齿根圆角
        public string McpChiGenYuanJiao
        {
            set { _mcpChiGenYuanJiao = value; }
            get { return _mcpChiGenYuanJiao; }
        }
        private string _waiJing;//外径
        public string WaiJing
        {
            set { _waiJing = value; }
            get { return _waiJing; }
        }
        private string _mcpGFXDGC;//摩擦片公法线长度公差
        public string McpGFXDGC
        {
            set { _mcpGFXDGC = value; }
            get { return _mcpGFXDGC; }
        }
        private string _mcpHouDu;//摩擦片厚度
        public string McpHouDu
        {
            set { _mcpHouDu = value; }
            get { return _mcpHouDu; }
        }
        private string _chiCeJianXi;//尺侧间隙
        public string ChiCeJianXi
        {
            set { _chiCeJianXi = value; }
            get { return _chiCeJianXi; }
        }
        //内毂设计参数
        private string _ngChiDingGao;//内毂齿顶高
        public string NgChiDingGao
        {
            set { _ngChiDingGao = value; }
            get { return _ngChiDingGao; }
        }
        private string _ngChiGenGao;//内毂齿根高
        public string NgChiGenGao
        {
            set { _ngChiGenGao = value; }
            get { return _ngChiGenGao; }
        }
        private string _ngChiGenYuanJiao;//内毂齿根圆角
        public string NgChiGenYuanJiao
        {
            set { _ngChiGenYuanJiao = value; }
            get { return _ngChiGenYuanJiao; }
        }
        private string _kongJing;//孔径
        public string KongJing
        {
            set { _kongJing = value; }
            get { return _kongJing; }
        }
        private string _ngGFXCDGC;//内毂公法线长度公差
        public string NgGFXCDGC
        {
            set { _ngGFXCDGC = value; }
            get { return _ngGFXCDGC; }
        }
        private string _ngHouDu;//内毂厚度
        public string NgHouDu
        {
            set { _ngHouDu = value; }
            get { return _ngHouDu; }
        }
        //摩擦片强度参数
        private string _mccHouDu;//摩擦层厚度
        public string MccHouDu
        {
            set { _mccHouDu = value; }
            get { return _mccHouDu; }
        }
        private string _mccJingKuan;//摩擦层径宽
        public string MccJingKuan
        {
            set { _mccJingKuan = value; }
            get { return _mccJingKuan; }
        }
        private string _duCengHouDu;//镀层厚度
        public string DuCengHouDu
        {
            set { _duCengHouDu = value; }
            get { return _duCengHouDu; }
        }
        //材料参数
        private string _mcpTXML;//摩擦片弹性模量
        public string McpTXML
        {
            set { _mcpTXML = value; }
            get { return _mcpTXML; }
        }
        private string _mcpCLMD;//摩擦片材料密度
        public string McpCLMD
        {
            set { _mcpCLMD = value; }
            get { return _mcpCLMD; }
        }
        private string _mcpBSB;//摩擦片泊松比
        public string McpBSB
        {
            set { _mcpBSB = value; }
            get { return _mcpBSB; }
        }
        private string _kangLaQDJX;//抗拉强度极限
        public string KangLaQDJX
        {
            set { _kangLaQDJX = value; }
            get { return _kangLaQDJX; }
        }
        private string _piLaoJiXian;//疲劳极限
        public string PiLaoJiXian
        {
            set { _piLaoJiXian = value; }
            get { return _piLaoJiXian; }
        }
        private string _ngTXML;//内毂弹性模量
        public string NgTXML
        {
            set { _ngTXML = value; }
            get { return _ngTXML; }
        }
        private string _ngCLMD;//内毂材料密度
        public string NgCLMD
        {
            set { _ngCLMD = value; }
            get { return _ngCLMD; }
        }
        private string _ngBSB;//内毂泊松比
        public string NgBSB
        {
            set { _ngBSB = value; }
            get { return _ngBSB; }
        }
        private string _mccTXML;//摩擦层弹性模量
        public string MccTXML
        {
            set { _mccTXML = value; }
            get { return _mccTXML; }
        }
        private string _mccCLMD;//摩擦层材料密度
        public string MccCLMD
        {
            set { _mccCLMD = value; }
            get { return _mccCLMD; }
        }
        private string _mccBSB;//摩擦层泊松比
        public string MccBSB
        {
            set { _mccBSB = value; }
            get { return _mccBSB; }
        }
        private string _dcTXML;//镀层弹性模量
        public string DcTXML
        {
            set { _dcTXML = value; }
            get { return _dcTXML; }
        }
        private string _dcCLMD;//镀层材料密度
        public string DcCLMD
        {
            set { _dcCLMD = value; }
            get { return _dcCLMD; }
        }
        private string _dcBSB;//镀层泊松比
        public string DcBSB
        {
            set { _dcBSB = value; }
            get { return _dcBSB; }
        }
        //仿真参数
        private string _ngChuShiJiaoWeiYi;//内毂初始角位移
        public string NgChuShiJiaoWeiYi
        {
            set { _ngChuShiJiaoWeiYi = value; }
            get { return _ngChuShiJiaoWeiYi; }
        }
        private string _ngChuShiSuDu;//内毂初始速度
        public string NgChuShiSuDu
        {
            set { _ngChuShiSuDu = value; }
            get { return _ngChuShiSuDu; }
        }
        private string _mcpChuShiJiaoWeiYi;//摩擦片初始角位移
        public string McpChuShiJiaoWeiYi
        {
            set { _mcpChuShiJiaoWeiYi = value; }
            get { return _mcpChuShiJiaoWeiYi; }
        }
        private string _mcpChuShiSuDu;//摩擦片初始速度
        public string McpChuShiSuDu
        {
            set { _mcpChuShiSuDu = value; }
            get { return _mcpChuShiSuDu; }
        }
        private string _youMoHouDu;//油膜厚度
        public string YouMoHouDu
        {
            set { _youMoHouDu = value; }
            get { return _youMoHouDu; }
        }
        private string _youYeNianDu;//油液黏度
        public string YouYeNianDu
        {
            set { _youYeNianDu = value; }
            get { return _youYeNianDu; }
        }
        private string _wenDu;//温度
        public string WenDu
        {
            set { _wenDu = value; }
            get { return _wenDu; }
        }
        //计算条件
        private string _shiJiJieChuChiShu;//实际接触齿数
        public string ShiJiJieChuChiShu
        {
            set { _shiJiJieChuChiShu = value; }
            get { return _shiJiJieChuChiShu; }
        }
        private string _fanTanXiShu;//反弹系数
        public string FanTanXiShu
        {
            set { _fanTanXiShu = value; }
            get { return _fanTanXiShu; }
        }
        private string _ngZhuanSu;//内毂转速
        public string NgZhuanSu
        {
            set { _ngZhuanSu = value; }
            get { return _ngZhuanSu; }
        }
        private string _ngZhenFu;//内毂振幅
        public string NgZhenFu
        {
            set { _ngZhenFu = value; }
            get { return _ngZhenFu; }
        }
        private string _ngZhenPin;//内毂振频
        public string NgZhenPin
        {
            set { _ngZhenPin = value; }
            get { return _ngZhenPin; }
        }
        private string _jieGouZuNi;//结构阻尼
        public string JieGouZuNi
        {
            set { _jieGouZuNi = value; }
            get { return _jieGouZuNi; }
        }
        private string _mcpZhuanDongGuanLiang;//摩擦片转动惯量
        public string McpZhuanDongGuanLiang
        {
            set { _mcpZhuanDongGuanLiang = value; }
            get { return _mcpZhuanDongGuanLiang; }
        }
        private string _ngZhuanDongGuanLiang;//内毂转动惯量
        public string NgZhuanDongGuanLiang
        {
            set { _ngZhuanDongGuanLiang = value; }
            get { return _ngZhuanDongGuanLiang; }
        }
        private string _jieChuQuJinXiangChuangDu;//接触区径向长度
        public string JieChuQuJinXiangChuangDu
        {
            set { _jieChuQuJinXiangChuangDu = value; }
            get { return _jieChuQuJinXiangChuangDu; }
        }
        private string _jieChuQuZhouXiangChangDu;//接触区轴向长度
        public string JieChuQuZhouXiangChangDu
        {
            set { _jieChuQuZhouXiangChangDu = value; }
            get { return _jieChuQuZhouXiangChangDu; }
        }
        private string _zuNiCaoChang;//阻尼槽长
        public string ZuNiCaoChang
        {
            set { _zuNiCaoChang = value; }
            get { return _zuNiCaoChang; }
        }
        private string _zuNiCaoKuan;//阻尼槽宽
        public string ZuNiCaoKuan
        {
            set { _zuNiCaoKuan = value; }
            get { return _zuNiCaoKuan; }
        }
        private string _zuNiCaoBanJing;//阻尼槽半径
        public string ZuNiCaoBanJing
        {
            set { _zuNiCaoBanJing = value; }
            get { return _zuNiCaoBanJing; }
        }
        private string _qiDongShiJian;//启动时间
        public string QiDongShiJian
        {
            set { _qiDongShiJian = value; }
            get { return _qiDongShiJian; }
        }
        private string _zengSuShiJian;//增速时间
        public string ZengSuShiJian
        {
            set { _zengSuShiJian = value; }
            get { return _zengSuShiJian; }
        }
        private string _wenDingShiJian;//稳定时间
        public string WenDingShiJian
        {
            set { _wenDingShiJian = value; }
            get { return _wenDingShiJian; }
        }
        private string _tingZhiShiJIan;//停止时间
        public string TingZhiShiJIan
        {
            set { _tingZhiShiJIan = value; }
            get { return _tingZhiShiJIan; }
        }
        //误差条件
        private string _pianXinJu;//偏心距
        public string PianXinJu
        {
            set { _pianXinJu = value; }
            get { return _pianXinJu; }
        }
        private string _jieJuZuiDaWuCha;//节距最大误差
        public string JieJuZuiDaWuCha
        {
            set { _jieJuZuiDaWuCha = value; }
            get { return _jieJuZuiDaWuCha; }
        }
        private string _jieJuZuiXiaoWuCha;//节距最小误差
        public string JieJuZuiXiaoWuCha
        {
            set { _jieJuZuiXiaoWuCha = value; }
            get { return _jieJuZuiXiaoWuCha; }
        }
        //实验数据标定与转换系数
        private string _caiYangPinLv;//采样频率
        public string CaiYangPinLv
        {
            set { _caiYangPinLv = value; }
            get { return _caiYangPinLv; }
        }
        private string _yinLiYingBianZhuanHuanXiShu;//应力应变转换系数
        public string YinLiYingBianZhuanHuanXiShu
        {
            set { _yinLiYingBianZhuanHuanXiShu = value; }
            get { return _yinLiYingBianZhuanHuanXiShu; }
        }



    }
}
