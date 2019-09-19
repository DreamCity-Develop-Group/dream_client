
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/17 09:51:03
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


public class FriendListPanel : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.FRIEND_LIST_PANEL_ACTIVE, UIEvent.FRIEND_LIST_PANEL_VIEW);
    }
    /// <summary>
    /// ºÃÓÑÊý¾Ý
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    Dictionary<string, UserInfo> dicFriendData;

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.FRIEND_LIST_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            case UIEvent.FRIEND_LIST_PANEL_VIEW:
                
                dicFriendData = message as Dictionary<string, UserInfo>;
                //TODO
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        setPanelActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
