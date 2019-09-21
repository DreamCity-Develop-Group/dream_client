
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/16 17:28:57
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetExPwPanel : UIBase
{

    private Button BtnDetermine;           //ȷ����ť
    private Button BtnCancel;              //ȡ����ť
    private InputField inputTransaction;   //����Ľ�������
    private string inputInfo;              //������Ϣ
    private void Awake()
    {
        Bind(UIEvent.SETTRANSACT_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SETTRANSACT_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    void Start()
    {
        BtnDetermine = transform.Find("BtnCommit").GetComponent<Button>();
        BtnCancel = transform.Find("BtnCancle").GetComponent<Button>();
        inputTransaction = transform.Find("InputExPw").GetComponent<InputField>();
        setPanelActive(false);
        BtnDetermine.onClick.AddListener(clickDetermine);
        BtnCancel.onClick.AddListener(clickCancel);
    }
    private void Update()
    {
        inputTransaction.text = inputInfo;
    }
    /// <summary>
    /// ȷ���¼�
    /// </summary>
    private void clickDetermine()
    {

    }
    /// <summary>
    /// ȡ����ť
    /// </summary>
    private void clickCancel()
    {
        setPanelActive(false);
    }
}
