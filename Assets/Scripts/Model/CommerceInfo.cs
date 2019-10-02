using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommerceInfo
{
    /// <summary>
    /// 商会成员信息
    /// </summary>
    public List<MermberInfo> members_info { get; set; }
       
}
public class MermberInfo
{
    /// <summary>
    /// 名字
    /// </summary>
        public string member_name { get; set; }
    /// <summary>
    /// 加入时间
    /// </summary>
        public string come_time { get; set; }

}

/// <summary>
/// 兑换记录
/// </summary>
public class ExchangeInfo
{
    /// <summary>
    /// 成员手机号
    /// </summary>
    public string member_name { get; set; }
    /// <summary>
    /// 加入时间
    /// </summary>
    public string exchange_time { get; set; }
    /// <summary>
    ///兑换mt数
    /// </summary>
    public string exchange_mt { get; set; }
    /// <summary>
    /// 支付usdt数
    /// </summary>
    public string pay_usdt { get; set; }
    /// <summary>
    /// 兑换结果
    /// </summary>
    public string exchange_result { get; set; }

}

public class ReqCommerceInfo
{
    /// <summary>
    /// 成员手机号
    /// </summary>
    public string member_name;
    /// <summary>
    /// 请求结果
    /// </summary>
    public string exchange_result;
    /// <summary>
    /// 企业商会标识
    /// </summary>
    public string commerce_name;
    /// <summary>
    /// mt兑换数
    /// </summary>
    public string mt_count;
    /// <summary>
    /// usdt消耗数
    /// </summary>
    public string usdt_count;

    public string username;

    public string token;


    public void Change(string ust_count =null,string mt_count=null,string commerce_name=null,string member_name =null,string exchange_result =null)
    {
        this.usdt_count = ust_count;
        this.mt_count = mt_count;
        this.commerce_name = commerce_name;
        this.member_name = member_name;
        this.exchange_result = exchange_result;
        username = PlayerPrefs.GetString("username");
        token = PlayerPrefs.GetString("token");
    }
}