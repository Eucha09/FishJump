using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_TitleScene : UI_Scene
{
    enum Buttons
    {
        StartButton,
        HistoryButton,
        NewsButton,
        SettingsButton,
    }

    string _url = "https://www.instagram.com/sangango_official/";

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnStartButton);
        GetButton((int)Buttons.HistoryButton).gameObject.BindEvent(OnHistoryButton);
        GetButton((int)Buttons.NewsButton).gameObject.BindEvent(OnNewsButton);
        GetButton((int)Buttons.SettingsButton).gameObject.BindEvent(OnSettingsButton);
    }

    public void OnStartButton(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public void OnHistoryButton(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_History>();
    }

    public void OnNewsButton(PointerEventData data)
    {
        Application.OpenURL(_url);
    }

    public void OnSettingsButton(PointerEventData data)
    {
        //Managers.UI.ShowPopupUI<UI_Settings>();
    }
}
