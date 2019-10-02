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
        SocketMsg<ReqCommerceInfo> socketMsg = new SocketMsg<ReqCommerceInfo>();
        MessageData<ReqCommerceInfo> messageData = new MessageData<ReqCommerceInfo>();
        ReqCommerceInfo reqCommerceInfo = new ReqCommerceInfo();
        /// <summary>
        /// 商会请求加入消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<ReqCommerceInfo> ReqComeCommerceMsg(object msg)
        {
            if (msg == null || msg.Equals(""))
            {
                //TODO提示
                promptMsg.Change("null",Color.white);
                return null;
            }
            reqCommerceInfo.Change(null,null,msg.ToString(),null,null);
            //t.Add("commerce_name");
            //t.Add("username", PlayerPrefs.GetString("username"));
            //t.Add("token",PlayerPrefs.GetString("token"));
            messageData.Change("consumer/tree", "commerce_in", reqCommerceInfo);
            socketMsg.Change(LoginInfo.ClientId, "商会请求加入消息", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 购买MT消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<ReqCommerceInfo> ReqBuyMTMsg(object msg)
        {
            //Dictionary<string, string> t = msg as Dictionary<string, string>;
            //t.Add("username", PlayerPrefs.GetString("username"));
            //t.Add("token",PlayerPrefs.GetString("token"));
            reqCommerceInfo.Change(null, msg.ToString(), null, null, null);
            messageData.Change("consumer/tree", "commerce_in", reqCommerceInfo);
            socketMsg.Change(LoginInfo.ClientId, "购买MT消息请求", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 会长发放结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<ReqCommerceInfo> ReqSendMTMsg(object msg)
        {
            //Dictionary<string, string> t = msg as Dictionary<string, string>;
            //t.Add("username", PlayerPrefs.GetString("username"));
            //t.Add("token",  PlayerPrefs.GetString("token"));
            reqCommerceInfo.Change(null, null, null, null, msg.ToString());
            messageData.Change("consumer/tree", "commerce", reqCommerceInfo);
            socketMsg.Change(LoginInfo.ClientId, "会长发放结果", messageData);
            return socketMsg;
        }
        /// <summary>
        /// 商会信息请求
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public SocketMsg<ReqCommerceInfo> ReqCommerceMsg(object msg)
        {
            //Dictionary<string, string> t = msg as Dictionary<string, string>;
            //t.Add("username", PlayerPrefs.GetString("username"));
            //t.Add("token",PlayerPrefs.GetString("token"));
            reqCommerceInfo.Change(null, null, null, null, null);
            messageData.Change("consumer/tree", "commerce", reqCommerceInfo);
            socketMsg.Change(LoginInfo.ClientId, "商会信息请求", messageData);
            return socketMsg;
        }

        
    }
}
