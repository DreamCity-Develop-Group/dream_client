
/***
  * Title:    ChargePanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 11:58:34
  *
  * Description: 资产界面
  *
  * Version:    0.1
  *
  *
***/

using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MeunUI
{
    public class ChargePanel : UIBase
    {

        private Button transferAccounts;                  //转账按钮
        private Button topUp;                             //充值按钮
        private Button InviteFriends;                     //邀请好友
        private Button transactionRecord;                 //交易记录按钮
        private Button CopyInvitationCode;                //复制邀请码
        private GameObject PanleInviterFrindsBG;          //邀请好友面板
        private GameObject TransactionRecord;             //交易记录面板  
        private Button TransctionClose;                   //交易面板关闭
        private Transform TransactionListPraent;          //交易列表父物体
        private List<UserInfo> List_Transaction = new List<UserInfo>();  //存储交易记录的所有记录

    //动态加载图片
    private Image Bg;                             //背景
    private Image transferBtn;                    //转账按钮
    private Image TopUpBtn;                       //充值按钮
    private Image InviteFriendsBtn;               //邀请好友按钮

    private Text UserName;                       //玩家昵称
    private Text AccumulatedEarnings;            //累计收益
    private Text AccumulatedEarningsNum;         //累计收益数  
    private Text TotalAssets;                    //持仓总资产
    private Text TotalAssetsNum;                 //持仓总资产数
    private Text PositionUSDT;                   //持仓USDT
    private Text PositionUSDTNum;                //持仓USDT数
    private Text AvailableUSDT;                  //可用USDT
    private Text AvailableUSDTNum;               //可用USDT数
    private Text FreezeUSDT;                     //冻结USDT
    private Text FreezeUSDTNum;                  //冻结USDT数
    private Text PositionMT;                     //持仓MT;
    private Text positionMTNum;                  //持仓MT数
    private Text AvailableMT;                    //可用MT
    private Text AvailableNum;                   //可用MT数
    private Text FreezeMT;                       //冻结MT
    private Text FreezeMTNum;                    //冻结MT数
    private Text ChamberOfCommerceLV;            //商会等级
    private Text ChamberOfCommerceMembers;       //商会成员
    private Text TxtInviteCode;                  //邀请码
    private Text TxtTransactionRecords;          //交易记录 




    private void Awake()
    {
        Bind(UIEvent.CHARGE_PANEL_ACTIVE);
    }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.CHARGE_PANEL_ACTIVE:
                UserName.text = "";
                AccumulatedEarnings.text = "";
                    setPanelActive(true);
                    break;
                default:
                    break;
            }
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            btnClose.onClick.RemoveAllListeners();
        }

        Button btnClose;

    private void Start()
    {
        Bg = transform.Find("bg").GetComponent<Image>();
        transferBtn = transform.Find("BtnTransfer").GetComponent<Image>();
        TopUpBtn = transform.Find("BtnRecharge").GetComponent<Image>();
        InviteFriendsBtn = transform.Find("BtnApplyFreind").GetComponent<Image>();
        //多语系动态加载图片
        //Bg.sprite = Resources.Load<Sprite>("UI/");
        //transferBtn.sprite = Resources.Load<Sprite>("UI/");
        //TopUpBtn.sprite = Resources.Load<Sprite>("UI/");
        //InviteFriendsBtn.sprite = Resources.Load<Sprite>("UI/");

        PanleInviterFrindsBG = transform.Find("PanleInviterFrindsBG").gameObject;
        TransactionRecord = transform.Find("TransactionRecord").gameObject;
        transferAccounts = transform.Find("BtnTransfer").GetComponent<Button>();
        topUp = transform.Find("BtnRecharge").GetComponent<Button>();
        InviteFriends = transform.Find("BtnApplyFreind").GetComponent<Button>();
        transactionRecord = transform.Find("BtnChargeLog").GetComponent<Button>();
        CopyInvitationCode = transform.Find("bg/BtnCopy").GetComponent<Button>();
        btnClose = transform.Find("bg/BtnClose").GetComponent<Button>();
        TransctionClose = TransactionRecord.transform.Find("Frame/BtnColse").GetComponent<Button>();
        TransactionListPraent = TransactionRecord.transform.Find("Frame/RecordList/Viewport/Content");

        UserName = transform.Find("NickName").GetComponent<Text>();
        AccumulatedEarnings = transform.Find("NameEarning").GetComponent<Text>();
        AccumulatedEarningsNum = transform.Find("TextAllEarning").GetComponent<Text>();
        TotalAssets = transform.Find("NameHold").GetComponent<Text>();
        TotalAssetsNum = transform.Find("TextAllHold").GetComponent<Text>();
        TxtTransactionRecords = transform.Find("BtnChargeLog/Text").GetComponent<Text>();
        PositionUSDT = transform.Find("bg/HoldUSDT").GetComponent<Text>();     
        PositionUSDTNum = transform.Find("bg/HoldNum").GetComponent<Text>();
        AvailableUSDT = transform.Find("bg/AvailableUSDT").GetComponent<Text>();
        AvailableUSDTNum = transform.Find("bg/AvailableNum").GetComponent<Text>();
        FreezeUSDT = transform.Find("bg/FreezeUSDT").GetComponent<Text>();
        FreezeUSDTNum = transform.Find("bg/FreezeNum").GetComponent<Text>();
        PositionMT = transform.Find("bg/HoldMT").GetComponent<Text>();
        positionMTNum = transform.Find("bg/HoldNumMT").GetComponent<Text>();
        AvailableMT = transform.Find("bg/AvailableMT").GetComponent<Text>();
        AvailableNum = transform.Find("bg/AvailableNumMT").GetComponent<Text>();
        FreezeMT = transform.Find("bg/FreezeMT").GetComponent<Text>();
        FreezeMTNum = transform.Find("bg/FreezeNumMT").GetComponent<Text>();
        ChamberOfCommerceLV = transform.Find("bg/ChamberLV").GetComponent<Text>();
        ChamberOfCommerceMembers = transform.Find("bg/ChamberMembers").GetComponent<Text>();
        TxtInviteCode = transform.Find("bg/InviteCode").GetComponent<Text>();


        transferAccounts.onClick.AddListener(clickTransferAccounts);
        topUp.onClick.AddListener(clickTopUp);
        InviteFriends.onClick.AddListener(clickInviteFriends);
        transactionRecord.onClick.AddListener(clicktransactionRecord);
        CopyInvitationCode.onClick.AddListener(clickCopyInvitationCode);
        btnClose.onClick.AddListener(clickClose);
        TransctionClose.onClick.AddListener(clickTransactionCosle);
        setPanelActive(false);
        if(List_Transaction.Count>0)
        {
            for (int i = 0; i <List_Transaction.Count; i++)
            {
                if(i%2==0)
                {
                    GameObject obj = Resources.Load("PerFab/RecordItme0") as GameObject;
                    obj= CreatePreObj(obj, TransactionListPraent);
                    //找到Test，赋值信息
                }
                else
                {
                    GameObject obj = Resources.Load("PerFab/RecordItme1") as GameObject;
                    obj= CreatePreObj(obj, TransactionListPraent);
                    //找到Test，赋值信息
                }
            }
        }
    }

        /// <summary>
        /// 关闭资产面板
        /// </summary>
        private void clickClose()
        {
            setPanelActive(false);
        }
        /// <summary>
        /// 转账
        /// </summary>
        private void clickTransferAccounts()
        {
            Dispatch(AreaCode.UI, UIEvent.TRANSFERACCOUNTS_ACTIVE, true);
        }
        /// <summary>
        /// 充值
        /// </summary>
        private void clickTopUp()
        {
            Dispatch(AreaCode.UI, UIEvent.TOPUP_ACTIVE, true);
        }
        /// <summary>
        /// 邀请好友
        /// </summary>
        private void clickInviteFriends()
        {
            PanleInviterFrindsBG.SetActive(true);
        }
        /// <summary>
        /// 交易记录
        /// </summary>
        private void clicktransactionRecord()
        {
            TransactionRecord.SetActive(true);
        }
        private void clickTransactionCosle()
        {
            TransactionRecord.SetActive(false);
        }

        /// <summary>
        /// 复制邀请码
        /// </summary>
        private void clickCopyInvitationCode()
        {

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

            Transform trans = null;
            trans = GameObject.Instantiate(Prefab, m_transPerfab).transform;
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
            obj = trans.gameObject;
            obj.SetActive(true);

            return obj;
        }
    }
}
