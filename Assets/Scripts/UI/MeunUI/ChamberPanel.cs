/***
  * Title:     
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/20 11:16:17
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 商会面板
/// </summary>
public class ChamberPanel : UIBase
{
    private Button ClosePanel;           //关闭商会面板
    private void Awake()
    {
        Bind(UIEvent.COMMERCE_PANEL_ACTIVE);
        Bind(UIEvent.COMMERCE_NOJIONPANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            //如果没有加入商会
            //case UIEvent.COMMERCE_NOJIONPANEL_ACTIVE:
            //    setPanelActive((bool)message);
            //加入商会
            case UIEvent.COMMERCE_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
                
            default:
                break;
        }
    }
   
    void Start()
    {
        ClosePanel = transform.Find("Chamber/BtnClose").GetComponent<Button>();
        ClosePanel.onClick.AddListener(OnclikPanel);
        setPanelActive(false);
    }
    private void OnclikPanel()
    {
        Dispatch(AreaCode.UI, UIEvent.COMMERCE_PANEL_ACTIVE, false);
        setPanelActive(false);
    }
}
