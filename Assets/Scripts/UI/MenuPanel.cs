using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIBase
{
    Button btnFriends;
    Button btnSet;
    Button btnMsg;
    Button btnCommerce;//商会
    Button btnTreasure;//资产
    Button btnAdd;
    private GameObject HandPortrait;                    //头像选择
    private Button changeHand;                          //换头像
    private Button[] handArray = new Button[8];         //头像数组

    Transform usdtCharge;
    Text txtUsdt;
    Transform mtCharge;
    Text txtMt;
    string textForEncoding;
    GameObject gameobjectRed;

    GameObject notice;
    float txtLength;
    float txtNoticeLength;
    Text txtNotice1;
    //通知数
    int noticeCount = 2;
    //
    float t = 0;

    bool isinCommerce=false;

    private void Awake()
    {
        Bind(UIEvent.MENU_PANEL_VIEW);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.MENU_PANEL_VIEW:
                MenuInfo menuInfo = message as MenuInfo;
                IsHasMsg(menuInfo.data.messages);
                //InitInfo(null);
                //setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }

    
    private void Start()
    {
        HandPortrait = transform.Find("HandFrame").gameObject;
        btnTreasure = transform.Find("BtnTreasure").GetComponent<Button>();
        btnCommerce = transform.Find("BtnCommerce").GetComponent<Button>(); 
        btnSet = transform.Find("BtnSet").GetComponent<Button>();
        btnMsg = transform.Find("BtnMsg").GetComponent<Button>();
        btnFriends = transform.Find("BtnFriends").GetComponent<Button>();

        txtUsdt = transform.Find("USDTCharge").GetComponentInChildren<Text>() ;
        txtMt = transform.Find("MTCharge").GetComponentInChildren<Text>();
        btnAdd = transform.Find("BtnAdd").GetComponent<Button>();

        notice = transform.Find("Notice").gameObject;
        txtLength = notice.GetComponent<RectTransform>().rect.width;
      
        txtNotice1 = transform.Find("Notice/TxtNotice1").GetComponent<Text>();
        txtNoticeLength = txtNotice1.GetComponent<RectTransform>().rect.width;
        gameobjectRed = transform.Find("BtnMsg/ImgRed").gameObject;
        changeHand = transform.Find("BtnPersonInfo/BtnHead").GetComponent<Button>();
        for (int i = 0; i < handArray.Length; i++)
        {
            handArray[i] = HandPortrait.transform.Find("Frame/Hand" + i).GetComponent<Button>();
        }
       
        btnAdd = transform.Find("BtnAdd").GetComponent<Button>();
        HandPortrait.SetActive(false);
        btnAdd.onClick.AddListener(clickAdd);
        btnTreasure.onClick.AddListener(clickTreasure);
        btnSet.onClick.AddListener(clickSet);
        btnFriends.onClick.AddListener(clickFriend);
        btnMsg.onClick.AddListener(clickEmali);
        btnCommerce.onClick.AddListener(clickCommerce);
        txtNotice1.gameObject.SetActive(false);
        

    }

    private void InitInfo(MenuInfo menuInfo)
    {
        txtMt.text = menuInfo.data.account.mt.ToString();
        txtUsdt.text = menuInfo.data.account.usdt.ToString();
        noticeCount = menuInfo.data.notices.Count;
       
        if (noticeCount > 0)
        {
            notice.gameObject.SetActive(true);
            StartCoroutine(NoticeStart());
          
        }
        isinCommerce = menuInfo.data.commerce;
        btnCommerce.onClick.AddListener(clickChamber);
        changeHand.onClick.AddListener(clickChangeHand);
        handArray[0].onClick.AddListener(clickHand0);
        handArray[1].onClick.AddListener(clickHand1);
        handArray[2].onClick.AddListener(clickHand2);
        handArray[3].onClick.AddListener(clickHand3);
        handArray[4].onClick.AddListener(clickHand4);
        handArray[5].onClick.AddListener(clickHand5);
        handArray[6].onClick.AddListener(clickHand6);
        handArray[7].onClick.AddListener(clickHand7);

        //menuInfo.data.notices
    }


    private void IsHasMsg(int count)
    {
        if (count > 0)
        {
            gameobjectRed.SetActive(true);
        }
        else
        {
            gameobjectRed.SetActive(false);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>


    IEnumerator NoticeStart()
    {
        while (noticeCount>0)
        {
            noticeCount--;
            txtNotice1.gameObject.SetActive(true);
            t = 0;
            StartCoroutine(NoticeRuning());
            yield return new WaitForSeconds(15);
        }
        notice.gameObject.SetActive(false);
    }

    IEnumerator NoticeRuning()
    {
        while (t<=1)
        {
            txtNotice1.transform.localPosition = new Vector2(Mathf.Lerp((txtLength+txtNoticeLength)/2,-(txtLength + txtNoticeLength)/ 2, t),0);
            t+= Time.deltaTime/10;
            yield return new WaitForEndOfFrame();
        }
    }
    private void clickAdd()
    {
        //测试
        //获取二维码字符串
        textForEncoding = "0x8dbd8843d9e9de809c19ed53e0403475c987ab15";
        //CreatQRcode(textForEncoding,)
        //Sprite spriteQRcode=GetSprite(textForEncoding);
        // Dispatch(AreaCode.Net,EventType);
        
        Dispatch(AreaCode.UI,UIEvent.QRECODE_PANEL_ACTIVE,CreatQRcode(textForEncoding));

    }
    private Texture2D CreatQRcode(string textForEncoding, Texture2D logo = null)
    {
        if (string.IsNullOrEmpty(textForEncoding))
        {
            return null;
        }
        Texture2D encode = new Texture2D(100, 100, TextureFormat.RGBA32, false);
        var colors = MsgTool.Encode(textForEncoding, encode.width, encode.height);
        encode.SetPixels32(colors);
        //if (logo != null)
        //{
        //    int x = (encode.width-logo.width) / 2;
        //    int y = (encode.height-logo.height) / 2;
        //    Color32[] colorlogo = logo.GetPixels32();
        //    encode.SetPixels32(x,y,logo.width,logo.height,colorlogo);
        //}
        encode.Apply();
        return encode;
    }
    private void clickFriend()
    {
        Dispatch(AreaCode.UI, UIEvent.FRIENDMENU_PANEL_ACTIVE, true);
    }
    private void clickTreasure()
    {
        Dispatch(AreaCode.UI,UIEvent.CHARGE_PANEL_ACTIVE,true);
    }

    private void clickSet()
    {
        Dispatch(AreaCode.UI,UIEvent.SET_PANEL_ACTIVE,true);
    }

    private void clickEmali()
    {
        Dispatch(AreaCode.UI, UIEvent.MSG_PANEL_ACTIVE, true);
    }
    private void clickChamber()
    {

    }
    private void clickCommerce()
    {
        if (isinCommerce)
        {
            Dispatch(AreaCode.UI, UIEvent.COMMERCE_PANEL_ACTIVE, true);
        }
        else
        {

        }
        //判断是不是没有加入商会
        //if(如果没有)
        Dispatch(AreaCode.UI, UIEvent.COMMERCE_NOJIONPANEL_ACTIVE, true);
        //else
        //Dispatch(AreaCode.UI, UIEvent.COMMERCE_PANEL_ACTIVE, true);
    }
    private void clickChangeHand()
    {
        HandPortrait.SetActive(true);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        btnTreasure.onClick.RemoveAllListeners();
        btnSet.onClick.RemoveAllListeners();
    }
    private void clickHand0()
    {
        changeHand.GetComponent<Image>().sprite = handArray[0].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand1()
    {
        changeHand.GetComponent<Image>().sprite = handArray[1].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand2()
    {
        changeHand.GetComponent<Image>().sprite = handArray[2].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand3()
    {
        changeHand.GetComponent<Image>().sprite = handArray[3].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand4()
    {
        changeHand.GetComponent<Image>().sprite = handArray[4].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand5()
    {
        changeHand.GetComponent<Image>().sprite = handArray[5].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand6()
    {
        changeHand.GetComponent<Image>().sprite = handArray[6].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }
    private void clickHand7()
    {
        changeHand.GetComponent<Image>().sprite = handArray[7].GetComponent<Image>().sprite;
        HandPortrait.SetActive(false);
    }

}
