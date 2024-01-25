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
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnStartButton);
        GetButton((int)Buttons.HistoryButton).gameObject.BindEvent(OnHistoryButton);
    }

    public void OnStartButton(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public void OnHistoryButton(PointerEventData data)
    {

    }
}
