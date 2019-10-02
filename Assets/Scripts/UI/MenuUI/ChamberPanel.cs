/***
  * Title:     
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/20 11:16:17
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/

using Assets.Scripts.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MeunUI
{
    /// <summary>
    /// 商会面板
    /// </summary>
    public class ChamberPanel : UIBase
    {
        private GameObject Chamber;                                      //商会主面板
        private GameObject ChamberRule;                                  //商会规则
        private GameObject BusinessesAreUnderfunded;                     //企业商会兑换资金不足
        private GameObject EnterTradeCode;                               //输入交易码
        private GameObject TopUpRequest;                                 //提交请求
        private GameObject ExchangeCenterBG;                             //兑换中心
        private GameObject AutomaticDeliveryPanel;                       //自动发货
        private GameObject InsufficientFund;                             //自动发货资金不足
        private GameObject SuccessfullySet;                              //设置自动发货成功 
        //商会面板
        private Text chamberTitle;                        //商会标题             
        private Button ClosePanel;                        //关闭商会面板
        private Button Enterprise;                        //企业商会按钮
        private Button MyEnterprise;                      //我的商会按钮
        private Button ExchangeCenter;                    //兑换中心
        private GameObject EnterpriseClick;               //企业激活按钮
        private GameObject MyEnterpriseClick;             //我的商会激活按钮
        private Image CoreMember;                         //核心成员
        private Text CommonMemberNum;                     //普通成员人数
        private GameObject ExchangeCenterClick;           //兑换中心激活按钮
        private GameObject EnterpriseInfo;                //企业商会信息
        private GameObject MyEnterpriseInfo;              //我的商会信息
        private Button ExchangeCenterBtn;                 //兑换中心按钮 
        //兑换中心
        private Text CenterTitle;                         //标题
        private Button CenterCloseBtn;                    //关闭兑换中心
        private Button CenterEnterpriseBtn;              //企业商会
        private Button CenterMyEnter;                     //我的商会
        private Button AutomaticDelivery;                 //自动发货
        private Button AKeyDelivery;                      //一键发货     
        //企业商会面板
        private Text ChanberLV;                          //企业商会等级
        private InputField inputConversion;              //输入兑换金额
        private Text ConversionRate;                     //兑换率
        private Button BtnRule;                          //规则按钮
        private Button BtnComfing;                       //确定 
        //商会规则
        private Button CloseRule;                        //关闭规则
        private Text RuleTitle;                          //标题
        private Text Level;                              //商会等级
        private Text Condition;                          //条件
        private Text Discount;                           //折扣
        private Text star1;                              //一星
        private Text Condition1;                         //一星条件
        private Text Discount1;                          //一星折扣 
        private Text star2;                              //一星
        private Text Condition2;                         //一星条件
        private Text Discount2;                          //一星折扣 
        private Text star3;                              //一星
        private Text Condition3;                         //一星条件
        private Text Discount3;                          //一星折扣 
        private Text star4;                              //一星
        private Text Condition4;                         //一星条件
        private Text Discount4;                          //一星折扣 
        private Text star5;                              //一星
        private Text Condition5;                         //一星条件
        private Text Discount5;                          //一星折扣 
        private Text star6;                              //一星
        private Text Condition6;                         //一星条件
        private Text Discount6;                          //一星折扣 
        private Text star7;                              //一星
        private Text Condition7;                         //一星条件
        private Text Discount7;                          //一星折扣 
        private Text star8;                              //一星
        private Text Condition8;                         //一星条件
        private Text Discount8;                          //一星折扣 
        private Text star9;                              //一星
        private Text Condition9;                         //一星条件
        private Text Discount9;                          //一星折扣 
        //输入交易码
        private Button TradeClose;                       //关闭交易面板
        private Button TradeConfindBtn;                  //确定
        private Button TradeCancel;                      //取消
        private InputField InputTradeCode;               //交易码输入  
        //提交请求
        private Button RequestClose;                     //关闭请求
        private Button RequestCloseBtn;                  //关闭 
        //自动发货
        private Text AutomaticDeliveryTitle;             //自动发货标题
        private Text Hint;                               //自动发货提示
        private Text Reminder;                           //备货数量提示
        private InputField InputReminderNum;             //输入的备用数量
        private Text DeliveryConversionRate;            //USDT兑换率
        private Button OpenOrClose;                     //自动发货开关
        private Button DeliveryClose;                   //关闭
        private Button DeliveryEnsure;                  //确定 
        private Sprite[] Spr_OpenOrClose = new Sprite[2];//自动开关按钮图
        public int IsAutomaticDelivery = 0;            //是否自动发货 (0为关。1为开）
        //去兑换
        private Text description;                     //提示内容
        private Button CloseChange;                   //关闭兑换
        private Button ToChangeBtn;                   //去兑换

        private List<int> listMyMember = new List<int>();   //我的核心成员列表
        private List<int> listConversion = new List<int>(); //我的兑换列表
        private GameObject MyMemberInfoPerfab0;              //我的核心成员信息预制体 
        private GameObject MyMemberInfoPerfab1;              //我的核心成员信息预制体 
        private Transform TranConnet;                        //信息的父物体Transform

        private GameObject ExchangeCenterInfoPerfab0;        //我的核心成员信息预制体 
        private GameObject ExchangeCenterInfoPerfab1;       //我的核心成员信息预制体 
        private Transform TranExchangeCenterConnet;         //信息的父物体Transform

        private List<GameObject> listNoExchangeRequestForshipment = new List<GameObject>();//没有发货的兑换请求
        /// <summary>
        /// 商会成员信息
        /// </summary>
        private CommerceInfo commerceInfo = new CommerceInfo();

        private void Awake()
        {
            Bind(UIEvent.COMMERCE_PANEL_ACTIVE);
            Bind(UIEvent.COMMERCE_NOJIONPANEL_ACTIVE,UIEvent.COMMERCE_PANEL_VIEW);
        }
        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                //如果没有加入商会
                //case UIEvent.COMMERCE_NOJIONPANEL_ACTIVE:
                //    setPanelActive((bool)message);
                //加入商会
                case UIEvent.COMMERCE_PANEL_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                case UIEvent.COMMERCE_PANEL_VIEW:
                    commerceInfo = message as CommerceInfo;
                    break;
                default:
                    break;
            }
        }
   
        void Start()
        {
            MyMemberInfoPerfab0 = Resources.Load<GameObject>("PerFab/ChamberFream0");
            MyMemberInfoPerfab1 = Resources.Load<GameObject>("PerFab/ChamberFream1");
            ExchangeCenterInfoPerfab0 = Resources.Load<GameObject>("PerFab/ToExchangeInformationFream0");
            ExchangeCenterInfoPerfab1 = Resources.Load<GameObject>("PerFab/ToExchangeInformationFream1");
            ClosePanel = transform.Find("Chamber/BtnClose").GetComponent<Button>();
            ClosePanel.onClick.AddListener(OnclikPanel);
            GetGameObj();
            Enterprise.onClick.AddListener(OnClickEnterprise);
            MyEnterprise.onClick.AddListener(OnClickMyEnterprise);
            ExchangeCenter.onClick.AddListener(OnClickExchangeCenter);
            CenterCloseBtn.onClick.AddListener(OnClickCloseCenter);
            CenterEnterpriseBtn.onClick.AddListener(OnClickCanterEnterprise);
            CenterMyEnter.onClick.AddListener(OnClickCanterMyEnterprise);
            ExchangeCenterBtn.onClick.AddListener(OnClickExchangeCenterBtn);
            BtnRule.onClick.AddListener(OnClickBtnRule);
            CloseRule.onClick.AddListener(OnClickCloseRule);
            BtnComfing.onClick.AddListener(OnClickEnsure);
            TradeClose.onClick.AddListener(OnClickTrande);
            TradeCancel.onClick.AddListener(OnClickTrande);
            TradeConfindBtn.onClick.AddListener(OnClickTrandeConfindBtn);
            RequestClose.onClick.AddListener(OnClickRequestClose);
            RequestCloseBtn.onClick.AddListener(OnClickRequestClose);
            AutomaticDelivery.onClick.AddListener(OnClickAutomaticDelivery);
            DeliveryClose.onClick.AddListener(OnClickCloseAutomaticDelivery);
            OpenOrClose.onClick.AddListener(SettingAutomaticDelivery);
            DeliveryEnsure.onClick.AddListener(OnClickAutomaticDeliveryEnsure);
            AKeyDelivery.onClick.AddListener(OnClickAKeyDelivery);
            CloseChange.onClick.AddListener(OnClickCloseChange);
            ToChangeBtn.onClick.AddListener(OnClickToChange);
            if (PlayerPrefs.GetInt("IsAutomaticDelivery")==1)
            {
                OpenOrClose.GetComponent<Image>().sprite = Spr_OpenOrClose[1];
            }
            else
            {
                OpenOrClose.GetComponent<Image>().sprite = Spr_OpenOrClose[0];
            }
            setPanelActive(false);
          
        }
        /// <summary>
        /// 查找游戏物体
        /// </summary>
        private void GetGameObj()
        {
            Chamber = transform.Find("Chamber").gameObject;
            ChamberRule = transform.Find("ChamberRule").gameObject;
            BusinessesAreUnderfunded = transform.Find("BusinessesAreUnderfunded").gameObject;
            EnterTradeCode = transform.Find("EnterTradeCode").gameObject;
            TopUpRequest = transform.Find("TopUpRequest").gameObject;
            ExchangeCenterBG = transform.Find("ExchangeCenterBG").gameObject;
            AutomaticDeliveryPanel = transform.Find("AutomaticDeliveryPanel").gameObject;
            InsufficientFund = transform.Find("InsufficientFund").gameObject;
            SuccessfullySet = transform.Find("SuccessfullySet").gameObject;
            chamberTitle = Chamber.transform.Find("Title").GetComponent<Text>();
            Enterprise = Chamber.transform.Find("Enterprise").GetComponent<Button>();
            MyEnterprise = Chamber.transform.Find("MyEnterprise").GetComponent<Button>();
            ExchangeCenter = Chamber.transform.Find("ExchangeCenter").GetComponent<Button>();
            EnterpriseClick = Chamber.transform.Find("EnterpriseClick").gameObject;
            MyEnterpriseClick = Chamber.transform.Find("MyEnterpriseClick").gameObject;
            ExchangeCenterClick = Chamber.transform.Find("ExchangeCenterClick").gameObject;
            EnterpriseInfo = Chamber.transform.Find("EnterpriseInfo").gameObject;
            MyEnterpriseInfo = Chamber.transform.Find("MyEnterpriseInfo").gameObject;
            ExchangeCenterBtn = MyEnterpriseClick.transform.Find("ExchangeCenter1").GetComponent<Button>();
            CoreMember = MyEnterpriseClick.transform.Find("CoreMember").GetComponent<Image>();
            CommonMemberNum = MyEnterpriseClick.transform.Find("RankAndFile/Membership").GetComponent<Text>();
            TranConnet = MyEnterpriseInfo.transform.Find("ChamberOfCommerceMembers/Viewport/Content");

            CenterTitle = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/Title").GetComponent<Text>();
            CenterCloseBtn = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/CloseBtn").GetComponent<Button>();
            CenterEnterpriseBtn = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/EnterpriseBtn").GetComponent<Button>();
            CenterMyEnter = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/MyEnterpriseBtn").GetComponent<Button>();
            AutomaticDelivery = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/ExchangeCenterPanel/AutomaticDelivery").GetComponent<Button>();
            AKeyDelivery = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/ExchangeCenterPanel/AKeyDelivery").GetComponent<Button>();
            TranExchangeCenterConnet = ExchangeCenterBG.transform.Find("ExchangeCenterPanel/ExchangeCenterPanel/ExchangeCenter/Viewport/Content");

                ChanberLV = EnterpriseInfo.transform.Find("Image/ChamberOfCommerceLV").GetComponent<Text>();
            inputConversion = EnterpriseInfo.transform.Find("InputField").GetComponent<InputField>();
            ConversionRate = EnterpriseInfo.transform.Find("ConversionRate").GetComponent<Text>();
            BtnRule = EnterpriseInfo.transform.Find("BtnRule").GetComponent<Button>();
            BtnComfing = EnterpriseInfo.transform.Find("BtnComfing").GetComponent<Button>();

            CloseRule = ChamberRule.transform.Find("BtnClose").GetComponent<Button>();

            TradeClose = EnterTradeCode.transform.Find("CloseBtn").GetComponent<Button>();
            TradeConfindBtn= EnterTradeCode.transform.Find("ConfindBtn").GetComponent<Button>();
            TradeCancel = EnterTradeCode.transform.Find("Cancel").GetComponent<Button>();
            InputTradeCode = EnterTradeCode.transform.Find("InputField").GetComponent<InputField>();

            RequestClose = TopUpRequest.GetComponent<Button>();
            RequestCloseBtn = TopUpRequest.transform.Find("Image").GetComponent<Button>();

            AutomaticDeliveryTitle = AutomaticDeliveryPanel.transform.Find("Title").GetComponent<Text>();
            Hint = AutomaticDeliveryPanel.transform.Find("Hint").GetComponent<Text>();
            Reminder = AutomaticDeliveryPanel.transform.Find("Reminder").GetComponent<Text>();
            InputReminderNum = AutomaticDeliveryPanel.transform.Find("InputField").GetComponent<InputField>();
            DeliveryConversionRate = AutomaticDeliveryPanel.transform.Find("ConversionRate").GetComponent<Text>();
            OpenOrClose = AutomaticDeliveryPanel.transform.Find("OnOff").GetComponent<Button>();
            DeliveryClose = AutomaticDeliveryPanel.transform.Find("ColseBtn").GetComponent<Button>();
            DeliveryEnsure = AutomaticDeliveryPanel.transform.Find("EnsureBtn").GetComponent<Button>();

            description = InsufficientFund.transform.Find("Text").GetComponent<Text>();
            CloseChange = InsufficientFund.transform.Find("CloseBtn").GetComponent<Button>();
            ToChangeBtn = InsufficientFund.transform.Find("ToChangeBtn").GetComponent<Button>();
        }
        /// <summary>
        /// 多语言切换图
        /// </summary>
        private void ManyLanguages()
        {
            chamberTitle.text = "";
            CommonMemberNum.text = "";
            CenterTitle.text = "";
            ChanberLV.text = "";
            ConversionRate.text = "";
            AutomaticDeliveryTitle.text = "";
            Hint.text = "";
            Reminder.text = "";
            DeliveryConversionRate.text = "";
            description.text = "";
            ClosePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            Enterprise.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            MyEnterprise.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            ExchangeCenter.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            EnterpriseClick.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            MyEnterpriseClick.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            CoreMember.sprite = Resources.Load<Sprite>("UI/menu/chinese");
            ExchangeCenterClick.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            ExchangeCenterBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            CenterCloseBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            CenterEnterpriseBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            CenterMyEnter.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            AutomaticDelivery.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            AKeyDelivery.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            BtnRule.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            BtnComfing.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            CloseRule.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            TradeClose.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            TradeConfindBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            TradeCancel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            OpenOrClose.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            DeliveryClose.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            DeliveryEnsure.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            for (int i = 0; i < Spr_OpenOrClose.Length; i++)
            {
                Spr_OpenOrClose[i]= Resources.Load<Sprite>("UI/menu/chinese");
            }
            CloseChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");
            ToChangeBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu/chinese");         
        }
        /// <summary>
        /// 关闭商会面板
        /// </summary>
        private void OnclikPanel()
        {
            Dispatch(AreaCode.UI, UIEvent.COMMERCE_PANEL_ACTIVE, false);
            setPanelActive(false);
        }
        /// <summary>
        /// 点击企业商会按钮
        /// </summary>
        private void OnClickEnterprise()
        {
            EnterpriseClick.SetActive(true);
            EnterpriseInfo.SetActive(true);
            MyEnterpriseInfo.SetActive(false);
            MyEnterpriseClick.SetActive(false);
            ExchangeCenterClick.SetActive(false);
            ExchangeCenter.gameObject.SetActive(true);
        }
        /// <summary>
        /// 点击我的商会按钮
        /// </summary>
        private void OnClickMyEnterprise()
        {

            EnterpriseClick.SetActive(false);
            MyEnterpriseInfo.SetActive(true);
            EnterpriseInfo.SetActive(false);
            MyEnterpriseClick.SetActive(true);
            ExchangeCenterClick.SetActive(false);
            ExchangeCenter.gameObject.SetActive(false);
            //初步在次生成成员信息
            if(listMyMember.Count>0)
            {
                for (int i = 0; i < listMyMember.Count; i++)
                {
                    GameObject obj = null;
                    if (i%2==0)
                    {
                        obj =  CreatePreObj(MyMemberInfoPerfab0, TranConnet);
                        obj.transform.Find("Info").GetComponent<Text>().text = "成员信息";
                        obj.transform.Find("Time").GetComponent<Text>().text = "加入时间";
                    }
                    else
                    {
                        obj= CreatePreObj(MyMemberInfoPerfab1, TranConnet);
                        obj.transform.Find("Info").GetComponent<Text>().text = "成员信息";
                        obj.transform.Find("Time").GetComponent<Text>().text = "加入时间";
                    }
                }
            }
            
        }
        /// <summary>
        /// 点击兑换中心
        /// </summary>
        private void OnClickExchangeCenter()
        {
            //初步在次生成兑换信息
            if (listConversion.Count > 0)
            {
                for (int i = 0; i < listConversion.Count; i++)
                {
                    GameObject obj = null;
                    if (i % 2 == 0)
                    {
                        obj = CreatePreObj(ExchangeCenterInfoPerfab0, TranExchangeCenterConnet);             
                    }
                    else
                    {
                        obj = CreatePreObj(ExchangeCenterInfoPerfab1, TranExchangeCenterConnet);
                    }
                    //obj.transform.Find("Time").GetComponent<Text>().text = "时间";
                    //obj.transform.Find("Number").GetComponent<Text>().text = "账号";
                    //obj.transform.Find("MTNum").GetComponent<Text>().text = "MT数";
                    //obj.transform.Find("MT").GetComponent<Text>().text = "兑换MT";
                    //obj.transform.Find("PayUSDT").GetComponent<Text>().text = "支付USDT";
                    //obj.transform.Find("USDTNum").GetComponent<Text>().text = "PayUSDT";
                    //obj.transform.Find("DeliverGoodsBtn").GetComponent<Text>().text = "兑换MT";
                    //obj.transform.Find("TurnDownBtn").GetComponent<Text>().text = "兑换MT";
                    //if (发货)
                    //    obj.transform.Find("ShippingStatus").GetComponent<Image>().sprite = "已发货图片";
                    //else if (过期)
                    //{
                    //    obj.transform.Find("ShippingStatus").GetComponent<Image>().sprite = "已过期图片";
                    //}
                    //else
                    //{
                    //    obj.transform.Find("ShippingStatus").GetComponent<Image>().sprite = "拒绝图片";
                    //}
                    //把没有发货的兑换请求添加到listNoExchangeRequestForshipment列表
                }
            }
            ExchangeCenterBG.SetActive(true);
        }
        /// <summary>
        /// 关闭兑换中心
        /// </summary>
        private void OnClickCloseCenter()
        {
            ExchangeCenterBG.SetActive(false);
        }
        /// <summary>
        /// 兑换中心的企业
        /// </summary>
        private void OnClickCanterEnterprise()
        {
            ExchangeCenterBG.SetActive(false);
            EnterpriseClick.SetActive(true);
            EnterpriseInfo.SetActive(true);
            MyEnterpriseInfo.SetActive(false);
            MyEnterpriseClick.SetActive(false);
            ExchangeCenterClick.SetActive(false);
            ExchangeCenter.gameObject.SetActive(true);
        }
        /// <summary>
        /// 兑换中心的我的商会
        /// </summary>
        private void OnClickCanterMyEnterprise()
        {
            ExchangeCenterBG.SetActive(false);
            EnterpriseClick.SetActive(false);
            MyEnterpriseInfo.SetActive(true);
            EnterpriseInfo.SetActive(false);
            MyEnterpriseClick.SetActive(true);
            ExchangeCenterClick.SetActive(false);
            ExchangeCenter.gameObject.SetActive(false);
        }
        /// <summary>
        /// 我的商会的兑换中心的按钮
        /// </summary>
        private void OnClickExchangeCenterBtn()
        {
            ExchangeCenterBG.SetActive(true);
        }
        /// <summary>
        /// 点击问号
        /// </summary>
        private void OnClickBtnRule()
        {
            ChamberRule.SetActive(true);
        }
        /// <summary>
        /// 关闭规则
        /// </summary>
        private void OnClickCloseRule()
        {
            ChamberRule.SetActive(false);
        }
        /// <summary>
        /// 企业商会兑换确定按钮
        /// </summary>
        private void OnClickEnsure()
        {
            ////判断
            //if(USDT不足)
            //{

            //}
            //else
            //{
                EnterTradeCode.SetActive(true);
            //}
        }
        /// <summary>
        /// 关闭输入交易码
        /// </summary>
        private void OnClickTrande()
        {
            EnterTradeCode.SetActive(false);
        }
        /// <summary>
        /// 确定交易码
        /// </summary>
        private void OnClickTrandeConfindBtn()
        {
            Chamber.SetActive(false);
            EnterTradeCode.SetActive(false);
            TopUpRequest.SetActive(true);
        }
       /// <summary>
       /// 关闭发送兑换请求
       /// </summary>
        private void OnClickRequestClose()
        {
            TopUpRequest.SetActive(false);
        }
        /// <summary>
        /// 点击自动发货按钮
        /// </summary>
        private void OnClickAutomaticDelivery()
        {
            AutomaticDeliveryPanel.SetActive(true);
            ExchangeCenterBG.SetActive(false);
            Chamber.SetActive(false);
        }
        /// <summary>
        /// 关闭自动发货
        /// </summary>
        private void OnClickCloseAutomaticDelivery()
        {
            AutomaticDeliveryPanel.SetActive(false);
        }
        /// <summary>
        /// 设置是否自动发货
        /// </summary>
        private void SettingAutomaticDelivery()
        {
            if(IsAutomaticDelivery==0)
            {
                IsAutomaticDelivery = 1;
                OpenOrClose.GetComponent<Image>().sprite = Spr_OpenOrClose[0];
                PlayerPrefs.SetInt("IsAutomaticDelivery", IsAutomaticDelivery);
            }
            else
            {
                IsAutomaticDelivery = 0;
                OpenOrClose.GetComponent<Image>().sprite = Spr_OpenOrClose[1];
                PlayerPrefs.SetInt("IsAutomaticDelivery", IsAutomaticDelivery);
            }
        }
        /// <summary>
        /// 自动发货确定
        /// </summary>
        private void OnClickAutomaticDeliveryEnsure()
        {
            //判断MT是否足够
            //if(不足)
            //{
            //AutomaticDeliveryPanel.SetActive(false);
            //InsufficientFund.SetActive(true);
            //}
            //else
            //{
            AutomaticDeliveryPanel.SetActive(false);
            SuccessfullySet.SetActive(true);
            StartCoroutine(CloseScc());
            //}
        }
        /// <summary>
        /// 一键发货
        /// </summary>
        private void OnClickAKeyDelivery()
        {
            for (int i = 0; i < listNoExchangeRequestForshipment.Count; i++)
            {
                //listNoExchangeRequestForshipment[i].transform.Find("ShippingStatus").GetComponent<Image>().sprite = "已发货";
            }
        }
        /// <summary>
        /// 去兑换
        /// </summary>
        private void OnClickToChange()
        {
            InsufficientFund.SetActive(false);
            Chamber.SetActive(true);
        }
        /// <summary>
        /// 关闭去兑换
        /// </summary>
        private void OnClickCloseChange()
        {
            InsufficientFund.SetActive(false);
        }
 
        private IEnumerator CloseScc()
        {
            yield return new WaitForSeconds(1f);
            SuccessfullySet.SetActive(false);
        }
        private Queue<GameObject> m_queue_gPreObj = new Queue<GameObject>();          //对象池
        private Transform TempTrans;
        /// <summary>
        /// 创建预制体
        /// </summary>
        /// <param name="Prefab">预制体</param>
        /// <param name="m_transPerfab">预制体父物体的transform</param>
        /// <returns></returns>
        public GameObject CreatePreObj(GameObject Prefab, Transform m_transPerfab)
        {
            GameObject obj = null;
            if (m_queue_gPreObj.Count > 0)
            {
                obj = m_queue_gPreObj.Dequeue();
            }
            else
            {
                Transform trans = null;
                trans = GameObject.Instantiate(Prefab, m_transPerfab).transform;
                //trans.localPosition = Vector3.zero;
                trans.localRotation = Quaternion.identity;
                trans.localScale = Vector3.one;
                obj = trans.gameObject;
                obj.SetActive(false);
            }
            return obj;
        }
        /// <summary>
        /// 预制体回收
        /// </summary>
        /// <param name="obj">回收的预制体</param>
        private void RePreObj(GameObject obj)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                obj.transform.SetParent(TempTrans);
                m_queue_gPreObj.Enqueue(obj);
            }
        }
    }
}
