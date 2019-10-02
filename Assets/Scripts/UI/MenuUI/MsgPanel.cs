
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/11 11:22:14
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/

using Assets.Scripts.Model;
using Boo.Lang;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MeunUI
{
    /// <summary>
    /// 邮件信息
    /// </summary>
    public class MsgPanel : UIBase
    {
        private Image BG;                          //邮件背景框
        private string language;                   //语言版本
        private GameObject MaliBox;                //邮件框
        private Transform content;                 //邮件父物体
        Button btnClose;        
        private List<MessageInfo> msgInfos;
        private void Awake()
        {
            Bind(UIEvent.MSG_PANEL_ACTIVE,UIEvent.MESSAGE_PANEL_VIEW);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.MSG_PANEL_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                case UIEvent.MESSAGE_PANEL_VIEW:
                    msgInfos = message as List<MessageInfo>;
                    if(msgInfos.Count>0)
                    {
                        for (int i = 0; i < msgInfos.Count; i++)
                        {
                            GameObject obj = null;
                            obj = CreatePreObj(MaliBox, content);
                            obj.transform.Find("MailTitle").GetComponent<Text>().text = msgInfos[i].title;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            btnClose.onClick.RemoveAllListeners();
        }
        void Start()
        {
            MaliBox = Resources.Load("Malie/MailBox") as GameObject;
            content = transform.Find("bg/Emali/Viewport/Content");
            btnClose = transform.Find("bg/BtnClose").GetComponent<Button>();
            btnClose.onClick.AddListener(clickClose);
            setPanelActive(false);
        }
        private void clickClose()
        {
            setPanelActive(false);
        }
        private void Multilingual()
        {
            BG = transform.Find("bg").GetComponent<Image>();
            BG.sprite = Resources.Load<Sprite>("UI/menu" + language + "/MailFrame");
        }
        private System.Collections.Generic.Queue<GameObject> m_queue_gPreObj = new System.Collections.Generic.Queue<GameObject>();          //对象池
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
    }
}
