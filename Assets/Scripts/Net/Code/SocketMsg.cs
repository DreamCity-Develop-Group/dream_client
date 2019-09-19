using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 网络消息
/// 作用：发送的时候 都要发送这个类
/// </summary>
[System.Serializable]
public class SocketMsg
{
   
     /// <summary>
    ///  //源clientid
    /// </summary>
    public string source { get; set; }
    /// <summary>
    /// // 消息数据
    /// </summary>
    public MessageData data { get; set; }
    /// <summary>
    ///  // 发送目的地
    /// </summary>
    public string target { get; set; }
    /// <summary>
    ///  // 消息保存时间
    /// </summary>
    public string createtime { get; set; }
    /// <summary>
    /// // 描述
    /// </summary>
    public string desc { get; set; }
    //public  MessageData data=new MessageData() ;
    //public string desc;
    //public string target;
    //public string createtime;
    //public string source;
    public SocketMsg()
    {
        
    }

    public  SocketMsg(string Source,string desc, MessageData data, string target="server")
    {
        source = Source;
        this.target = target;
        createtime = GetTimeStamp();
        this.desc = desc;
        this.data = data;
    }
    /// <summary>
    /// 防止重复创建socket
    /// </summary>
    public void Change()
    {
        //this.source = source;
        //this.target = target;
        //this.createtime = GetTimeStamp();
        //this.desc = desc;
        //this.data = data;
        //if (source != null || source != "")
        //{
        //    ClientId = source;
        //    this.source = ClientId;
        //}
    }
    /// <summary>
    ///  获取时间戳
    /// </summary>
    /// <returns></returns>
    private string GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds).ToString();
    }
}
/// <summary>
/// 
/// </summary>
public class Condition
{
    /// <summary>
    /// 
    /// </summary>
    public string friendId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string playerId { get; set; }
}


/// <summary>
/// 广场用户
/// </summary>
public class UserInfos {
    /// <summary>
    /// 
    /// </summary>
    public string friendName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string imgurl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string friendId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string friendNick { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string agree { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string friendlink { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string playerId { get; set; }
}


public class SquareUser
{
    /// <summary>
    /// 
    /// </summary>
    public int start { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int pageSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int pageNo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int totalCount { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Condition condition { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<UserInfos> result { get; set; }
}

public class MessageData
{
    /// <summary>
    /// //事件类型
    /// </summary>
    public string type { get; set; }
    /// <summary>
    ///  //接收事件处理的模块
    /// </summary>
    public string model { get; set; }
    /// <summary>
    /// //具体业务数据
    /// </summary>
    public Object t { get; set; }
}



