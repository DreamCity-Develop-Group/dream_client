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
        private InputField _inputFieldMobile;
        private InputField _inputFieldVerification;
        private InputField _inputFieldCurrentPassword;
        private InputField _inputFieldNewPassword;
        private Button _btnConfirm;
        private Button _btnClose;
        private Button _btnGetVerificationCode;

        private string _currentpassword;
        private string _newpassword;
        private string _verificationcode;
        private void Awake()
        {
            Bind(UIEvent.CHANGELONG_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.CHANGELONG_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                default:
                    break;
            }
        }
        void Start()
        {
           // inputFieldMobile = transform.Find("BG/InputFieldMobile").GetComponent<InputField>();
            _inputFieldVerification= transform.Find("BG/InputFieldVerification").GetComponent<InputField>();
            _inputFieldCurrentPassword = transform.Find("BG/InputFieldCurrentPassword").GetComponent<InputField>();
            _inputFieldNewPassword = transform.Find("BG/InputFieldNewPassword").GetComponent<InputField>();
            _btnConfirm = transform.Find("BG/BtnConfirm").GetComponent<Button>();
            _btnClose = transform.Find("BG/BtnClose").GetComponent<Button>();
            _btnGetVerificationCode = transform.Find("BG/BtnGetVerificationCode").GetComponent<Button>();

            _btnGetVerificationCode.onClick.AddListener(ClickGetVerificationCode);
            _btnConfirm.onClick.AddListener(ClickConfirm);
            _btnClose.onClick.AddListener(ClickClose);
            setPanelActive(false);
        }

        private void ClickConfirm()
        {
             _currentpassword = _inputFieldCurrentPassword.text;
             _newpassword = _inputFieldNewPassword.text;
             _verificationcode = _inputFieldVerification.text;
            Dictionary<string,string> msg = new Dictionary<string, string>()
            {
                ["oldpw"]=_currentpassword,
                ["newpw"] = _newpassword,
                ["code"]=_verificationcode,
            };
            Dispatch(AreaCode.NET, EventType.expw, msg); 
        }

        private void ClickClose()
        {
            setPanelActive(false);
        }

        private void ClickGetVerificationCode()
        {
            Dispatch(AreaCode.NET,EventType.identy,null);
        }
        // Update is called once per frame
        void Update()
        {
            //if (_inputFieldCurrentPassword.text == null || _inputFieldNewPassword.text == null ||
            //    _inputFieldVerification.text == null)
            //{
            //    _btnConfirm.gameObject.SetActive(false);
            //}
            //else
            //{
            //    _btnConfirm.gameObject.SetActive(true);
            //}
        }
    }
}
