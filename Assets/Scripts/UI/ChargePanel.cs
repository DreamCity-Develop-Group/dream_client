
/***
  * Title:    ChargePanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 11:58:34
  *
  * Description: �ʲ�����
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

    private Button transferAccounts;                  //ת�˰�ť
    private Button topUp;                             //��ֵ��ť
    private Button InviteFriends;                     //�������
    private Button transactionRecord;                 //���׼�¼��ť
    private Button CopyInvitationCode;                //����������
    private GameObject PanleInviterFrindsBG;          //����������
    private GameObject TransactionRecord;             //���׼�¼���  
    private Button TransctionClose;                   //�������ر�
    private Transform TransactionListPraent;          //�����б�����
    private List<UserInfo> List_Transaction = new List<UserInfo>();  //�洢���׼�¼�����м�¼

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
                    //�ҵ�Test����ֵ��Ϣ
                }
                else
                {
                    GameObject obj = Resources.Load("PerFab/RecordItme1") as GameObject;
                    obj= CreatePreObj(obj, TransactionListPraent);
                    //�ҵ�Test����ֵ��Ϣ
                }
            }
        }
    }

    /// <summary>
    /// �ر��ʲ����
    /// </summary>
    private void clickClose()
    {
        setPanelActive(false);
    }
    /// <summary>
    /// ת��
    /// </summary>
    private void clickTransferAccounts()
    {
        Dispatch(AreaCode.UI, UIEvent.TRANSFERACCOUNTS_ACTIVE, true);
    }
    /// <summary>
    /// ��ֵ
    /// </summary>
    private void clickTopUp()
    {
        Dispatch(AreaCode.UI, UIEvent.TOPUP_ACTIVE, true);
    }
    /// <summary>
    /// �������
    /// </summary>
    private void clickInviteFriends()
    {
        PanleInviterFrindsBG.SetActive(true);
    }
    /// <summary>
    /// ���׼�¼
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
    /// ����������
    /// </summary>
    private void clickCopyInvitationCode()
    {

    }
    private Queue<GameObject> m_queue_gPreObj = new Queue<GameObject>();          //�����
    private Transform TempTrans;
    /// <summary>
    /// ����Ԥ����
    /// </summary>
    /// <param name="Prefab">Ԥ����</param>
    /// <param name="m_transPerfab">Ԥ���常�����transform</param>
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
