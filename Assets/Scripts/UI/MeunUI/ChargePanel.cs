
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Awake()
    {
        Bind(UIEvent.CHARGE_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.CHARGE_PANEL_ACTIVE:
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
