using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.UI;

/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/21 14:57:52
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
namespace Assets.Scripts.Net.Handler
{
    public class InvestHandler : HandlerBase
    {
        private UserInfo userInfo = new UserInfo();
        public override bool OnReceive(int subCode, object value)
        {
            switch (subCode)
            {
                case EventType.invest_info:
                    Dispatch(AreaCode.UI, UIEvent.SENCE_INVEST_VIEW, value);
                    break;
                default:
                    break;
            }
            return false;
        }

    }
}
