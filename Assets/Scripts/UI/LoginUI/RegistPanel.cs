using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;
using EventType = Assets.Scripts.Net.EventType;

namespace Assets.Scripts.UI.LoginUI
{
    public class RegistPanel : UIBase
    {
        Button btnRegist;
        Button btnIdentify;
        Button btnReturn;
        Button btnLogin;
        InputField inputIdentify;
        InputField inputUserName;
        InputField inputPassWord;
        InputField inputNickName;
        InputField inputInviteCode;
        private Image getCodeImage;
        private Image registImage;

        string phone;
        string identify;
        string passWord;
        string nickName;
        string inviteCode;
        //InputField inputRePassWord;
        private void Awake()
        {
            Bind(UIEvent.REG_ACTIVE, UIEvent.REG_PANEL_CODEVIEW,UIEvent.LANGUAGE_VIEW);
       
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.REG_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                case UIEvent.REG_PANEL_CODEVIEW:
                    inputIdentify.text = message.ToString();
                    break;
                case UIEvent.LANGUAGE_VIEW:
                    initSource(message.ToString());
                    break;
                default:
                    break;
            }
        }

        void Start()
        {
            btnLogin = transform.Find("BtnLogin").GetComponent<Button>();
            btnIdentify = transform.Find("BtnIdentify").GetComponent<Button>();
            btnRegist = transform.Find("BtnRegist").GetComponent<Button>();
            btnReturn = transform.Find("BtnReturn").GetComponent<Button>();
            inputUserName = transform.Find("InputUserName").GetComponent<InputField>();
            inputIdentify = transform.Find("InputIdentify").GetComponent<InputField>(); 
            inputPassWord = transform.Find("InputPassWord").GetComponent<InputField>();
            inputNickName = transform.Find("InputNickName").GetComponent<InputField>();
            inputInviteCode = transform.Find("InputInviteCode").GetComponent<InputField>();

            getCodeImage = btnIdentify.GetComponent<Image>();
            registImage = btnRegist.GetComponent<Image>();

            btnLogin.onClick.AddListener(clickLogin);
            btnIdentify.onClick.AddListener(clickIdentify);
            btnRegist.onClick.AddListener(clickRegist);
            btnReturn.onClick.AddListener(clickReturn);
            btnRegist.enabled = false;
            setPanelActive(false);
        }
        private void initSource(string language)
        {
            //string language = PlayerPrefs.GetString("language");
            //string language = "chinese";
            Debug.Log(language);
            getCodeImage.sprite = Resources.Load<Sprite>("UI/login/" + language + "/" + "huoquyanzhengma@2x");
            registImage.sprite = Resources.Load<Sprite>("UI/login/" + language + "/" + "zhucelv");
        }
        private void clickLogin()
        {
            setPanelActive(false);
            Dispatch(AreaCode.UI,UIEvent.LOG_ACTIVE,true);
        }
        private void clickIdentify()
        {
            btnRegist.enabled = true;
            phone = inputUserName.text;
            Dispatch(AreaCode.NET, EventType.identy, phone);
            Debug.Log("clickIdentify");
        }
        private void clickReturn()
        {
            setPanelActive(false);
            Dispatch(AreaCode.UI,UIEvent.LOG_ACTIVE,true);
        }
        private void clickRegist()
        {
            phone=inputUserName.text;
            passWord = inputPassWord.text;
            inviteCode = inputInviteCode.text;
            nickName = inputNickName.text;
            identify = inputIdentify.text;
            UserInfo userinfo = new UserInfo(phone,passWord,identify,inviteCode,nickName);
            Dispatch(AreaCode.NET,EventType.regist, userinfo);
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            btnIdentify.onClick.RemoveAllListeners();
            btnRegist.onClick.RemoveAllListeners();
            btnReturn.onClick.RemoveAllListeners();
        }
    }
}
