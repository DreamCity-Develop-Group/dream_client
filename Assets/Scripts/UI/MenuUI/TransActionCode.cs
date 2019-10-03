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

using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Net;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MenuUI
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
        private GameObject TransfeScc;       //提交成功
        private GameObject TransactionFrame; //输入交易码框
        private Button TransfeSccBtn;        //关闭交易成功 
        private TransferInfo transferInfo;
        private void Awake()
        {
            Bind(UIEvent.TRANSACTIONCODE_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.TRANSACTIONCODE_ACTIVE:
                    transferInfo = message as TransferInfo;
                    setPanelActive(true);
                    TransactionFrame.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        void Start()
        {
            TransactionFrame = transform.Find("TransactionFrame").gameObject;
            TransfeScc = transform.Find("TransfeScc").gameObject;
            TransfeSccBtn = TransfeScc.GetComponent<Button>();
            title = transform.Find("TransactionFrame/Title").GetComponent<Text>();
            InputCode = transform.Find("TransactionFrame/InputField").GetComponent<InputField>();
            ConfirmBtn = transform.Find("TransactionFrame/Confirm").GetComponent<Button>();
            CloseBtn = transform.Find("TransactionFrame/CloseBtn").GetComponent<Button>();
           
            ConfirmBtn.onClick.AddListener(clickConfirm);
            CloseBtn.onClick.AddListener(clickClose);
            TransfeSccBtn.onClick.AddListener(clickCloseScc);
            setPanelActive(false);
            Multilingual();
        }
        /// <summary>
        /// 多语言
        /// </summary>
        /// <param name="language"></param>
        private void Multilingual()
        {
            string language = PlayerPrefs.GetString("language");
            ConfirmBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/"+ language+ "/ConfirmMin");
            TransfeScc.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/" + language + "/Submitted");

            title.text = "";
        }
        /// <summary>
        /// 点击确定按钮
        /// </summary>
        private void clickConfirm()
        {
            if (transferInfo == null)
            {
                //todo 提示错误
                return;
            }
            transferInfo.transactPassWord = InputCode.text;
            Dispatch(AreaCode.NET,ReqEventType.transfer,transferInfo);
            TransactionFrame.SetActive(false);
            transferInfo = null;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void clickClose()
        {
            setPanelActive(false);
        }
        /// <summary>
        /// 关闭交易成功提示
        /// </summary>
        private void clickCloseScc()
        {
            TransfeScc.SetActive(false);
            setPanelActive(false);
        }
    }
}
