using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/23 09:08:12
  *
  * Description:主界面数据
  *
  * Version:    0.1
  *
  *
***/
    public class MenuInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Profile profile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool commerce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int messages { get; set; }
        /// <summary>
        /// mt usdt
        /// </summary>
        public MenuAccount account { get; set; }
        /// <summary>
        /// ֪ͨ
        /// </summary>
        public List<MenuNoticesItem> notices { get; set; }
    }
    public class Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int level { get; set; }
    }

    public class MenuAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public double mt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double usdt { get; set; }
    }

    public class MenuNoticesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int noticeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string noticeContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int noticeState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
    }

}