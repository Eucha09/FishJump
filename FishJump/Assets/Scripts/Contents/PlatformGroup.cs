using System.Collections;
using System.Collections.Generic;
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

    public float GetRandTime()
    {
        float minTime = 1.5f;//0.7f;
        float maxTime = 2.5f;//1.3f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }

    public void Update()
    {
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
}
