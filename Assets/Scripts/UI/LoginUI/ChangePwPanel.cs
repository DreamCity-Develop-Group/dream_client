
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/16 17:28:17
  *
  * Description: 改密码面板
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangePwPanel : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.CHANGETRADE_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.CHANGETRADE_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    void Start()
    {
        setPanelActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
