using System.CodeDom;
using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Net.Code;
using Assets.Scripts.Net.Handler;
using Assets.Scripts.Net.Request;
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
       


            //初始化操作
            if (eventCode == EventType.init && _wabData.WebSocket == null)
            {
                _wabData.OpenWebSocket();
                if (PlayerPrefs.HasKey("token")&&WebData.isReconnect)
                {
                    Dictionary<string, string> logMsg = new Dictionary<string, string>()
                    {
                        ["token"] = PlayerPrefs.GetString("token"),
                    };
                    _wabData.SendMsg(logMsg);
                }
                return;
            }

            if  (_wabData.WebSocket!=null&&_wabData.WebSocket.IsAlive) //调试TODO(true)
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
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.applytofriend:
                        //申请通过/拒绝
                        socketMsg = friendRequestMsg.ReqAgreeFriendMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.property:
                        //测试资产请求
                        socketMsg = accountRequestMsg.ReqPropertyTestMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.nextgrouds:
                        //换一批
                        socketMsg = friendRequestMsg.ReqNextUserList(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.commerce:
                        //商会信息请求
                        socketMsg = commerceRequsetMsg.ReqCommerceMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.commerce_in:
                        //商会加入请求
                        socketMsg = commerceRequsetMsg.ReqComeCommerceMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.transfer:
                        socketMsg = accountRequestMsg.ReqTransferMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.recharge:
                        socketMsg = accountRequestMsg.ReqRechargeMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.commerce_sendmt:
                        socketMsg = commerceRequsetMsg.ReqSendMTMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.invest_req:
                        socketMsg = investRequestMsg.ReqInvestMsg(message);
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
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.change_expwshop:
                        socketMsg = setRequestMsg.ReqPWShopChangeMsg(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.applyfriend:
                        socketMsg = friendRequestMsg.ReqApplyFriendList(message);
                        _wabData.SendMsg(socketMsg);
                        break;
                    case EventType.exit:
                        socketMsg = accountRequestMsg.ReqExitMsg(null);
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

            //test
            string jsonmsg = JsonMapper.ToJson(socketMsg);
            Dispatch(AreaCode.UI, UIEvent.TEST_PANEL_ACTIVE, "sendMsg:"+ MsgTool.gb2312_utf8(jsonmsg));
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
        
        }


        private void OnDestroy()
        {
            //if (_wabData.WebSocket != null)
            //    _wabData.WebSocket.Close();
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
        /// <summary>
        /// 设置模块
        /// </summary>
        /// <param name="msg"></param>
        //private void setSocketMsg(SocketMsg msg)
        //{
        //    switch (msg.data.type)
        //    {
        //        case "voice":
        //            // setHandler.OnReceive(EventType.voiceset, msg.data.t);
        //            break;

        //        case "expw":
        //            setHandler.OnReceive(EventType.expw, msg.data.t["desc"]);
        //            break;
        //        case "expwshop":
        //            setHandler.OnReceive(EventType.expw, msg.data.t["desc"]);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        private HandlerBase friendHandler = new FriendHandler();
        /// <summary>
        /// friend模块
        /// </summary>
        /// <param name="msg"></param>
        //private void friendSocketMsg(SocketMsg<SquareUser> msg)
        //{
        //    switch (msg.data.type)
        //    {
        //        case "addfriend":
        //            friendHandler.OnReceive(EventType.addfriend, msg.data.t["desc"]);
        //            break;
        //        case "likefriend":
        //            // friendHandler.OnReceive(EventType.likefriend, msg.data.t["desc"]);
        //            break;
        //        case "seachfriend":
        //            friendHandler.OnReceive(EventType.searchfriend, msg.data.t);
        //            break;
        //        case "squarefriend":
        //            friendHandler.OnReceive(EventType.squarefriend, msg.data.t);
        //            break;
        //        case "applyfriend":

        //            friendHandler.OnReceive(EventType.applyfriend, msg.data.t);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        /// <summary>
        /// 处理接收到的服务器发来的消息模块
        /// </summary>
        /// <param name="msg"></param>
        /// 


    
        private void processMenuMsg(SocketMsg<MenuInfo> msg)
        {
            //test
            string jsonmsg = JsonMapper.ToJson(msg);
            //Dispatch(AreaCode.UI, UIEvent.TEST_PANEL_ACTIVE, "reciveMsg"+ MsgTool.utf8_gb2312(jsonmsg));
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
            //test
            string jsonmsg = JsonMapper.ToJson(msg);
            Dispatch(AreaCode.UI, UIEvent.TEST_PANEL_ACTIVE, "reciveMsg" + MsgTool.utf8_gb2312(jsonmsg));

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
            //test
            string jsonmsg = JsonMapper.ToJson(msg);
            Dispatch(AreaCode.UI, UIEvent.TEST_PANEL_ACTIVE, "reciveMsg" + MsgTool.utf8_gb2312(jsonmsg));

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
                            PlayerPrefs.SetString("token", dicRegLogRespon["token"].ToString());
                        }
                        WebData.isLogin = true;
                    }
                    break;
                case "codeLogin":
                    if (dicRegLogRespon == null || !dicRegLogRespon.ContainsKey("desc"))
                    {
                        Debug.LogError("login error");
                        return;
                    }
                    if (accountHandler.OnReceive(EventType.login, dicRegLogRespon["desc"]))
                    {
                        if (dicRegLogRespon.ContainsKey("token"))
                        {
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
                    setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                    break;
                case "":

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
                        Debug.LogError("addfriend error");
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
