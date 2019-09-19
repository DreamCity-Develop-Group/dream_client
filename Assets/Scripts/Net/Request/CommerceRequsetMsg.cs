using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/19 18:21:25
  *
  * Description:   
  *
  * Version:    0.1
  *
  *
***/
public class CommerceRequsetMsg 
{
    private HintMsg promptMsg = new HintMsg();
    SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
    MessageData<Dictionary<string, string>> messageData = new MessageData<Dictionary<string, string>>();
    /// <summary>
    /// �̻����������Ϣ
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string,string>> ReqComeCommerceMsg(object msg)
    {
        Dictionary<string, string> t = msg as Dictionary<string, string>;
        t.Add("username", PlayerPrefs.GetString("username"));
        t.Add("token", PlayerPrefs.GetString("token"));
        messageData.Change("consumer", "commerce", t);
        socketMsg.Change(LoginInfo.ClientId, "�̻����������Ϣ", messageData);
        return socketMsg;
    }
    /// <summary>
    /// ����MT��Ϣ
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqBuyMTMsg(object msg)
    {
        Dictionary<string, string> t = msg as Dictionary<string, string>;
        t.Add("username", PlayerPrefs.GetString("username"));
        t.Add("token", PlayerPrefs.GetString("token"));
        messageData.Change("consumer", "commerce", t);
        socketMsg.Change(LoginInfo.ClientId, "����MT��Ϣ����", messageData);
        return socketMsg;
    }
    /// <summary>
    /// �᳤���Ž��
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqSendMTMsg(object msg)
    {
        Dictionary<string, string> t = msg as Dictionary<string, string>;
        t.Add("username", PlayerPrefs.GetString("username"));
        t.Add("token", PlayerPrefs.GetString("token"));
        messageData.Change("consumer", "commerce", t);
        socketMsg.Change(LoginInfo.ClientId, "�᳤���Ž��", messageData);
        return socketMsg;
    }
    /// <summary>
    /// �̻���Ϣ����
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqCommerceMsg(object msg)
    {
        Dictionary<string, string> t = msg as Dictionary<string, string>;
        t.Add("username", PlayerPrefs.GetString("username"));
        t.Add("token", PlayerPrefs.GetString("token"));
        messageData.Change("consumer", "commerce", t);
        socketMsg.Change(LoginInfo.ClientId, "�̻���Ϣ����", messageData);
        return socketMsg;
    }

}
