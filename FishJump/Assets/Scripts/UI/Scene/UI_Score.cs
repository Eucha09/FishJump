using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Score : UI_Scene
{
    enum Texts
    {
        ScoreText,
    }

    public override void Init()
    {
        base.Init();

        Bind<Text>(typeof(Texts));
    }

    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        int score = Mathf.Max(Managers.Game.Score, 0);
        GetText((int)Texts.ScoreText).text = score.ToString();
    }
}
