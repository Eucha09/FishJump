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
        "Ocean2(1)",
        "Ocean2(2)",
        "Ocean2-Mountain1",
        "Mountain1(1)",
        "Mountain1(2)",
        "Mountain1-2",
        "Mountain2",
        "Mountain2",
        "Mountain2-Sky1",
        "Sky1",
        "Sky1",
        "Sky1-2",
        "Sky2"
    };

    Vector3 _startPos = new Vector3(0.0f, -1.5f, 0.0f);
    float _gap = 11.83f;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            int idx = Mathf.Min(i, _backgroundList.Count - 1);
            GameObject bg = Managers.Resource.Instantiate(_path + _backgroundList[idx], this.transform);
            bg.transform.position = _startPos + Vector3.up * i * _gap;
        }
    }

    void Update()
    {
        
    }
}
