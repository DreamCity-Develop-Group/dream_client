using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/10/02 12:26:39
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
public class SocketEventType
{
    /// <summary>
    /// 初始连接
    /// </summary>
    public const string InitConnect = "init";
    /// <summary>
    /// 
    /// </summary>
    public const string Default= "";
    /// <summary>
    /// 用戶注冊
    /// </summary>
    public const string Regist = "reg";

    /// <summary>
    /// 密码登入
    /// </summary>
    public const string PassWordLogin = "Login";
    /// <summary>
    /// 验证码登入
    /// </summary>
    public const string CodeLogin = "codeLogin";
    /// <summary>
    /// 忘记密码
    /// </summary>
    public const string ForgerPassWord = "pwforget";
    /// <summary>
    /// 
    /// </summary>
    public const string Exit = "";
    /// <summary>
    /// 获取验证码
    /// </summary>
    public const string GetCode = "getCode";
    /// <summary>
    /// 设置交易密码
    /// </summary>
    public const string SetExchangePassWord = "expwshop";
    /// <summary>
    /// 好友点赞
    /// </summary>
    public const string LikeFriend = "likefriend";
    /// <summary>
    /// 搜索好友
    /// </summary>
    public const string SearchFriend = "searchfriend";
    /// <summary>
    /// 申请列表
    /// </summary>
    public const string ApplyList = "applyfriend";
    /// <summary>
    /// 添加好友
    /// </summary>
    public const string AddFriend = "addFriend";
    /// <summary>
    /// 广场列表
    /// </summary>
    public const string SquareFriends = "squareFriends";
    /// <summary>
    /// 好友列表
    /// </summary>
    public const string FriendList = "friendList";
    /// <summary>
    /// 
    /// </summary>
    public const string NextGround = "";
    /// <summary>
    /// 修改密码
    /// </summary>
    public const string ChangPassWord = "expw";
    /// <summary>
    /// 转账
    /// </summary>
    public const string TransferAccount = "transferaccount";
    /// <summary>
    /// Recharge
    /// </summary>
    public const string Recharge = "";
    /// <summary>
    /// 资产信息
    /// </summary>
    public const string PropertyInfo = "getPlayerAccount";
    /// <summary>
    /// 投资
    /// </summary>
    public const string Invest = "playerInvest";
    /// <summary>
    /// 投资信息
    /// </summary>
    public const string InvestInfo = "getInvestList";
    /// <summary>
    /// 商会
    /// </summary>
    public const string Commerce = "";
    /// <summary>
    /// 会长发货
    /// </summary>
    public const string SendMt = "sendmt";
    /// <summary>
    /// 
    /// </summary>
    public const string BuyMt = "";
    /// <summary>
    /// 
    /// </summary>
    public const string JoinCommerce = "";
    /// <summary>
    /// 邮件
    /// </summary>
    public const string Message = "";


}
