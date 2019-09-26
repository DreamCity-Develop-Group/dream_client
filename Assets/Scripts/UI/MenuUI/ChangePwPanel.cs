using System.Collections.Generic;
using Assets.Scripts.Framework;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Net;
using EventType = Assets.Scripts.Net.EventType;
/***
* Title:     
*
* Created:	zp
*
* CreatTime:  2019/09/16 17:28:17
*
* Description: 改密码面板
*
* Version:    0.1
*
*
***/

namespace Assets.Scripts.UI.LoginUI
{
    public class ChangePwPanel : UIBase
    {
        private InputField inputFieldMobile;
        private InputField inputFieldVerification;
        private InputField inputFieldCurrentPassword;
        private InputField inputFieldNewPassword;
        private Button btnConfirm;
        private Button btnClose;
        private Button btnGetVerificationCode;

        private string currentpassword;
        private string newpassword;
        private string verificationcode;
        private void Awake()
        {
            Bind(UIEvent.CHANGETRADE_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.CHANGETRADE_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                default:
                    break;
            }
        }
        void Start()
        {
           // inputFieldMobile = transform.Find("BG/InputFieldMobile").GetComponent<InputField>();
            inputFieldVerification= transform.Find("BG/InputFieldVerification").GetComponent<InputField>();
            inputFieldCurrentPassword = transform.Find("BG/InputFieldCurrentPassword").GetComponent<InputField>();
            inputFieldNewPassword = transform.Find("BG/InputFieldNewPassword").GetComponent<InputField>();
            btnConfirm = transform.Find("BG/BtnConfirm").GetComponent<Button>();
            btnClose = transform.Find("BG/BtnClose").GetComponent<Button>();
            btnGetVerificationCode = transform.Find("BG/BtnGetVerificationCode").GetComponent<Button>();

            btnGetVerificationCode.onClick.AddListener(clickGetVerificationCode);
            btnConfirm.onClick.AddListener(clickConfirm);
            btnClose.onClick.AddListener(clickClose);
            setPanelActive(false);
        }

        private void clickConfirm()
        {
             currentpassword = inputFieldCurrentPassword.text;
             newpassword = inputFieldNewPassword.text;
             verificationcode = inputFieldVerification.text;
            Dictionary<string,string> msg = new Dictionary<string, string>()
            {
                ["oldpw"]=currentpassword,
                ["newpw"] = newpassword,
            };
            Dispatch(AreaCode.NET, EventType.expw, msg); 
        }

        private void clickClose()
        {
            setPanelActive(false);
        }

        private void clickGetVerificationCode()
        {
            Dispatch(AreaCode.NET,EventType.identy,null);
        }
        // Update is called once per frame
        void Update()
        {
            if (inputFieldCurrentPassword.text == null || inputFieldNewPassword.text == null ||
                inputFieldVerification.text == null)
            {
                btnConfirm.gameObject.SetActive(false);
            }
            else
            {
                btnConfirm.gameObject.SetActive(true);
            }
        }
    }
}
