using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Title;

        Screen.SetResolution(1440, 2960, true);

        Managers.UI.ShowSceneUI<UI_TitleScene>();

        Managers.Sound.Play("Lost in heaven", Define.Sound.Bgm);
    }

    int _clickCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _clickCount++;

            if (Managers.UI.PopupUICount() == 0)
                Managers.UI.ShowPopupUI<UI_ClickBackButton>();
            else
                Managers.UI.ClosePopupUI();

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
