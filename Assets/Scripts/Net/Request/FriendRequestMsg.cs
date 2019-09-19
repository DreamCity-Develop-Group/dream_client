
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 09:22:48
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


public class FriendRequestMsg :RequestBase
{
   

    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqAddFriendMsg(object msg)
    {
        string applyUserName = msg.ToString();
       // ApplyInfo.applyList.Add(applyUserName);
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, object>
        {
            ["nick"] = applyUserName,
            ["username"] = PlayerPrefs.GetString("username"),
        };
        messageData.model = "friend";
        messageData.type = "addfriend";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "������Ѳ���", messageData);
        return socketMsg;
    }
    /// <summary>
    /// �������ͨ��/�ܾ�
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqAgreeFriendMsg(object msg)
    {
        Dictionary<string, object> msgDci = msg as Dictionary<string, object>;
        MessageData messageData = new MessageData();
        //TODO
        messageData.t = msgDci;
        messageData.model = "friend";
        messageData.type = "addfriend";

        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "��Ӻ��Ѳ���", messageData);
        //TODO
        //Dispatch(AreaCode.UI,11111,"removeList");
        return socketMsg;
    }
    /// <summary>
    /// ���ѵ���
    /// </summary>
    /// <returns></returns>
    public SocketMsg ReqLikeFriendMsg(object msg)
    {
        UserInfo userInfo = msg as UserInfo;

        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, object>
        {
            ["nick"] = userInfo.NickName,
            ["likes"] = userInfo.Like,
            ["username"] = PlayerPrefs.GetString("username"),
        };
        messageData.model = "friend";
        messageData.type = "likefriend";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "���ѵ���", messageData);
        //Dispatch(AreaCode.UI,11111,"activefalse");
        return socketMsg;
    }
    /// <summary>
    /// �����û���Ϣ
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg ReqSearchUserMsg(object msg)
    {
        string nickName = msg.ToString();
        if (nickName == null)
        {
            //TODO��ʾ����
            return null;
        }
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, object>
        {
            ["nick"] = nickName,
            ["username"] = PlayerPrefs.GetString("username"),
        };
        messageData.model = "friend";
        messageData.type = "searchfriend";
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "�����û�", messageData);
        return socketMsg;
    }
    public  SocketMsg ReqNextUserList(object msg)
    {
        MessageData messageData = new MessageData();
        messageData.t = new Dictionary<string, object>
        {
            ["username"] = PlayerPrefs.GetString("username"),
        };
        SocketMsg socketMsg = new SocketMsg(LoginInfo.ClientId, "��һ���㳡���", messageData);
        return socketMsg;
    }
}
