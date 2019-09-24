using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/23 09:08:12
  *
  * Description:主页信息数据
  *
  * Version:    0.1
  *
  *
***/
public class MenuInfo
{
    /// <summary>
    /// 
    /// </summary>
    public bool success { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int code { get; set; }
    /// <summary>
    /// 主页信息
    /// </summary>
    public string msg { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public MenuData data { get; set; }
}
public class Profile
{
    /// <summary>
    /// 
    /// </summary>
    public string nick { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int level { get; set; }
}

public class MenuAccount
{
    /// <summary>
    /// 
    /// </summary>
    public int mt { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int usdt { get; set; }
}

public class MenuNoticesItem
{
    /// <summary>
    /// 
    /// </summary>
    public int noticeId { get; set; }
    /// <summary>
    /// 你要做什么，告诉我看看！
    /// </summary>
    public string noticeContent { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int noticeState { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string createTime { get; set; }
}

public class MenuData
{
    /// <summary>
    /// 
    /// </summary>
    public Profile profile { get; set; }
    /// <summary>
    /// 是否加入了商会
    /// </summary>
    public bool commerce { get; set; }
    /// <summary>
    /// 邮件数
    /// </summary>
    public int messages { get; set; }
    /// <summary>
    /// 个人mt和usdt
    /// </summary>
    public MenuAccount account { get; set; }
    /// <summary>
    /// 通知
    /// </summary>
    public List<MenuNoticesItem> notices { get; set; }
}

