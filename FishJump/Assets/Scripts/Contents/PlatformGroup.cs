using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformGroup : MonoBehaviour
{
    Platform[] _platforms;
    bool _missionComplete = false;

    GameObject _player = null;

    public bool IsMovingPlatform;
    bool _isMoving;
    Vector3 _destPos;
    float _speed = 12.0f;

    private void Start()
    {
        _destPos = transform.position;
    }

    public void Activate(float movingTime, bool isMovingPlatform)
    {
        IsMovingPlatform = isMovingPlatform;

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

        if (_isMoving && transform.position.y < _destPos.y)
        {
            if (_player != null)
                _player.transform.position += Vector3.up * _speed * Time.deltaTime;
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        else if (_isMoving)
        {
            if (_player != null)
                _player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, _speed);
            _isMoving = false;
            IsMovingPlatform = false;
        }

        if (_isMoving == false && IsMovingPlatform && CheckPlatformsDeactivate())
        {
            _destPos = transform.position + Vector3.up * 2.366f;
            _isMoving = true;
        }

        if (_isMoving == false && _missionComplete == false && CheckPlatformsDeactivate())
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = null;
        }
    }
}
