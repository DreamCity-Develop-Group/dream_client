using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
public class SelectInvestPanel : UIBase
{
    Transform transformStore;
    private ScrollRect m_SR;
    Image storeImage;
    Text storeNameText;
    Button btnStore;
    Transform quest;

    

    List<string> storeIdList= new List<string>{"1","2"};
    List<string> unlockStoreList = new List<string>();
    private void Awake()
    {
        Bind(UIEvent.SELECTINVEST_PANEL_ACTIVE,UIEvent.SELECCTINVEST_PANEL_VIEW);
    }

    public override void Execute(int eventCode, object message)
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
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transformStore = transform.Find("ViewPoint/InvestStore");
        m_SR = transform.GetComponent<ScrollRect>();
        //监听值改变事件
        m_SR.onValueChanged.AddListener(ScrollRectChange);

        quest = transform.Find("ViewPoint/InvestStore/Quest");

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
                    GameObject slectUIstore = Instantiate(Resources.Load("Prefabs/SelctStorePrefab")) as GameObject;
                    //Instantiate(slectUIstore);
                    slectUIstore.transform.SetParent(this.transform.Find("ViewPoint/InvestStore"));
                    btnStore = slectUIstore.GetComponent<Button>();
                    storeImage =slectUIstore.transform.Find("Image").GetComponent<Image>();
                    storeNameText = slectUIstore.transform.Find("Text").GetComponent<Text>();
                    storeImage.sprite = Resources.Load("UI/investImg/" + item.投资名称+ "小@2x",typeof (Sprite)) as Sprite;
                    btnStore.onClick.AddListener(()=>
                    {
                      
                        Dispatch(AreaCode.UI, UIEvent.IVEST_PANEL_ACTIVE, true);
                       // Dispatch(AreaCode.UI, UIEvent.IVEST_PANEL_ACTIVE, item.id);
                        setPanelActive(false);
                        MenuInvestPanelManager.Instance.SceneInvestOnclick(item.id);

                    });
                    storeNameText.text = item.投资名称;
                    break;
                }
            }
        }
        quest.transform.SetAsLastSibling();
       // m_SR.content.localPosition = Vector2.zero;
    }

    void UnSockStore()
    {
        foreach (var item2 in unlockStoreList)
        {
            foreach (var item in MenuInvestPanelManager.Instance.listStores)
            {
                if (item2.Equals(item.id))
                {
                    //
                    GameObject slectUIstore = Instantiate(Resources.Load("Prefabs/SelctStorePrefab")) as GameObject;
                    //Instantiate(slectUIstore);
                    slectUIstore.transform.SetParent(this.transform.Find("ViewPoint/InvestStore"));
                    btnStore = slectUIstore.GetComponent<Button>();
                    storeImage = slectUIstore.transform.Find("Image").GetComponent<Image>();
                    storeNameText = slectUIstore.transform.Find("Text").GetComponent<Text>();
                    storeImage.sprite = Resources.Load("UI/investImg/" + item.投资名称 + "小@2x", typeof(Sprite)) as Sprite;
                    btnStore.onClick.AddListener(() =>
                    {
                        setPanelActive(false);
                        MenuInvestPanelManager.Instance.SceneInvestOnclick(item.id);
                        Dispatch(AreaCode.UI, UIEvent.IVEST_PANEL_ACTIVE, true);
                    });
                    storeNameText.text = item.投资名称;
                    break;
                }
            }
        }
        quest.transform.SetAsLastSibling();
        //m_SR.content.localPosition = Vector2.zero;
    }
    private void ScrollRectChange(Vector2 T)
    {
        m_SR.horizontalScrollbar.value = T.x;
    }
}
