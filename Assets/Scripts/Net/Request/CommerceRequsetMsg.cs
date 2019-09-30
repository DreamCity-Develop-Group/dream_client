using System.Collections.Generic;
using Assets.Scripts.Model;
using Assets.Scripts.Net.Code;
using Assets.Scripts.UI.Msg;
using UnityEngine;

/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/19 18:21:25
  *
  * Description:   
  *
  * Version:    0.1
  *
  *
***/
namespace Assets.Scripts.Net.Request
{
    public class CommerceRequsetMsg 
    {
        private HintMsg promptMsg = new HintMsg();
        SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
        MessageData<Dictionary<string, string>> messageData = new MessageData<Dictionary<string, string>>();
        /// <summary>
        /// 商会请求加入消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<Dictionary<string,string>> ReqComeCommerceMsg(object msg)
        {
            Dictionary<string, string> t = msg as Dictionary<string, string>;
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token",PlayerPrefs.GetString("token"));
            messageData.Change("consumer", "commerce", t);
            socketMsg.Change(LoginInfo.ClientId, "商会请求加入消息", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 购买MT消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<Dictionary<string, string>> ReqBuyMTMsg(object msg)
        {
            Dictionary<string, string> t = msg as Dictionary<string, string>;
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token",PlayerPrefs.GetString("token"));
            messageData.Change("consumer", "commerce", t);
            socketMsg.Change(LoginInfo.ClientId, "购买MT消息请求", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 会长发放结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<Dictionary<string, string>> ReqSendMTMsg(object msg)
        {
            Dictionary<string, string> t = msg as Dictionary<string, string>;
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token",  PlayerPrefs.GetString("token"));
            messageData.Change("consumer", "commerce", t);
            socketMsg.Change(LoginInfo.ClientId, "会长发放结果", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 商会信息请求
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<Dictionary<string, string>> ReqCommerceMsg(object msg)
        {
            Dictionary<string, string> t = msg as Dictionary<string, string>;
            t.Add("username", PlayerPrefs.GetString("username"));
            t.Add("token",PlayerPrefs.GetString("token"));
            messageData.Change("consumer", "commerce", t);
            socketMsg.Change(LoginInfo.ClientId, "商会信息请求", messageData);
            return socketMsg;
        }

        
    }
}
