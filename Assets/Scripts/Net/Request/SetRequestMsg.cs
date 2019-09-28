
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/11 09:23:12
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/

using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Net.Code;
using Assets.Scripts.Net.Handler;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Msg;
using UnityEngine;

namespace Assets.Scripts.Net.Request
{
    public class SetRequestMsg :HandlerBase
    {
        MessageData<Dictionary<string, string>> messageData = new MessageData<Dictionary<string, string>>();
        SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
        private HintMsg promptMsg = new HintMsg();
        /// <summary>
        /// 设置交易密码
        /// </summary>
        /// <returns></returns>
        public SocketMsg<Dictionary<string,string>> ReqExPwShopMsg(object msg)
        {
            UserInfo userinfo = msg as UserInfo;

            Dictionary<string, string> t = new Dictionary<string, string>
            {
                ["pwshop"] = userinfo.Password,
                ["code"] = userinfo.Identity,
                ["invite"] = userinfo.InviteCode
            };
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token", PlayerPrefs.GetString("token"));
            messageData.model = "consumer";
            messageData.type = "expwshop";
            messageData.Change("consumer/player", "expwshop",t);
            socketMsg.Change(LoginInfo.ClientId, "注册操作", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 音效设置
        /// </summary>
        /// <returns></returns>
        public SocketMsg<Dictionary<string, string>> ReqVoiceSetMsg(object msg)
        {
            SetInfo setInfo = msg as SetInfo;

            Dictionary<string, string> t = new Dictionary<string, string>
            {
                ["bg"] = setInfo.BgVoice,
                ["game"] = setInfo.GameVoice

            };
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token", PlayerPrefs.GetString("token"));
            messageData.model = "consumer/player";
            messageData.type = "voice";
            socketMsg.Change(LoginInfo.ClientId, "音效设置", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 修改密码消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<Dictionary<string, string>> ReqPWChangeMsg(object msg)
        {

            Dictionary<string, string> t = msg as Dictionary<string, string>;
            //todo配置
            if (t["oldpw"] == null || t["oldpw"].Equals(""))
            {
                promptMsg.Change("请输入当前密码", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }
            if (t["newpw"] == null || t["newpw"].Equals(""))
            {
                promptMsg.Change("请输入新密码", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }
            if (t["code"] == null || t["code"].Equals(""))
            {
                promptMsg.Change("请输入验证码", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token", PlayerPrefs.GetString("token"));
            messageData.Change("consumer/player", "expw", t);
            socketMsg.Change(LoginInfo.ClientId, "修改登入密码操作", messageData);
            return socketMsg;
        }

        /// <summary>
        /// 修改交易密码消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<Dictionary<string, string>> ReqPWShopChangeMsg(object msg)
        {

            Dictionary<string, string> t = msg as Dictionary<string, string>;
            //todo配置
            if (t["oldpw"] == null || t["oldpw"].Equals(""))
            {
                promptMsg.Change("请输入当前密码", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }
            if (t["newpw"] == null || t["newpw"].Equals(""))
            {
                promptMsg.Change("请输入新密码", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }
            if (t["code"] == null || t["code"].Equals(""))
            {
                promptMsg.Change("请输入验证码", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }

            if (CacheData.Instance().Mt < CacheData.Instance().ChangExPassWordMt)
            {
                promptMsg.Change("你的MT不足", Color.red);
                Dispatch(AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
                return null;
            }
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token", PlayerPrefs.GetString("token"));
            messageData.Change("consumer/player", "change_expwshop", t);
            socketMsg.Change(LoginInfo.ClientId, "修改交易密码操作", messageData);
            return socketMsg;
        }

    }
}
