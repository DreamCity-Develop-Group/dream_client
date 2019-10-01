/***
  * Title:    NoHaveChamber 
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/23 17:25:07
  *
  * Description: 加入商会界面
  *
  * Version:    0.1
  *
  *
***/

using Assets.Scripts.Framework;
using UnityEngine;
using UnityEngine.UI;
using EventType=Assets.Scripts.Net.EventType;
namespace Assets.Scripts.UI.MeunUI
{
    /// <summary>
    /// 加入商会面板
    /// </summary>
    public class NoHaveChamber : UIBase
    {
        //面板
        private GameObject JionChamber;                           //加入商会面板
        private GameObject IncorrectPrompt;                       //邀请码错误提示
        private GameObject JIonScee;                              //邀请码正确
        private GameObject SettingtradingCode;                    //设置交易码
        private GameObject ChamberOfCommerceRules;                //商会规则
        private GameObject ConfirmationPaymentPanel;              //确认支付面板
        private GameObject InsufficientFunds;                     //资金不足提示
        //加入商会  
        private Button DetermineBtn;                              //确定按钮
        private Button CloseBtn;                                  //关闭按钮
        private InputField InputChamberCode;                      //输入商会邀请码
        private Text txt_Text;                                    //描述
                                                                  //邀请错误提示 
        private Button PromptOKBtn;                               //好的按钮
        private Button PromptClose;                               //错误提示关闭按钮
        private Text promptTxt;                                   //描述
        //成功加入商会
        private Text succTile;                                     //标题
        private Text succInstructions;                             //描述
        private Button ConfindBtn;                                 //确定按钮
        //设置交易码
        private Text tradingTitle;                                 //标题
        private GameObject ErrorMessage;                           //错误提示   
        private InputField InputField;                             //输入交易码
        private Button tradingDeDetermineBtn;                      //确定按钮
        private Button tradingCancel;                              //取消
        private Button tradingClose;                               //关闭
        //商会规则
        private Text ChamberRulesTitle;                            //商会规则的标题
        private Image MembershipStatement;                         //规则图片
        private Button PayBtn;                                     //支付按钮
        //确定支付
        private Text description;                                  //描述
        private Button payClose;                                   //关闭
        private Button payDetermine;                               //确定
        private Button payCancle;                                  //取消
        //资金不足
        private Button fundsColse;                                 //关闭
        private Button GoPayBtn;                                   //去充值
        private Text FundsTxt;                                     //描述 
        private void Awake()
        {
            Bind(UIEvent.COMMERCE_NOJIONPANEL_ACTIVE,UIEvent.BusinessPrompt_NOTIVE_VIEW);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.COMMERCE_NOJIONPANEL_ACTIVE:
                  setPanelActive((bool)message);
                    break;
                case UIEvent.BusinessPrompt_NOTIVE_VIEW:

                    break;
                default:
                    break;
            }
        }
        void Start()
        {
            JionChamber = transform.Find("JionChamber").gameObject;
            IncorrectPrompt = transform.Find("IncorrectPrompt").gameObject;
            JIonScee = transform.Find("JIonScee").gameObject;
            SettingtradingCode = transform.Find("SettingtradingCode").gameObject;
            ChamberOfCommerceRules = transform.Find("ChamberOfCommerceRules").gameObject;
            ConfirmationPaymentPanel = transform.Find("ConfirmationPaymentPanel").gameObject;
            InsufficientFunds = transform.Find("InsufficientFunds").gameObject;
            DetermineBtn = transform.Find("JionChamber/BtnConfirm").GetComponent<Button>();
            CloseBtn = transform.Find("JionChamber/BtnClose").GetComponent<Button>();
            InputChamberCode = transform.Find("JionChamber/InputField").GetComponent<InputField>();
            txt_Text = transform.Find("JionChamber/Text").GetComponent<Text>();
            succTile = JIonScee.transform.Find("Title").GetComponent<Text>();
            succInstructions = JIonScee.transform.Find("Instructions").GetComponent<Text>();
            ConfindBtn = JIonScee.transform.Find("OKBtn").GetComponent<Button>();
            tradingTitle = SettingtradingCode.transform.Find("Title").GetComponent<Text>();
            ErrorMessage = SettingtradingCode.transform.Find("Text").gameObject;
            InputField = SettingtradingCode.transform.Find("InputField").GetComponent<InputField>();
            tradingDeDetermineBtn = SettingtradingCode.transform.Find("DetermineBtn").GetComponent<Button>();
            tradingCancel = SettingtradingCode.transform.Find("Cancel").GetComponent<Button>();
            tradingClose = SettingtradingCode.transform.Find("CloseBtn").GetComponent<Button>();
            ChamberRulesTitle = ChamberOfCommerceRules.transform.Find("Title").GetComponent<Text>();
            MembershipStatement = ChamberOfCommerceRules.transform.Find("MembershipStatement").GetComponent<Image>();
            PayBtn = ChamberOfCommerceRules.transform.Find("PayBtn").GetComponent<Button>();
            description = ConfirmationPaymentPanel.transform.Find("Text").GetComponent<Text>();
            payClose = ConfirmationPaymentPanel.transform.Find("CloseBtn").GetComponent<Button>();
            payDetermine = ConfirmationPaymentPanel.transform.Find("Determine").GetComponent<Button>();
            payCancle = ConfirmationPaymentPanel.transform.Find("Cancel").GetComponent<Button>();
            fundsColse = InsufficientFunds.transform.Find("CloseBtn").GetComponent<Button>();
            GoPayBtn = InsufficientFunds.transform.Find("GoToPrepaid").GetComponent<Button>();
            FundsTxt = InsufficientFunds.transform.Find("Text").GetComponent<Text>();
            CloseBtn.onClick.AddListener(clickClose);
            PromptOKBtn = IncorrectPrompt.transform.Find("OK").GetComponent<Button>();
            PromptClose = IncorrectPrompt.transform.Find("Close").GetComponent<Button>();
            DetermineBtn.onClick.AddListener(clickDetermine);
            PromptClose.onClick.AddListener(clickPromptClose);
            PromptOKBtn.onClick.AddListener(clickPromptClose);
            ConfindBtn.onClick.AddListener(clickOK);
            tradingDeDetermineBtn.onClick.AddListener(SettingTrandingOK);
            tradingCancel.onClick.AddListener(CloseSettingTranding);
            tradingClose.onClick.AddListener(CloseSettingTranding);
            PayBtn.onClick.AddListener(cilckPay);
            payClose.onClick.AddListener(CloseConfirmationPaymentPanel);
            payCancle.onClick.AddListener(CloseConfirmationPaymentPanel);
            GoPayBtn.onClick.AddListener(clickGoPay);
            fundsColse.onClick.AddListener(clickClosePay);
            payDetermine.onClick.AddListener(clickConfirmationPayment);
            setPanelActive(false);
        }
        /// <summary>
        /// 多语言换图
        /// </summary>
        private void ManyLanguages()
        {
            DetermineBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            CloseBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            PromptOKBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            PromptClose.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            ConfindBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            tradingDeDetermineBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            tradingCancel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            tradingClose.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            MembershipStatement.sprite = Resources.Load<Sprite>("UI/menu/chinese");
            PayBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            payClose.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            payDetermine.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            payCancle.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            fundsColse.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            GoPayBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
        }
    /// <summary>
    /// 关闭
    /// </summary>
    private void clickClose()
        {
            setPanelActive(false);
        }
        /// <summary>
        /// 确定加入商会
        /// </summary>
        private void clickDetermine()
        {
            //判断商会邀请码是否正确
            //if(不正确)
            //{
            //    IncorrectPrompt.SetActive(true);
            //}
            //else
            //{
            string commerceCode = InputChamberCode.text;
            if (commerceCode == null || commerceCode.Equals(""))
            {
                //TODO输入提示
            }
            Dispatch(AreaCode.NET,EventType.commerce_in,InputChamberCode.text.ToString());
            JionChamber.SetActive(false);
            JIonScee.SetActive(true);
            //}
        }
        /// <summary>
        /// 关闭邀请码错误提示
        /// </summary>
        private void clickPromptClose()
        {
            IncorrectPrompt.SetActive(false);
        }
        /// <summary>
        /// 好的按钮
        /// </summary>
        private void clickOK()
        {
            JIonScee.SetActive(false);
            SettingtradingCode.SetActive(true);
        }
        /// <summary>
        /// 设置交易码
        /// </summary>
        private void SettingTrandingOK()
        {
            //判断是否设置了交易密码
            //if(设置了)
            //{
            ChamberOfCommerceRules.SetActive(true);
            //}
            //else
            //{
            //    ErrorMessage.SetActive(true);
            //}
        }
        /// <summary>
        /// 取消、关闭设置交易码
        /// </summary>
        private void CloseSettingTranding()
        {
            SettingtradingCode.SetActive(false);
        }
        /// <summary>
        /// 去支付
        /// </summary>
        private void cilckPay()
        {
            ChamberOfCommerceRules.SetActive(false);
            ConfirmationPaymentPanel.SetActive(true);
        }
        /// <summary>
        /// 关闭确定支付面板
        /// </summary>
        private void CloseConfirmationPaymentPanel()
        {
            ConfirmationPaymentPanel.SetActive(false);
        }
        /// <summary>
        /// 确认支付
        /// </summary>
        private void clickConfirmationPayment()
        {
            //判断USDT是否足够
            //if(不足)
            //{
            InsufficientFunds.SetActive(true);
            //}

        }
       /// <summary>
       /// 去充值
       /// </summary>
        private void clickGoPay()
        {
            Dispatch(AreaCode.UI, UIEvent.TOPUP_ACTIVE, true);
        }
        /// <summary>
        /// 关闭去充值面板
        /// </summary>
        private void clickClosePay()
        {
            InsufficientFunds.SetActive(false);
        }
    }
}
