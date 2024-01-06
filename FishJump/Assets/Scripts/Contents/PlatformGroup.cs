using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformGroup : MonoBehaviour
{
    Platform[] _platforms;
    bool _missionComplete = false;

    private void Start()
    {

    }

    public void Activate(float movingTime)
    {
        _platforms = GetComponentsInChildren<Platform>();
        foreach (Platform platform in _platforms)
        {
            if (platform.tag == "L_Platform")
                platform.Activate(Vector2.right, 2.3f, movingTime);
            else if (platform.tag == "R_Platform")
                platform.Activate(Vector2.left, 2.3f, movingTime);
        }
    }

    public void Update()
    {
        if (Managers.Game.IsGameOver)
            return;

        if (_missionComplete == false && CheckPlatformsDeactivate())
        {
            _missionComplete = true;
            Managers.Platform.AddNewPlatform();
        }
    }

    public bool CheckPlatformsDeactivate()
    {
        bool deactivate = true;
        foreach (Platform platform in _platforms)
        {
            if (platform.Arrived == false)
            {
                deactivate = false;
                break;
            }
        }
        return deactivate;
    }

    public void SetName(string name)
    {
        foreach (Platform platform in _platforms)
        {
            platform.gameObject.name = name;
        }
    }
}
