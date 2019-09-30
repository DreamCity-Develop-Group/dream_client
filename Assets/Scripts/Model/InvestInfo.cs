using System.Collections.Generic;
// ReSharper disable InconsistentNaming

/***
  * Title:     
  *
  * Created:	zp
  *
  * CreatTime:          2019/09/21 14:44:23
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/
namespace Assets.Scripts.Model
{
    public class InvestInfo 
    {
        /// <summary>
        /// 投资项目id
        /// </summary>
        public string inId { get; set; }
        /// <summary>
        /// 可提取usdt
        /// </summary>
        public string extractable { get; set; }
        /// <summary>
        /// 收益usdt
        /// </summary>
        public string income { get; set; }
        /// <summary>
        /// 投资状态
        /// </summary>
        public int state { get; set; }

    }

}

