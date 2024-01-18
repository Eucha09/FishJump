using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    string _path = "Background/";
    List<string> _backgroundList = new List<string>() 
    { 
        "Ocean1",
        "Ocean1",
        "Ocean1-2",
        "Ocean2",
        "Ocean2",
        "Ocean2-Mountain1",
        "Mountain1",
        "Mountain1",
        "Mountain1-2",
        "Mountain2",
        "Mountain2",
        "Mountain2-Sky1",
        "Sky1",
        "Sky1",
        "Sky1-2",
        "Sky2",
        "Sky2"
    };

    Vector3 _startPos = new Vector3(0.0f, -1.5f, 0.0f);
    float _gap = 11.83f;

    void Start()
    {
        for (int i = 0; i < _backgroundList.Count; i++)
        {
            GameObject bg = Managers.Resource.Instantiate(_path + _backgroundList[i], this.transform);
            bg.transform.position = _startPos + Vector3.up * i * _gap;
        }
    }

    void Update()
    {
        
    }
}
