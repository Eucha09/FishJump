using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Screen.SetResolution(2960, 1440, true);

        Managers.Resource.Instantiate("Background");

        Managers.Platform.AddNewPlatform(0.5f);

        GameObject player = Managers.Resource.Instantiate("Player");

        Managers.UI.ShowSceneUI<UI_Score>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public override void Clear()
    {

    }
}
