
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/16 11:28:49
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

public class SecurityPanel : UIBase
{

    private void Awake()
    {
        Bind(UIEvent.VOICE_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.VOICE_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }

    Button btnLike;

    // Start is called before the first frame update
    void Start()
    {
        btnLike = transform.Find("BtnLike").GetComponent<Button>();
        btnLike.onClick.AddListener(clickLike);
    }

    private void clickLike()
    {
        btnLike.gameObject.SetActive(false);
        Dispatch(AreaCode.NET, EventType.likefriend, null);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
