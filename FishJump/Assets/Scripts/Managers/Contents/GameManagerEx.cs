using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    public int Score { get; private set; }

    public void AddScore()
    {
        Score++;
    }

    public void Clear()
    {
        Score = 0;
    }
}
