
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

    SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
    MessageData<Dictionary<string, string>> messageData = new MessageData<Dictionary<string, string>>();
    /// <summary>
    /// 申请消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqAddFriendMsg(object msg)
    {
        string applyUserName = msg.ToString();
       // ApplyInfo.applyList.Add(applyUserName);
        Dictionary<string, string>t = new Dictionary<string, string>
        {
            ["nick"] = applyUserName,
            ["username"] = PlayerPrefs.GetString("username"),
        };
        messageData.Change("consumer", "addfriend", t);
        socketMsg.Change(LoginInfo.ClientId, "申请好友操作", messageData);
        return socketMsg;
    }
    /// <summary>
    /// 申请好友通过/拒绝
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqAgreeFriendMsg(object msg)
    {
        Dictionary<string, string> t = msg as Dictionary<string, string>;
        //TODO
        messageData.model = "friend";
        messageData.type = "addTofriend";
        messageData.Change("consumer", "addfriend", t);
        socketMsg.Change(LoginInfo.ClientId, "添加好友操作", messageData);
        //TODO
        //Dispatch(AreaCode.UI,11111,"removeList");
        return socketMsg;
    }
    /// <summary>
    /// 好友点赞
    /// </summary>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqLikeFriendMsg(object msg)
    {
        //TODO点赞逻辑


        UserInfo userInfo = msg as UserInfo;
        Dictionary<string, string>t = new Dictionary<string, string>
        {
            ["nick"] = userInfo.NickName,
            ["likes"] = userInfo.Like,
            ["username"] = PlayerPrefs.GetString("username"),
        };
        messageData.Change("consumer", "likefriend", t);
        socketMsg.Change(LoginInfo.ClientId, "好友点赞", messageData);
        //Dispatch(AreaCode.UI,11111,"activefalse");
        return socketMsg;
    }
    /// <summary>
    /// 搜索用户消息
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public SocketMsg<Dictionary<string, string>> ReqSearchUserMsg(object msg)
    {
        string nickName = msg.ToString();
        if (nickName == null)
        {
            //TODO提示界面
            return null;
        }
        Dictionary<string, string>t = new Dictionary<string, string>
        {
            ["nick"] = nickName,
            ["username"] = PlayerPrefs.GetString("username"),
        };
        messageData.model = "friend";
        messageData.type = "searchfriend";
        messageData.Change("consumer", "searchfriend", t);
        socketMsg.Change(LoginInfo.ClientId, "搜索用户", messageData);
        return socketMsg;
    }
    public  SocketMsg<Dictionary<string, string>> ReqNextUserList(object msg)
    {
        Dictionary<string, string>t = new Dictionary<string, string>
        {
            ["username"] = PlayerPrefs.GetString("username"),
        };
        socketMsg.Change(LoginInfo.ClientId, "换一批广场玩家", messageData);
        return socketMsg;
    }
}
