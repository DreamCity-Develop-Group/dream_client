
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
using Assets.Scripts.Model;
using Assets.Scripts.Net.Code;

namespace Assets.Scripts.Net.Request
{
    public class SetRequestMsg 
    {
        MessageData<Dictionary<string, string>> messageData = new MessageData<Dictionary<string, string>>();
        SocketMsg<Dictionary<string, string>> socketMsg = new SocketMsg<Dictionary<string, string>>();
        /// <summary>
        /// 设置交易密码
        /// </summary>
        /// <returns></returns>
        public SocketMsg<Dictionary<string,string>> ReqExPwShopMsg(object msg)
        {
            UserInfo userinfo = msg as UserInfo;

            Dictionary<string, string> t = new Dictionary<string, string>
            {
                ["username"] = userinfo.Phone,
                ["userpass"] = userinfo.Password,
                ["code"] = userinfo.Identity,
                ["NickName"] = userinfo.NickName,
                ["invite"] = userinfo.InviteCode
            };
            messageData.model = "consumer";
            messageData.type = "expwshop";
            messageData.Change("consumer", "expwshop",t);
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
            messageData.model = "consumer";
            messageData.type = "voice";
            socketMsg.Change(LoginInfo.ClientId, "音效设置", messageData);
            return socketMsg;
        }
    }
}
