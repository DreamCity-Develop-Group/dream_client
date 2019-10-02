using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Model;
using Assets.Scripts.Net;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/25 16:19:32
  *
  * Description: 投资选择界面
  *
  * Version:    0.1
  *
  *
***/
namespace Assets.Scripts.UI
{
    public class SelectInvestPanel : UIBase
    {
        Transform transformStore;
        private ScrollRect m_SR;
        Image storeImage;
        Text storeNameText;
        /// <summary>
        /// 
        /// </summary>
        Button btnStore;
        /// <summary>
        /// 预约
        /// </summary>
        private Button btnInvest;
        /// <summary>
        /// 预约灰色
        /// </summary>
        private Image imgInvested;
        /// <summary>
        /// 预约中
        /// </summary>
        private Image imgInvesting;
        /// <summary>
        /// 经营中
        /// </summary>
        private Image imgInvestManaging;
        /// <summary>
        /// 可提取
        /// </summary>
        private Image imgInvestExtractable;

        private Button btnClose;
        Transform quest;
        /// <summary>
        /// 滑动框的宽高
        /// </summary>
        private float width;
        private float height;

        List<string> storeIdList= new List<string>{"1","2"};
        List<string> unlockStoreList = new List<string>();
        List<InvestInfo> investInfoList = new List<InvestInfo>();

        Dictionary<string,GameObject> CacheInvest = new Dictionary<string, GameObject>();
        private void Awake()
        {
            Bind(UIEvent.SELECTINVEST_PANEL_ACTIVE,UIEvent.SELECCTINVEST_PANEL_VIEW);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.SELECTINVEST_PANEL_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                case UIEvent.SELECCTINVEST_PANEL_VIEW:
                    unlockStoreList = message as List<string>;
                    UnSockStore();
                    break;
                case UIEvent.INVESTED_REPLY_VIEW:

                    break;
                case UIEvent.INVESTING_REPLY_VIEW:

                    break;
                default:
                    break;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            transformStore = transform.Find("ViewPoint/InvestStore");
           // InVestStore = transformStore.GetComponent<RectTransform>();
            m_SR = transform.GetComponent<ScrollRect>();
            //监听值改变事件
            m_SR.onValueChanged.AddListener(ScrollRectChange);
            height = transformStore.GetComponent<RectTransform>().rect.height;
            quest = transform.Find("ViewPoint/InvestStore/Quest");
            btnClose = transform.Find("BtnClose").GetComponent<Button>();
            btnClose.onClick.AddListener(() =>
            {
                setPanelActive(false);
            });
            // setPanelActive(false);
            Init();
        }

        public void Test()
        {
            unlockStoreList = new List<string> { "3", "4" };
            UnSockStore();
        }
        void Init()
        {
            foreach (var item2 in storeIdList)
            {
                foreach (var item in MenuInvestPanelManager.Instance.listStores)
                {
                    if (item2.Equals(item.id))
                    {
                        //
                        GameObject slectUIstore = Instantiate(Resources.Load<GameObject>("Prefabs/SelectStorePrefab"), transformStore);
                        //Instantiate(slectUIstore);
                        if (slectUIstore != null)
                        {
                             
                            //slectUIstore.transform.SetParent(transformStore);
                            storeImage = slectUIstore.transform.Find("Image").GetComponent<Image>();
                            btnStore = storeImage.GetComponent<Button>();
                            storeNameText = slectUIstore.transform.Find("Text").GetComponent<Text>();
                            btnInvest = slectUIstore.transform.Find("BtnInvest").GetComponent<Button>();
                        }

                       
                        storeImage.sprite = Resources.Load("UI/investImg/" + item.投资名称+ "小@2x",typeof (Sprite)) as Sprite;
                        btnStore.onClick.AddListener(()=>
                        {
                      
                            Dispatch(AreaCode.UI, UIEvent.IVEST_PANEL_ACTIVE, true);
                            // 
                            setPanelActive(false);
                            MenuInvestPanelManager.Instance.SceneInvestOnclick(item.id);

                        });
                        btnInvest.onClick.AddListener(() =>
                        {
                            Dispatch(AreaCode.NET, ReqEventType.invest_req, item.id);
                            CacheInvest.Add(item.id,slectUIstore);
                            btnInvest.gameObject.SetActive(false);
                        });

                        storeNameText.text = item.投资名称;
                        break;
                    }
                }
            }
            quest.transform.SetAsLastSibling();
            // m_SR.content.localPosition = Vector2.zero;
        }
        /// <summary>
        /// 解锁新可投资项目
        /// </summary>
        void UnSockStore()
        {
            foreach (var item2 in unlockStoreList)
            {
                foreach (var item in MenuInvestPanelManager.Instance.listStores)
                {
                    if (item2.Equals(item.id))
                    {
                        //
                        GameObject slectUIstore = Instantiate(Resources.Load<GameObject>("Prefabs/SelectStorePrefab"), transformStore);
                        //Instantiate(slectUIstore);
                        if (slectUIstore != null)
                        {
                            width = transformStore.GetComponent<RectTransform>().rect.width;
                            transformStore.GetComponent<RectTransform>().sizeDelta=new Vector2(width + 365,height);
                            //transformStore.GetComponent<RectTransform>().offsetMax.Set(width + 365,height);
                            btnStore = slectUIstore.GetComponent<Button>();
                            storeImage = slectUIstore.transform.Find("Image").GetComponent<Image>();
                            storeNameText = slectUIstore.transform.Find("Text").GetComponent<Text>();
                            btnInvest = slectUIstore.transform.Find("BtnInvest").GetComponent<Button>();
                        }

                        storeImage.sprite = Resources.Load("UI/investImg/" + item.投资名称 + "小@2x", typeof(Sprite)) as Sprite;
                        btnStore.onClick.AddListener(() =>
                        {
                            setPanelActive(false);
                            MenuInvestPanelManager.Instance.SceneInvestOnclick(item.id);
                           
                            Dispatch(AreaCode.UI, UIEvent.IVEST_PANEL_ACTIVE, true);
                        });
                        btnInvest.onClick.AddListener(() =>
                        {
                            Dispatch(AreaCode.NET, ReqEventType.invest_req, item.id);
                            btnInvest.gameObject.SetActive(false);
                            setPanelActive(false);
                        });
                        //btnStore Dispatch(AreaCode.NET, ReqEventType.invest_req, item.id);
                        storeNameText.text = item.投资名称;
                        break;
                    }
                }
            }
            quest.transform.SetAsLastSibling();
            //m_SR.content.localPosition = Vector2.zero;
        }

        void UpdataState()
        {
            foreach (var itemInfo in investInfoList)
            {
                switch (itemInfo.state)
                {
                    case InvestState.Ording:
                        break;
                    case InvestState.Managing:
                        break;
                    case InvestState.Extractable:
                        break;
                }
                
            }
        }
        private void ScrollRectChange(Vector2 T)
        {
            m_SR.horizontalScrollbar.value = T.x;
        }
    }
}
