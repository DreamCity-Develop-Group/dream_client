using UnityEngine;

namespace Assets.Scripts.Model
{
    public class TransferInfo
    {

        public  TransferInfo()
        {
            username = PlayerPrefs.GetString("username");
            token = PlayerPrefs.GetString("token");
        }

        public string username { get; set; }

        public string token { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double money { get; set; }

        /// <summary>
        /// 转账地址
        /// </summary>
        public string moneyaddress { get; set; }

        /// <summary>
        /// 交易密码
        /// </summary>
        public string transactPassWord { get; set; }


      
    }
}