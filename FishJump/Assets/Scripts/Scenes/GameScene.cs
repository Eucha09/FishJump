using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.Platform.AddNewPlatform(0.5f);

        GameObject player = Managers.Resource.Instantiate("Player");
        player.transform.position = Vector3.zero;
    }

    public override void Clear()
    {

    }
}
