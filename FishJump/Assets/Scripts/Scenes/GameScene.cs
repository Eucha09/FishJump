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

    int _clickCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _clickCount++;

            if (Managers.UI.PopupUICount() == 0)
                Managers.UI.ShowPopupUI<UI_ClickBackButton>();
            else
                Managers.Scene.LoadScene(Define.Scene.Title);

            if (!IsInvoking("DoubleClick"))
            {
                Invoke("DoubleClick", 1.0f);
            }
        }
        else if (_clickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    void DoubleClick()
    {
        _clickCount = 0;
    }

    public override void Clear()
    {

    }
}
