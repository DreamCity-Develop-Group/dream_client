/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 18:50:30
  *
  * Description: ������ӣ�ɾ�������ޣ�������Ӧ����
  *
  * Version:    0.1
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FriendHandler : HandlerBase
{
    Dictionary<string, UserInfo> dicSquareData = new Dictionary<string, UserInfo>();
    Dictionary<string, UserInfo> dicFriendData = new Dictionary<string, UserInfo>();
    private UserInfo userInfo = new UserInfo();
    public override bool OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case EventType.addfriend:
                //diFriendData = value as Dictionary<string, UserInfo>;
                addfriendRespon(value);
                break;
            case EventType.listfriend:
                dicFriendData = value as Dictionary<string, UserInfo>;
                listfriendRespon(value);
                break;
            case EventType.searchfriend:
                searchfriendRespon(value);
                break;
            case EventType.applyfriend:

                applyfriendRespon(value);
                break;
            case EventType.squarefriend:
                dicSquareData = value as Dictionary<string, UserInfo>;
                dicSquareFriendRespon();
                break;
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();

    /// <summary>
    /// �㳡�б�
    /// </summary>
    private void dicSquareFriendRespon()
    {
        if (dicSquareData.Count < 1)
        {
            Debug.LogError("dicSquareFriend is null");
            return;
        }
        Dispatch(AreaCode.UI,UIEvent.SQUARE_LIST_PANEL_VIEW,dicSquareData);

    }

    /// <summary>
    /// �����б�
    /// </summary>
    /// <param name="value"></param>
    private void listfriendRespon(object value)
    {
        if (dicFriendData.Count < 1)
        {
            Debug.LogError("dicFriendData is null");
            return;
        }
        Dispatch(AreaCode.UI,UIEvent.FRIEND_LIST_PANEL_VIEW,dicFriendData);
    }
    private void searchfriendRespon(object value)
    {

    }
    private void addfriendRespon(object value)
    {

    }
    /// <summary>
    /// ��������б�
    /// </summary>
    List<UserInfo> applyList = new List<UserInfo>();
   
    /// <summary>
    /// ���������Ӧ
    /// </summary>
    private void applyfriendRespon(object msg)
    {
        if (msg == null)
        {
            //�Է��ܾ�
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
    /// ����Ӧ��
    /// </summary>
    /// <param name="msg"></param>
    private void searchuserReson(object msg)
    {

    }
}
