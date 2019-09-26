
/***
  * Title:     设置模块
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/09 18:09:46
  *
  * Description:设置模块消息处理
  *
  * Version:    0.1
  *
  *
***/

using Assets.Scripts.Framework;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Msg;
using UnityEngine;

namespace Assets.Scripts.Net.Handler
{
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
            if (value == "修改成功")
            {
                promptMsg.Change(value.ToString(), Color.green);
            }
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        }
        private void expwshopRespon(string value)
        {
            promptMsg.Change(value, Color.red);
           
            if (value == "设置成功")
            {
                promptMsg.Change(value.ToString(), Color.green);
            }
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        }
        //private void voicesetRespon(object value)
        //{
        //    Dispatch(AreaCode.UI, UIEvent.GAMEVOICE, value);
        //}
    }
}
