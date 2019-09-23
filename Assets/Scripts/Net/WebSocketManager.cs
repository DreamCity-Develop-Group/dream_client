using System;
using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
public class WebSocketManager : ManagerBase
{
    public static WebSocketManager Instance = null;

    private void Awake()
    {
        Instance = this;
        Add(0, this);
    }
    #region 处理发送服务器的请求
    AccountRequestMsg accountRequestMsg = new AccountRequestMsg();
    FriendRequestMsg friendRequestMsg = new FriendRequestMsg();
    SetRequestMsg setRequestMsg = new SetRequestMsg();
    CommerceRequsetMsg commerceRequsetMsg = new CommerceRequsetMsg();
    SocketMsg<Dictionary<string,string>> socketMsg;
    SocketMsg<SquareUser> squareMsg;
    public override void Execute(int eventCode, object message)
    {
        //初始化操作
        if (eventCode == EventType.init && _wabData.WebSocket == null)
        {
            _wabData.OpenWebSocket();
            if (PlayerPrefs.HasKey("token"))
            {
                Dictionary<string, string> logMsg = new Dictionary<string, string>()
                {
                    ["token"] = PlayerPrefs.GetString("token"),
                };
                _wabData.SendMsg(logMsg);
            }
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
                    _wabData.SendMsg(socketMsg);
                    break;
                case EventType.regist:
                    //注册操作
                    socketMsg = accountRequestMsg.ReqRegMsg(message);
                    //TODOtest
                    //if (socketMsg == null)
                    //{
                    //    return;
                    //}
                    _wabData.SendMsg(socketMsg);
                    break;
                case EventType.pwforget:
                    //忘记密码
                    socketMsg = accountRequestMsg.ReqPWChangeMsg(message);
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
                   // _wabData.SendMsg(socketMsg);
                    break;
                case EventType.expw:
                    //修改密码TODO 暂时设置和忘记密码模块一样
                    socketMsg = accountRequestMsg.ReqPWChangeMsg(message);
                    _wabData.SendMsg(socketMsg);
                    break;
                case EventType.expwshop:
                    //设置交易密码
                    socketMsg = setRequestMsg.ReqExPwShopMsg(message);
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
                case EventType.commerce_sendmt:
                    socketMsg = commerceRequsetMsg.ReqSendMTMsg(message);
                    _wabData.SendMsg(socketMsg);
                    break;
                case EventType.exit:
                    socketMsg.desc = "exit";
                    socketMsg.data = null;
                    _wabData.SendMsg(socketMsg);
                    _wabData.WebSocket.Close(1000, "Bye!");
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
    string _address;

    /// <summary>  
    /// Debug text to draw on the gui  
    /// </summary>  
    string _text;

    /// <summary>  
    /// GUI scroll position  
    /// </summary>  
    Vector2 _scrollPos;

    private WebData _wabData;

    #endregion


    void Start()
    {
        _wabData = new WebData();
        _address = _wabData.Address;
        _text = _wabData.Text;
    }

    void Update()
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
        
    }


    void OnDestroy()
    {
        //if (_wabData.WebSocket != null)
        //    _wabData.WebSocket.Close();
    }

    void OnGUI()
    {
        _address = GUILayout.TextField(_address);
    }

    #region 处理接收到的服务器发来的消息
    HandlerBase accountHandler = new AccoutHandler();
    Dictionary<string, string> dicRegLogRespon;
    SquareUser squareData;
   
    HandlerBase setHandler = new SetHandler();
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
    HandlerBase friendHandler = new FriendHandler();
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
        switch (msg.data.type)
        {
            case "":

                break;
            default:
                break;
        }
    }
    private void processSquareMsg(SocketMsg<SquareUser> msg)
    {
        switch (msg.data.type)
        {
            case "squarefriend":
                SquareUser squareUser = msg.data.t as SquareUser;
                friendHandler.OnReceive(EventType.squarefriend, squareUser);
                break;
            case "applyfriend":
                SquareUser applyUser = msg.data.t as SquareUser;
                friendHandler.OnReceive(EventType.applyfriend, applyUser);
                break;
            default:
                break;
        }
    }
    private void processSocketMsg(SocketMsg<Dictionary<string,string>> msg)
    {
        dicRegLogRespon = msg.data.t as Dictionary<string, string>;
        switch (msg.data.type)
        {
            case "init":
              
                accountHandler.OnReceive(EventType.init, msg.target);
                break;
            case "logoin":
                if (!dicRegLogRespon.ContainsKey("desc"))
                {
                    Debug.LogError("logoin error");
                    return;
                }
                if (accountHandler.OnReceive(EventType.login, dicRegLogRespon["desc"]))
                {
                    if (dicRegLogRespon.ContainsKey("token"))
                    {
                        PlayerPrefs.SetString("token", dicRegLogRespon["token"].ToString());
                    }
                    _wabData.ThreadStart();
                }
                break;

            case "reg":
                if (!dicRegLogRespon.ContainsKey("desc"))
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
                if (!dicRegLogRespon.ContainsKey("desc"))
                {
                    Debug.LogError("expw error");
                    return;
                }
                setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                break;
            case "expwshop":
                setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                break;
            case "addfriend":
                if (!dicRegLogRespon.ContainsKey("desc"))
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
            case "pwforget":
                //setHandler.OnReceive(EventType)
                if (!dicRegLogRespon.ContainsKey("desc"))
                {
                    Debug.LogError("pwforget error");
                    return;
                }
                setHandler.OnReceive(EventType.expw, dicRegLogRespon["desc"]);
                break;
            default:
                break;
        }
    }
    #endregion
}
