using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Framework;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Msg;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/***
* Title:     
*
* Created:	zp
*
* CreatTime:          2019/10/02 10:13:39
*
* Description:
*
* Version:    0.1
*
*
***/
public class SaveImage :UIBase ,IPointerClickHandler , IPointerExitHandler, IPointerDownHandler
{
public UnityEvent onLongPress = new UnityEvent();
private float holdTime = 2f;
  private HintMsg promptMsg = new HintMsg();
   public void OnPointerClick(PointerEventData eventData)
{
    //print("I was clicked:" + eventData.pointerCurrentRaycast.gameObject.name);
}
 
public void OnPointerExit(PointerEventData eventData)
{
    CancelInvoke("OnLongPress");
}
 
public void OnPointerDown(PointerEventData eventData)
{
    // this.position = eventData.position;
    // menu.pivot = new Vector2(eventData.position.x/Screen.width, eventData.position.y/Screen.height);
    // menu.gameObject.SetActive(false);
    Invoke("OnLongPress", holdTime);
}

 private void OnLongPress()
{
    Debug.Log("Haha");
    SaveImages(GetComponent<RawImage>().texture as Texture2D);
    //弹出保存成功提示
    promptMsg.Change("保存成功", Color.white);
    Dispatch( AreaCode.UI, UIEvent.HINT_ACTIVE, promptMsg);
    gameObject.SetActive(false);
    transform.parent.gameObject.SetActive(false);
}
public void OnPointerUp(PointerEventData eventData)
{
    CancelInvoke("OnLongPress");
}

    byte[] byteImage;
    //    /// <summary>
    //    /// 保存Png图片
    //    /// </summary>
    //    /// <param name="texture"></param>
    //    /// <returns></returns>
    IEnumerator SaveImages(Texture2D texture)
    {
        string path = Application.persistentDataPath;
        //#if UNITY_ANDROID
        //        path = "/storage/emulated/0/DCIM/DreamCity"; //设置图片保存到设备的目.
        //#endif
        //        if (!Directory.Exists(path)) 
        //            Directory.CreateDirectory(path);


        byteImage = texture.EncodeToPNG();
        string savePath = string.Format("{0}/{1}.png", path, "dreamCode");
        File.WriteAllBytes(savePath, byteImage);
        savePngAndUpdate(path);
        yield return new WaitForEndOfFrame();
    }
    public void savePngAndUpdate(string path)
    {
#if UNITY_IOS

#elif UNITY_ANDROID
        //GetAndroidJavaObject().Call("saveImage", fileName, byteImage);
        GetAndroidJavaObject().Call("testCallAndroid");
        GetAndroidJavaObject().Call("requestExternalStorage");
        GetAndroidJavaObject().Call("saveImageToGallery", path, "保存成功");

        Debug.Log(path);
#endif
    }
#if UNITY_ANDROID
    public AndroidJavaObject GetAndroidJavaObject()
    {
        return new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    }

    
#endif

}
