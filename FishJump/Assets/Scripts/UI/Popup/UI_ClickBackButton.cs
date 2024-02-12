using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ClickBackButton : UI_Popup
{
    public override void Init()
    {
        base.Init();

        Invoke("Close", 1.0f);
    }

    void Close()
    {
        Managers.UI.CloseAllPopupUI();
    }
}
