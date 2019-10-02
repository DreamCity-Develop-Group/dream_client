using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Scenes;
using Assets.Scripts.Scenes.Msg;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Msg;
using System.Collections.Generic;
using UnityEngine;

/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/21 14:57:52
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
namespace Assets.Scripts.Net.Handler
{
   
    public class InvestHandler : HandlerBase
    {
        private HintMsg promptMsg = new HintMsg();
        private UserInfo userInfo = new UserInfo();
        private List<InvestInfo> investInfos;
        public override bool OnReceive(int subCode, object value)
        {
            switch (subCode)
            {
                case ReqEventType.invest_info:
                    investInfos =value as List<InvestInfo>;
                    investInfoResponse(investInfos);
                    break;
                case ReqEventType.invest_req:
                    investResponse(value.ToString());
                    break;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// 投资响应
        /// </summary>
        private bool investResponse(string result)
        {
            promptMsg.Change(result, Color.white);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            if (result == "投资成功")
            {
                //跳转场景 TODO
                SceneMsg msg = new SceneMsg("menu",
                    delegate () {

                        Debug.Log("场景加载完成");
                    });
                //
                Dispatch(AreaCode.SCENE, SceneEvent.MENU_PLAY_SCENE, msg);
                return true;
            }
            return false;
            //登录错误
            //promptMsg.Change(result.ToString(), Color.white);
            //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
        }
        /// <summary>
        /// 投资信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool investInfoResponse(List<InvestInfo> msg)
        {
            if (msg == null) return false;
            Dispatch(AreaCode.UI, UIEvent.SENCE_INVEST_VIEW, msg);
            return true;
        }
    }
}
