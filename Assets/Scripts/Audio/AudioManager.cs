
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:  2019/09/16 16:26:43
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


public class AudioManager : ManagerBase
{
    public static AudioManager Instance = null;

    void Awake()
    {
        Instance = this;
    }
}
