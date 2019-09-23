
/***
  * Title:    SquareListPanel 
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/17 09:45:07
  *
  * Description: �㳡�б����
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
    /// �㳡�û�����
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    List<UserInfo> dicSquareData = new List<UserInfo>();
    private GameObject PersonalInformationBox;           //�б���Ϣ��Ԥ����
    private Transform ListBox;                           //�б��
    private List<GameObject> list_InformationBox = new List<GameObject>();
    private Button InABatchBtn;                          //��һ����ť

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
                dicSquareData = message as List<UserInfo>;
                if (dicSquareData.Count > 0)
                {
                    GameObject obj = null;
                    for (int i = 0; i < dicSquareData.Count; i++)
                    {
                        obj = CreatePreObj(PersonalInformationBox, ListBox);
                    obj.transform.SetParent(ListBox);
                    obj.SetActive(true);
                        list_InformationBox.Add(obj);
                        //obj����Բ�����ʾ��Ϣ�����壬Ȼ���ڸ�ֵ
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

    private Queue<GameObject> m_queue_gPreObj = new Queue<GameObject>();          //�����
    private Transform TempTrans;
    /// <summary>
    /// ����Ԥ����
    /// </summary>
    /// <param name="Prefab">Ԥ����</param>
    /// <param name="m_transPerfab">Ԥ���常�����transform</param>
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
    /// Ԥ�������
    /// </summary>
    /// <param name="obj">���յ�Ԥ����</param>
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
    /// ��һ��
    /// </summary>
    private void clickInABatch()
    {

    }
}
