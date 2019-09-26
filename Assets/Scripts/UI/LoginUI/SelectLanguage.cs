using System;
using Assets.Scripts.Framework;
using Assets.Scripts.Language;
using Assets.Scripts.Net;
using UnityEngine;
using UnityEngine.UI;
using EventType = Assets.Scripts.Net.EventType;

/***
* Title:     
*
* Created:	zp
*
* CreatTime:          2019/09/20 13:33:56
*
* Description:
*
* Version:    0.1
*
*
***/
namespace Assets.Scripts.UI.LoginUI
{
    public class SelectLanguage : UIBase
    {
        Button btnSelectLanguage;
        Button btnEnglish;
        Button btnChinese;
        Button btnKorean;
        bool isSelect;

        Text localText;
        Button btnConfim;
        InputField testInputIp;


        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.TEST_PANEL_ACTIVE:
                    localText.text = message.ToString();
                    //gameObjectLoginSelectPanel.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        void Awake()
        {
            Bind(UIEvent.TEST_PANEL_ACTIVE);
            LanguageService.Instance.Language = new LanguageInfo("Chinese");
        }
        void Start()
        {
            btnChinese = transform.Find("BtnChinese").GetComponent<Button>();
            btnEnglish = transform.Find("BtnEnglish").GetComponent<Button>();
            btnKorean = transform.Find("BtnKorean").GetComponent<Button>();

            localText = transform.Find("Test/LocalText").GetComponent<Text>();
            btnConfim = transform.Find("Test/TestInput/BtnIp").GetComponent<Button>();
            testInputIp = transform.Find("Test/TestInput").GetComponent<InputField>();
            btnConfim.onClick.AddListener(clickIpConfim);
            btnEnglish.onClick.AddListener(clickEnglish);
            btnChinese.onClick.AddListener(clickChinese);
            btnKorean.onClick.AddListener(clickKorean);
            GameObject textPrefab = (GameObject)Resources.Load("Text");
            //GameObject textObj = (GameObject)Instantiate(textPrefab);
            //textObj.transform.SetParent(this.transform);
            //textObj.transform.localPosition = Vector3.zero;
            btnSelectLanguage = transform.Find("BtnSelectLanguage").GetComponent<Button>() ;
            btnSelectLanguage.onClick.AddListener(clickSelectLanguage);
            btnChinese.gameObject.SetActive(false);
            btnEnglish.gameObject.SetActive(false);
            btnKorean.gameObject.SetActive(false);
            //Dispatch(AreaCode.NET, EventType.init, null);
        }
        private void clickIpConfim()
        {
            WebData.ip = testInputIp.text;
            Dispatch(AreaCode.NET, EventType.init, null);
        }

        /// <summary>
        /// 核对手机系统语言自动选择默认语言
        /// </summary>
        private void CheckLanaguage()
        {
            string language = Application.systemLanguage.ToString();
       
            bool containChinese = language.IndexOf("Chinese", StringComparison.OrdinalIgnoreCase) >= 0;
            if (containChinese)
            {
                clickChinese();
            }
            bool containEnglish = language.IndexOf("English", StringComparison.OrdinalIgnoreCase) >= 0;
            if (containEnglish)
            {
                clickEnglish();
            }
            bool containKorean = language.IndexOf("Korean", StringComparison.OrdinalIgnoreCase) >= 0;
            if (containKorean)
            {
                clickKorean();
            }
        }


        void clickSelectLanguage()
        {
            if (!isSelect)
            {
                btnChinese.gameObject.SetActive(true);
                btnEnglish.gameObject.SetActive(true);
                btnKorean.gameObject.SetActive(true);
                isSelect = !isSelect;
            }
            else
            {
                btnChinese.gameObject.SetActive(false);
                btnEnglish.gameObject.SetActive(false);
                btnKorean.gameObject.SetActive(false);
                isSelect = !isSelect;
            }
        
        }

        void clickEnglish()
        {
            LanguageService.Instance.Language = new LanguageInfo("English");
            PlayerPrefs.SetString("language","English");
            Dispatch(AreaCode.UI, UIEvent.LANGUAGE_VIEW, "English");
        }
        void clickChinese()
        {
            LanguageService.Instance.Language = new LanguageInfo("Chinese");
            PlayerPrefs.SetString("language", "Chinese");
            Dispatch(AreaCode.UI, UIEvent.LANGUAGE_VIEW, "Chinese");
        }
        void clickKorean()
        {
            LanguageService.Instance.Language = new LanguageInfo("Korean");
            PlayerPrefs.SetString("language", "Korean");
            Dispatch(AreaCode.UI, UIEvent.LANGUAGE_VIEW, "Korean");
        }
    }
}
