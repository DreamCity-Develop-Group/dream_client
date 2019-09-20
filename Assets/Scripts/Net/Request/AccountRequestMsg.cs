﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountRequestMsg:RequestBase
{

    private HintMsg promptMsg = new HintMsg();
    SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
    MessageData<Dictionary<string,string>> messageData = new MessageData<Dictionary<string, string>>();
    /// <summary>
    /// 登入消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqPWLoginMsg(object msg)
    {
        //登入检验TODO
        LoginInfo loginInfo = msg as LoginInfo;
        if (loginInfo.UserName==""||loginInfo.Password=="")
        {
            promptMsg.Change("请输入用户名和密码", Color.red);
            Dispatch(AreaCode.UI,UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        if (!MsgTool.CheckMobile(loginInfo.UserName))
        {
            promptMsg.Change("请输入正确的手机号码", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        string userpass = loginInfo.Password;
        //string userpass= MsgTool.MD5Encrypt(loginInfo.Password);
          Dictionary<string, string>  t = new Dictionary<string, string>
            {
               // ["IsIdentityLog"] = loginInfo.Identity,
                ["username"] = loginInfo.UserName,
                ["userpass"] = userpass,
                //["Identity"] = loginInfo.Identity
            };
            messageData.model = "consumer";
            messageData.type = "pwlog";
            messageData.Change("consumer", "pwlog",t);
            socketMsg.Change(LoginInfo.ClientId, "登入操作", messageData);
            PlayerPrefs.SetString("username", loginInfo.UserName);
        return socketMsg;
    }
    /// <summary>
    /// 忘记密码消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqForgetMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        string userpass = MsgTool.MD5Encrypt(loginInfo.Password);
        Dictionary<string, string> t = new Dictionary<string, string>
        {
            // ["IsIdentityLog"] = loginInfo.Identity,
            ["username"] = loginInfo.UserName,
            ["newpw"] = userpass,
            ["code"] = loginInfo.Identity,
            ["token"] = PlayerPrefs.GetString("token")
        };
        //messageData.model = "consumer";
        //messageData.type = "expw";
        messageData.Change("consumer", "expw", t);
        socketMsg.Change(LoginInfo.ClientId, "修改登入密码操作", messageData);
        return socketMsg;
    }


    /// <summary>
    /// 修改密码消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqPWChangeMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        string userpass = MsgTool.MD5Encrypt(loginInfo.Password);
        Dictionary<string, string> t = new Dictionary<string, string>
        {
            // ["IsIdentityLog"] = loginInfo.Identity,
            ["username"] = loginInfo.UserName,
            ["userpass"] = userpass,
            ["Identity"] = loginInfo.Identity,
            ["token"] = PlayerPrefs.GetString("token")
        };
        messageData.Change("consumer", "expw", t);
        socketMsg.Change(LoginInfo.ClientId,  "修改登入密码操作", messageData);
        return socketMsg;
    }
  /// <summary>
  /// 获取验证码请求消息
  /// </summary>
  /// <param name="msg"></param>
  /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqGetIdentityMsg(object msg)
    {
        if (msg == null)
        {
            promptMsg.Change("请输入手机号", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        if (!MsgTool.CheckMobile(msg.ToString()))
        {
            promptMsg.Change("请输入正确的手机号码", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        messageData.Change("consumer", "getcode", null);
        //messageData.t = null;
        socketMsg.Change(LoginInfo.ClientId, "获取验证码操作", messageData);
        return socketMsg;
    }
    
    /// <summary>
    /// 验证码登入消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqIDLoginMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        //TODO
        if (loginInfo.UserName == "" || loginInfo.Password == "")
        {
            promptMsg.Change("请输入用户名和验证码", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        if (!MsgTool.CheckMobile(loginInfo.UserName))
        {
            promptMsg.Change("请输入正确的手机号码", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }

        Dictionary<string, string>t = new Dictionary<string, string>
        {
            // ["IsIdentityLog"] = loginInfo.Identity,
            ["username"] = loginInfo.UserName,
            ["userpass"] = loginInfo.Password,
            //["Identity"] = loginInfo.Identity
        };
        messageData.Change("consumer", "idlog", null);
        socketMsg.Change(LoginInfo.ClientId, "登入操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 注册消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqRegMsg(object msg)
    {
        UserInfo userinfo = msg as UserInfo;

        if (userinfo.Phone == "" || userinfo.Password == "")
        {
            promptMsg.Change("请输入用户名和验证码", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        if (!MsgTool.CheckMobile(userinfo.Phone ))
        {
            promptMsg.Change("请输入正确的手机号码", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        if (!MsgTool.CheckPass(userinfo.Password))
        {
            promptMsg.Change("8-16位字符,可包含数字,字母,下划线", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        if (!MsgTool.CheckNickName(userinfo.NickName))
        {
            promptMsg.Change("2-10位字符,可包含数字,字母,下划线,汉字", Color.red);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return null;
        }
        Dictionary<string, string>t = new Dictionary<string, string>
        {
            ["username"] = userinfo.Phone,
            ["userpass"] = userinfo.Password,
            ["code"] = userinfo.Identity,
            ["nick"] = userinfo.NickName,
            ["invite"] = userinfo.InviteCode
        };
        messageData.Change("consumer", "reg", null);
        Debug.LogError(LoginInfo.ClientId);
        socketMsg.Change(LoginInfo.ClientId,  "注册操作", messageData);
        return socketMsg;
    }

    /// <summary>
    /// 资产测试请求消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqPropertyTestMsg(object msg)
    {
        LoginInfo loginInfo = msg as LoginInfo;
        Dictionary<string, string> t = new Dictionary<string, string>
        {
            // ["IsIdentityLog"] = loginInfo.Identity,
            ["username"] = loginInfo.UserName,
            ["token"] = PlayerPrefs.GetString("token")
        };
        messageData.Change("consumer", "property", t);
        socketMsg.Change(LoginInfo.ClientId, "资产信息", messageData);
        return socketMsg;
    }


}