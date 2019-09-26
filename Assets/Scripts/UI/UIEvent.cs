using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent 
{
    /// <summary>
    /// 加载
    /// </summary>
    public const int LOAD_PANEL_ACTIVE = int.MinValue;
    /// <summary>
    /// 测试用
    /// </summary>
    public const int TEST_PANEL_ACTIVE = -3;
    /// <summary>
    /// 验证码
    /// </summary>
    public const int REG_PANEL_CODEVIEW = -2;
    /// <summary>
    /// 登入注册选择界面
    /// </summary>
    public const int LOGINSELECT_PANEL_ACTIVE = -1;

    /// <summary>
    /// 登入界面
    /// </summary>
    public const int LOG_ACTIVE = 0; 
    /// <summary>
    ///注册界面
    /// </summary>
    public const int REG_ACTIVE =1;
    /// <summary>
    ///忘记密码界面
    /// </summary>
    public const int Forget_ACTIVE = 2;
    /// <summary>
    ///设置界面
    /// </summary>
    public const int SET_PANEL_ACTIVE = 3;
    /// <summary>
    /// 资产界面
    /// </summary>
    public const int CHARGE_PANEL_ACTIVE = 4;
    /// <summary>
    /// 
    /// </summary>
    public const int GAMEVOICE =5 ;
    /// <summary>
    /// 
    /// </summary>
    public const int GAMEBG = 6;
    /// <summary>
    /// 好友主界面
    /// </summary>
    public const int FRIENDMENU_PANEL_ACTIVE = 7;
    /// <summary>
    /// 验证码界面
    /// </summary>
    public const int QRECODE_PANEL_ACTIVE = 8;
    /// <summary>
    /// 邮件界面
    /// </summary>
    public const int MSG_PANEL_ACTIVE = 9;
    /// <summary>
    /// 音效界面
    /// </summary>
    public const int VOICE_PANEL_ACTIVE = 10;
    /// <summary>
    /// 安全界面
    /// </summary>
    public const int SECURITY_PANEL_ACTIVE = 11;
    /// <summary>
    /// 好友界面
    /// </summary>
    public const int FRIEND_LIST_PANEL_ACTIVE = 12;
    /// <summary>
    /// 好友列表获取
    /// </summary>
    public const int FRIEND_LIST_PANEL_VIEW = 13;
    /// <summary>
    /// 广场界面
    /// </summary>
    public const int SQUARE_LIST_PANEL_ACTIVE = 14;
    /// <summary>
    /// 广场用户列表获取
    /// </summary>
    public const int SQUARE_LIST_PANEL_VIEW = 15;
    /// <summary>
    /// 商会面板
    /// </summary>
    public const int COMMERCE_PANEL_ACTIVE = 16;
    /// <summary>
    /// 没加入商会面板
    /// </summary>
    public const int COMMERCE_NOJIONPANEL_ACTIVE = 17;
    /// <summary>
    /// 语言
    /// </summary>
    public const int LANGUAGE_VIEW = 18;
    /// <summary>
    /// 设置交易密码
    /// </summary>
    public const int SETTRANSACT_ACTIVE = 19;
    /// <summary>
    /// 修改交易密码
    /// </summary>
    public const int CHANGETRADE_ACTIVE = 20;
    /// <summary>
    /// 修改登陆密码
    /// </summary>
    public const int CHANGELONG_ACTIVE = 21;


    /// <summary>
    /// 场景投资界面数据
    /// </summary>
    public const int SENCE_INVEST_VIEW = 22;
    /// <summary>
    /// 主界面数据
    /// </summary>
    public const int MENU_PANEL_VIEW = 23;
    /// <summary>
    /// 申请好友数据
    /// </summary>
    public const int APPLY_PANEL_VIEW = 24;

    /// <summary>
    /// 转账
    /// </summary>
    public const int TRANSFERACCOUNTS_ACTIVE = 25;
    /// <summary>
    /// 充值
    /// </summary>
    public const int TOPUP_ACTIVE = 26;
    /// <summary>
    /// 输入交易码
    /// </summary>
    public const int TRANSACTIONCODE_ACTIVE = 27;
    /// <summary>
    /// 好友申请界面
    /// </summary>
    public const int APPLYFOR_ACTIVE = 28;
    /// <summary>
    /// 获取申请好友列表
    /// </summary>
    public const int APPLYFOR_VIEW = 29;
    /// <summary>
    /// 成功加入商会
    /// </summary>
    public const int SUCCESSFULSHAMBER_ACTIVE = 30;
    /// <summary>
    /// 投资商家界面
    /// </summary>
    public const int IVEST_PANEL_ACTIVE = 31;
    /// <summary>
    /// 选择投资商界面
    /// </summary>
    public const int SELECTINVEST_PANEL_ACTIVE = 32;
    /// <summary>
    /// 选择投资商版本数据
    /// </summary>
    public const int SELECCTINVEST_PANEL_VIEW = 33;





    /// <summary>
    /// 提示界面
    /// </summary>
    public const int HINT_ACTIVE = int.MaxValue;
}
