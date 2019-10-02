
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

using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Net.Code;
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
                case ReqEventType.expw:
                    expwRespon(value.ToString());
                    break;
                case ReqEventType.expwshop:
                    expwshopRespon(value.ToString());
                    break;
                case ReqEventType.change_expwshop:
                    changeExPwShopRespon(value.ToString());
                    break;
                default:
                    break;
            }
            return false;
        }

        private HintMsg promptMsg = new HintMsg();
        private void expwRespon(string value)
        {
            promptMsg.Change(value, Color.white);
            if (value == "修改成功")
            {
                promptMsg.Change(value.ToString(), Color.green);
            }
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        }
        /// <summary>
        /// 设置交易密码
        /// </summary>
        /// <param name="value"></param>
        private void expwshopRespon(string value)
        {
            promptMsg.Change(value, Color.white);
           
            if (value == "设置成功")
            {
                promptMsg.Change(value.ToString(), Color.green);
            }
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        }
        /// <summary>
        /// 修改交易密码响应
        /// </summary>
        /// <param name="value"></param>
        private void changeExPwShopRespon(string value)
        {
            promptMsg.Change(value, Color.white);

            if (value == "修改成功")
            {
                //CacheData.Instance().Mt -= CacheData.Instance().ChangExPassWordMt;

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
