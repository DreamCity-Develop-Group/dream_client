
/***
  * Title:    SquareListPanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/17 09:45:07
  *
  * Description: 广场列表界面
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareListPanel : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.SQUARE_LIST_PANEL_ACTIVE, UIEvent.SQUARE_LIST_PANEL_VIEW);
    }
    /// <summary>
    /// 广场用户数据
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    List<UserInfos> dicSquareData;

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SQUARE_LIST_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            case UIEvent.SQUARE_LIST_PANEL_VIEW:
                dicSquareData = message as List<UserInfos>;
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
