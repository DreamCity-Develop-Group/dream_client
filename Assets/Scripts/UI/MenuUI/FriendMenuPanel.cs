
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
using Assets.Scripts.Net;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MeunUI
{
    public class FriendMenuPanel : UIBase 
    {
        private GameObject FriendBtn;         //好友激活按钮
        private GameObject SquareBtn;         //广场激活按钮
        private GameObject AppyForBtn;        //申请激活按钮  
    private Image FriendClick;            //好友点击按钮换图
    private Image SquareBtnClick;         //广场点击按钮换图
    private Image AppyForClick;           //申请点击按钮换图
    private Image SearchClick;            //搜索点击按钮换图
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
                    setPanelActive((bool)message);
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
        //动态加载图片
        //FriendClick = transform.Find("BtnFriend").GetComponent<Image>();
        //SquareBtnClick = transform.Find("BtnGround").GetComponent<Image>();
        //AppyForClick = transform.Find("BtnApply").GetComponent<Image>();
        //FriendBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/");
        //SquareBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/");
        //AppyForBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/");
        //FriendClick.sprite = Resources.Load<Sprite>("UI/");
        //AppyForClick.sprite = Resources.Load<Sprite>("UI/");
        //SquareBtnClick.sprite = Resources.Load<Sprite>("UI/");
        //SearchClick = transform.Find("BtnSearch").GetComponent<Image>();
        //SearchClick.sprite = Resources.Load<Sprite>("UI/");

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
            Dispatch(AreaCode.NET,ReqEventType.squarefriend,null);
            Dispatch(AreaCode.UI, UIEvent.FRIEND_LIST_PANEL_ACTIVE, false);
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_ACTIVE, true);
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
            Dispatch(AreaCode.NET,ReqEventType.applyfriend,null);
        }
        private void clickSearch()
        {
            nickName = inputSearch.text;
            Dispatch(AreaCode.NET,ReqEventType.searchfriend,nickName);
        }
    }
}
