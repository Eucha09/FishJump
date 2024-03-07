using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_AgreeReceiveNOtifications : UI_Popup
{
    enum Buttons
    {
        NoButton,
        YesButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.NoButton).gameObject.BindEvent(OnNoButton);
        GetButton((int)Buttons.YesButton).gameObject.BindEvent(OnYesButton);
    }

    public void OnYesButton(PointerEventData data)
    {
        Managers.Firebase.ReceiveMessage = true;
        
        Managers.UI.SwapPopupUI<UI_NotificationConsentResult>();

    }

    public void OnNoButton(PointerEventData data)
    {
        Managers.Firebase.ReceiveMessage = false;

        Managers.UI.SwapPopupUI<UI_NotificationRejectionResult>();
    }
}
