/***
  * Title:    JionShamber 
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/23 18:45:07
  *
  * Description: 加入商会界面
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加入商会
/// </summary>
public class JionShamber : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.SUCCESSFULSHAMBER_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SUCCESSFULSHAMBER_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    private void Start()
    {
        setPanelActive(false);
    }
}
