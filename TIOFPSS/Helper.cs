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
        public delegate void delgateShaoChiDongTaiFenXiMethod(List<string> para);
        public delegate void delgateDongTaiYingLiJiSuanMethod(List<string> para);


        public delegate void delgateWuJieJuWuChaFenXiFinish(bool finish);
        public delegate void delgateZaoShengFenXiFinish(bool finish);
        public delegate void delgateYouJieJuWuChaFenXiFinish(bool finish);
        public delegate void delgateDLZHPFinish(bool finish,string fileType);
        public delegate void delgateFXXSSFinish(bool finish, string fileType);

        public delegate void delgateFXXSS(TIOFPSS.Dialog.FXXSSFile para);

        public delegate void delgateShengChengBaoBiaoMethod(List<string> para);
    }
}
