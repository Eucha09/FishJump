using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float _speed = 0.6f;
    float _boostSpeed = 4;
    float _offset = -1.5f;
    Vector3 _followPos;
    bool _boost;

    void Start()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)1440 / 2960); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }

    void OnPreCull() => GL.Clear(true, true, Color.black);

    void LateUpdate()
    {
        if (Managers.Scene.CurrentScene.SceneType != Define.Scene.Game)
            return;
        if (Managers.Game.IsGameOver)
            return;

        float dist = _followPos.y - transform.position.y;
        if (_boost && dist < _offset)
        {
            _boost = false;
        }

        if (_boost)
            transform.position = transform.position + Vector3.up * _boostSpeed * Time.deltaTime;
        else
            transform.position = transform.position + Vector3.up * _speed * Time.deltaTime;
    }

    public void CameraFollow(Vector3 pos)
    {
        _followPos = pos;
        _boost = true;
    }
}
