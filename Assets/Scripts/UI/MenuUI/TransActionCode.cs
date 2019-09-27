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

using UnityEngine.UI;

namespace Assets.Scripts.UI.MeunUI
{
    /// <summary>
    /// 输入交易码界面
    /// </summary>
    public class TransActionCode : UIBase
    {
        private Text title;                  //标题
        private InputField InputCode;        //输入交易码
        private Button ConfirmBtn;           //确定按钮   
        private Button CloseBtn;             //关闭按钮
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
            title = transform.Find("TransactionFrame/Title").GetComponent<Text>();
            InputCode = transform.Find("TransactionFrame/InputField").GetComponent<InputField>();
            ConfirmBtn = transform.Find("TransactionFrame/Confirm").GetComponent<Button>();
            CloseBtn = transform.Find("TransactionFrame/CloseBtn").GetComponent<Button>();
            //ConfirmBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/");
            //CloseBtn.GetComponent<Image>().sprite=Resources.Load<Sprite>("UI/");
            ConfirmBtn.onClick.AddListener(clickConfirm);
            CloseBtn.onClick.AddListener(clickClose);
            setPanelActive(false);
        }
        /// <summary>
        /// 点击确定按钮
        /// </summary>
        private void clickConfirm()
        {

        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void clickClose()
        {
            setPanelActive(false);
        }
    }
}
