using Assets.Scripts.Tools;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/10/01 20:26:11
  *
  * Description:  海报界面
  *
  * Version:    0.1
  *
  *
***/
public class PostPanel : UIBase
{
    // Start is called before the first frame update
    private Image _post1Image;
    private Image _post2Image;
    private Image _post3Image;
    private Image _qrCode1Image;
    private Image _qrCode2Image;
    private Image _qrCode3Image;
    private Text _inviteCode1;
    private Text _inviteCode2;
    private Text _inviteCode3;

    private void Awake()
    {
        Bind(UIEvent.SHARKEPOST_PANEL_VIEW);
    }

    protected internal override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SHARKEPOST_PANEL_VIEW:
                setPanelActive(true);
                CreatQRcode(CacheData.QrCode);
                break;
            default:
                break;
        }
    }
    void Start()
    {
        _post1Image = transform.Find("Post1").GetComponent<Image>();
        _post2Image = transform.Find("Post2").GetComponent<Image>();
        _post3Image = transform.Find("Post3").GetComponent<Image>();

        _qrCode1Image = transform.Find("Post1/").GetComponent<Image>();
        _qrCode2Image = transform.Find("Post1").GetComponent<Image>();
        _qrCode3Image = transform.Find("Post1").GetComponent<Image>();

        _inviteCode1 = transform.Find("Post1/InviteCode").GetComponent<Text>();
        _inviteCode2 = transform.Find("Post2/InviteCode").GetComponent<Text>();
        _inviteCode3 = transform.Find("Post3/InviteCode").GetComponent<Text>();

        setPanelActive(false);
      //  InitSource();
    }
    /// <summary>
    /// 多语言选择初始化
    /// </summary>
    private void InitSource()
    {
        string language = PlayerPrefs.GetString("language");
        _post1Image.sprite = Resources.Load<Sprite>("UI/menu/" + language + "/" + "Poster1");
        _post1Image.sprite = Resources.Load<Sprite>("UI/menu/" + language + "/" + "Poster2");
        _post1Image.sprite = Resources.Load<Sprite>("UI/menu/" + language + "/" + "Poster3");
    }
    private Texture2D CreatQRcode(string textForEncoding, Texture2D logo = null)
    {
        if (string.IsNullOrEmpty(textForEncoding))
        {
            return null;
        }
        int num = Random.Range(1, 3);
        switch (num)
        {
            case 1:
                _post1Image.gameObject.SetActive(true);
                break;
            case 2:
                _post2Image.gameObject.SetActive(true);
                break;
            case 3:
                _post3Image.gameObject.SetActive(true);
                break;
        }
       
        //TODO之后可以去除
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
    private void Onclose()
    {
        //保存海报
        //SaveImages();
        //关闭界面
        setPanelActive(false);
    }
}
