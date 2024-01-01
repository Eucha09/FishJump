using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager
{
    Vector2 _createPos = new Vector2(0.0f, -4.0f);
    float _heightBetweenPlatform = 3.0f;

    public void Init()
    {

    }

    public void AddNewPlatform(float movingTime = 0.0f)
    {
        GameObject newPlatform = Managers.Resource.Instantiate("PlatformGroup");
        newPlatform.transform.position = _createPos;

        if (movingTime > 0.0f)
            newPlatform.GetComponent<PlatformGroup>().Activate(movingTime);
        else
            newPlatform.GetComponent<PlatformGroup>().Activate(GetRandTime());

        _createPos = new Vector2(_createPos.x, _createPos.y + _heightBetweenPlatform);
    }

    public float GetRandTime()
    {
        float minTime = 1.5f;//0.7f;
        float maxTime = 2.5f;//1.3f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }

    public void Clear()
    {
        _createPos = new Vector2(0.0f, -4.0f);
    }
}