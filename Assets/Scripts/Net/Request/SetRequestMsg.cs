
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/11 09:23:12
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetRequestMsg 
{
    /// <summary>
    /// ���ý�������
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReqExPwShopMsg(object msg)
    {
        UserInfo userinfo = msg as UserInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, object>
        {
            ["username"] = userinfo.Phone,
            ["userpass"] = userinfo.Password,
            ["code"] = userinfo.Identity,
            ["NickName"] = userinfo.NickName,
            ["invite"] = userinfo.InviteCode
        };
        messageData.model = "consumer";
        messageData.type = "expwshop";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "ע�����", messageData);
        return socketMsg;
    }
    /// <summary>
    /// ��Ч����
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReqVoiceSetMsg(object msg)
    {
        SetInfo setInfo = msg as SetInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, object>
        {
            ["bg"] = setInfo.BgVoice,
            ["game"] = setInfo.GameVoice

        };
        messageData.model = "consumer";
        messageData.type = "voice";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "��Ч����", messageData);
        return socketMsg;
    }
}
