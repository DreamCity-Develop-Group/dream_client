
/***
  * Title:     ����ģ��
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 18:09:46
  *
  * Description:����ģ����Ϣ����
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetHandler : HandlerBase
{
    public override bool OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case EventType.expw:
                expwRespon(value.ToString());
                break;
            case EventType.expwshop:
                expwshopRespon(value.ToString());
                break;
            default:
                break;
        }
        return false;
    }

    private HintMsg promptMsg = new HintMsg();
    private void expwRespon(string value)
    {
        promptMsg.Change(value, Color.red);
        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        if (value == "�޸ĳɹ�")
        {
            promptMsg.Change(value.ToString(), Color.green);
           // Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, null);
        }
    }
    private void expwshopRespon(string value)
    {
        promptMsg.Change(value, Color.red);
        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        if (value == "���óɹ�")
        {
            promptMsg.Change(value.ToString(), Color.green);
          //  Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, null);
        }
    }
    //private void voicesetRespon(object value)
    //{
    //    Dispatch(AreaCode.UI, UIEvent.GAMEVOICE, value);
    //}
}
