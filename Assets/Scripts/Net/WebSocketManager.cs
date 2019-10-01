using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Net.Code;
using Assets.Scripts.Net.Handler;
using Assets.Scripts.Net.Request;
using Assets.Scripts.Scenes;
using Assets.Scripts.Scenes.Msg;
using Assets.Scripts.Tools;
using Assets.Scripts.UI;
using LitJson;
using UnityEngine;
using EventType = Assets.Scripts.Net.EventType;

namespace Assets.Scripts.Net
{
    public class WebSocketManager : ManagerBase
    {
        public static WebSocketManager Instance = null;

        private void Awake()
        {
            Instance = this;
            Add(0, this);
        }
        #region 处理发送服务器的请求

        private AccountRequestMsg accountRequestMsg = new AccountRequestMsg();
        private FriendRequestMsg friendRequestMsg = new FriendRequestMsg();
        private SetRequestMsg setRequestMsg = new SetRequestMsg();
        private CommerceRequsetMsg commerceRequsetMsg = new CommerceRequsetMsg();
        private InvestRequestMsg investRequestMsg = new InvestRequestMsg();
        private SocketMsg<Dictionary<string,string>> socketMsg;
        private SocketMsg<SquareUser> squareMsg;

        protected internal override void Execute(int eventCode, object message)
        {
            //初始化联接操作
            if (_wabData.WebSocket == null||eventCode == EventType.init)
            {
                _wabData.OpenWebSocket();
                //登入断线重连
                if (PlayerPrefs.HasKey("token")&&_wabData.WebSocket.IsAlive)
                {
                    Dictionary<string, string> logMsg = new Dictionary<string, string>()
                    {
                        // ["token"] = CacheData.Instance().Token
                        ["token"] = PlayerPrefs.GetString("token")
                    };
                    _wabData.SendMsg(logMsg);
                }
                return;
            }

            if  (_wabData.WebSocket!=null&&_wabData.WebSocket.IsAlive)
            {
                switch (eventCode)
                {
                    case EventType.pwlogin:
                        //密码登入操作
                        socketMsg = accountRequestMsg.ReqPWLoginMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.idlogin:
                        //验证码登入
                        socketMsg = accountRequestMsg.ReqIDLoginMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.regist:
                        //注册操作
                        socketMsg = accountRequestMsg.ReqRegMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.pwforget:
                        //忘记密码
                        socketMsg = accountRequestMsg.ReqForgetMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.addfriend:
                        //添加好友
                        socketMsg = friendRequestMsg.ReqAddFriendMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }

                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.identy:
                        //获取验证码
                        socketMsg = accountRequestMsg.ReqGetIdentityMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.expw:
                        //修改密码
                        socketMsg = setRequestMsg.ReqPWChangeMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.expwshop:
                        //设置交易密码
                        socketMsg = setRequestMsg.ReqExPwShopMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    //case EventType.voiceset:
                    //    //音效设置
                    //    socketMsg = setRequestMsg.ReqVoiceSetMsg(message);
                    //    _wabData.SendMsg(socketMsg);
                    //    break;
                    case EventType.searchfriend:
                        //搜索用户
                        socketMsg = friendRequestMsg.ReqSearchUserMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.likefriend:
                        //好友点赞
                        socketMsg = friendRequestMsg.ReqLikeFriendMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.applytofriend:
                        //申请通过/拒绝
                        
                        socketMsg = friendRequestMsg.ReqAgreeFriendMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.property:
                        //测试资产请求
                        socketMsg = accountRequestMsg.ReqPropertyTestMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.nextgrouds:
                        //换一批
                        socketMsg = friendRequestMsg.ReqNextUserList(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.commerce_member:
                        //商会成员信息请求
                        socketMsg = commerceRequsetMsg.ReqCommerceMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.commerce_in:
                        //商会加入请求
                        socketMsg = commerceRequsetMsg.ReqComeCommerceMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.transfer:
                        socketMsg = accountRequestMsg.ReqTransferMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.recharge:
                        socketMsg = accountRequestMsg.ReqRechargeMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.commerce_sendmt:
                        socketMsg = commerceRequsetMsg.ReqSendMTMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.invest_req:
                        socketMsg = investRequestMsg.ReqInvestMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.squarefriend:
                        socketMsg = friendRequestMsg.ReqSearchUserMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.menu_req:
                        socketMsg = accountRequestMsg.ReqMenuMsg(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.change_expwshop:
                        socketMsg = setRequestMsg.ReqPWShopChangeMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.applyfriend:
                        socketMsg = friendRequestMsg.ReqApplyFriendList(message);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.exit:
                        socketMsg = accountRequestMsg.ReqExitMsg(null);
                        if (socketMsg == null)
                        {
                            return;
                        }
                        _wabData.SendMsg(socketMsg);
                        _wabData.WebSocket.Close(1000, "Bye!");
                        Dispatch(AreaCode.SCENE,UIEvent.LOG_ACTIVE,true);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.LogError("连接断开");
            }
        }
        #endregion
        #region Private Fields

        /// <summary>  
        /// The WebSocket address to connect  
        /// </summary>  
        private string _address;

        /// <summary>  
        /// Debug text to draw on the gui  
        /// </summary>  
        private string _text;

        /// <summary>  
        /// GUI scroll position  
        /// </summary>  
        private Vector2 _scrollPos;

        private WebData _wabData;

        #endregion
        private void Start()
        {
            _wabData = WebData.Instance();
            _address = _wabData.Address;
            _text = _wabData.Text;
        }

        private void Update()
        {
            if (_wabData.MsgQueue.Count > 0)
            {
                SocketMsg<Dictionary<string,string>>info = _wabData.MsgQueue.Dequeue();
                processSocketMsg(info);
            
            }
            if (_wabData.SquareQueue.Count > 0)
            {
                SocketMsg<SquareUser> squareinfo = _wabData.SquareQueue.Dequeue();
                processSquareMsg(squareinfo);
            }
            if (_wabData.MenuQueue.Count > 0)
            {
                SocketMsg<MenuInfo> menuinfo = _wabData.MenuQueue.Dequeue();
                processMenuMsg(menuinfo);
            }

            if (_wabData.InvestQueue.Count>0)
            {
                SocketMsg<List<InvestInfo>> investinfo = _wabData.InvestQueue.Dequeue();
                processInvestSocketMsg(investinfo);
            }

            if (_wabData.MessageQueue.Count > 0)
            {
                SocketMsg<List<MessageInfo>> messageinfo = _wabData.MessageQueue.Dequeue();
                processMessageSocketMsg(messageinfo);
            }
        
        }


        private void OnDestroy()
        {
            //if (_wabData.WebSocket != null)
            //    _wabData.WebSocket.Close();
        }

        public bool ReConnectState = false;
        /// <summary>
        /// 断线重连
        /// </summary>
        public IEnumerator  ReConnect()
        {
            ReConnectState = true;
                while (WebData.Instance().RecTimes <= 10)
                {
                    WebData.Instance().RecTimes += 1;
                    yield return new WaitForSeconds(5);
                    if (!WebData.Instance().IsReconnect)
                    {
                        Debug.Log("第" + WebData.Instance().RecTimes + "次重连尝试");
                        WebData.Instance().OpenWebSocket();
                    }
                    else
                    {
                        ReConnectState = false;
                        break;
                    }
                }
                if (WebData.Instance().RecTimes >10)
                {
                    Debug.LogError("网络断开");
                    //客户端断开网络退出应用
                    //Application.Quit();
                    SceneMsg msg = new SceneMsg("login",
                        delegate () {
                            Debug.Log("场景加载完成");
                            Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
                        });
                    //
                    Dispatch(AreaCode.SCENE, SceneEvent.LOGIN_PLAY_SCENE, msg);
            }
                   
                
        }

        //void OnGUI()
        //{
        //    _address = GUILayout.TextField(_address);
        //}

        #region 处理接收到的服务器发来的消息

        private HandlerBase accountHandler = new AccoutHandler();
        private Dictionary<string, string> dicRegLogRespon;
        private SquareUser squareData;
        private InvestHandler investHandler = new InvestHandler();
        private HandlerBase setHandler = new SetHandler();
        private FriendHandler friendHandler = new FriendHandler();
        private CommerceHander commerceHander = new CommerceHander();
        /// <summary>
        /// 处理接收到的服务器发来的消息模块
        /// </summary>
        /// <param name="msg"></param>
        /// 
        private void processMsg(SocketMsg<MenuInfo> msg)
        {
            //test
            string jsonmsg = JsonMapper.ToJson(msg);
            //Dispatch(AreaCode.UI, UIEvent.TEST_PANEL_ACTIVE, "reciveMsg"+ MsgTool.utf8_gb2312(jsonmsg));
            switch (msg.data.type)
            {
                case "default":
                    //todo 缓存
                    Dispatch(AreaCode.UI, UIEvent.MENU_PANEL_VIEW, msg.data.data);
                    break;
                default:
                    break;
            }
        }

        private void processCommerceSocketMsg(SocketMsg<CommerceInfo> msg)
        {
            switch (msg.data.type)
            {
                case "commerce":
                    //todo 缓存
                    Dispatch(AreaCode.UI, UIEvent.MESSAGE_PANEL_VIEW, msg.data.data);

                    break;
            }
        }

        private void processMessageSocketMsg(SocketMsg<List<MessageInfo>> msg)
        {
            switch (msg.data.type)
            {
                case "message":
                    //todo 缓存
                    Dispatch(AreaCode.UI, UIEvent.MESSAGE_PANEL_VIEW, msg.data.data);

                    break;
            }
        }
        private void processMenuMsg(SocketMsg<MenuInfo> msg)
        {
            switch (msg.data.type)
            {
                case "default":
                    //todo 缓存
                    Dispatch(AreaCode.UI,UIEvent.MENU_PANEL_VIEW,msg.data.data);
                    break;
                default:
                    break;
            }
        }
        private void processSquareMsg(SocketMsg<SquareUser> msg)
        {

            switch (msg.data.type)
            {
                case "squareFriends":
                    SquareUser squareUser = msg.data.data as SquareUser;
                    friendHandler.OnReceive(EventType.squarefriend, squareUser);
                    break;
                case "applyFriend":
                    SquareUser applyUser = msg.data.data as SquareUser;
                    friendHandler.OnReceive(EventType.applyfriend, applyUser);
                    break;
                case "friendList":
                    SquareUser friendUser = msg.data.data as SquareUser;
                    friendHandler.OnReceive(EventType.listfriend, friendUser);
                    break;
                default:
                    break;
            }
        }

        private void processInvestSocketMsg(SocketMsg<List<InvestInfo>> msg)
        {
            if (msg == null || msg.data == null)
            {
                Debug.Log("message is null");
                return;
            }

            switch (msg.data.type)
            {
                case "getInvestList":

                    investHandler.OnReceive(EventType.invest_info, msg.data.data);
                    break;
            }
        }

        private void processSocketMsg(SocketMsg<Dictionary<string,string>> msg)
        {

            if (msg == null||msg.data==null)
            {
                Debug.Log("message is null");
                return;
            }
            
            dicRegLogRespon = msg.data.data as Dictionary<string, string>;
        
            switch (msg.data.type)
            {
                case "init":
                   
                    accountHandler.OnReceive(EventType.init, msg.target);
                    //_wabData.ThreadStart();
                    break;
                case "Login":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("login error");
                        return;
                    }
                    if (accountHandler.OnReceive(EventType.login, dicRegLogRespon["desc"]))
                    {
                        if (dicRegLogRespon.ContainsKey("token"))
                        {
                          //  CacheData.Instance().Token= dicRegLogRespon["token"].ToString();
                          PlayerPrefs.SetString("token", dicRegLogRespon["token"].ToString());
                        }
                        WebData.isLogin = true;
                    }
                    break;
                case "codeLogin":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("codeLogin error");
                        return;
                    }
                    if (accountHandler.OnReceive(EventType.login, dicRegLogRespon["desc"]))
                    {
                        if (dicRegLogRespon.ContainsKey("token"))
                        {
                            //CacheData.Instance().Token= dicRegLogRespon["token"].ToString();
                            PlayerPrefs.SetString("token", dicRegLogRespon["token"].ToString());
                        }
                        WebData.isLogin = true;
                    }
                    break;
                case "reg":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("reg error");
                        return;
                    }
                    accountHandler.OnReceive(EventType.regist, dicRegLogRespon["desc"]);
                    break;
                case "voice":
                    // setHandler.OnReceive(EventType.voiceset, msg.data.t);
                    break;
                case "expw":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("expw error");
                        return;
                    }
                    setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                    break;
                case "expwshop":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("expwshop error");
                        return;
                    }
                    setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                    break;
                case "sendmt":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("sendmt error");
                        return;
                    }
                    commerceHander.OnReceive(EventType.commerce_sendmt,dicRegLogRespon);
                    break;
                case "addFriend":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("addfriend error");
                        return;
                    }
                    friendHandler.OnReceive(EventType.addfriend, dicRegLogRespon["desc"]);
                    break;
                case "likefriend":
                    // friendHandler.OnReceive(EventType.likefriend, msg.data.t["desc"]);
                    break;
                //case "searchfriend":
                //    SquareUser searchUser = msg.data.t as SquareUser;
                //    friendHandler.OnReceive(EventType.searchfriend, msg.data.t);
                //    break;
                case "getCode":
                    if (dicRegLogRespon==null||!dicRegLogRespon.ContainsKey("code"))
                    {
                        Debug.LogError("getCode error");
                        return;
                    }
                    accountHandler.OnReceive(EventType.identy, msg.data.data["code"]);
                    break;
                case "pwforget":
                    //忘记密码响应和修改一样
                    //setHandler.OnReceive(EventType)
                    if (dicRegLogRespon == null||!dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("pwforget error");
                        return;
                    }
                    setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                    break;
                case "property":
                    break;
                case "transferaccount":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("transferaccount error");
                        return;
                    }
                    accountHandler.OnReceive(EventType.transfer, dicRegLogRespon["desc"]);
                    break;
                case "recharge":
                    break;
                case "playerInvest":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("playerInvest error");
                        return;
                    }
                    investHandler.OnReceive(EventType.invest_req, dicRegLogRespon["desc"]);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
