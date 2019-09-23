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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 加入商会面板
/// </summary>
public class NoHaveChamber : UIBase
{
    private Button DetermineBtn;                              //确定按钮
    private Button CloseBtn;                                  //关闭按钮
    private InputField InputChamberCode;                      //输入商会邀请码
    private GameObject IncorrectPrompt;                       //邀请码错误提示
    private Button PromptOKBtn;                               //好的按钮
    private Button PromptClose;                               //错误提示关闭按钮
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
        //判断商会邀请码是否正确
        //if(不正确)
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
