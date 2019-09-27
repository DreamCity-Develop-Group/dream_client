using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;
using EventType = Assets.Scripts.Net.EventType;
// ReSharper disable InconsistentNaming

namespace Assets.Scripts.UI.LoginUI
{
    public class LgoinPanel : UIBase
    {
        Button btnLogin;
        Button btnReg;
        Button btnIdentityLog;
        Button btnForget;
        InputField inputUserName;
        InputField inputPassWord;
        InputField inputIdentity;
        Button btnGetIdentity;

        Text textIdentityLog;
        string username = "jx";
        string password = "123";
        string identity = "000";
        private string code;

        bool isLogIdentity = false;
        LoginInfo loginInfo;
        private void Awake()
        {
            Bind(UIEvent.LOG_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.LOG_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                default:
                    break;
            }
        }
        void Start()
        {
            inputUserName = transform.Find("InputUserName").GetComponent<InputField>();
            inputPassWord = transform.Find("InputPassWord").GetComponent<InputField>();
            inputIdentity = transform.Find("InputIdentity").GetComponent<InputField>();

            btnForget = transform.Find("BtnForget").GetComponent<Button>();
            btnLogin = transform.Find("BtnLogin").GetComponent<Button>();
            btnReg = transform.Find("BtnReg").GetComponent<Button>();
            btnIdentityLog = transform.Find("BtnIdentityLog").GetComponent<Button>();
            btnGetIdentity = transform.Find("BtnGetIdentity").GetComponent<Button>();
            textIdentityLog = btnIdentityLog.GetComponent<Text>();

            btnIdentityLog.onClick.AddListener(clickIdentityLog);
            btnGetIdentity.onClick.AddListener(clickGetIdentity);
            btnLogin.onClick.AddListener(clickLogin);
            btnReg.onClick.AddListener(clickReg);

            btnForget.onClick.AddListener(clickForget);

            //inputUserName.GetComponent<LanguageText>().Key =LanguageService.Instance.GetStringByKey("UILogin.InputUserName", string.Empty);

            btnGetIdentity.gameObject.SetActive(false);
            inputIdentity.gameObject.SetActive(false);
            loginInfo = new LoginInfo();
            setPanelActive(false);

        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            btnLogin.onClick.RemoveAllListeners();
            btnGetIdentity.onClick.RemoveAllListeners();
            btnIdentityLog.onClick.RemoveAllListeners();
        }


        private void clickForget()
        {
            Dispatch(AreaCode.UI, UIEvent.Forget_ACTIVE, true);
            Debug.Log("clickGetIdentity");
        }
        private void clickGetIdentity()
        {
            username = inputUserName.text;
            Dispatch(AreaCode.NET, EventType.identy,username);
            Debug.Log("clickGetIdentity");
        }
        private void clickIdentityLog()
        {
        
            if (!isLogIdentity)
            {
                textIdentityLog.text = "密码登入";
                btnForget.gameObject.SetActive(false);
                inputPassWord.gameObject.SetActive(false);
                inputIdentity.gameObject.SetActive(true);
                btnGetIdentity.gameObject.SetActive(true);
                isLogIdentity = !isLogIdentity;
            }
            else
            {
                textIdentityLog.text = "验证码登入";
                btnForget.gameObject.SetActive(true);
                inputPassWord.gameObject.SetActive(true);
                inputIdentity.gameObject.SetActive(false);
                btnGetIdentity.gameObject.SetActive(false);
                isLogIdentity = !isLogIdentity;
            }

        }
        private void clickReg()
        {
            setPanelActive(false);
            Dispatch(AreaCode.UI, UIEvent.REG_ACTIVE, true);
        }
        private void clickLogin()
        {
            //testTODO调试用
            // Dispatch(AreaCode.SCENE, SceneEvent.MENU_PLAY_SCENE, new SceneMsg("menu", null));
            username = inputUserName.text;
            loginInfo.UserName = username;

            if (isLogIdentity)
            {
                identity = inputIdentity.text;
                loginInfo.Password = identity;
                Dispatch(AreaCode.NET, EventType.idlogin, loginInfo);
            }
            else
            {
                password = inputPassWord.text;
                loginInfo.Password = password;
                Dispatch(AreaCode.NET, EventType.pwlogin, loginInfo);
            }
        }
    }
}
