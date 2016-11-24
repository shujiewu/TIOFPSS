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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.ComponentModel;
using TIOFPSS.DB;
namespace TIOFPSS.Dialog
{
    /// <summary>
    /// paraProperty.xaml 的交互逻辑
    /// </summary>
    public partial class paraProperty : Window
    {

        public paraProperty()
        {
            InitializeComponent();
            this.DataContext = new TIOFPSS.ViewModels.ParaLibViewModel();
            _propertyGrid.SelectedObject = FlateParameter.CreateFlateParameter(null);
        }

        [DisplayName("摩擦片参数")]
        [CategoryOrder("摩擦片设计参数", 1)]
        [CategoryOrder("内毂设计参数", 2)]
        [CategoryOrder("摩擦片强度参数", 3)]
        [CategoryOrder("材料参数", 4)]
        [CategoryOrder("仿真参数", 5)]
        [CategoryOrder("计算条件", 6)]
        [CategoryOrder("误差条件", 7)]
        [CategoryOrder("实验数据标定与转换系数", 8)]
        public class FlateParameter
        {
            public static FlateParameter CreateFlateParameter(List<string> libData)
            {
                var flateParameter = new FlateParameter();
                if (libData != null)
                {
                    //DB.BLLUserProject bll = new DB.BLLUserProject();
                    //List<string> result = new List<string>();
                    //result = bll.GetLibModel(flateName);
                    //List<string> result = new List<string>();

                    //result = temp.LibData[0];
                    flateParameter.ChiShu = libData[1];//齿数          
                    flateParameter.MoShu = libData[2];//模数           
                    flateParameter.YaLiJiao = libData[3];//压力角      
                    flateParameter.McpChiDingGao = libData[4];//齿顶高 
                    flateParameter.McpChiGenGao = libData[5];//齿根高  
                    flateParameter.McpChiGenYuanJiao = libData[6];//齿根
                    flateParameter.WaiJing = libData[7];//外径         
                    flateParameter.ChiCeJianXi = libData[8];//齿侧间隙
                    flateParameter.KongJing = libData[9];//孔径
                    flateParameter.NgHouDu = libData[10];//厚度

                    //摩擦片强化参数 2
                    flateParameter.MccHouDu = libData[11];//摩擦层厚度
                    flateParameter.DuCengHouDu = libData[12];//镀层厚度

                    //材料参数 14
                    //摩擦片
                    flateParameter.McpTXML = libData[13];//摩擦片弹性模量
                    flateParameter.McpCLMD = libData[14];//摩擦片材料密度
                    flateParameter.McpBSB = libData[15];//摩擦片泊松比
                    flateParameter.KangLaQDJX = libData[16];//抗拉强度极限
                    flateParameter.PiLaoJiXian = libData[17];//疲劳极限
                    //内毂
                    flateParameter.NgTXML = libData[18];//内毂弹性模量
                    flateParameter.NgCLMD = libData[19];//内毂材料密度
                    flateParameter.NgBSB = libData[20];//内毂泊松比
                    //摩擦层
                    flateParameter.MccTXML = libData[21];//摩擦层弹性模量
                    flateParameter.MccCLMD = libData[22];//摩擦层材料密度
                    flateParameter.MccBSB = libData[23];//摩擦层泊松比
                    //镀层
                    flateParameter.DcTXML = libData[24];//镀层弹性模量
                    flateParameter.DcCLMD = libData[25];//镀层材料密度
                    flateParameter.DcBSB = libData[26];//镀层泊松比
                    //仿真参数
                    //初始条件 7
                    flateParameter.NgChuShiJiaoWeiYi = libData[27];//内毂初始角位移
                    flateParameter.NgChuShiSuDu = libData[28];//内毂初始速度
                    flateParameter.McpChuShiJiaoWeiYi = libData[29];//摩擦片初始角位移
                    flateParameter.McpChuShiSuDu = libData[30];//摩擦片初始速度
                    flateParameter.YouMoHouDu = libData[31];//油膜厚度
                    flateParameter.YouYeNianDu = libData[32];//油膜粘度
                    flateParameter.WenDu = libData[33];//温度
                    //计算条件 14
                    flateParameter.ShiJiJieChuChiShu = libData[34];//实际接触齿数
                    flateParameter.FanTanXiShu = libData[35];//反弹系数
                    flateParameter.NgZhuanSu = libData[36];//内毂转速
                    flateParameter.NgZhenFu = libData[37];//内毂振幅
                    flateParameter.NgZhenPin = libData[38];//内毂振频
                    flateParameter.JieGouZuNi = libData[39];//结构阻尼
                    flateParameter.McpZhuanDongGuanLiang = libData[40];//摩擦片转动惯量
                    flateParameter.NgZhuanDongGuanLiang = libData[41];//内毂转动惯量
                    flateParameter.JieChuQuJinXiangChuangDu = libData[42];//接触区径向长度
                    flateParameter.JieChuQuZhouXiangChangDu = libData[43];//接触区轴向长度
                    flateParameter.QiDongShiJian = libData[44];//启动时间
                    flateParameter.ZengSuShiJian = libData[45];//增速时间
                    flateParameter.WenDingShiJian = libData[46];//稳定时间
                    flateParameter.TingZhiShiJIan = libData[47];//停止时间
                    //误差条件 3
                    flateParameter.PianXinJu = libData[48];//偏心距
                    flateParameter.JieJuZuiDaWuCha = libData[49];//节距最大误差
                    flateParameter.JieJuZuiXiaoWuCha = libData[50];//节距最小误差
                    //实验数据标定与转换系数 2
                    flateParameter.CaiYangPinLv = libData[51];//采样频率
                    flateParameter.YinLiYingBianZhuanHuanXiShu = libData[52];//应力应变转换系数
                    flateParameter.MccJingKuan = libData[53];
                    flateParameter.McpHouDu = libData[54];
                    //增加的参数
                    flateParameter.NgChiDingGao = libData[55];//内毂齿顶高
                    flateParameter.NgChiGenGao = libData[56];//内毂齿根高
                    flateParameter.McpGFXDGC = libData[57];//摩擦片公法线长度公差
                    flateParameter.NgGFXCDGC = libData[58];//内毂公法线长度公差
                    flateParameter.ZuNiCaoChang = libData[59];//阻尼槽长
                    flateParameter.ZuNiCaoKuan = libData[60];//阻尼槽宽
                    flateParameter.ZuNiCaoBanJing = libData[61];//阻尼槽半径
                    flateParameter.NgChiGenYuanJiao = libData[62];//内毂齿根圆角
                }
                else
                {

                }






                //flateParameter.ChiShu = result.ChiShu;//齿数          
                //flateParameter.MoShu = result.MoShu;//模数           
                //flateParameter.YaLiJiao = result.YaLiJiao;//压力角      
                //flateParameter.McpChiDingGao = result.McpChiDingGao;//齿顶高 
                //flateParameter.McpChiGenGao = result.McpChiGenGao;//齿根高  
                //flateParameter.McpChiGenYuanJiao = result.McpChiGenYuanJiao;//齿根
                //flateParameter.WaiJing = result.WaiJing;//外径         
                //flateParameter.ChiCeJianXi = result.ChiCeJianXi;//齿侧间隙
                //flateParameter.KongJing = result.KongJing;//孔径
                //flateParameter.NgHouDu = result.NgHouDu;//厚度

                ////摩擦片强化参数 2
                //flateParameter.MccHouDu = result.MccHouDu;//摩擦层厚度
                //flateParameter.DuCengHouDu = result.DuCengHouDu;//镀层厚度

                ////材料参数 14
                ////摩擦片
                //flateParameter.McpTXML = result.McpTXML;//摩擦片弹性模量
                //flateParameter.McpCLMD = result.McpCLMD;//摩擦片材料密度
                //flateParameter.McpBSB = result.McpBSB;//摩擦片泊松比
                //flateParameter.KangLaQDJX = result.KangLaQDJX;//抗拉强度极限
                //flateParameter.PiLaoJiXian = result.PiLaoJiXian;//疲劳极限
                ////内毂
                //flateParameter.NgTXML = result.NgTXML;//内毂弹性模量
                //flateParameter.NgCLMD = result.NgCLMD;//内毂材料密度
                //flateParameter.NgBSB = result.NgBSB;//内毂泊松比
                ////摩擦层
                //flateParameter.MccTXML = result.MccTXML;//摩擦层弹性模量
                //flateParameter.MccCLMD = result.MccCLMD;//摩擦层材料密度
                //flateParameter.MccBSB = result.MccBSB;//摩擦层泊松比
                ////镀层
                //flateParameter.DcTXML = result.DcTXML;//镀层弹性模量
                //flateParameter.DcCLMD = result.DcCLMD;//镀层材料密度
                //flateParameter.DcBSB = result.DcBSB;//镀层泊松比
                ////仿真参数
                ////初始条件 7
                //flateParameter.NgChuShiJiaoWeiYi = result.NgChuShiJiaoWeiYi;//内毂初始角位移
                //flateParameter.NgChuShiSuDu = result.NgChuShiSuDu;//内毂初始速度
                //flateParameter.McpChuShiJiaoWeiYi = result.McpChuShiJiaoWeiYi;//摩擦片初始角位移
                //flateParameter.McpChuShiSuDu = result.McpChuShiSuDu;//摩擦片初始速度
                //flateParameter.YouMoHouDu = result.YouMoHouDu;//油膜厚度
                //flateParameter.YouYeNianDu = result.YouYeNianDu;//油膜粘度
                //flateParameter.WenDu = result.WenDu;//温度
                ////计算条件 14
                //flateParameter.ShiJiJieChuChiShu = result.ShiJiJieChuChiShu;//实际接触齿数
                //flateParameter.FanTanXiShu = result.FanTanXiShu;//反弹系数
                //flateParameter.NgZhuanSu = result.NgZhuanSu;//内毂转速
                //flateParameter.NgZhenFu = result.NgZhenFu;//内毂振幅
                //flateParameter.NgZhenPin = result.NgZhenPin;//内毂振频
                //flateParameter.JieGouZuNi = result.JieGouZuNi;//结构阻尼
                //flateParameter.McpZhuanDongGuanLiang = result.McpZhuanDongGuanLiang;//摩擦片转动惯量
                //flateParameter.NgZhuanDongGuanLiang = result.NgZhuanDongGuanLiang;//内毂转动惯量
                //flateParameter.JieChuQuJinXiangChuangDu = result.JieChuQuJinXiangChuangDu;//接触区径向长度
                //flateParameter.JieChuQuZhouXiangChangDu = result.JieChuQuZhouXiangChangDu;//接触区轴向长度
                //flateParameter.QiDongShiJian = result.QiDongShiJian;//启动时间
                //flateParameter.ZengSuShiJian = result.ZengSuShiJian;//增速时间
                //flateParameter.WenDingShiJian = result.WenDingShiJian;//稳定时间
                //flateParameter.TingZhiShiJIan = result.TingZhiShiJIan;//停止时间
                ////误差条件 3
                //flateParameter.PianXinJu = result.PianXinJu;//偏心距
                //flateParameter.JieJuZuiDaWuCha = result.JieJuZuiDaWuCha;//节距最大误差
                //flateParameter.JieJuZuiXiaoWuCha = result.JieJuZuiXiaoWuCha;//节距最小误差
                ////实验数据标定与转换系数 2
                //flateParameter.CaiYangPinLv = result.CaiYangPinLv;//采样频率
                //flateParameter.YinLiYingBianZhuanHuanXiShu = result.YinLiYingBianZhuanHuanXiShu;//应力应变转换系数
                //flateParameter.MccJingKuan = result.MccJingKuan;
                //flateParameter.McpHouDu = result.McpHouDu;
                ////增加的参数
                //flateParameter.NgChiDingGao = result.NgChiDingGao;//内毂齿顶高
                //flateParameter.NgChiGenGao = result.NgChiGenGao;//内毂齿根高
                //flateParameter.McpGFXDGC = result.McpGFXDGC;//摩擦片公法线长度公差
                //flateParameter.NgGFXCDGC = result.NgGFXCDGC;//内毂公法线长度公差
                //flateParameter.ZuNiCaoChang = result.ZuNiCaoChang;//阻尼槽长
                //flateParameter.ZuNiCaoKuan = result.ZuNiCaoKuan;//阻尼槽宽
                //flateParameter.ZuNiCaoBanJing = result.ZuNiCaoBanJing;//阻尼槽半径
                //flateParameter.NgChiGenYuanJiao = result.NgChiGenYuanJiao;//内毂齿根圆角


                return flateParameter;
            }
            ////项目基本参数
            //private string _projectID;//项目ID
            //public string ProjectID
            //{
            //    set { _projectID = value; }
            //    get { return _projectID; }
            //}
            //private string _projectPath;//项目路径
            //public string ProjectPath
            //{
            //    set { _projectPath = value; }
            //    get { return _projectPath; }
            //}
            //private string _projectName;//项目名
            //public string ProjectName
            //{
            //    set { _projectName = value; }
            //    get { return _projectName; }
            //}

