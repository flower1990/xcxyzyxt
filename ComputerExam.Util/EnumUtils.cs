using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Util
{
    #region 枚举
    public enum Enum_DengLuFangShi
    {
        BiaoZhunDengLuFangShi,
        ZhiJieJinRuKaoShi
    }

    public enum Enum_KaiShiFangShi
    {
        XinDeKaiShi,
        JiXuShangCiKaoShi,
        ChongChouShangCiKaoTi,
        XinDeZuoYe,
        JiXuShangCiZuoYe
    }

    public enum Enum_XueXiMoShi
    {
        LianXiMoShi,
        CeShiMoShi
    }

    public enum Enum_CeShiNeiRong
    {
        随机组卷,
        固定套卷,
        实操强化
    }

    public enum Enum_TTopicRealType
    {
        trtUnknown,
        trtDanXuan,
        trtDuoXuan,
        trtPanDuan,
        trtTianKong,
        trtAnLiFenXi,
        trtJiSuanFenXi,
        trtZhuGuan,
        trtTyping,
        trtCaoZuoWindows,
        trtCaoZuoWord,
        trtCaoZuoExcel,
        trtCaoZuoPowerPoint,
        trtCaoZuoAccess,
        trtCaoZuoUFIDA,
        //2013-10-12 新增
        trtCaoZuo_VB,
        trtCaoZuo_VF,
        trtCaoZuo_IE,
        trtCaoZuo_Java,
        trtCaoZuo_C,
        trtCaoZuo_CPP,
        trtCaoZuo_Outlook,
        trtCaoZuo_ShiWuFangZhen,
        trtCaoZuo_Email,
    }

    public enum Enum_KeGuanTi
    {
        trtDanXuan,
        trtDuoXuan,
        trtPanDuan
    }
    #endregion
}
