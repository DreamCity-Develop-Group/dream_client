using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent 
{
    public const int LOAD_PANEL_ACTIVE = int.MinValue;
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
    /// 语言选择
    /// </summary>
    public const int LANGUAGE_VIEW = 16;

   
    /// <summary>
    /// 提示界面
    /// </summary>
    public const int HINT_ACTIVE = int.MaxValue;

}
