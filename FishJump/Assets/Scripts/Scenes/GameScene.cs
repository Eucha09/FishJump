using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Screen.SetResolution(1440, 2960, true);

        Managers.Resource.Instantiate("Background/Background");
        Managers.Sound.Play("Lost in heaven", Define.Sound.Bgm, 0.2f);

        Managers.Platform.AddNewPlatform(true);

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
