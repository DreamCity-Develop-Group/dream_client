using Assets.Scripts.Framework;
using Assets.Scripts.Net.Handler;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace Assets.Scripts.Net.Handler
{
    public class CommerceHander : HandlerBase
    {

        List<CommerceInfo> _commerceData = new List<CommerceInfo>();


        public override bool OnReceive(int subCode, object value)
        {
            switch (subCode)
            {
                case EventType.commerce_member:
                    //diFriendData = value as Dictionary<string, UserInfo>;
                    dicComerceDataRespon();
                    break;
                case EventType.commerce_sendmt:
                    ComerceMtBuyRespon();
                    break;
                case EventType.commerce_in:
                    ComerceComeInRespon();
                    break;
                default:
                    break;
            }
            return false;
        }

       // private HintMsg promptMsg = new HintMsg();

        /// <summary>
        ///商会数据
        /// </summary>
        private void dicComerceDataRespon()
        {
            if (_commerceData.Count < 1)
            {
                Debug.LogError("_commerceData is null");
                return;
            }
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_VIEW, _commerceData);

        }
        /// <summary>
        /// Mt购买
        /// </summary>
        private void ComerceMtBuyRespon()
        {
            if (_commerceData.Count < 1)
            {
                Debug.LogError("_commerceData is null");
                return;
            }
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_VIEW, _commerceData);

        }

        /// <summary>
        /// 商会加入
        /// </summary>
        private void ComerceComeInRespon()
        {
            if (_commerceData.Count < 1)
            {
                Debug.LogError("_commerceData is null");
                return;
            }
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_VIEW, _commerceData);

        }

        /// <summary>
        /// 兑换中心
        /// </summary>
        private void ComerceexchangeRespon()
        {
            if (_commerceData.Count < 1)
            {
                Debug.LogError("_commerceData is null");
                return;
            }
            Dispatch(AreaCode.UI, UIEvent.SQUARE_LIST_PANEL_VIEW, _commerceData);

        }
    }
}
