using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    public bool IsGameOver { get; private set; }
    public int Score { get; private set; } = -1;
    public int HighScore { get { ScoreInit(); return PlayerPrefs.GetInt("HighScore"); } }
    public int TodayHighScore { get { ScoreInit(); return PlayerPrefs.GetInt("TodayHighScore"); } }

    public void Init()
    {
        ScoreInit();
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
        SaveScore();
        Managers.UI.ShowPopupUI<UI_GameOver>();
    }

    void ScoreInit()
    {
        if (PlayerPrefs.HasKey("TodayHighScore") && PlayerPrefs.HasKey("ScoreDate"))
        {
            string savedDateString = PlayerPrefs.GetString("ScoreDate");
            DateTime savedDate = DateTime.Parse(savedDateString);
            DateTime currentDate = DateTime.Now;

            if (currentDate.Date > savedDate.Date)
            {
                PlayerPrefs.DeleteKey("TodayHighScore");
                PlayerPrefs.DeleteKey("ScoreDate");
            }
        }
    }

    void SaveScore()
    {
        ScoreInit();

        PlayerPrefs.SetInt("TodayHighScore", Mathf.Max(TodayHighScore, Score));
        PlayerPrefs.SetString("ScoreDate", DateTime.Now.ToString());
        PlayerPrefs.SetInt("HighScore", Mathf.Max(HighScore, Score));
    }


    public void Clear()
    {
        Score = -1;
        IsGameOver = false;
    }
}
