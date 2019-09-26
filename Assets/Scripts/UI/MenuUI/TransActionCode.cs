/***
  * Title:    TransActionCode
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/23 14:00
  *
  * Description: 输入交易码界面
  *
  * Version:    0.1
  *
  *
***/

namespace Assets.Scripts.UI.MeunUI
{
    /// <summary>
    /// 输入交易码界面
    /// </summary>
    public class TransActionCode : UIBase
    {

        private void Awake()
        {
            Bind(UIEvent.TRANSACTIONCODE_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.TRANSACTIONCODE_ACTIVE:
                    setPanelActive(true);
                    break;
                default:
                    break;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            setPanelActive(false);
        }

    }
}
