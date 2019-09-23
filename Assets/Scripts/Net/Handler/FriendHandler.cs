/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 18:50:30
  *
  * Description: 好友添加，删除，点赞，搜索响应处理
  *
  * Version:    0.1
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FriendHandler : HandlerBase
{
    List<UserInfos> _squareData = new List<UserInfos>();
    List<UserInfos> _friendData = new List<UserInfos>();
    private UserInfo userInfo = new UserInfo();
    public override bool OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case EventType.addfriend:
                //diFriendData = value as Dictionary<string, UserInfo>;
                addfriendRespon();
                break;
            case EventType.listfriend:
                _friendData = value as List<UserInfos>;
                listfriendRespon();
                break;
            case EventType.searchfriend:
                searchfriendRespon(value);
                break;
            case EventType.applyfriend:

                applyfriendRespon(value);
                break;
            case EventType.squarefriend:
                _squareData = value as List<UserInfos>;
                dicSquareFriendRespon();
                break;
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();

    /// <summary>
    /// 广场列表
    /// </summary>
    private void dicSquareFriendRespon()
    {
        if (_squareData.Count < 1)
        {
            Debug.LogError("dicSquareFriend is null");
            return;
        }
        Dispatch(AreaCode.UI,UIEvent.SQUARE_LIST_PANEL_VIEW,_squareData);

    }

    /// <summary>
    /// 好友列表
    /// </summary>
    /// <param name="value"></param>
    private void listfriendRespon()
    {
        if (_friendData.Count < 1)
        {
            Debug.LogError("dicFriendData is null");
            return;
        }
        Dispatch(AreaCode.UI,UIEvent.FRIEND_LIST_PANEL_VIEW, _friendData);
    }
    private void searchfriendRespon(object value)
    {

    }
    private void addfriendRespon()
    {

    }
    /// <summary>
    /// 申请好友列表
    /// </summary>
    List<UserInfo> applyList = new List<UserInfo>();
   
    /// <summary>
    /// 申请好友响应
    /// </summary>
    private void applyfriendRespon(object msg)
    {
        if (msg == null)
        {
            //对方拒绝
        }
        else
        {
            Dictionary<string,string> applyfriendDic = msg as Dictionary<string, string>;
            userInfo.Imgurl = applyfriendDic["imgurl"];
            userInfo.NickName = applyfriendDic["nick"];
            userInfo.FriendLink = applyfriendDic["friendlink"];
            //TODO
        }
    }
    /// <summary>
    /// 搜索应答
    /// </summary>
    /// <param name="msg"></param>
    private void searchuserReson(object msg)
    {

    }
}
