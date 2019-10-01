

/**
 *
 *  请求操作事件码
 **/

using System.CodeDom;

namespace Assets.Scripts.Net
{
    public class EventType
    {
        public const int init = int.MinValue; //连接
        public const int login = 0;//登入
        public const int pwlogin = 1; //密码登入
        public const int idlogin = 2; //验证码登入
        public const int regist = 3;//注册
        /// <summary>
        /// 验证码获取
        /// </summary>
        public const int identy = 4;
        public const int voiceset = 5;//
        public const int pwforget=6;//忘记密码
        public const int addfriend = 7;//添加好友
        /// <summary>
        /// 修改密码
        /// </summary>
        public const int expw = 8;
        /// <summary>
        /// 设置交易密码
        /// </summary>
        public const int expwshop = 9;
        /// <summary>
        /// //搜索用户
        /// </summary>
        public const int searchfriend = 10;
        public const int likefriend = 11;//好友点赞
        /// <summary>
        /// /广场玩家列表
        /// </summary>
        public const int squarefriend = 12;
        /// <summary>
        /// //好友列表
        /// </summary>
        public const int listfriend = 13;
        /// <summary>
        /// //申请列表
        /// </summary>
        public const int applyfriend = 14;
        /// <summary>
        /// //申请通过/拒绝
        /// </summary>
        public const int applytofriend = 15;
        /// <summary>
        /// //获取二维码
        /// </summary>
        public const int getrecode = 16;
        /// <summary>
        /// 测试资产信息
        /// </summary>
        public const int property = 17;
        /// <summary>
        /// 换一批
        /// </summary>
        public const int nextgrouds=18;
        /// <summary>
        /// 商会成员信息
        /// </summary>
        public const int commerce_member = 19;
        /// <summary>
        /// 商会加入请求
        /// </summary>
        public const int commerce_in = 20;
        /// <summary>
        /// 会长发货结果
        /// </summary>
        public const int commerce_sendmt = 21;
        /// <summary>
        /// 投资信息
        /// </summary>
        public const int invest_info = 22;
        /// <summary>
        /// 投资请求
        /// </summary>
        public const int invest_req = 23;
        /// <summary>
        /// 转账
        /// </summary>
        public const int transfer = 24;
        /// <summary>
        /// 充值
        /// </summary>
        public const int recharge = 25;

        /// <summary>
        /// 主界面数据请求
        /// </summary>
        public const int menu_req = 26;

        /// <summary>
        /// 修改交易密码
        /// </summary>
        public const int change_expwshop=27;

        /// <summary>
        /// 提现
        /// </summary>
        public const int cach_withdrawal = 28;

        /// <summary>
        /// 商会信息
        /// </summary>
        public const int commerce_info = 29;
        /// <summary>
        /// 退出登入
        /// </summary>
        public const int exit = int.MaxValue;
    }
}