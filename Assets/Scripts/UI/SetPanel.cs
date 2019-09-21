using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel: UIBase
{
    private GameObject MusicClik;               //点击状态的音效按钮
    private GameObject SecutiryClik;            //点击状态的安全设置按钮
    private GameObject HelpClik;                //点击状态的帮助按钮
    private GameObject PanelSound;              //音效设置面板
    private GameObject panelSecutiry;           //安全设置面板
    private GameObject PanelHelp;               //帮助设置面板
    private Button btnSecutiry;                 //设置按钮  
    private Button SoundBtn;                    //音效开关
    private Button MusicBtn;                    //背景音乐开关

    Button btnPanelMusic;
    Button btnHelp;
    Button btnChangePW;
    Button btnChangeExPW;
    Button btnExit;
    Button btnClose;

    private bool IsOpenSound = true;          //是否开启音效
    private bool IsOpenMuisc = true;          //是否开启背景音效
    bool isVoice=true;
    private void Awake()
    {
        Bind(UIEvent.SET_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SET_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        btnPanelMusic = transform.Find("BtnPanelMusic").GetComponent<Button>();
        btnSecutiry = transform.Find("BtnSecutiry").GetComponent<Button>();
        btnHelp  = transform.Find("BtnHelp").GetComponent<Button>();
        btnChangeExPW = transform.Find("panelSecutiry/BtnChangeExPW").GetComponent<Button>();
        btnChangePW = transform.Find("panelSecutiry/BtnChangePW").GetComponent<Button>();
        btnExit = transform.Find("panelSecutiry/BtnExit").GetComponent<Button>();
        btnClose = transform.Find("BtnClose").GetComponent<Button>();

        btnClose.onClick.AddListener(clickClose);
        btnPanelMusic.onClick.AddListener(clickMusic);
        btnExit.onClick.AddListener(clickExit);
        btnSecutiry.onClick.AddListener(ClickSecutiry);
        btnHelp.onClick.AddListener(ClickHelp);

        MusicClik = transform.Find("MusicClik").gameObject;
        SecutiryClik = transform.Find("SecutiryClik").gameObject;
        SecutiryClik.SetActive(false);
        HelpClik = transform.Find("HelpClik").gameObject;
        HelpClik.SetActive(false);
        PanelSound = transform.Find("PanelSound").gameObject;
        panelSecutiry = transform.Find("panelSecutiry").gameObject;
        PanelHelp = transform.Find("PanelHelp").gameObject;
        panelSecutiry.SetActive(false);
        PanelHelp.SetActive(false);
        SoundBtn = PanelSound.transform.Find("BtnGameMusic ").GetComponent<Button>();
        MusicBtn= PanelSound.transform.Find("BtnBgMusic ").GetComponent<Button>();
        SoundBtn.onClick.AddListener(SoundClick);
        MusicBtn.onClick.AddListener(MuiscClick);
        setPanelActive(false);
    }

   /// <summary>
   /// 音效设置
   /// </summary>
    private void clickMusic()
    {
        Dispatch(AreaCode.UI, UIEvent.VOICE_PANEL_ACTIVE, true);
        PanelSound.SetActive(true);
        panelSecutiry.SetActive(false);
        PanelHelp.SetActive(false);
        MusicClik.SetActive(true);
        SecutiryClik.SetActive(false);
        HelpClik.SetActive(false);
    }
    /// <summary>
    /// 安全设置按钮
    /// </summary>
    private void ClickSecutiry()
    {
        panelSecutiry.SetActive(true);
        PanelHelp.SetActive(false);
        PanelSound.SetActive(false);
        SecutiryClik.SetActive(true);
        HelpClik.SetActive(false);
        MusicClik.SetActive(false);
    }
    /// <summary>
    /// 帮助按钮
    /// </summary>
    private void ClickHelp()
    {
        panelSecutiry.SetActive(false);
        PanelHelp.SetActive(true);
        PanelSound.SetActive(false);
        SecutiryClik.SetActive(false);
        HelpClik.SetActive(true);
        MusicClik.SetActive(false);
    }
    /// <summary>
    /// 设置音效
    /// </summary>
    private void SoundClick()
    {

    }
    /// <summary>
    /// 设置背景音乐
    /// </summary>
    private void MuiscClick()
    {

    }
    /// <summary>
    /// 退出按钮
    /// </summary>
    private void clickExit()
    {
        Dispatch(AreaCode.NET,EventType.exit,null);
        Application.Quit();
    }
    /// <summary>
    /// 关闭设置按钮
    /// </summary>
    private void clickClose()
    {
        Dispatch(AreaCode.UI, UIEvent.VOICE_PANEL_ACTIVE, false);
        setPanelActive(false);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnClose.onClick.RemoveAllListeners();
        //btnMusic.onClick.RemoveAllListeners();
        //btnHelp.onClick.RemoveAllListeners();
        //btnChangeExPW.onClick.RemoveAllListeners();
        //btnChangePW.onClick.RemoveAllListeners();
    }







}
