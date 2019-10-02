
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/16 17:28:57
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MeunUI
{
    /// <summary>
    /// 设置交易码
    /// </summary>
    public class SetExPwPanel : UIBase
    {

        private Button BtnDetermine;           //确定按钮
        private Button BtnCancel;              //取消按钮
        private InputField inputTransaction;   //输入的交易密码
        private string inputInfo;              //输入信息
        private Text Title;                    //标题
        private void Awake()
        {
            Bind(UIEvent.SETTRANSACT_ACTIVE);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.SETTRANSACT_ACTIVE:
                    setPanelActive((bool)message);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 多语言
        /// </summary>
        /// <param name="language"></param>
        private void Multilingual(string language)
        {
            BtnDetermine.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu" + language + "/ConfirmBig");
            BtnCancel.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/menu" + language + "/CancelBig");
            Title.text = "";
        }
        void Start()
        {
            BtnDetermine = transform.Find("bg/BtnCommit").GetComponent<Button>();
            BtnCancel = transform.Find("bg/BtnCancle").GetComponent<Button>();
            inputTransaction = transform.Find("bg/InputExPw").GetComponent<InputField>();
            Title = transform.Find("bg/Title").GetComponent<Text>();
            setPanelActive(false);
            BtnDetermine.onClick.AddListener(clickDetermine);
            BtnCancel.onClick.AddListener(clickCancel);
        }
        private void Update()
        {
            inputTransaction.text = inputInfo;
        }
        /// <summary>
        /// 确定事件
        /// </summary>
        private void clickDetermine()
        {
            //判断交易码输入是不是正确且不为空
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        private void clickCancel()
        {
            setPanelActive(false);
        }
    }
}
