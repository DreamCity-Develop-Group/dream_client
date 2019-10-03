

/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/28 13:51:30
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
namespace Assets.Scripts.Net
{
    public class CacheData 
    {
        private static volatile CacheData _instance = null;

        private static readonly object LockHelper = new object();

        private CacheData() { }

        public static CacheData Instance()

        {

            if (_instance == null)

            {

                lock (LockHelper)

                {

                    if (_instance == null)

                        _instance = new CacheData();

                }

            }

            return _instance;

        }
        /// <summary>
        /// 下载地址
        /// </summary>
        public const string QrCode = "www.baidui.com";
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick;
        /// <summary>
        /// 登入成功token
        /// </summary>
        public string Token;

        /// <summary>
        /// 个人账户号
        /// </summary>
        public  string Username;

        public double Usdt;
        /// <summary>
        /// 显示Mt数
        /// </summary>
        public double Mt;

        /// <summary>
        /// 修改交易密码的费用
        /// </summary>
        public double ChangExPassWordMt=5;
        /// <summary>
        /// 变化后的Mt数
        /// </summary>
        public double ConsumerThenMt;

        //public 


    }
}
