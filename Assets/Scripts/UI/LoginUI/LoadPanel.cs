using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/20 18:42:08
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
public class LoadPanel : UIBase
{
   
    Slider sliderLoading;
    GameObject gameObjectLoginSelectPanel;
    Button btnRegist;
    Button btnLogin;
    private void Awake()
    {
        Bind(UIEvent.LOAD_PANEL_ACTIVE);

    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.LOAD_PANEL_ACTIVE:
                setPanelActive((bool)message);
                StartCoroutine(Loading());
                //gameObjectLoginSelectPanel.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObjectLoginSelectPanel = transform.Find("LoginSelectPanel").gameObject;
        btnLogin = transform.Find("LoginSelectPanel/BtnLogin").GetComponent<Button>();
        btnRegist = transform.Find("LoginSelectPanel/BtnRegist").GetComponent<Button>();

        btnLogin.onClick.AddListener(clickLogin);
        btnRegist.onClick.AddListener(clickRegist);
        //ÏµÍ³×ÖÌå
        string language = Application.systemLanguage.ToString();
        Debug.Log(language);
        

        sliderLoading = transform.Find("SliderLoading").GetComponent<Slider>();
        
        gameObjectLoginSelectPanel.SetActive(false);
        setPanelActive(false);
       
    }

    IEnumerator Loading()
    {
        while (sliderLoading.GetComponent<Slider>().value<1)
        {
            sliderLoading.GetComponent<Slider>().value += 0.1f;
            yield return new WaitForSeconds(1);
        }
        sliderLoading.gameObject.SetActive(false);
        gameObjectLoginSelectPanel.SetActive(true);
    }
    private void clickLogin()
    {
        setPanelActive(false);
        Dispatch(AreaCode.UI, UIEvent.LOG_ACTIVE, true);
    }

    private void clickRegist()
    {
        setPanelActive(false);
        Dispatch(AreaCode.UI, UIEvent.REG_ACTIVE, true);
    }

}
