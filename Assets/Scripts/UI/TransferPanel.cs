/***
  * Title:    TransferPanel
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/23 10:00
  *
  * Description: 转账界面
  *
  * Version:    0.1
  *
  *
***/

using Assets.Scripts.Framework;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// 转账界面
    /// </summary>
    public class TransferPanel : UIBase
    {
        private InputField TransactionMoney;                        //转账金额
        private InputField TransferTheAddress;                      //转账地址
        private Button BtnConfirm;                                  //确定按钮
        private Button BtnClose;                                    //关闭按钮

        private void Awake()
        {
            Bind(UIEvent.TRANSFERACCOUNTS_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.TRANSFERACCOUNTS_ACTIVE:
                    setPanelActive(true);
                    break;
                default:
                    break;
            }
        }
        void Start()
        {
            TransactionMoney = transform.Find("InputChargeField").GetComponent<InputField>();
            TransferTheAddress = transform.Find("InputFieldAddress").GetComponent<InputField>();
            BtnConfirm = transform.Find("BtnDetermine").GetComponent<Button>();
            BtnClose = transform.Find("BtnClose").GetComponent<Button>();
            BtnConfirm.onClick.AddListener(clickConfirm);
            BtnClose.onClick.AddListener(clickClose);
            setPanelActive(false);
        }
        /// <summary>
        /// 关闭面板
        /// </summary>
        private void clickClose()
        {
            setPanelActive(false);
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        private void clickConfirm()
        {
            Dispatch(AreaCode.UI, UIEvent.TRANSACTIONCODE_ACTIVE, true);
        }
    }
}
