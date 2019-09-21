/***
  * Title:     
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/20 15:32:00
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

/// <summary>
/// ÐÞ¸Ä½»Ò×ÃÜÂë
/// </summary>
public class ChangeEXPwPanel : UIBase
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
