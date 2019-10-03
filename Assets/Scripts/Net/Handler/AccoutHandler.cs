using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Scenes;
using Assets.Scripts.Scenes.Msg;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Msg;
using UnityEngine;

namespace Assets.Scripts.Net.Handler
{
    public class AccoutHandler: HandlerBase
    {
        // SocketMsg msg = new SocketMsg();

        public  override bool OnReceive(int subCode, object value)
        {
            switch (subCode)
            {
                case ReqEventType.init:
                    return initResponse(value.ToString());
                case ReqEventType.login:
                    return loginResponse(value.ToString());
                case ReqEventType.regist:
                    return registResponse(value.ToString());
                case ReqEventType.identy:
                    return getCodeResponse(value.ToString());
                case ReqEventType.transfer:
                    return transferResponse(value.ToString());
                case ReqEventType.property:
                    propertyResonse(value as PropertyInfo);
                    break;
                default:
                    break;
            }
            return false;
        }

        private HintMsg promptMsg = new HintMsg();


        private bool initResponse(string msg)
        {
            if (msg != null)
            {
                LoginInfo.ClientId = msg;
                Debug.Log(LoginInfo.ClientId);
                //Dispatch(AreaCode.UI, UIEvent.LOGINSELECT_PANEL_ACTIVE, true);
          
                Dispatch(AreaCode.UI, UIEvent.LOAD_PANEL_ACTIVE, true);
            }
            return true;
        }
       
        /// <summary>
        /// 登录响应
        /// </summary>
        private bool loginResponse(string result)
        {
            promptMsg.Change(result, Color.white);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            if (result == "登录成功")
            {
                //跳转场景 TODO
                SceneMsg msg = new SceneMsg("menu", 
                    delegate () {
                        Debug.Log("场景加载完成");
                        Dispatch(AreaCode.NET, ReqEventType.menu_req, null);
                    });
                //
                Dispatch(AreaCode.SCENE,SceneEvent.MENU_PLAY_SCENE,msg);
                return true;
            }
            return false;
            //登录错误
            //promptMsg.Change(result.ToString(), Color.white);
            //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
        }
        /// <summary>
        /// 验证码响应
        /// </summary>
        private bool getCodeResponse(string result)
        {
            promptMsg.Change(result, Color.white);

            Dispatch(AreaCode.UI, UIEvent.REG_PANEL_CODEVIEW, result);
       
            return true;
        }
        /// <summary>
        /// 注册响应
        /// </summary>
        private bool registResponse(string result)
        {
            if (result == "注册成功")
            {
                promptMsg.Change(result.ToString(), Color.green);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                Dispatch(AreaCode.UI, UIEvent.REG_ACTIVE, false);
                Dispatch(AreaCode.UI,UIEvent.LOG_ACTIVE,true);
                return true;
            }
            promptMsg.Change(result, Color.white);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
       
            return false;
            //注册错误
            // promptMsg.Change(result.ToString(), Color.white);
            //Dispatch(AreaCode.UI, UIEvent.PROMPT_MSG, promptMsg);
        }
        private bool forgetpwReponse(string result)
        {
            if (result == "修改成功!")
            {
                promptMsg.Change(result.ToString(), Color.green);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                Dispatch(AreaCode.UI, UIEvent.Forget_ACTIVE, false);
                Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 转账响应
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool transferResponse(string result)
        {
            
            if (result == "转账成功")
            {
                promptMsg.Change(result.ToString(), Color.white);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                //Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                ////Dispatch(AreaCode.UI, UIEvent.Forget_ACTIVE, false);
                ////Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
                return true;
            }
            promptMsg.Change(result.ToString(), Color.white);
            Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool rechargeReponse(string result)
        {
            if (result == "修改成功!")
            {
                promptMsg.Change(result.ToString(), Color.green);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                Dispatch(AreaCode.UI, UIEvent.Forget_ACTIVE, false);
                Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 资产信息
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool propertyResonse(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                //todo测试
                
                return false;
            }
            Dispatch(AreaCode.UI, UIEvent.CHARGE_PANEL_ACTIVE, propertyInfo);

            return false;
        }

        //private bool propertyResonse(string result)
        //{
        //    if (result == "修改成功!")
        //    {
        //        promptMsg.Change(result.ToString(), Color.green);
        //        Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
        //        Dispatch(AreaCode.UI, UIEvent.Forget_ACTIVE, false);
        //        Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
        //        return true;
        //    }
        //    return false;
        //}
    }
}
