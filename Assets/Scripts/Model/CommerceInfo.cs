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
        public string member_name { get; set; }
        public string come_time { get; set; }

}

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