using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameOver : UI_Popup
{
    enum Texts
    {
        HighScore,
        Score,
    }

    enum Buttons
    {
        RetryButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetText((int)Texts.Score).text = Managers.Game.Score.ToString();
        GetText((int)Texts.HighScore).text = Managers.Game.TodayHighScore.ToString();
        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnRetryButton);
    }

    public void OnRetryButton(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
