using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Settings : UI_Popup
{
    enum Buttons
    { 
        CloseButton,
    }

    enum GameObjects
    {
        Toggle1,
        Toggle2,
        //Toggle3,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        Toggle t1 = GetObject((int)GameObjects.Toggle1).GetComponent<Toggle>();
        Toggle t2 = GetObject((int)GameObjects.Toggle2).GetComponent<Toggle>();
        //Toggle t3 = GetObject((int)GameObjects.Toggle3).GetComponent<Toggle>();
        t1.isOn = Managers.Firebase.ReceiveMessage;
        t2.isOn = Managers.Sound.BgmVolume > 0.5;
        //t3.isOn = Managers.Sound.EffectVolume > 0.5;

        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnCloseButton);
        GetObject((int)GameObjects.Toggle1).BindEvent(OnToggle1);
        GetObject((int)GameObjects.Toggle2).BindEvent(OnToggle2);
        //GetObject((int)GameObjects.Toggle3).BindEvent(OnToggle3);
    }

    public void OnCloseButton(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
    }

    public void OnToggle1(PointerEventData data)
    {
        Toggle t = GetObject((int)GameObjects.Toggle1).GetComponent<Toggle>();
        if (t.isOn)
        {
            Managers.Firebase.ReceiveMessage = true;
            Managers.UI.ShowPopupUI<UI_NotificationConsentResult>();
        }
        else
        {
            Managers.Firebase.ReceiveMessage = false;
            Managers.UI.ShowPopupUI<UI_NotificationRejectionResult>();
        }
    }

    public void OnToggle2(PointerEventData data)
    {
        Toggle t = GetObject((int)GameObjects.Toggle2).GetComponent<Toggle>();
        if (t.isOn)
            Managers.Sound.BgmVolume = 1.0f;
        else
            Managers.Sound.BgmVolume = 0.0f;
    }

    //public void OnToggle3(PointerEventData data)
    //{
    //    Toggle t = GetObject((int)GameObjects.Toggle3).GetComponent<Toggle>();
    //    if (t.isOn)
    //        Managers.Sound.EffectVolume = 1.0f;
    //    else
    //        Managers.Sound.EffectVolume = 0.0f;
    //}
}
