using Assets.Scripts.Framework;
using Assets.Scripts.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
#if PLATFORM_ANDROID

#endif

namespace Assets.Scripts
{
    public class PermissionsRationaleDialog : UIBase
    {
        const int kDialogWidth = 500;
        const int kDialogHeight = 200;
        private bool windowOpen = true;

        void DoMyWindow(int windowId)
        {
            GUI.Label(new Rect(10, 20, kDialogWidth - 20, kDialogHeight - 50), "Please let me use the Write.");
            if (GUI.Button(new Rect(10, kDialogHeight - 30, 100, 20), "No"))
            {
                windowOpen = false;
            }
            if (GUI.Button(new Rect(kDialogWidth - 110, kDialogHeight - 30, 100, 20), "Yes"))
            {
#if PLATFORM_ANDROID
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
#endif
                windowOpen = false;
                Dispatch(AreaCode.UI,UIEvent.LOGINSELECT_PANEL_ACTIVE,true);
            }
        }

        void OnGUI()
        {
            if (windowOpen)
            {
                Rect rect = new Rect((Screen.width / 2) - (kDialogWidth / 2), (Screen.height / 2) - (kDialogHeight / 2), kDialogWidth, kDialogHeight);
                GUI.ModalWindow(0, rect, DoMyWindow, "Permissions Request Dialog");
            }
        }

    }
}