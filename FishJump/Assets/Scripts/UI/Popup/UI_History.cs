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

    int _eventScore1 = 20;
    int _eventScore2 = 80;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetText((int)Texts.HighScore).text = Managers.Game.HighScore.ToString();
        GetText((int)Texts.TodayHighScore).text = Managers.Game.TodayHighScore.ToString();
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnCloseButton);
    }

    void Update()
    {
        GetButton((int)Buttons.EventAuthButton1).interactable = Managers.Game.TodayHighScore >= _eventScore1;
        GetButton((int)Buttons.EventAuthButton2).interactable = Managers.Game.TodayHighScore >= _eventScore2;
    }

    public void OnCloseButton(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
    }
}
