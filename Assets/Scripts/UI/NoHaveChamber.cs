/***
  * Title:    NoHaveChamber 
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/23 17:25:07
  *
  * Description: �����̻����
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
/// �����̻����
/// </summary>
public class NoHaveChamber : UIBase
{
    private Button DetermineBtn;                              //ȷ����ť
    private Button CloseBtn;                                  //�رհ�ť
    private InputField InputChamberCode;                      //�����̻�������
    private GameObject IncorrectPrompt;                       //�����������ʾ
    private Button PromptOKBtn;                               //�õİ�ť
    private Button PromptClose;                               //������ʾ�رհ�ť
    private void Awake()
    {
        Bind(UIEvent.COMMERCE_NOJIONPANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.COMMERCE_NOJIONPANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    void Start()
    {
        DetermineBtn = transform.Find("JionChamber/BtnConfirm").GetComponent<Button>();
        CloseBtn = transform.Find("JionChamber/BtnClose").GetComponent<Button>();
        InputChamberCode = transform.Find("JionChamber/InputField").GetComponent<InputField>();
        IncorrectPrompt = transform.Find("IncorrectPrompt").gameObject;
        CloseBtn.onClick.AddListener(clickClose);
        PromptOKBtn = IncorrectPrompt.transform.Find("OK").GetComponent<Button>();
        PromptClose = IncorrectPrompt.transform.Find("Close").GetComponent<Button>();
        DetermineBtn.onClick.AddListener(clickDetermine);
        PromptClose.onClick.AddListener(clickPromptClose);
        PromptOKBtn.onClick.AddListener(clickPromptClose);
        setPanelActive(false);
    }
    private void clickClose()
    {
        setPanelActive(false);
    }
    private void clickDetermine()
    {
        //�ж��̻��������Ƿ���ȷ
        //if(����ȷ)
        //{
        //    IncorrectPrompt.SetActive(true);
        //}
        //else
        //{
        Dispatch(AreaCode.UI, UIEvent.SUCCESSFULSHAMBER_ACTIVE, true);
        //}
    }
    private void clickPromptClose()
    {
        IncorrectPrompt.SetActive(false);
    }
}
