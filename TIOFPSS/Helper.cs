using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS
{
    public class Helper
    {
        public delegate void delgateNewProjMethod(string projectName, string pathString);

        public delegate void delgateApplyLibMethod(List<string> para);

        public delegate void delgateDLZHP(List<TIOFPSS.Dialog.DSFileList> para);

        public delegate void delgateJingTaiQiangDuFenXiMethod(List<string> para);
        public delegate void delgateMoCaPianMoTaiJiSuanMethod(List<string> para);
        public delegate void delgateMcpNgMoTaiJiSuanMethod(List<string> para);
        public delegate void delgateDuCengShaoChiFenXiMethod(List<string> para);
        public delegate void delgateShaoChiYuYingLiFenXiMethod(List<string> para);
        public delegate void delgateQuanChiPianXinJiSuanMethod(List<string> para);
        public delegate void delgateDongTaiFenXiMethod(List<string> para);
        //public delegate void delgateShaoChiDongTaiFenXiMethod(List<string> para);
        public delegate void delgateDongTaiYingLiJiSuanMethod(List<string> para);


        public delegate void delgateWuJieJuWuChaFenXiFinish(bool finish);
        public delegate void delgateZaoShengFenXiFinish(bool finish);
        public delegate void delgateYouJieJuWuChaFenXiFinish(bool finish);
        public delegate void delgateDLZHPFinish(bool finish,string fileType);
        public delegate void delgateFXXSSFinish(bool finish, string fileType);

        public delegate void delgateJingTaiQiangDuFenXiFinish(bool finish);
        public delegate void delgateMoCaPianMoTaiJiSuanFinish(bool finish);
        public delegate void delgateMcpNgMoTaiJiSuanFinish(bool finish);
        public delegate void delgateDuCengShaoChiFenXiFinish(bool finish);
        public delegate void delgateShaoChiYuYingLiFenXiFinish(bool finish);
        public delegate void delgateQuanChiPianXinJiSuanFinish(bool finish);
        public delegate void delgateDongTaiFenXiFinish(bool finish);
        public delegate void delgateDongTaiYingLiJiSuanFinish(bool finish);

        public delegate void delgateFXXSS(TIOFPSS.Dialog.FXXSSFile para);

        public delegate void delgateShengChengBaoBiaoMethod(List<string> para);

        public delegate void delgateViewMoTaiResultOKMethod(int select,List<int> para);

        public static string [] str_AnsysTempPath=new string [12]{
	"ShaoChi",
	"DuCeng",
	"CuiHuo",
	"QuanChi",
	"DongTai",
	"ZhunDongTai",
	"MoChaPianMoTai",
	"MoChaPianNeiGuMoTai",
	"冲击动力学分析结果",
	"当量载荷谱分析结果",
	"非线性损伤分析结果",
	"噪声分析结果"};
       public static string[] str_FloderPath=new string [14]{//摩擦片项目文件的文件层次结构
	"参数文件",
	"冲击动力学分析文件",
	"当量载荷谱分析文件",
	"非线性损伤分析文件",
	"噪声分析结果",
	"协同分析",
	"协同分析\\少齿当量静态强度分析文件",
	"协同分析\\镀层少齿当量静态强度分析文件",
	"协同分析\\淬火少齿当量静态强度分析文件",
	"协同分析\\全齿静态强度分析",
	"协同分析\\准动态分析文件",
	"协同分析\\摩擦片模态分析文件",
	"协同分析\\摩擦片内毂模态分析文件",
	"协同分析\\动态分析文件"};
        public static string[] compareFilePath=new string [30]{//需要对比的条款（参数图片文件）的路径
	"\\冲击动力学分析结果\\摩擦片冲击力.png",
	"\\冲击动力学分析结果\\摩擦片冲击力频谱图.png",

	"\\冲击动力学分析结果\\摩擦片与内毂相对扭转角度.png",
	"\\冲击动力学分析结果\\相对扭转角度频谱图.png",

	"\\冲击动力学分析结果\\摩擦片与内毂相对旋转速度.png",
	"\\冲击动力学分析结果\\相对旋转速度频谱图.png",

	"\\冲击动力学分析结果\\内毂角加速度.png",
	"\\冲击动力学分析结果\\内毂加速度频谱图.png",

	"\\冲击动力学分析结果\\摩擦片角加速度.png",
	"\\冲击动力学分析结果\\摩擦片加速度频谱图.png",

	"\\冲击动力学分析结果\\内毂角速度.png",
	"\\冲击动力学分析结果\\内毂速度频谱图.png",

	"\\冲击动力学分析结果\\摩擦片角速度.png",
	"\\冲击动力学分析结果\\摩擦片速度频谱图.png",

	"\\冲击动力学分析结果\\摩擦片位移.png",
	"\\冲击动力学分析结果\\内毂位移.png",
	"\\噪声分析结果\\噪声分析.png",
	"\\非线性损伤分析结果\\摩擦片齿根应力时域波形.png",
	"\\非线性损伤分析结果\\摩擦片齿根应力频域波形.png",
	"\\非线性损伤分析结果\\摩擦片累计损伤.png",

	"\\当量载荷谱分析结果\\当量载荷谱.png",
	"\\当量载荷谱分析结果\\雨流计数结果.png",
	"\\ShaoChi\\danchiweiyiyuntu.jpeg",
	"\\ShaoChi\\danchiyingliyuntu.jpeg",
	"\\DuCeng\\ducengweiyiyuntu.jpeg",
	"\\DuCeng\\ducengyingliyuntu.jpeg",
	"\\QuanChi\\pianxinweiyiyuntu.jpeg",
	"\\QuanChi\\pianxinyingliyuntu.jpeg",
	"\\CuiHuo\\cuihuoweiyiyuntu.jpeg",
	"\\CuiHuo\\cuihuoyingliyuntu.jpeg"};



     public static string[] fileName=new string [30]{//需要对比的条款（参数图片文件）的文件名字
	"摩擦片冲击力",
	"摩擦片冲击力频谱图",

	"摩擦片与内毂相对扭转角度",
	"摩擦片与内毂相对扭转角度频谱图",

	"摩擦片与内毂相对旋转速度",
	"摩擦片与内毂相对旋转速度频谱图",

	"内毂角加速度",
	"内毂角加速度频谱图",

	"摩擦片角加速度",
	"摩擦片角加速度频谱图",

	"内毂角速度",
	"内毂角速度频谱图",

	"摩擦片角速度",
	"摩擦片角速度频谱图",

	"摩擦片位移",
	"内毂位移",

	"噪声分析",
	"摩擦片齿根应力时域波形",
	"摩擦片齿根应力频域波形",
	"摩擦片累计损伤",

	"当量载荷谱",
	"雨流计数结果",
	"少齿当量位移云图",
	"少齿当量应力云图",
	"镀层位移云图",
	"镀层应力云图",
	"全齿位移云图",
	"全齿应力云图",
	"淬火位移云图",
	"淬火应力云图"};


     public static string[] parNames=new string [62]{
	"齿数",
	"模数",
	"压力角",
	"摩擦片齿顶高",
	"摩擦片齿根高",
	"摩擦片齿根圆角",
	"外径",
	"齿侧间隙",
	"孔径",
	"内毂厚度",
	"摩擦层厚度",
	"镀层厚度",
	"摩擦片弹性模量",
	"摩擦片材料密度",
	"摩擦片泊松比",
	"抗拉强度极限",
	"疲劳极限",
	"内毂弹性模量",
	"内毂材料密度",
	"内毂泊松比",
	"摩擦层弹性模量",
	"摩擦层材料密度",
	"摩擦层泊松比",
	"镀层弹性模量",
	"镀层材料密度",
	"镀层泊松比",
	"内毂初始角位移",
	"内毂初始速度",
	"摩擦片初始角位移",
	"摩擦片初始速度",
	"油膜厚度",
	"油膜粘度",
	"温度",
	"实际接触齿数",
	"反弹系数",
	"内毂转速",
	"内毂振幅",
	"内毂振频",
	"结构阻尼",
	"摩擦片转动惯量",
	"内毂转动惯量",
	"接触区径向长度",
	"接触区轴向长度",
	"启动时间",
	"增速时间",
	"稳定时间",
	"停止时间",
	"偏心距",
	"节距最大误差",
	"节距最小误差",
	"采样频率",
	"应力应变转换系数",
	"摩擦层径宽",
	"摩擦片厚度",
	"内毂齿顶高",
	"内毂齿根高",
	"摩擦片公法线长度公差",
	"内毂公法线长度公差",
	"阻尼槽长",
	"阻尼槽宽",
	"阻尼槽半径",
	"内毂齿根圆角"};

    }
}
