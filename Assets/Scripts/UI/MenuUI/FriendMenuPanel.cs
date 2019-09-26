
/***
  * Title:    FriendPanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/10 16:50:31
  *
  * Description: 好友界面
  *
  * Version:    0.1
  *
  *
***/

using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;
using EventType = Assets.Scripts.Net.EventType;

namespace Assets.Scripts.UI.MeunUI
{
    public class FriendMenuPanel : UIBase 
    {
        private GameObject FriendBtn;         //好友激活按钮
        private GameObject SquareBtn;         //广场激活按钮
        private GameObject AppyForBtn;        //申请激活按钮  
        private void Awake()
        {
            Bind(UIEvent.FRIENDMENU_PANEL_ACTIVE);
            FriendBtn = transform.Find("FriendActive").gameObject;
            SquareBtn = transform.Find("SquareActive").gameObject;
            AppyForBtn = transform.Find("ApplyForActive").gameObject;
            SquareBtn.SetActive(false);
            AppyForBtn.SetActive(false);
        }
        /// <summary>
        /// 用户名，个人信息
        /// str["123"].img
        /// </summary>
        /// <param name="eventCode"></param>
        /// <param name="message"></param>
//Dictionary<string ,UserInfo>()
        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.FRIENDMENU_PANEL_ACTIVE:
                    setPanelActive(true);
                    break;
                case UIEvent.FRIEND_LIST_PANEL_VIEW:
                    friendData = message as List<UserInfos>;
                    break;
                case UIEvent.SQUARE_LIST_PANEL_VIEW:
                    squareData = message as List<UserInfos>;
                    break;
                case UIEvent.APPLY_PANEL_VIEW:
                    applyData = message as List<UserInfos>;
                    break;
                default:
                    break;
            }
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        Button btnFriend;
        Button btnGround;
        Button btnSearch;
        Button btnApply;
        Button btnClose;
        InputField inputSearch;

        List<UserInfos> friendData;
        List<UserInfos> squareData;
        List<UserInfos> applyData;

        string nickName;
        Text textTitle;
        private void Start()
        {
            inputSearch = transform.Find("InputSearch").GetComponent<InputField>();
            btnFriend = transform.Find("BtnFriend").GetComponent<Button>();
            btnApply = transform.Find("BtnApply").GetComponent<Button>();
            btnGround = transform.Find("BtnGround").GetComponent<Button>(); 
            btnSearch = transform.Find("BtnSearch").GetComponent<Button>();
            btnClose = transform.Find("BtnClose").GetComponent<Button>();
            textTitle = transform.Find("TextTitle").GetComponent<Text>();

            btnFriend.onClick.AddListener(clickFriend);
            btnSearch.onClick.AddListener(clickSearch);
            btnApply.onClick.AddListener(clickApply);
            btnGround.onClick.AddListener(clickGround);
            btnClose.onClick.AddListener(clickClose);
            setPanelActive(false);
        }
        private void OnEnable()
        {
            if(FriendBtn.activeInHierarchy)
            {
                Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_ACTIVE, true);
                Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_VIEW, true);
            }
            else if(SquareBtn.activeInHierarchy)
            {
                Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_ACTIVE, true);
                Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_VIEW, true);
            }
            else if(AppyForBtn.activeInHierarchy)
            {
                Dispatch(AreaCode.UI, UIEvent.APPLYFOR_ACTIVE, true);
                Dispatch(AreaCode.UI, UIEvent.APPLYFOR_VIEW, true);
            }
        }
        private void clickClose()
        {
            setPanelActive(false);
            Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.APPLYFOR_ACTIVE, false);
        }
        private void clickGround()
        {
            textTitle.text = "广场";
            SquareBtn.SetActive(true);
            AppyForBtn.SetActive(false);
            FriendBtn.SetActive(false);
            Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_ACTIVE, true);
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_VIEW, true);
            Dispatch(AreaCode.UI, UIEvent.APPLYFOR_ACTIVE, false);
            //
        }
        private void clickFriend()
        {
            textTitle.text = "好友";
            SquareBtn.SetActive(false);
            AppyForBtn.SetActive(false);
            FriendBtn.SetActive(true);
            Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_ACTIVE, true);
            Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_VIEW, true);
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.APPLYFOR_ACTIVE, false); 
        }
        private void clickApply()
        {
            textTitle.text = "申请";
            SquareBtn.SetActive(false);
            AppyForBtn.SetActive(true);
            FriendBtn.SetActive(false);
            Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.APPLYFOR_ACTIVE, true);
            Dispatch(AreaCode.UI, UIEvent.APPLYFOR_VIEW, true);
        }
        private void clickSearch()
        {
            nickName = inputSearch.text;
            Dispatch(AreaCode.NET,EventType.searchfriend,nickName);
        }
    }
}
