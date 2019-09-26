using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/21 14:41:14
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
/// <summary>
/// �㳡�û���
/// </summary>
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

/// <summary>
/// 单个广场数据
/// </summary>
public class UserInfos
{
    /// <summary>
    /// 昵称
    /// </summary>
    public string friendName { get; set; }
    /// <summary>
    /// 图片链接
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
