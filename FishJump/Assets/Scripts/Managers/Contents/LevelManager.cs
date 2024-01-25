using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager
{



    //List<int> _levelDisign = new List<int>() { 0, 25, 28, 31, 34, 37, 40 };
    //float[] closeTimeToLevel = new float[] { 0.0f, 3.0f, 2.0f, 1.0f, 1.0f, 1.0f };
    //float[] nextTimeToLevel = new float[] { 0.0f, 1.0f, 0.5f, 0.0f };
    //int _level;
    //int _totalDifficulty;

    //public PlatformType CreatePlatformInfo()
    //{
    //    int curLevel = (Managers.Game.Score - 1) / 5;
    //    if (curLevel < 1)
    //    {
    //        return new PlatformType() { closeTime = 2.0f, nextTime = 0.0f };
    //    }

    //    if (_level != curLevel)
    //    {
    //        _level = curLevel;
    //        if (_level < _levelDisign.Count)
    //            _totalDifficulty = _levelDisign[_level];
    //        else
    //            _totalDifficulty = _levelDisign[_levelDisign.Count - 1];
    //    }

    //    int idx = (Managers.Game.Score - 1) % 5 + 1;
    //    int minDifficulty = Mathf.Max(_totalDifficulty - 8 * (5 - idx), 2);
    //    int maxDifficulty = Mathf.Min(_totalDifficulty - 2 * (5 - idx), 8);

    //    // 2 3 4 5 6 7 8
    //    int difficulty = Random.Range(minDifficulty, maxDifficulty + 1);
    //    _totalDifficulty -= difficulty;

    //    int a = Random.Range(Mathf.Max(1, difficulty - 3), Mathf.Min(5, difficulty - 1) + 1);
    //    int b = difficulty - a;

    //    Debug.Log($"difficulty : {a} {b} {difficulty}");

    //    return new PlatformType() { closeTime = closeTimeToLevel[a], nextTime = nextTimeToLevel[b] };
    //}
}
