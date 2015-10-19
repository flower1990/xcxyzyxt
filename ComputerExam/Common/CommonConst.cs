using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam
{
    /// <summary>
    /// 评分引擎
    /// </summary>
    public static class JudgeEngine
    {
        public const string Word = "10001";
        public const string Excel = "10002";
        public const string PowerPoint = "10003";
        public const string FrontPage = "10027";
        public const string Office = "10005";
        public const string Access = "10006";
        public const string Email = "10020";
        public const string OutLook = "10007";
        public const string WPS = "10008";
        public const string PhotoShop = "10009";
        public const string VisualBasic = "10010";
        public const string VisualFoxPro = "10011";
        public const string Windows = "10014";
        public const string Internet = "10015";
        public const string JAVA = "10016";
        public const string C = "10018";
        public const string CC = "10018";
        public const string DanXuan = "10022";
        public const string DuoXuan = "10023";
        public const string PanDuan = "10024";
        public const string TianKong = "10025";
        public const string ZhuGuan = "10026";
        public const string Typing = "10027";
        public const string AnLiFenXi = "10031";
        public const string JiSuanFenXi = "10032";
        public const string ShiWuFangZhen = "20006";
        public const string UFIDA = "20001";
    }

    public static class KaiShiFangShi
    {
        public const string XinDeKaiShi = "XinDeKaiShi";
        public const string JiXuShangCiKaoShi = "JiXuShangCiKaoShi";
        public const string ChongChouShangCiKaoTi = "ChongChouShangCiKaoTi";

        public const string XinDeZuoYe = "XinDeZuoYe";
        public const string JiXuShangCiZuoYe = "JiXuShangCiZuoYe";
    }

    public static class JobType
    {
        public const string ShiJuan = "ShiJuan";

        public const string TiKu = "TiKu";
    }
}
