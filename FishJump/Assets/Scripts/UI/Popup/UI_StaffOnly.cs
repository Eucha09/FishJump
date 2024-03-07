using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_StaffOnly : UI_Popup
{
    enum Buttons
    {
        CloseButton,
        NoButton,
        YesButton,
    }

    public int AuthNumber { get; set; }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnCloseButton);
        GetButton((int)Buttons.NoButton).gameObject.BindEvent(OnCloseButton);
        GetButton((int)Buttons.YesButton).gameObject.BindEvent(OnYesButton);
    }

    public void OnCloseButton(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
    }

    public void OnYesButton(PointerEventData data)
    {
        if (AuthNumber == 1)
            Managers.Game.AuthCompleted1 = 1;
        if (AuthNumber == 2)
            Managers.Game.AuthCompleted2 = 1;
        Managers.UI.ClosePopupUI();
    }
}
