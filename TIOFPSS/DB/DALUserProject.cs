using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIOFPSS.DB
{
    class DALUserProject
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(UserProject model)
        {
            List<string> hasProj = GetModel(model.ProjectPath);
            if (hasProj != null)
            {
                //Xceed.Wpf.Toolkit.MessageBox.Show("已存在同名参数库，请重新命名");
                return false;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Insert into projectInfo(");
                strSql.Append("项目路径,项目名, 齿数, 模数, 压力角, 齿顶高, 齿根高, 齿根圆角, 外径,齿侧间隙, 孔径, 厚度,摩擦层厚度, 镀层厚度, 摩擦片弹性模量, 摩擦片材料密度, 摩擦片泊松比, 抗拉强度极限, 疲劳极限, 内毂弹性模量, 内毂材料密度,内毂泊松比, 摩擦层弹性模量, 摩擦层材料密度, 摩擦层泊松比, 镀层弹性模量, 镀层材料密度, 镀层泊松比,内毂初始角位移, 内毂初始速度, 摩擦片初始角位移, 摩擦片初始速度, 油膜厚度, 油膜粘度, 温度, 实际接触齿数, 反弹系数, 内毂转速,内毂振幅, 内毂振频, 结构阻尼, 摩擦片转动惯量, 内毂转动惯量, 接触区径向长度, 接触区轴向长度, 启动时间, 增速时间, 稳定时间, 停止时间,偏心距, 节距最大误差, 节距最小误差, 采样频率, 应力应变转换系数,摩擦层径宽,摩擦片厚度,内毂齿顶高,内毂齿根高,摩擦片公法线长度公差,内毂公法线长度公差,阻尼槽长,阻尼槽宽,阻尼槽半径,内毂齿根圆角)");
                strSql.Append(" values (");
                strSql.Append("@项目路径, @项目名,@齿数, @模数, @压力角, @齿顶高, @齿根高, @齿根圆角, @外径,@齿侧间隙, @孔径, @厚度,@摩擦层厚度, @镀层厚度, @摩擦片弹性模量, @摩擦片材料密度, @摩擦片泊松比, @抗拉强度极限, @疲劳极限, @内毂弹性模量, @内毂材料密度,@内毂泊松比, @摩擦层弹性模量, @摩擦层材料密度, @摩擦层泊松比, @镀层弹性模量, @镀层材料密度, @镀层泊松比,@内毂初始角位移, @内毂初始速度, @摩擦片初始角位移, @摩擦片初始速度, @油膜厚度, @油膜粘度, @温度, @实际接触齿数, @反弹系数, @内毂转速,@内毂振幅, @内毂振频, @结构阻尼, @摩擦片转动惯量, @内毂转动惯量, @接触区径向长度, @接触区轴向长度, @启动时间, @增速时间, @稳定时间, @停止时间,@偏心距, @节距最大误差, @节距最小误差, @采样频率, @应力应变转换系数,@摩擦层径宽,@摩擦片厚度,@内毂齿顶高,@内毂齿根高,@摩擦片公法线长度公差,@内毂公法线长度公差,@阻尼槽长,@阻尼槽宽,@阻尼槽半径,@内毂齿根圆角)");

                SQLiteParameter[] parameters = new SQLiteParameter[]{                 
                    new SQLiteParameter("@项目路径",model.ProjectPath), 
                    new SQLiteParameter("@项目名",model.ProjectName),      
                    new SQLiteParameter("@齿数",model.ChiShu),                    
                    new SQLiteParameter("@模数",model.MoShu),                        
                    new SQLiteParameter("@压力角",model.YaLiJiao),                
                    new SQLiteParameter("@齿顶高",model.McpChiDingGao),           
                    new SQLiteParameter("@齿根高",model.McpChiGenGao),            
                    new SQLiteParameter("@齿根圆角",model.McpChiGenYuanJiao),                    
                    new SQLiteParameter("@外径",model.WaiJing),                        
                    new SQLiteParameter("@齿侧间隙",model.ChiCeJianXi),                 
                    new SQLiteParameter("@孔径",model.KongJing),                    
                    new SQLiteParameter("@厚度",model.NgHouDu),                     
                    new SQLiteParameter("@摩擦层厚度",model.MccHouDu),              
                    new SQLiteParameter("@镀层厚度",model.DuCengHouDu),             
                    new SQLiteParameter("@摩擦片弹性模量",model.McpTXML),           
                    new SQLiteParameter("@摩擦片材料密度",model.McpCLMD),           
                    new SQLiteParameter("@摩擦片泊松比",model.McpBSB),              
                    new SQLiteParameter("@抗拉强度极限",model.KangLaQDJX),               
                    new SQLiteParameter("@疲劳极限",model.PiLaoJiXian),             
                    new SQLiteParameter("@内毂弹性模量",model.NgTXML),              
                    new SQLiteParameter("@内毂材料密度",model.NgCLMD),              
                    new SQLiteParameter("@内毂泊松比",model.NgBSB),                 
                    new SQLiteParameter("@摩擦层弹性模量",model.MccTXML),           
                    new SQLiteParameter("@摩擦层材料密度",model.MccCLMD),           
                    new SQLiteParameter("@摩擦层泊松比",model.MccBSB),              
                    new SQLiteParameter("@镀层弹性模量",model.DcTXML),              
                    new SQLiteParameter("@镀层材料密度",model.DcCLMD),              
                    new SQLiteParameter("@镀层泊松比",model.DcBSB),                    
                    new SQLiteParameter("@内毂初始角位移",model.NgChuShiJiaoWeiYi),    
                    new SQLiteParameter("@内毂初始速度",model.NgChuShiSuDu),           
                    new SQLiteParameter("@摩擦片初始角位移",model.McpChuShiJiaoWeiYi), 
                    new SQLiteParameter("@摩擦片初始速度",model.McpChuShiSuDu),        
                    new SQLiteParameter("@油膜厚度",model.YouYeNianDu),                
                    new SQLiteParameter("@油膜粘度",model.YouYeNianDu),                
                    new SQLiteParameter("@温度",model.WenDu),                          
                    new SQLiteParameter("@实际接触齿数",model.ShiJiJieChuChiShu),      
                    new SQLiteParameter("@反弹系数",model.FanTanXiShu),                
                    new SQLiteParameter("@内毂转速",model.NgZhuanSu),                  
                    new SQLiteParameter("@内毂振幅",model.NgZhenFu),                   
                    new SQLiteParameter("@内毂振频",model.NgZhenPin),                  
                    new SQLiteParameter("@结构阻尼",model.JieGouZuNi),                 
                    new SQLiteParameter("@摩擦片转动惯量",model.McpZhuanDongGuanLiang),
                    new SQLiteParameter("@内毂转动惯量",model.NgZhuanDongGuanLiang),                 
                    new SQLiteParameter("@接触区径向长度",model.JieChuQuJinXiangChuangDu),         
                    new SQLiteParameter("@接触区轴向长度",model.JieChuQuZhouXiangChangDu),      
                    new SQLiteParameter("@启动时间",model.QiDongShiJian),                       
                    new SQLiteParameter("@增速时间",model.ZengSuShiJian),                
                    new SQLiteParameter("@稳定时间",model.WenDingShiJian),               
                    new SQLiteParameter("@停止时间",model.TingZhiShiJIan),               
                    new SQLiteParameter("@偏心距",model.PianXinJu),                      
                    new SQLiteParameter("@节距最大误差",model.JieJuZuiDaWuCha),          
                    new SQLiteParameter("@节距最小误差",model.JieJuZuiXiaoWuCha),              
                    new SQLiteParameter("@采样频率",model.CaiYangPinLv),                 
                    new SQLiteParameter("@应力应变转换系数",model.YinLiYingBianZhuanHuanXiShu), 
                    new SQLiteParameter("@摩擦层径宽",model.MccJingKuan),               
                    new SQLiteParameter("@摩擦片厚度",model.McpHouDu),                  
                    new SQLiteParameter("@内毂齿顶高",model.NgChiDingGao),              
                    new SQLiteParameter("@内毂齿根高",model.NgChiGenGao),               
                    new SQLiteParameter("@摩擦片公法线长度公差",model.McpGFXDGC),       
                    new SQLiteParameter("@内毂公法线长度公差",model.NgGFXCDGC),         
                    new SQLiteParameter("@阻尼槽长",model.ZuNiCaoChang),                
                    new SQLiteParameter("@阻尼槽宽",model.ZuNiCaoKuan),                 
                    new SQLiteParameter("@阻尼槽半径",model.ZuNiCaoBanJing),            
                    new SQLiteParameter("@内毂齿根圆角",model.NgChiGenYuanJiao)};
                int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool AddLatestProject(string path,string projectName,string date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into latestProject(");
            strSql.Append("项目路径,项目名,时间)");
            strSql.Append(" values (");
            strSql.Append("@项目路径,@项目名,@时间)");
            SQLiteParameter[] parameters = new SQLiteParameter[]{ 
                    new SQLiteParameter("@项目路径",path), 
                    new SQLiteParameter("@项目名",projectName),
                    new SQLiteParameter("@时间",date)};
            int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool AddLib(UserProject model)
        {
            List<string> hasLib=GetLibModel(model.ProjectName);
            if (hasLib!=null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("已存在同名参数库，请重新命名");
                return false;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Insert into platePara(");
                strSql.Append("片子名称, 齿数, 模数, 压力角, 齿顶高, 齿根高, 齿根圆角, 外径,齿侧间隙, 孔径, 厚度,摩擦层厚度, 镀层厚度, 摩擦片弹性模量, 摩擦片材料密度, 摩擦片泊松比, 抗拉强度极限, 疲劳极限, 内毂弹性模量, 内毂材料密度,内毂泊松比, 摩擦层弹性模量, 摩擦层材料密度, 摩擦层泊松比, 镀层弹性模量, 镀层材料密度, 镀层泊松比,内毂初始角位移, 内毂初始速度, 摩擦片初始角位移, 摩擦片初始速度, 油膜厚度, 油膜粘度, 温度, 实际接触齿数, 反弹系数, 内毂转速,内毂振幅, 内毂振频, 结构阻尼, 摩擦片转动惯量, 内毂转动惯量, 接触区径向长度, 接触区轴向长度, 启动时间, 增速时间, 稳定时间, 停止时间,偏心距, 节距最大误差, 节距最小误差, 采样频率, 应力应变转换系数,摩擦层径宽,摩擦片厚度,内毂齿顶高,内毂齿根高,摩擦片公法线长度公差,内毂公法线长度公差,阻尼槽长,阻尼槽宽,阻尼槽半径,内毂齿根圆角)");
                strSql.Append(" values (");
                strSql.Append("@片子名称, @齿数, @模数, @压力角, @齿顶高, @齿根高, @齿根圆角, @外径,@齿侧间隙, @孔径, @厚度,@摩擦层厚度, @镀层厚度, @摩擦片弹性模量, @摩擦片材料密度, @摩擦片泊松比, @抗拉强度极限, @疲劳极限, @内毂弹性模量, @内毂材料密度,@内毂泊松比, @摩擦层弹性模量, @摩擦层材料密度, @摩擦层泊松比, @镀层弹性模量, @镀层材料密度, @镀层泊松比,@内毂初始角位移, @内毂初始速度, @摩擦片初始角位移, @摩擦片初始速度, @油膜厚度, @油膜粘度, @温度, @实际接触齿数, @反弹系数, @内毂转速,@内毂振幅, @内毂振频, @结构阻尼, @摩擦片转动惯量, @内毂转动惯量, @接触区径向长度, @接触区轴向长度, @启动时间, @增速时间, @稳定时间, @停止时间,@偏心距, @节距最大误差, @节距最小误差, @采样频率, @应力应变转换系数,@摩擦层径宽,@摩擦片厚度,@内毂齿顶高,@内毂齿根高,@摩擦片公法线长度公差,@内毂公法线长度公差,@阻尼槽长,@阻尼槽宽,@阻尼槽半径,@内毂齿根圆角)");

                SQLiteParameter[] parameters = new SQLiteParameter[]{                 
                    new SQLiteParameter("@片子名称",model.ProjectName),           
                    new SQLiteParameter("@齿数",model.ChiShu),                    
                    new SQLiteParameter("@模数",model.MoShu),                        
                    new SQLiteParameter("@压力角",model.YaLiJiao),                
                    new SQLiteParameter("@齿顶高",model.McpChiDingGao),           
                    new SQLiteParameter("@齿根高",model.McpChiGenGao),            
                    new SQLiteParameter("@齿根圆角",model.McpChiGenYuanJiao),                    
                    new SQLiteParameter("@外径",model.WaiJing),                        
                    new SQLiteParameter("@齿侧间隙",model.ChiCeJianXi),                 
                    new SQLiteParameter("@孔径",model.KongJing),                    
                    new SQLiteParameter("@厚度",model.NgHouDu),                     
                    new SQLiteParameter("@摩擦层厚度",model.MccHouDu),              
                    new SQLiteParameter("@镀层厚度",model.DuCengHouDu),             
                    new SQLiteParameter("@摩擦片弹性模量",model.McpTXML),           
                    new SQLiteParameter("@摩擦片材料密度",model.McpCLMD),           
                    new SQLiteParameter("@摩擦片泊松比",model.McpBSB),              
                    new SQLiteParameter("@抗拉强度极限",model.KangLaQDJX),               
                    new SQLiteParameter("@疲劳极限",model.PiLaoJiXian),             
                    new SQLiteParameter("@内毂弹性模量",model.NgTXML),              
                    new SQLiteParameter("@内毂材料密度",model.NgCLMD),              
                    new SQLiteParameter("@内毂泊松比",model.NgBSB),                 
                    new SQLiteParameter("@摩擦层弹性模量",model.MccTXML),           
                    new SQLiteParameter("@摩擦层材料密度",model.MccCLMD),           
                    new SQLiteParameter("@摩擦层泊松比",model.MccBSB),              
                    new SQLiteParameter("@镀层弹性模量",model.DcTXML),              
                    new SQLiteParameter("@镀层材料密度",model.DcCLMD),              
                    new SQLiteParameter("@镀层泊松比",model.DcBSB),                    
                    new SQLiteParameter("@内毂初始角位移",model.NgChuShiJiaoWeiYi),    
                    new SQLiteParameter("@内毂初始速度",model.NgChuShiSuDu),           
                    new SQLiteParameter("@摩擦片初始角位移",model.McpChuShiJiaoWeiYi), 
                    new SQLiteParameter("@摩擦片初始速度",model.McpChuShiSuDu),        
                    new SQLiteParameter("@油膜厚度",model.YouYeNianDu),                
                    new SQLiteParameter("@油膜粘度",model.YouYeNianDu),                
                    new SQLiteParameter("@温度",model.WenDu),                          
                    new SQLiteParameter("@实际接触齿数",model.ShiJiJieChuChiShu),      
                    new SQLiteParameter("@反弹系数",model.FanTanXiShu),                
                    new SQLiteParameter("@内毂转速",model.NgZhuanSu),                  
                    new SQLiteParameter("@内毂振幅",model.NgZhenFu),                   
                    new SQLiteParameter("@内毂振频",model.NgZhenPin),                  
                    new SQLiteParameter("@结构阻尼",model.JieGouZuNi),                 
                    new SQLiteParameter("@摩擦片转动惯量",model.McpZhuanDongGuanLiang),
                    new SQLiteParameter("@内毂转动惯量",model.NgZhuanDongGuanLiang),                 
                    new SQLiteParameter("@接触区径向长度",model.JieChuQuJinXiangChuangDu),         
                    new SQLiteParameter("@接触区轴向长度",model.JieChuQuZhouXiangChangDu),      
                    new SQLiteParameter("@启动时间",model.QiDongShiJian),                       
                    new SQLiteParameter("@增速时间",model.ZengSuShiJian),                
                    new SQLiteParameter("@稳定时间",model.WenDingShiJian),               
                    new SQLiteParameter("@停止时间",model.TingZhiShiJIan),               
                    new SQLiteParameter("@偏心距",model.PianXinJu),                      
                    new SQLiteParameter("@节距最大误差",model.JieJuZuiDaWuCha),          
                    new SQLiteParameter("@节距最小误差",model.JieJuZuiXiaoWuCha),              
                    new SQLiteParameter("@采样频率",model.CaiYangPinLv),                 
                    new SQLiteParameter("@应力应变转换系数",model.YinLiYingBianZhuanHuanXiShu), 
                    new SQLiteParameter("@摩擦层径宽",model.MccJingKuan),               
                    new SQLiteParameter("@摩擦片厚度",model.McpHouDu),                  
                    new SQLiteParameter("@内毂齿顶高",model.NgChiDingGao),              
                    new SQLiteParameter("@内毂齿根高",model.NgChiGenGao),               
                    new SQLiteParameter("@摩擦片公法线长度公差",model.McpGFXDGC),       
                    new SQLiteParameter("@内毂公法线长度公差",model.NgGFXCDGC),         
                    new SQLiteParameter("@阻尼槽长",model.ZuNiCaoChang),                
                    new SQLiteParameter("@阻尼槽宽",model.ZuNiCaoKuan),                 
                    new SQLiteParameter("@阻尼槽半径",model.ZuNiCaoBanJing),            
                    new SQLiteParameter("@内毂齿根圆角",model.NgChiGenYuanJiao)};
                int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserProject model,string oldPath)
        {
            


                StringBuilder strSql = new StringBuilder();
                strSql.Append("update projectInfo set ");
                strSql.Append("项目路径=@项目路径,项目名=@项目名, 齿数=@齿数, 模数=@模数, 压力角=@压力角, 齿顶高=@齿顶高, 齿根高=@齿根高, 齿根圆角=@齿根圆角, 外径=@外径,齿侧间隙=@齿侧间隙, 孔径=@孔径, 厚度=@厚度,摩擦层厚度=@摩擦层厚度, 镀层厚度= @镀层厚度, 摩擦片弹性模量=@摩擦片弹性模量, 摩擦片材料密度=@摩擦片材料密度, 摩擦片泊松比=@摩擦片泊松比, 抗拉强度极限=@抗拉强度极限, 疲劳极限=@疲劳极限, 内毂弹性模量=@内毂弹性模量, 内毂材料密度=@内毂材料密度,内毂泊松比=@内毂泊松比, 摩擦层弹性模量=@摩擦层弹性模量, 摩擦层材料密度=@摩擦层材料密度, 摩擦层泊松比=@摩擦层泊松比, 镀层弹性模量=@镀层弹性模量, 镀层材料密度=@镀层材料密度, 镀层泊松比=@镀层泊松比,内毂初始角位移=@内毂初始角位移, 内毂初始速度=@内毂初始速度, 摩擦片初始角位移=@摩擦片初始角位移, 摩擦片初始速度=@摩擦片初始速度, 油膜厚度=@油膜厚度, 油膜粘度=@油膜粘度, 温度=@温度, 实际接触齿数=@实际接触齿数, 反弹系数=@反弹系数, 内毂转速=@内毂转速,内毂振幅=@内毂振幅, 内毂振频=@内毂振频, 结构阻尼=@结构阻尼, 摩擦片转动惯量=@摩擦片转动惯量, 内毂转动惯量=@内毂转动惯量, 接触区径向长度=@接触区径向长度, 接触区轴向长度=@接触区轴向长度, 启动时间=@启动时间, 增速时间=@增速时间, 稳定时间=@稳定时间, 停止时间=@停止时间,偏心距=@偏心距, 节距最大误差=@节距最大误差, 节距最小误差=@节距最小误差, 采样频率=@采样频率, 应力应变转换系数=@应力应变转换系数,摩擦层径宽=@摩擦层径宽,摩擦片厚度=@摩擦片厚度,内毂齿顶高=@内毂齿顶高,内毂齿根高=@内毂齿根高,摩擦片公法线长度公差=@摩擦片公法线长度公差,内毂公法线长度公差=@内毂公法线长度公差,阻尼槽长=@阻尼槽长,阻尼槽宽=@阻尼槽宽,阻尼槽半径=@阻尼槽半径,内毂齿根圆角=@内毂齿根圆角");
                strSql.Append(" where 项目路径=@旧项目路径");

                int rows=0;
                if(oldPath==null)
                {
                    List<string> hasLib = GetModel(model.ProjectPath);
                    if (hasLib == null)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("数据库中不存在该项目");
                        return false;
                    }

                    SQLiteParameter[] parameters = new SQLiteParameter[]{
                    new SQLiteParameter("@旧项目路径",model.ProjectPath),
                    new SQLiteParameter("@项目路径",model.ProjectPath), 
                    new SQLiteParameter("@项目名",model.ProjectName),      
                    new SQLiteParameter("@齿数",model.ChiShu),                    
                    new SQLiteParameter("@模数",model.MoShu),                        
                    new SQLiteParameter("@压力角",model.YaLiJiao),                
                    new SQLiteParameter("@齿顶高",model.McpChiDingGao),           
                    new SQLiteParameter("@齿根高",model.McpChiGenGao),            
                    new SQLiteParameter("@齿根圆角",model.McpChiGenYuanJiao),                    
                    new SQLiteParameter("@外径",model.WaiJing),                        
                    new SQLiteParameter("@齿侧间隙",model.ChiCeJianXi),                 
                    new SQLiteParameter("@孔径",model.KongJing),                    
                    new SQLiteParameter("@厚度",model.NgHouDu),                     
                    new SQLiteParameter("@摩擦层厚度",model.MccHouDu),              
                    new SQLiteParameter("@镀层厚度",model.DuCengHouDu),             
                    new SQLiteParameter("@摩擦片弹性模量",model.McpTXML),           
                    new SQLiteParameter("@摩擦片材料密度",model.McpCLMD),           
                    new SQLiteParameter("@摩擦片泊松比",model.McpBSB),              
                    new SQLiteParameter("@抗拉强度极限",model.KangLaQDJX),               
                    new SQLiteParameter("@疲劳极限",model.PiLaoJiXian),             
                    new SQLiteParameter("@内毂弹性模量",model.NgTXML),              
                    new SQLiteParameter("@内毂材料密度",model.NgCLMD),              
                    new SQLiteParameter("@内毂泊松比",model.NgBSB),                 
                    new SQLiteParameter("@摩擦层弹性模量",model.MccTXML),           
                    new SQLiteParameter("@摩擦层材料密度",model.MccCLMD),           
                    new SQLiteParameter("@摩擦层泊松比",model.MccBSB),              
                    new SQLiteParameter("@镀层弹性模量",model.DcTXML),              
                    new SQLiteParameter("@镀层材料密度",model.DcCLMD),              
                    new SQLiteParameter("@镀层泊松比",model.DcBSB),                    
                    new SQLiteParameter("@内毂初始角位移",model.NgChuShiJiaoWeiYi),    
                    new SQLiteParameter("@内毂初始速度",model.NgChuShiSuDu),           
                    new SQLiteParameter("@摩擦片初始角位移",model.McpChuShiJiaoWeiYi), 
                    new SQLiteParameter("@摩擦片初始速度",model.McpChuShiSuDu),        
                    new SQLiteParameter("@油膜厚度",model.YouYeNianDu),                
                    new SQLiteParameter("@油膜粘度",model.YouYeNianDu),                
                    new SQLiteParameter("@温度",model.WenDu),                          
                    new SQLiteParameter("@实际接触齿数",model.ShiJiJieChuChiShu),      
                    new SQLiteParameter("@反弹系数",model.FanTanXiShu),                
                    new SQLiteParameter("@内毂转速",model.NgZhuanSu),                  
                    new SQLiteParameter("@内毂振幅",model.NgZhenFu),                   
                    new SQLiteParameter("@内毂振频",model.NgZhenPin),                  
                    new SQLiteParameter("@结构阻尼",model.JieGouZuNi),                 
                    new SQLiteParameter("@摩擦片转动惯量",model.McpZhuanDongGuanLiang),
                    new SQLiteParameter("@内毂转动惯量",model.NgZhuanDongGuanLiang),                 
                    new SQLiteParameter("@接触区径向长度",model.JieChuQuJinXiangChuangDu),         
                    new SQLiteParameter("@接触区轴向长度",model.JieChuQuZhouXiangChangDu),      
                    new SQLiteParameter("@启动时间",model.QiDongShiJian),                       
                    new SQLiteParameter("@增速时间",model.ZengSuShiJian),                
                    new SQLiteParameter("@稳定时间",model.WenDingShiJian),               
                    new SQLiteParameter("@停止时间",model.TingZhiShiJIan),               
                    new SQLiteParameter("@偏心距",model.PianXinJu),                      
                    new SQLiteParameter("@节距最大误差",model.JieJuZuiDaWuCha),          
                    new SQLiteParameter("@节距最小误差",model.JieJuZuiXiaoWuCha),              
                    new SQLiteParameter("@采样频率",model.CaiYangPinLv),                 
                    new SQLiteParameter("@应力应变转换系数",model.YinLiYingBianZhuanHuanXiShu), 
                    new SQLiteParameter("@摩擦层径宽",model.MccJingKuan),               
                    new SQLiteParameter("@摩擦片厚度",model.McpHouDu),                  
                    new SQLiteParameter("@内毂齿顶高",model.NgChiDingGao),              
                    new SQLiteParameter("@内毂齿根高",model.NgChiGenGao),               
                    new SQLiteParameter("@摩擦片公法线长度公差",model.McpGFXDGC),       
                    new SQLiteParameter("@内毂公法线长度公差",model.NgGFXCDGC),         
                    new SQLiteParameter("@阻尼槽长",model.ZuNiCaoChang),                
                    new SQLiteParameter("@阻尼槽宽",model.ZuNiCaoKuan),                 
                    new SQLiteParameter("@阻尼槽半径",model.ZuNiCaoBanJing),            
                    new SQLiteParameter("@内毂齿根圆角",model.NgChiGenYuanJiao)};
                    rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
                }
                else
                {
                    List<string> hasLib = GetModel(model.ProjectPath);
                    if (hasLib != null)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("数据库已存在该项目");
                        return false;
                    }

                    SQLiteParameter[] parameters = new SQLiteParameter[]{
                    new SQLiteParameter("@旧项目路径",oldPath), 
                    new SQLiteParameter("@项目路径",model.ProjectPath), 
                    new SQLiteParameter("@项目名",model.ProjectName),      
                    new SQLiteParameter("@齿数",model.ChiShu),                    
                    new SQLiteParameter("@模数",model.MoShu),                        
                    new SQLiteParameter("@压力角",model.YaLiJiao),                
                    new SQLiteParameter("@齿顶高",model.McpChiDingGao),           
                    new SQLiteParameter("@齿根高",model.McpChiGenGao),            
                    new SQLiteParameter("@齿根圆角",model.McpChiGenYuanJiao),                    
                    new SQLiteParameter("@外径",model.WaiJing),                        
                    new SQLiteParameter("@齿侧间隙",model.ChiCeJianXi),                 
                    new SQLiteParameter("@孔径",model.KongJing),                    
                    new SQLiteParameter("@厚度",model.NgHouDu),                     
                    new SQLiteParameter("@摩擦层厚度",model.MccHouDu),              
                    new SQLiteParameter("@镀层厚度",model.DuCengHouDu),             
                    new SQLiteParameter("@摩擦片弹性模量",model.McpTXML),           
                    new SQLiteParameter("@摩擦片材料密度",model.McpCLMD),           
                    new SQLiteParameter("@摩擦片泊松比",model.McpBSB),              
                    new SQLiteParameter("@抗拉强度极限",model.KangLaQDJX),               
                    new SQLiteParameter("@疲劳极限",model.PiLaoJiXian),             
                    new SQLiteParameter("@内毂弹性模量",model.NgTXML),              
                    new SQLiteParameter("@内毂材料密度",model.NgCLMD),              
                    new SQLiteParameter("@内毂泊松比",model.NgBSB),                 
                    new SQLiteParameter("@摩擦层弹性模量",model.MccTXML),           
                    new SQLiteParameter("@摩擦层材料密度",model.MccCLMD),           
                    new SQLiteParameter("@摩擦层泊松比",model.MccBSB),              
                    new SQLiteParameter("@镀层弹性模量",model.DcTXML),              
                    new SQLiteParameter("@镀层材料密度",model.DcCLMD),              
                    new SQLiteParameter("@镀层泊松比",model.DcBSB),                    
                    new SQLiteParameter("@内毂初始角位移",model.NgChuShiJiaoWeiYi),    
                    new SQLiteParameter("@内毂初始速度",model.NgChuShiSuDu),           
                    new SQLiteParameter("@摩擦片初始角位移",model.McpChuShiJiaoWeiYi), 
                    new SQLiteParameter("@摩擦片初始速度",model.McpChuShiSuDu),        
                    new SQLiteParameter("@油膜厚度",model.YouYeNianDu),                
                    new SQLiteParameter("@油膜粘度",model.YouYeNianDu),                
                    new SQLiteParameter("@温度",model.WenDu),                          
                    new SQLiteParameter("@实际接触齿数",model.ShiJiJieChuChiShu),      
                    new SQLiteParameter("@反弹系数",model.FanTanXiShu),                
                    new SQLiteParameter("@内毂转速",model.NgZhuanSu),                  
                    new SQLiteParameter("@内毂振幅",model.NgZhenFu),                   
                    new SQLiteParameter("@内毂振频",model.NgZhenPin),                  
                    new SQLiteParameter("@结构阻尼",model.JieGouZuNi),                 
                    new SQLiteParameter("@摩擦片转动惯量",model.McpZhuanDongGuanLiang),
                    new SQLiteParameter("@内毂转动惯量",model.NgZhuanDongGuanLiang),                 
                    new SQLiteParameter("@接触区径向长度",model.JieChuQuJinXiangChuangDu),         
                    new SQLiteParameter("@接触区轴向长度",model.JieChuQuZhouXiangChangDu),      
                    new SQLiteParameter("@启动时间",model.QiDongShiJian),                       
                    new SQLiteParameter("@增速时间",model.ZengSuShiJian),                
                    new SQLiteParameter("@稳定时间",model.WenDingShiJian),               
                    new SQLiteParameter("@停止时间",model.TingZhiShiJIan),               
                    new SQLiteParameter("@偏心距",model.PianXinJu),                      
                    new SQLiteParameter("@节距最大误差",model.JieJuZuiDaWuCha),          
                    new SQLiteParameter("@节距最小误差",model.JieJuZuiXiaoWuCha),              
                    new SQLiteParameter("@采样频率",model.CaiYangPinLv),                 
                    new SQLiteParameter("@应力应变转换系数",model.YinLiYingBianZhuanHuanXiShu), 
                    new SQLiteParameter("@摩擦层径宽",model.MccJingKuan),               
                    new SQLiteParameter("@摩擦片厚度",model.McpHouDu),                  
                    new SQLiteParameter("@内毂齿顶高",model.NgChiDingGao),              
                    new SQLiteParameter("@内毂齿根高",model.NgChiGenGao),               
                    new SQLiteParameter("@摩擦片公法线长度公差",model.McpGFXDGC),       
                    new SQLiteParameter("@内毂公法线长度公差",model.NgGFXCDGC),         
                    new SQLiteParameter("@阻尼槽长",model.ZuNiCaoChang),                
                    new SQLiteParameter("@阻尼槽宽",model.ZuNiCaoKuan),                 
                    new SQLiteParameter("@阻尼槽半径",model.ZuNiCaoBanJing),            
                    new SQLiteParameter("@内毂齿根圆角",model.NgChiGenYuanJiao)};
                    rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
                }
                //int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            
        }

        public bool UpdateLatestProject(string path, string projectName, string date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update latestProject set ");
            strSql.Append("项目路径=@项目路径,");
            strSql.Append("时间=@时间");
            strSql.Append(" where 项目名=@项目名 ");
            SQLiteParameter[] parameters = new SQLiteParameter[]{ 
                    new SQLiteParameter("@项目路径",path),
                    new SQLiteParameter("@时间",date),
                    new SQLiteParameter("@项目名",projectName)
                    };

            int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ProPath)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  projectInfo  ");
            strSql.Append(" where 项目路径=@项目路径 ");


            SQLiteParameter[] parameters = new SQLiteParameter[]
            { 
               new SQLiteParameter("@项目路径",ProPath)
            };

            int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLatestProject(string projectName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from latestProject ");
            strSql.Append(" where 项目名=@项目名 ");


            SQLiteParameter[] parameters = new SQLiteParameter[]
            { 
               new SQLiteParameter("@项目名",projectName)
            };

            int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLib(string libName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from platePara ");
            strSql.Append(" where 片子名称=@libName ");


            SQLiteParameter[] parameters = new SQLiteParameter[]
            { 
               new SQLiteParameter("@libName",libName)
            };

            int rows = SQLiteDBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<string> GetModel(string ProPath)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from projectInfo ");
            strSql.Append(" where 项目路径=@项目路径 ");
            SQLiteParameter[] parameters =
                    new SQLiteParameter[] { new SQLiteParameter("@项目路径", ProPath) };

            UserProject model = new UserProject();
            DataSet ds = SQLiteDBHelper.Query(strSql.ToString(), parameters);
            List<string> result = new List<string>();
            //result.Add("0");
            //result.Add("1");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //return DataRowToModel(ds.Tables[0].Rows[0]);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in ds.Tables[0].Columns)
                    {
                        result.Add(row[mDc].ToString());
                    }
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetLibModel(string libName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from platePara ");
            strSql.Append(" where 片子名称=@libName ");
            SQLiteParameter[] parameters =
                    new SQLiteParameter[] { new SQLiteParameter("@libName", libName) };

            UserProject model = new UserProject();
            DataSet ds = SQLiteDBHelper.Query(strSql.ToString(), parameters);
            List<string> result = new List<string>();
            result.Add("0");
            result.Add("1");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //return DataRowToModel(ds.Tables[0].Rows[0]);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in ds.Tables[0].Columns)
                    {
                        result.Add(row[mDc].ToString());
                    }
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetLatestProjectList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 项目名 ");
            strSql.Append(" FROM latestProject order by 时间 desc limit 0,5; ");
            DataSet ds = SQLiteDBHelper.Query(strSql.ToString());
            List<string> result = new List<string>();


            if (ds.Tables[0].Rows.Count > 0)
            {
                //return DataRowToModel(ds.Tables[0].Rows[0]);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row[0].ToString());
                }
                return result;
            }
            else
            {
                return null;
            }

        }

        public string GetLatestProjectPath(string projectName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 项目路径 ");
            strSql.Append(" FROM latestProject");
            strSql.Append(" where 项目名=@项目名 ");
            SQLiteParameter[] parameters =
                    new SQLiteParameter[] { new SQLiteParameter("@项目名", projectName) };
            string result=null;
            DataSet ds = SQLiteDBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //return DataRowToModel(ds.Tables[0].Rows[0]);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result=row[0].ToString();
                }
                return result;
            }
            else
            {
                return null;
            }

        }

        public bool GetLatest(string projectName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM latestProject");
            strSql.Append(" where 项目名=@项目名 ");
            SQLiteParameter[] parameters =
                    new SQLiteParameter[] { new SQLiteParameter("@项目名", projectName) };

          
            DataSet ds = SQLiteDBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserProject DataRowToModel(DataRow row)
        {
            UserProject model = new UserProject();
            if (row != null)
            {
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPassword"] != null)
                {
                    model.UserPassword = row["UserPassword"].ToString();
                }
                if (row["UserType"] != null)
                {
                    model.UserType = row["UserType"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM projectInfo ");
            return SQLiteDBHelper.Query(strSql.ToString());
        }

        public DataSet GetLibList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM platePara ");
            return SQLiteDBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表，无参数
        /// </summary>
        //public DataSet GetList()
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select UserName,UserPassword,UserType ");
        //    strSql.Append(" FROM UserInfo ");
        //    return SQLiteDBHelper.Query(strSql.ToString());
        //}


    }
}
