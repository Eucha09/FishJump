using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    public bool IsGameOver { get; private set; }
    public int Score { get; private set; } = -1;
    public int HighScore
    {
        get { return PlayerPrefs.GetInt("HighScore"); }
        set { PlayerPrefs.SetInt("HighScore", value); }
    }

    public void AddScore()
    {
        Score++;
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;
        Debug.Log("GameOver!");
        IsGameOver = true;
        HighScore = Mathf.Max(HighScore, Score);
        Managers.UI.ShowPopupUI<UI_GameOver>();
    }

    public void Clear()
    {
        Score = -1;
        IsGameOver = false;
    }
}