            //摩擦片设计参数

            private string _chiShu;//齿数
            [Category("摩擦片设计参数")]
            [DisplayName("齿数")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string ChiShu
            {
                set { _chiShu = value; }
                get { return _chiShu; }
            }
            private string _moShu;//模数
            [Category("摩擦片设计参数")]
            [DisplayName("模数")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string MoShu
            {
                set { _moShu = value; }
                get { return _moShu; }
            }
            private string _yaLiJiao;//压力角
            [Category("摩擦片设计参数")]
            [DisplayName("压力角")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string YaLiJiao
            {
                set { _yaLiJiao = value; }
                get { return _yaLiJiao; }
            }
            private string _mcpChiDingGao;//摩擦片齿顶高
            [Category("摩擦片设计参数")]
            [DisplayName("摩擦片齿顶高")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(3)]
            public string McpChiDingGao
            {
                set { _mcpChiDingGao = value; }
                get { return _mcpChiDingGao; }
            }
            private string _mcpChiGenGao;//摩擦片齿根高
            [Category("摩擦片设计参数")]
            [DisplayName("摩擦片齿根高")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(4)]
            public string McpChiGenGao
            {
                set { _mcpChiGenGao = value; }
                get { return _mcpChiGenGao; }
            }
            private string _mcpChiGenYuanJiao;//摩擦片齿根圆角
            [PropertyOrder(5)]
            [Category("摩擦片设计参数")]
            [DisplayName("摩擦片齿根圆角")]
            [Description("This property uses a TextBox as the default editor.")]
            public string McpChiGenYuanJiao
            {
                set { _mcpChiGenYuanJiao = value; }
                get { return _mcpChiGenYuanJiao; }
            }
            private string _waiJing;//外径
            [Category("摩擦片设计参数")]
            [DisplayName("外径")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(6)]
            public string WaiJing
            {
                set { _waiJing = value; }
                get { return _waiJing; }
            }
            private string _mcpGFXDGC;//摩擦片公法线长度公差
            [Category("摩擦片设计参数")]
            [DisplayName("公法线长度公差")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(7)]
            public string McpGFXDGC
            {
                set { _mcpGFXDGC = value; }
                get { return _mcpGFXDGC; }
            }
            private string _mcpHouDu;//摩擦片厚度
            [Category("摩擦片设计参数")]
            [DisplayName("厚度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(8)]
            public string McpHouDu
            {
                set { _mcpHouDu = value; }
                get { return _mcpHouDu; }
            }
            private string _chiCeJianXi;//尺侧间隙
            [Category("摩擦片设计参数")]
            [DisplayName("齿侧间隙")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(9)]
            public string ChiCeJianXi
            {
                set { _chiCeJianXi = value; }
                get { return _chiCeJianXi; }
            }
            //内毂设计参数
            private string _ngChiDingGao;//内毂齿顶高
            [Category("内毂设计参数")]
            [DisplayName("内毂齿顶高")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string NgChiDingGao
            {
                set { _ngChiDingGao = value; }
                get { return _ngChiDingGao; }
            }
            private string _ngChiGenGao;//内毂齿根高
            [Category("内毂设计参数")]
            [DisplayName("内毂齿根高")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string NgChiGenGao
            {
                set { _ngChiGenGao = value; }
                get { return _ngChiGenGao; }
            }
            private string _ngChiGenYuanJiao;//内毂齿根圆角
            [Category("内毂设计参数")]
            [DisplayName("内毂齿根圆角")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string NgChiGenYuanJiao
            {
                set { _ngChiGenYuanJiao = value; }
                get { return _ngChiGenYuanJiao; }
            }
            private string _kongJing;//孔径
            [Category("内毂设计参数")]
            [DisplayName("孔径")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(3)]
            public string KongJing
            {
                set { _kongJing = value; }
                get { return _kongJing; }
            }
            private string _ngGFXCDGC;//内毂公法线长度公差
            [Category("内毂设计参数")]
            [DisplayName("内毂公法线长度公差")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(4)]
            public string NgGFXCDGC
            {
                set { _ngGFXCDGC = value; }
                get { return _ngGFXCDGC; }
            }
            private string _ngHouDu;//内毂厚度
            [Category("内毂设计参数")]
            [DisplayName("内毂厚度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(5)]
            public string NgHouDu
            {
                set { _ngHouDu = value; }
                get { return _ngHouDu; }
            }
            //摩擦片强度参数
            private string _mccHouDu;//摩擦层厚度
            [Category("摩擦片强度参数")]
            [DisplayName("摩擦层厚度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string MccHouDu
            {
                set { _mccHouDu = value; }
                get { return _mccHouDu; }
            }
            private string _mccJingKuan;//摩擦层径宽
            [Category("摩擦片强度参数")]
            [DisplayName("摩擦层径宽")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string MccJingKuan
            {
                set { _mccJingKuan = value; }
                get { return _mccJingKuan; }
            }
            private string _duCengHouDu;//镀层厚度
            [Category("摩擦片强度参数")]
            [DisplayName("镀层厚度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string DuCengHouDu
            {
                set { _duCengHouDu = value; }
                get { return _duCengHouDu; }
            }
            //材料参数
            private string _mcpTXML;//摩擦片弹性模量
            [Category("材料参数")]
            [DisplayName("摩擦片弹性模量")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string McpTXML
            {
                set { _mcpTXML = value; }
                get { return _mcpTXML; }
            }
            private string _mcpCLMD;//摩擦片材料密度
            [Category("材料参数")]
            [DisplayName("摩擦片材料密度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string McpCLMD
            {
                set { _mcpCLMD = value; }
                get { return _mcpCLMD; }
            }
            private string _mcpBSB;//摩擦片泊松比
            [Category("材料参数")]
            [DisplayName("摩擦片泊松比")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string McpBSB
            {
                set { _mcpBSB = value; }
                get { return _mcpBSB; }
            }
            private string _kangLaQDJX;//抗拉强度极限
            [Category("材料参数")]
            [DisplayName("抗拉强度极限")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(3)]
            public string KangLaQDJX
            {
                set { _kangLaQDJX = value; }
                get { return _kangLaQDJX; }
            }
            private string _piLaoJiXian;//疲劳极限
            [Category("材料参数")]
            [DisplayName("疲劳极限")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(4)]
            public string PiLaoJiXian
            {
                set { _piLaoJiXian = value; }
                get { return _piLaoJiXian; }
            }
            private string _ngTXML;//内毂弹性模量
            [Category("材料参数")]
            [DisplayName("内毂弹性模量")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(5)]
            public string NgTXML
            {
                set { _ngTXML = value; }
                get { return _ngTXML; }
            }
            private string _ngCLMD;//内毂材料密度
            [Category("材料参数")]
            [DisplayName("内毂材料密度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(6)]
            public string NgCLMD
            {
                set { _ngCLMD = value; }
                get { return _ngCLMD; }
            }
            private string _ngBSB;//内毂泊松比
            [Category("材料参数")]
            [DisplayName("内毂泊松比")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(7)]
            public string NgBSB
            {
                set { _ngBSB = value; }
                get { return _ngBSB; }
            }
            private string _mccTXML;//摩擦层弹性模量
            [Category("材料参数")]
            [DisplayName("摩擦层弹性模量")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(8)]
            public string MccTXML
            {
                set { _mccTXML = value; }
                get { return _mccTXML; }
            }
            private string _mccCLMD;//摩擦层材料密度
            [Category("材料参数")]
            [DisplayName("摩擦层材料密度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(9)]
            public string MccCLMD
            {
                set { _mccCLMD = value; }
                get { return _mccCLMD; }
            }
            private string _mccBSB;//摩擦层泊松比
            [Category("材料参数")]
            [DisplayName("摩擦层泊松比")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(10)]
            public string MccBSB
            {
                set { _mccBSB = value; }
                get { return _mccBSB; }
            }
            private string _dcTXML;//镀层弹性模量
            [Category("材料参数")]
            [DisplayName("镀层弹性模量")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(11)]
            public string DcTXML
            {
                set { _dcTXML = value; }
                get { return _dcTXML; }
            }
            private string _dcCLMD;//镀层材料密度
            [Category("材料参数")]
            [DisplayName("镀层材料密度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(12)]
            public string DcCLMD
            {
                set { _dcCLMD = value; }
                get { return _dcCLMD; }
            }
            private string _dcBSB;//镀层泊松比
            [Category("材料参数")]
            [DisplayName("镀层泊松比")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(13)]
            public string DcBSB
            {
                set { _dcBSB = value; }
                get { return _dcBSB; }
            }
            //仿真参数
            private string _ngChuShiJiaoWeiYi;//内毂初始角位移
            [Category("仿真参数")]
            [DisplayName("内毂初始角位移")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string NgChuShiJiaoWeiYi
            {
                set { _ngChuShiJiaoWeiYi = value; }
                get { return _ngChuShiJiaoWeiYi; }
            }


            private string _ngChuShiSuDu;//内毂初始速度
            [Category("仿真参数")]
            [DisplayName("内毂初始速度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string NgChuShiSuDu
            {
                set { _ngChuShiSuDu = value; }
                get { return _ngChuShiSuDu; }
            }
            private string _mcpChuShiJiaoWeiYi;//摩擦片初始角位移
            [Category("仿真参数")]
            [DisplayName("摩擦片初始角位移")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string McpChuShiJiaoWeiYi
            {
                set { _mcpChuShiJiaoWeiYi = value; }
                get { return _mcpChuShiJiaoWeiYi; }
            }
            private string _mcpChuShiSuDu;//摩擦片初始速度
            [Category("仿真参数")]
            [DisplayName("摩擦片初始速度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(3)]
            public string McpChuShiSuDu
            {
                set { _mcpChuShiSuDu = value; }
                get { return _mcpChuShiSuDu; }
            }
            private string _youMoHouDu;//油膜厚度
            [Category("仿真参数")]
            [DisplayName("油膜厚度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(4)]
            public string YouMoHouDu
            {
                set { _youMoHouDu = value; }
                get { return _youMoHouDu; }
            }
            private string _youYeNianDu;//油液黏度
            [Category("仿真参数")]
            [DisplayName("油膜黏度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(5)]
            public string YouYeNianDu
            {
                set { _youYeNianDu = value; }
                get { return _youYeNianDu; }
            }
            private string _wenDu;//温度
            [Category("仿真参数")]
            [DisplayName("温度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(6)]
            public string WenDu
            {
                set { _wenDu = value; }
                get { return _wenDu; }
            }
            //计算条件
            private string _shiJiJieChuChiShu;//实际接触齿数
            [Category("计算条件")]
            [DisplayName("实际接触齿数")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string ShiJiJieChuChiShu
            {
                set { _shiJiJieChuChiShu = value; }
                get { return _shiJiJieChuChiShu; }
            }
            private string _fanTanXiShu;//反弹系数
            [Category("计算条件")]
            [DisplayName("反弹系数")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string FanTanXiShu
            {
                set { _fanTanXiShu = value; }
                get { return _fanTanXiShu; }
            }
            private string _ngZhuanSu;//内毂转速
            [Category("计算条件")]
            [DisplayName("内毂转速")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string NgZhuanSu
            {
                set { _ngZhuanSu = value; }
                get { return _ngZhuanSu; }
            }
            private string _ngZhenFu;//内毂振幅
            [Category("计算条件")]
            [DisplayName("内毂振幅")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(3)]
            public string NgZhenFu
            {
                set { _ngZhenFu = value; }
                get { return _ngZhenFu; }
            }
            private string _ngZhenPin;//内毂振频
            [Category("计算条件")]
            [DisplayName("内毂振频")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(4)]
            public string NgZhenPin
            {
                set { _ngZhenPin = value; }
                get { return _ngZhenPin; }
            }
            private string _jieGouZuNi;//结构阻尼
            [Category("计算条件")]
            [DisplayName("结构阻尼")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(5)]
            public string JieGouZuNi
            {
                set { _jieGouZuNi = value; }
                get { return _jieGouZuNi; }
            }
            private string _mcpZhuanDongGuanLiang;//摩擦片转动惯量
            [Category("计算条件")]
            [DisplayName("摩擦片转动惯量")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(6)]
            public string McpZhuanDongGuanLiang
            {
                set { _mcpZhuanDongGuanLiang = value; }
                get { return _mcpZhuanDongGuanLiang; }
            }
            private string _ngZhuanDongGuanLiang;//内毂转动惯量
            [Category("计算条件")]
            [DisplayName("内毂转动惯量")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(7)]
            public string NgZhuanDongGuanLiang
            {
                set { _ngZhuanDongGuanLiang = value; }
                get { return _ngZhuanDongGuanLiang; }
            }
            private string _jieChuQuJinXiangChuangDu;//接触区径向长度
            [Category("计算条件")]
            [DisplayName("接触区径向长度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(8)]
            public string JieChuQuJinXiangChuangDu
            {
                set { _jieChuQuJinXiangChuangDu = value; }
                get { return _jieChuQuJinXiangChuangDu; }
            }
            private string _jieChuQuZhouXiangChangDu;//接触区轴向长度
            [Category("计算条件")]
            [DisplayName("接触区轴向长度")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(9)]
            public string JieChuQuZhouXiangChangDu
            {
                set { _jieChuQuZhouXiangChangDu = value; }
                get { return _jieChuQuZhouXiangChangDu; }
            }
            private string _zuNiCaoChang;//阻尼槽长
            [Category("计算条件")]
            [DisplayName("阻尼槽长")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(10)]
            public string ZuNiCaoChang
            {
                set { _zuNiCaoChang = value; }
                get { return _zuNiCaoChang; }
            }
            private string _zuNiCaoKuan;//阻尼槽宽
            [Category("计算条件")]
            [DisplayName("阻尼槽宽")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(11)]
            public string ZuNiCaoKuan
            {
                set { _zuNiCaoKuan = value; }
                get { return _zuNiCaoKuan; }
            }
            private string _zuNiCaoBanJing;//阻尼槽半径
            [Category("计算条件")]
            [DisplayName("阻尼槽半径")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(12)]
            public string ZuNiCaoBanJing
            {
                set { _zuNiCaoBanJing = value; }
                get { return _zuNiCaoBanJing; }
            }
            private string _qiDongShiJian;//启动时间
            [Category("计算条件")]
            [DisplayName("启动时间")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(13)]
            public string QiDongShiJian
            {
                set { _qiDongShiJian = value; }
                get { return _qiDongShiJian; }
            }
            private string _zengSuShiJian;//增速时间
            [Category("计算条件")]
            [DisplayName("增速时间")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(14)]
            public string ZengSuShiJian
            {
                set { _zengSuShiJian = value; }
                get { return _zengSuShiJian; }
            }
            private string _wenDingShiJian;//稳定时间
            [Category("计算条件")]
            [DisplayName("稳定时间")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(15)]
            public string WenDingShiJian
            {
                set { _wenDingShiJian = value; }
                get { return _wenDingShiJian; }
            }
            private string _tingZhiShiJIan;//停止时间
            [Category("计算条件")]
            [DisplayName("停止时间")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(16)]
            public string TingZhiShiJIan
            {
                set { _tingZhiShiJIan = value; }
                get { return _tingZhiShiJIan; }
            }
            //误差条件
            private string _pianXinJu;//偏心距
            [Category("误差条件")]
            [DisplayName("偏心距")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string PianXinJu
            {
                set { _pianXinJu = value; }
                get { return _pianXinJu; }
            }
            private string _jieJuZuiDaWuCha;//节距最大误差
            [Category("误差条件")]
            [DisplayName("节距最大误差")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string JieJuZuiDaWuCha
            {
                set { _jieJuZuiDaWuCha = value; }
                get { return _jieJuZuiDaWuCha; }
            }
            private string _jieJuZuiXiaoWuCha;//节距最小误差
            [Category("误差条件")]
            [DisplayName("节距最小误差")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(2)]
            public string JieJuZuiXiaoWuCha
            {
                set { _jieJuZuiXiaoWuCha = value; }
                get { return _jieJuZuiXiaoWuCha; }
            }
            //实验数据标定与转换系数
            private string _caiYangPinLv;//采样频率
            [Category("实验数据标定与转换系数")]
            [DisplayName("采样频率")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(0)]
            public string CaiYangPinLv
            {
                set { _caiYangPinLv = value; }
                get { return _caiYangPinLv; }
            }
            private string _yinLiYingBianZhuanHuanXiShu;//应力应变转换系数
            [Category("实验数据标定与转换系数")]
            [DisplayName("应力应变转换系数")]
            [Description("This property uses a TextBox as the default editor.")]
            [PropertyOrder(1)]
            public string YinLiYingBianZhuanHuanXiShu
            {
                set { _yinLiYingBianZhuanHuanXiShu = value; }
                get { return _yinLiYingBianZhuanHuanXiShu; }
            }

        }
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void OnDeleteLibClick(object sender, RoutedEventArgs e)
        {
            string selectName = lbxParaLib.SelectedItem.ToString();
            string flateName = selectName;
            DB.BLLUserProject bll = new DB.BLLUserProject();
            if(bll.DeleteLib(flateName)==true)
            {
                //
                //lbxParaLib.Items.RemoveAt(selectIndex);
                //foreach (var removedItem in lbxParaLib.SelectedItems)
                //{
                //    lbxParaLib.Items.Remove(removedItem);
                //    //(configSetListBox.ItemsSource as List<ConfigSet>).Remove(removedItem);
                //}
                int selectIndex = lbxParaLib.SelectedIndex;
                lbxParaLib.SelectedItem = null;
                _propertyGrid.SelectedObject = FlateParameter.CreateFlateParameter(null);
                TIOFPSS.ViewModels.ParaLibViewModel temp = (TIOFPSS.ViewModels.ParaLibViewModel)DataContext;
                temp.LibData.RemoveAt(selectIndex);
                temp.LibName.RemoveAt(selectIndex);
                //DataContext = temp;
                lbxParaLib.Items.Refresh();
                
                Xceed.Wpf.Toolkit.MessageBox.Show("删除成功！");
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("删除失败！");
            }
        }

        private void lbxParaLib_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbxParaLib.SelectedItem!=null)
            {
                //string selectName = lbxParaLib.SelectedItem.ToString();
                //string flateName = selectName;
                int selectIndex = lbxParaLib.SelectedIndex;
                TIOFPSS.ViewModels.ParaLibViewModel temp = (TIOFPSS.ViewModels.ParaLibViewModel)DataContext;
                //temp.LibData.RemoveAt(selectIndex);
                List<string> libData = temp.LibData[selectIndex];
                _propertyGrid.SelectedObject = FlateParameter.CreateFlateParameter(libData);

            }

        }
        public Helper.delgateApplyLibMethod CallBackMethod; 
        private void OnApplyLibClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;  
            if (this.DialogResult.Value && CallBackMethod != null)
            {
                int selectIndex = lbxParaLib.SelectedIndex;
                TIOFPSS.ViewModels.ParaLibViewModel temp = (TIOFPSS.ViewModels.ParaLibViewModel)DataContext;
                List<string> libData = temp.LibData[selectIndex];
                this.CallBackMethod(libData);
                this.Close();
            }
        }
    }
}
