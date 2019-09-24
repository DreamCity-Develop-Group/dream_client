using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;
//using LitJson;
using WebSocketSharp;
using System.Text;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WebData
{
    /// <summary>  
    /// The WebSocket address to connect  
    /// </summary>  
    //private readonly string address = "ws://192.168.0.102:8010/dream/city/";
    // private readonly string address = "ws://192.168.0.88:8010/dream/city/lili/你发";
    private  string address = "ws://192.168.0.88:8010/dream/city/lili/你发";
    public static string ip= "192.168.0.88";
    //private string address;

    /// <summary>  
    /// Default text to send  
    /// </summary>  

    /// <summary>
    /// 心跳时间
    /// </summary>
    private int recTimes;

    /// <summary>
    /// 重连判断
    /// </summary>
    public  bool isReconnect=false;
    /// <summary>  
    /// Debug text to draw on the gui  
    /// </summary>  
    private string _text = string.Empty;

    public static string ClientId;

    /// <summary>  
    /// Saved WebSocket instance  
    /// </summary>  
    private WebSocket _webSocket;

    private Queue<SocketMsg<Dictionary<string,string>>> _msgQueue = new Queue<SocketMsg<Dictionary<string, string>>> ();

    private Queue<SocketMsg<SquareUser>> _squareQueue = new Queue<SocketMsg<SquareUser>>();

    private Queue<SocketMsg<MenuInfo>> _menuQueue = new Queue<SocketMsg<MenuInfo>>();
    //private 
    public WebSocket WebSocket { get { return _webSocket; } }
    public string Address { get { return address; } }
    public string Text { get { return _text; } }

    public Queue<SocketMsg<Dictionary<string, string>>> MsgQueue { get => _msgQueue; set => _msgQueue = value; }
    public Queue<SocketMsg<SquareUser>> SquareQueue { get => _squareQueue; set => _squareQueue = value; }
    public Queue<SocketMsg<MenuInfo>> MenuQueue { get => _menuQueue; set => _menuQueue = value; }

    public void OpenWebSocket()
    {
        if (_webSocket == null)
            {
            address = "ws://"+ip+":8010/dream/city/lili/你发";
            _webSocket = new WebSocket(address,null);
            //if (HTTPManager.Proxy != null)
            //    _webSocket.InternalRequest.Proxy = new HTTPProxy(HTTPManager.Proxy.Address, HTTPManager.Proxy.Credentials, false);
            // Subscribe to the WS events  
            _webSocket.OnOpen += (sender, e) => {
                OnOpen();
             };
            _webSocket.OnMessage += (sender, e) => {
                OnMessageReceived(e.Data);
            };
            _webSocket.OnClose += (sender, e) => {
                OnClosed(e.Reason);
            };
            _webSocket.OnError += (sender, e) => {
                OnError(e.Exception,e.Message);
            };
            // Start connecting to the server  
            _webSocket.Connect();
        }
    }
    //readonly CancellationToken _cancellation = new CancellationToken();
    public   void SendMsg(object msg)
    {
        // Send message to the server  
     
            //if (_webSocket == null)
            //{
            //    ReConnect();
            //}
        //TODOtest

        //SocketMsg msg1 = new SocketMsg();
        
        //string jsonmsg = JsonMapper.ToJson(msg1);
         string jsonmsg = JsonMapper.ToJson(msg);
        Debug.Log("sendMsg: "+jsonmsg);
        //TODOtest
       
        _webSocket.Send(jsonmsg);
    }
    string statusDescription;
    public void CloseSocket()
    {
        // Close the connection  
        threads.Enqueue(t1);
        t1.Abort();
        _webSocket.Close(1000, "Bye!");
        _webSocket = null;
    }
    /// <summary>
    /// 心跳检测
    /// </summary> 
    Thread t1;
    int timeout = 3000;
    public bool isLogin = false;
    private static object lockObj = new object();
    private void heartCheck()
    {
        while (true)
        {
            lock (lockObj)
            {
                Thread.Sleep(timeout);
            //  SocketMsg msg = new SocketMsg(null, null, "ping", null);

                isReconnect = false;
                if (isLogin)
                {
                    _webSocket.Send("ping_" + PlayerPrefs.GetString("username"));
                }
                else
                {
                    _webSocket.Send("ping");
                }
            }
           
        }

    }

    /// <summary>  
    /// Called when the web socket is open, and we are ready to send and receive data  
    /// </summary>  
    void OnOpen()
    {
        recTimes = 0;
        isReconnect = true;
        if (PlayerPrefs.HasKey("token"))
        {
            Dictionary<string, object> logMsg = new Dictionary<string, object>()
            {
                ["token"] = PlayerPrefs.GetString("token"),
            };
            SendMsg(logMsg);
        }
        Debug.Log("-WebSocket Open!\n");
    }
    /// <summary>  
    /// Called when we received a text message from the server  
    /// </summary>  
    void OnMessageReceived(string jsonmsg)
     {
        Debug.Log("receiveMsg:  "+jsonmsg);
        if (jsonmsg.Contains("success"))
        {
            if (jsonmsg.Length>7)
            {
                PlayerPrefs.SetString("token", jsonmsg.Substring(8));
            }
            isReconnect = true;
            Debug.Log("isconnect"+jsonmsg);
            return;
        }

        SocketMsg<object> info = JsonMapper.ToObject<SocketMsg<object>>(jsonmsg);
        if (info == null)
        {
            Debug.Log("msg null error");
            return;
        }

        if(info.data.type== "squarefriend" || info.data.type == "listfriend")
        {
            SocketMsg<SquareUser> squareinfo = JsonMapper.ToObject<SocketMsg<SquareUser>>(jsonmsg);
            //TODO 过滤过时消息
            Debug.Log(squareinfo);
            SquareQueue.Enqueue(squareinfo);
            
        }
        else if (info.data.type=="")
        {
            SocketMsg<MenuInfo> menuinfo = JsonMapper.ToObject<SocketMsg<MenuInfo>>(jsonmsg);
            //TODO 过滤过时消息
            Debug.Log(menuinfo);
            MenuQueue.Enqueue(menuinfo);
        }
        else
        {
            SocketMsg<Dictionary<string,string>> msginfo = JsonMapper.ToObject<SocketMsg<Dictionary<string, string>>>(jsonmsg);
            //TODO 过滤过时消息
            Debug.Log(msginfo);
            MsgQueue.Enqueue(msginfo);
            
        }
    }
    /// <summary>  
    /// Called when the web socket closed  
    /// </summary>  
    void OnClosed(string message)
    {
        t1.Abort();
        isReconnect = false;
        ReConnect();
        Debug.Log(string.Format("-WebSocket closed! Code:  Message: [0]\n", message));
    }

    /// <summary>
    /// 断线重连
    /// </summary>
    private void ReConnect()
    {
        if (!isReconnect)
        {
            if (recTimes < 59)
            {
                recTimes += 1;
                OpenWebSocket();
            }
            else
            {
                //TODO跳到登入场景中去
                Debug.LogError("网络断开");
            }
        }
    }
    /// <summary>
    ///线程处理
    /// </summary>
    Queue<Thread> threads = new Queue<Thread>();
    public void ThreadStart()
    {
        if (threads.Count > 0)
        {
            t1 = threads.Dequeue();
        }
        else
        {
            t1 = new Thread(heartCheck);
            t1.Start();
            t1.IsBackground = true;
        }
    }
    /// <summary>  
    /// Called when an error occured on client side  
    /// </summary>  
    void OnError(Exception ex, string  error)
    {
        Debug.Log(string.Format("-An error occured: {0}\n", ex != null ? ex.Message : "Unknown Error " + error));
       //_webSocket = null;
    }
}



