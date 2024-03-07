using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformType
{
    public Define.SpeedType timeToClose;
    public Define.SpeedType timeToBeCreated;
    public bool isMovingPlatform;
}

public class PlatformManager
{
    Vector2 _createPos = new Vector2(0.0f, -4.0f);
    float _heightBetweenPlatform = 2.366f;
    int _index = 0;

    PlatformType _previousType;
    PlatformType _platformType;
    bool _isFirst = false;
    bool _addPlatform = false;
    float _curTime = 0.0f;
    float _timeToBeCreated;

    public void Init()
    {

    }

    public void OnUpdate()
    {
        if (!_addPlatform)
            return;

        _curTime += Time.deltaTime;
        if (!_isFirst && _curTime < _timeToBeCreated)
            return;

        GameObject newPlatform = CreatePlatformObject();
        newPlatform.transform.position = _createPos;

        if (_isFirst)
            newPlatform.GetComponent<PlatformGroup>().Activate(0.5f, false);
        else
        {
            switch (_platformType.timeToClose)
            {
                case Define.SpeedType.Slow:
                    newPlatform.GetComponent<PlatformGroup>().Activate(2.0f, _platformType.isMovingPlatform);
                    break;
                case Define.SpeedType.Normal:
                    newPlatform.GetComponent<PlatformGroup>().Activate(1.5f, _platformType.isMovingPlatform);
                    break;
                case Define.SpeedType.Fast:
                    newPlatform.GetComponent<PlatformGroup>().Activate(1.0f, _platformType.isMovingPlatform);
                    break;
                case Define.SpeedType.Variation:
                    newPlatform.GetComponent<PlatformGroup>().Activate(0.4f, _platformType.isMovingPlatform);
                    break;
            }
        }

        newPlatform.name = "PlatformGroup" + _index;
        newPlatform.GetComponent<PlatformGroup>().SetName("Platform" + _index);
        _index++;

        if (_platformType.isMovingPlatform)
            _createPos = new Vector2(_createPos.x, _createPos.y + _heightBetweenPlatform * 2);
        else
            _createPos = new Vector2(_createPos.x, _createPos.y + _heightBetweenPlatform);

        _addPlatform = false;
    }

    public GameObject CreatePlatformObject()
    {
        GameObject newPlatform = null;

        if (_createPos.y <= 53.0f)
            newPlatform = Managers.Resource.Instantiate("Platform/Seeweed");
        else if (_createPos.y <= 128.0f)
            newPlatform = Managers.Resource.Instantiate("Platform/Wood");
        else if (_createPos.y <= 163.0f)
            newPlatform = Managers.Resource.Instantiate("Platform/Cloud1");
        else
            newPlatform = Managers.Resource.Instantiate("Platform/Cloud2");

        return newPlatform;
    }

    public void AddNewPlatform(bool isFirst = false)
    {
        _previousType = _platformType;
        _platformType = GetTypeByLevel();

        switch (_platformType.timeToBeCreated)
        {
            case Define.SpeedType.Slow:
                _timeToBeCreated = 1.0f;
                break;
            case Define.SpeedType.Normal:
                _timeToBeCreated = 0.5f;
                break;
            case Define.SpeedType.Fast:
                _timeToBeCreated = 0.0f;
                break;
        }
        if (_previousType != null && _previousType.isMovingPlatform)
            _timeToBeCreated = 1.0f;

        _isFirst = isFirst;
        _curTime = 0.0f;
        _addPlatform = true;
    }

    public float GetRandTime()
    {
        float minTime = 1.0f;
        float maxTime = 1.0f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }

    PlatformType GetTypeByLevel()
    {
        PlatformType pt = new PlatformType();
        int level = (Managers.Game.Score - 1) / 5;
        int maxLevel = Managers.Data.TimeTooCloseDict.Count - 1;
        Debug.Log("maxLevel " + maxLevel);
        level = Mathf.Min(level, maxLevel);

        // Time to close
        Dictionary<int, TimeToClose> timeToCloseDict = Managers.Data.TimeTooCloseDict;
        int slow = timeToCloseDict[level].slow;
        int normal = slow + timeToCloseDict[level].normal;
        int fast = normal + timeToCloseDict[level].fast;
        int variation = fast + timeToCloseDict[level].variation;

        int rand = Random.Range(0, 100);
        if (rand < slow)
            pt.timeToClose = Define.SpeedType.Slow;
        else if (rand < normal)
            pt.timeToClose = Define.SpeedType.Normal;
        else if (rand < fast)
            pt.timeToClose = Define.SpeedType.Fast;
        else if (rand < variation)
            pt.timeToClose = Define.SpeedType.Variation;

        // Time to be created
        Dictionary<int, TimeToBeCreated> timeToBeCreatedDict = Managers.Data.TimetoBeCreatedDict;
        slow = timeToBeCreatedDict[level].slow;
        normal = slow + timeToBeCreatedDict[level].normal;
        fast = normal + timeToBeCreatedDict[level].fast;

        rand = Random.Range(0, 100);
        if (rand < slow)
            pt.timeToBeCreated = Define.SpeedType.Slow;
        else if (rand < normal)
            pt.timeToBeCreated = Define.SpeedType.Normal;
        else if (rand < fast)
            pt.timeToBeCreated = Define.SpeedType.Fast;

        // is moving
        rand = Random.Range(0, 100);
        if (level > 0 && rand < 10)
            pt.isMovingPlatform = true;
        else
            pt.isMovingPlatform = false;

        return pt;
    }

    public void Clear()
    {
        _createPos = new Vector2(0.0f, -4.0f);
        _index = 0;
        _previousType = null;
        _platformType = null;
    }
}
