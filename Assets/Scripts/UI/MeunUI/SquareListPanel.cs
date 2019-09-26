
/***
  * Title:    SquareListPanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/17 09:45:07
  *
  * Description: 广场列表界面
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareListPanel : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.SQUARE_LIST_PANEL_ACTIVE, UIEvent.SQUARE_LIST_PANEL_VIEW);
    }
    /// <summary>
    /// 广场用户数据
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    List<UserInfos> squareData;//= new List<UserInfos>();
    private GameObject PersonalInformationBox;           //列表信息框预制体
    private Transform ListBox;                           //列表框
    private List<GameObject> list_InformationBox = new List<GameObject>();
    private Button InABatchBtn;                          //换一批按钮

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.SQUARE_LIST_PANEL_ACTIVE:
                setPanelActive((bool)message);
                if ((bool)message == false)
                {
                    for (int i = 0; i < list_InformationBox.Count; i++)
                    {
                        RePreObj(list_InformationBox[i]);
                    }
                    list_InformationBox.Clear();
                }
                break;
            case UIEvent.SQUARE_LIST_PANEL_VIEW:
                squareData = message as List<UserInfos>;
                if (squareData.Count > 0)
                {
                    GameObject obj = null;
                    for (int i = 0; i < squareData.Count; i++)
                    {
                        obj = CreatePreObj(PersonalInformationBox, ListBox);
                    obj.transform.SetParent(ListBox);
                    obj.SetActive(true);
                        list_InformationBox.Add(obj);
                        //obj里可以查找显示信息的物体，然后在赋值
                    }
                }
                //TODO
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PersonalInformationBox = Resources.Load("PerFab/SquareFriend") as GameObject;
        ListBox = transform.Find("SquareFriendsList/Viewport/Content");
        InABatchBtn = transform.Find("BtnNextGround").GetComponent<Button>();
        InABatchBtn.onClick.AddListener(clickInABatch);
        setPanelActive(false);
    }

    private Queue<GameObject> m_queue_gPreObj = new Queue<GameObject>();          //对象池
    private Transform TempTrans;
    /// <summary>
    /// 创建预制体
    /// </summary>
    /// <param name="Prefab">预制体</param>
    /// <param name="m_transPerfab">预制体父物体的transform</param>
    /// <returns></returns>
    public GameObject CreatePreObj(GameObject Prefab, Transform m_transPerfab)
    {
        GameObject obj = null;
        if (m_queue_gPreObj.Count > 0)
        {
            obj = m_queue_gPreObj.Dequeue();
        }
        else
        {
            Transform trans = null;
            trans = GameObject.Instantiate(Prefab, m_transPerfab).transform;
            //trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
            obj = trans.gameObject;
            obj.SetActive(false);
        }
        return obj;
    }
    /// <summary>
    /// 预制体回收
    /// </summary>
    /// <param name="obj">回收的预制体</param>
    private void RePreObj(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
            obj.transform.SetParent(TempTrans);
            m_queue_gPreObj.Enqueue(obj);
        }
    }
    /// <summary>
    /// 换一批
    /// </summary>
    private void clickInABatch()
    {

    }
}
