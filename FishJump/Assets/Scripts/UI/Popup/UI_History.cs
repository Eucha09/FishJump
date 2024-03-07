using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_History : UI_Popup
{
    enum Texts
    {
        HighScore,
        TodayHighScore,
    }

    enum Buttons
    {
        CloseButton,
        EventAuthButton1,
        EventAuthButton2,
    }

    int _eventScore1 = 5;
    int _eventScore2 = 10;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetText((int)Texts.HighScore).text = Managers.Game.HighScore.ToString();
        GetText((int)Texts.TodayHighScore).text = Managers.Game.TodayHighScore.ToString();
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnCloseButton);
        GetButton((int)Buttons.EventAuthButton1).gameObject.BindEvent(OnEventAuthButton1);
        GetButton((int)Buttons.EventAuthButton2).gameObject.BindEvent(OnEventAuthButton2);
    }

    void Update()
    {
        if (Managers.Game.AuthCompleted1 == 1)
        {
            GetButton((int)Buttons.EventAuthButton1).interactable = false;
            GetButton((int)Buttons.EventAuthButton1).GetComponentInChildren<Text>().text = "완료";
        }
        else
        {
            GetButton((int)Buttons.EventAuthButton1).interactable = Managers.Game.TodayHighScore >= _eventScore1;
            GetButton((int)Buttons.EventAuthButton1).GetComponentInChildren<Text>().text = "인증";
        }

        if (Managers.Game.AuthCompleted2 == 1)
        {
            GetButton((int)Buttons.EventAuthButton2).interactable = false;
            GetButton((int)Buttons.EventAuthButton2).GetComponentInChildren<Text>().text = "완료";
        }
        else
        {
            GetButton((int)Buttons.EventAuthButton2).interactable = Managers.Game.TodayHighScore >= _eventScore2;
            GetButton((int)Buttons.EventAuthButton2).GetComponentInChildren<Text>().text = "인증";
        }
    }

    public void OnCloseButton(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
    }

    public void OnEventAuthButton1(PointerEventData data)
    {
        if (GetButton((int)Buttons.EventAuthButton1).interactable)
        {
            UI_StaffOnly ui = Managers.UI.ShowPopupUI<UI_StaffOnly>();
            ui.AuthNumber = 1;
        }
    }

    public void OnEventAuthButton2(PointerEventData data)
    {
        if (GetButton((int)Buttons.EventAuthButton2).interactable)
        {
            UI_StaffOnly ui = Managers.UI.ShowPopupUI<UI_StaffOnly>();
            ui.AuthNumber = 2;
        }
    }
}
