using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 _offset = new Vector3(0.0f, 0.0f, -10.0f);

    GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
