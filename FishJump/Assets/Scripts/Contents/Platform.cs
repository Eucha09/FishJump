using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool Arrived { get; private set; } = false;

    Vector2 _startPos;
    Vector2 _destPos;
    float _curTime;
    float _destTime;

    void Start()
    {
        _startPos = transform.position;
        _curTime = 0.0f;
    }

    void Update()
    {
        if (Arrived)
            return;
        if (_curTime >= _destTime)
            Arrived = true;

        Vector2 newPos = Vector2.Lerp(_startPos, _destPos, _curTime / _destTime);
        transform.position = newPos;
        _curTime += Time.deltaTime;
    }

    public void Activate(Vector2 moveDir, float distance, float time)
    {
        _destPos = (Vector2)transform.position + moveDir * distance;
        _destTime = time;
        Arrived = false;
    }
}
