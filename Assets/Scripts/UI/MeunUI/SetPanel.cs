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
    private GameObject SetTrading;              //设置交易密码面板
    private GameObject ChangeTrading;           //修改交易密码面板
    private Button btnSecutiry;                 //设置按钮  
    private Button SoundBtn;                    //音效开关
    private Button MusicBtn;                    //背景音乐开关
    private Image SoundImg;                     //声音图
    private Image MusicImg;                     //背景音乐图
    private Sprite[] switchSprite = new Sprite[2];              //开关图

    private Text TransactionCode;                //交易码设置
    private int setUp;                           //是否设置了交易吗(默认是设置)

    Button btnPanelMusic;
    Button btnHelp;
    Button btnChangePW;
    Button btnChangeExPW;
    Button btnExit;
    Button btnClose;

    private bool IsOpenSound = false;          //是否开启音效
    private bool IsOpenMuisc = false;          //是否开启背景音效
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
        SetTrading = transform.parent.Find("SetExPwPanel").gameObject;
        ChangeTrading = transform.parent.Find("ChangeExPwPanel").gameObject;
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
        MusicBtn= PanelSound.transform.Find("BtnBgMusic").GetComponent<Button>();
        SoundBtn.onClick.AddListener(SoundClick);
        MusicBtn.onClick.AddListener(MuiscClick);
        SoundImg = SoundBtn.GetComponent<Image>();
        MusicImg = MusicBtn.GetComponent<Image>();
        for (int i = 0; i < switchSprite.Length; i++)
        {
            switchSprite[i] = Resources.Load<Sprite>("UI/Switch" + i);
        }

        TransactionCode = panelSecutiry.transform.Find("BtnChangeExPW/Text").GetComponent<Text>();
        switch(setUp)
        {
            case 0:
                TransactionCode.text = "设置交易密码";
                break;
            case 1:
                TransactionCode.text = "修改交易密码";
                break;
        }
        btnChangeExPW.onClick.AddListener(clickChangeTradePassword);
        btnChangePW.onClick.AddListener(clickChangeLoginPassword);

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
        if(!IsOpenSound)
        {
            SoundImg.sprite = switchSprite[1];
            IsOpenSound = !IsOpenSound;
            //把所有音效开启
            Dispatch(AreaCode.AUDIO, AudioEvent.PLAY_EFFECT_AUDIO, "");
        }
        else
        {
            SoundImg.sprite = switchSprite[0];
            IsOpenSound = !IsOpenSound;
            //把所有音效关闭
        }
    }
    /// <summary>
    /// 设置背景音乐
    /// </summary>
    private void MuiscClick()
    {
        if(IsOpenMuisc)
        {
            MusicImg.sprite = switchSprite[1];
            IsOpenMuisc = !IsOpenMuisc;
            //把背景音乐开启
        }
        else
        {
            MusicImg.sprite = switchSprite[0];
            IsOpenMuisc = !IsOpenMuisc;
            //把背景音乐关闭
        }
    }
    private void clickChangeTradePassword()
    {
        switch (setUp)
        {
            case 0:
                Dispatch(AreaCode.UI, UIEvent.SETTRANSACT_ACTIVE, true);
                break;
            case 1:
                Dispatch(AreaCode.UI, UIEvent.SETTRANSACT_ACTIVE, true);
                break;
        }
    }
    private void clickChangeLoginPassword()
    {
        Dispatch(AreaCode.UI, UIEvent.CHANGELONG_ACTIVE, true);
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
