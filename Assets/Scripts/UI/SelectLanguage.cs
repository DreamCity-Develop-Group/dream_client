using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Language;
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
public class SelectLanguage : UIBase
{
    Button btnSelectLanguage;
    Button btnEnglish;
    Button btnChinese;
    Button btnKorean;
    bool isSelect;
    void Awake()
    {
       
        LanguageService.Instance.Language = new LanguageInfo("Chinese");
    }
    void Start()
    {
        btnChinese = transform.Find("BtnChinese").GetComponent<Button>();
        btnEnglish = transform.Find("BtnEnglish").GetComponent<Button>();
        btnKorean = transform.Find("BtnKorean").GetComponent<Button>();

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
    }

    void clickSelectLanguage()
    {
        if (isSelect)
        {
            btnChinese.gameObject.SetActive(true);
            btnEnglish.gameObject.SetActive(true);
            btnKorean.gameObject.SetActive(true);
        }
        else
        {
            btnChinese.gameObject.SetActive(false);
            btnEnglish.gameObject.SetActive(false);
            btnKorean.gameObject.SetActive(false);
        }
        
    }

    void clickEnglish()
    {
        LanguageService.Instance.Language = new LanguageInfo("English");
        Dispatch(AreaCode.UI, UIEvent.LANGUAGE_VIEW, "English");
    }
    void clickChinese()
    {
        LanguageService.Instance.Language = new LanguageInfo("Chinese");
        Dispatch(AreaCode.UI, UIEvent.LANGUAGE_VIEW, "Chinese");
    }
    void clickKorean()
    {
        LanguageService.Instance.Language = new LanguageInfo("Korean");
        Dispatch(AreaCode.UI, UIEvent.LANGUAGE_VIEW, "Korean");
    }
}
