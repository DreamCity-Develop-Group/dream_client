/***
  * Title:    TransferPanel
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/23 10:00
  *
  * Description: ת�˽���
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ת�˽���
/// </summary>
public class TransferPanel : UIBase
{
    private InputField TransactionMoney;                        //ת�˽��
    private InputField TransferTheAddress;                      //ת�˵�ַ
    private Button BtnConfirm;                                  //ȷ����ť
    private Button BtnClose;                                    //�رհ�ť

    private void Awake()
    {
        Bind(UIEvent.TRANSFERACCOUNTS_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
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
    /// �ر����
    /// </summary>
    private void clickClose()
    {
        setPanelActive(false);
    }
    /// <summary>
    /// ȷ����ť
    /// </summary>
    private void clickConfirm()
    {
        Dispatch(AreaCode.UI, UIEvent.TRANSACTIONCODE_ACTIVE, true);
    }
}
