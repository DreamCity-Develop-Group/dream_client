using System.Collections;
using Assets.Scripts.Framework;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable InconsistentNaming

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
namespace Assets.Scripts.UI.LoginUI
{
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

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.LOAD_PANEL_ACTIVE:
                    setPanelActive((bool)message);
                    //test hide TODO
                    gameObjectLoginSelectPanel.SetActive(true);
                    // StartCoroutine(Loading());
                    //gameObjectLoginSelectPanel.gameObject.SetActive(true);
                    break;
            }
        }
        // Start is called before the first frame update
        private void Start()
        {
            gameObjectLoginSelectPanel = transform.Find("LoginSelectPanel").gameObject;
            btnLogin = transform.Find("LoginSelectPanel/BtnLogin").GetComponent<Button>();
            btnRegist = transform.Find("LoginSelectPanel/BtnRegist").GetComponent<Button>();

            btnLogin.onClick.AddListener(clickLogin);
            btnRegist.onClick.AddListener(clickRegist);
            //系统字体
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
}
