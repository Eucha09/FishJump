using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    // 데이터들을 가지고 있을 Dictionary 선언
    // ex) public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<int, Data.TimeToClose> TimeTooCloseDict { get; private set; } = new Dictionary<int, Data.TimeToClose>();
    public Dictionary<int, Data.TimeToBeCreated> TimetoBeCreatedDict { get; private set; } = new Dictionary<int, Data.TimeToBeCreated>();

    public void Init()
    {
        // json 형식의 데이터 파일을 읽어들여 Dictionary 형태로 저장
        // ex) StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        TimeTooCloseDict = LoadJson<Data.TimeToCloseData, int, Data.TimeToClose>("TimeToCloseData").MakeDict();
        TimetoBeCreatedDict = LoadJson<Data.TimeToBeCreatedData, int, Data.TimeToBeCreated>("TimeToBeCreatedData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
