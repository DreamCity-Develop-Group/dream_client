using Language;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
/***
* Title:     
*
* Created:	zp
*
* CreatTime:          2019/09/24 20:28:00
*
* Description:投资界面
*
* Version:    0.1
*
*
***/
public class MenuInvestPanelManager : UIBase
{
    Button btnOrder;
    Text storeName;
    Text incomeUSDT;
    Text quotaTax;
    Text proIncome;
    Text investUSDT;
    Button btnClose;

    Image imageStoreMenu;
    /// <summary>
    /// 初始化数据
    /// </summary>
    public List<StoreInfo> listStores;
    Dictionary<string, StoreInfo> dicStores =new Dictionary<string, StoreInfo>();
    Queue<GameObject> CacheQueueStores = new Queue<GameObject>();
    Queue<GameObject> QueueStores = new Queue<GameObject>();
    StoreInfo storeInfo;
    public static MenuInvestPanelManager Instance =null;

    private void Awake()
    {
        Instance = this;
        Bind(UIEvent.IVEST_PANEL_ACTIVE);
        Init();
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.IVEST_PANEL_ACTIVE:
                MenuInfo menuInfo = message as MenuInfo;
                //InitStore(null);
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    private void Start()
    {
        btnOrder = transform.Find("StorePrefab/StoreImage/BtnOrder").GetComponent<Button>();
        storeName = transform.Find("StorePrefab/StoreInfoPanel/StoreName").GetComponent<Text>();
        incomeUSDT = transform.Find("StorePrefab/StoreInfoPanel/HeadIncomeUSDT/IncomeUSDT").GetComponent<Text>();
        quotaTax = transform.Find("StorePrefab/StoreInfoPanel/HeadQuotaTax/QuotaTax").GetComponent<Text>(); 
        proIncome = transform.Find("StorePrefab/StoreInfoPanel/HeadProIncome/ProIncome").GetComponent<Text>(); 
        investUSDT = transform.Find("StorePrefab/StoreInfoPanel/HeadInvestUSDT/InvestUSDT").GetComponent<Text>();
        imageStoreMenu = transform.Find("StorePrefab/StoreImage").GetComponent<Image>();
        btnClose = transform.Find("StorePrefab/BtnClose").GetComponent<Button>();
        Debug.Log(btnClose);
        btnClose.onClick.AddListener(clickClose);
        btnOrder.onClick.AddListener(clickOrder);
        setPanelActive(false);
    }

    private void Update()
    {
       
    }
    /// <summary>
    /// 初始化
    /// </summary>

    private void Init()
    {
        //test
        // string language = PlayerPrefs.GetString("language");
        string language = "Chinese";
        //加载json文件
        var path = "/Resources/" + "Localization/" + language + "/" + "Scene" + "/"+ "InvestStore.json";
        StreamReader streamReader = new StreamReader(Application.dataPath + path);
        string resources = streamReader.ReadToEnd();
        listStores = JsonMapper.ToObject<List<StoreInfo>>(resources);


        GameObject UIstore = Resources.Load("Prefabs/StorePrefab") as GameObject;

        //可优化部分
        foreach (var item in listStores)
        {
            dicStores.Add(item.id, item);
        }
      //  initStore();
      
    }
    /// <summary>
    /// 产生store
    /// </summary>
    private  void initStore()
    {
        GameObject UIstore = Instantiate(Resources.Load("Prefabs/StorePrefab")) as GameObject;
        //Instantiate(UIstore);
        UIstore.transform.SetParent(this.transform);
        UIstore.SetActive(true);
        CacheQueueStores.Enqueue(UIstore);
    }
    GameObject gameobject;
    /// <summary>
    /// 场景点击投资弹框
    /// </summary>
    public void SceneInvestOnclick(string id)
    {
        //if (CacheQueueStores.Count > 0)
        //{
        //    gameobject = CacheQueueStores.Dequeue();
        //   // QueueStores.Enqueue(gameobject);
        //}
        //else
        //{
        //    initStore();
        //}
       
     
        //btnOrder = gameobject.transform.Find("StoreImage/BtnOrder").GetComponent<Button>();
        //storeName = gameobject.transform.Find("StoreInfoPanel/StoreName").GetComponent<Text>();
        //incomeUSDT = gameobject.transform.Find("StoreInfoPanel/HeadIncomeUSDT/IncomeUSDT").GetComponent<Text>();
        //quotaTax = gameobject.transform.Find("StoreInfoPanel/HeadQuotaTax/QuotaTax").GetComponent<Text>();
        //proIncome = gameobject.transform.Find("StoreInfoPanel/HeadProIncome/ProIncome").GetComponent<Text>();
        //investUSDT = gameobject.transform.Find("StoreInfoPanel/HeadInvestUSDT/InvestUSDT").GetComponent<Text>();
        //btnOrder.onClick.AddListener(clickOrder);
        //null 条件
        storeInfo = dicStores[id];
        //图片地址todo
        Debug.Log(storeInfo.投资名称);
        Debug.Log(imageStoreMenu);
        imageStoreMenu.sprite = Resources.Load("UI/investImg/" + storeInfo.投资名称 + "大@2x",typeof(Sprite)) as Sprite;
        storeName.text = storeInfo.投资名称;
        quotaTax.text = storeInfo.税收;
        proIncome.text = storeInfo.预计收益;
        investUSDT.text = storeInfo.投资金额;
        //gameobject.SetActive(false);
    }

    private void clickClose()
    {
        setPanelActive(false);
        //CacheQueueStores.Enqueue(gameobject);
    }
    private void clickOrder()
    {
        //todo投资
    }

    
    
}
