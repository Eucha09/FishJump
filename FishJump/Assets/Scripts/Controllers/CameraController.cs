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

    GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
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
