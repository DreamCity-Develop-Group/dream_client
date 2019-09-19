
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
    MessageData<Dictionary<string, string>> messageData = new MessageData<Dictionary<string, string>>();
    SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
    /// <summary>
    /// ���ý�������
    /// </summary>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqExPwShopMsg(object msg)
    {
        UserInfo userinfo = msg as UserInfo;

        Dictionary<string, string> t = new Dictionary<string, string>
        {
            ["username"] = userinfo.Phone,
            ["userpass"] = userinfo.Password,
            ["code"] = userinfo.Identity,
            ["NickName"] = userinfo.NickName,
            ["invite"] = userinfo.InviteCode
        };
        messageData.model = "consumer";
        messageData.type = "expwshop";
        messageData.Change("consumer", "expwshop",t);
        socketMsg.Change(LoginInfo.ClientId, "ע�����", messageData);
        return socketMsg;
    }
    /// <summary>
    /// ��Ч����
    /// </summary>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqVoiceSetMsg(object msg)
    {
        SetInfo setInfo = msg as SetInfo;

         Dictionary<string, string> t = new Dictionary<string, string>
        {
            ["bg"] = setInfo.BgVoice,
            ["game"] = setInfo.GameVoice

        };
        messageData.model = "consumer";
        messageData.type = "voice";
        socketMsg.Change(LoginInfo.ClientId, "��Ч����", messageData);
        return socketMsg;
    }
}
